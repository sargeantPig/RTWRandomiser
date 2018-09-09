using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using RTWLib.Logger;
using RTWLib.Data;
using RTWLib.Functions;
using RTWR_RTWLIB.Randomiser;
using System.Threading;
using System.Diagnostics;
using RTWLib.Memory;
using RTWR_RTWLIB.Tests;
namespace RTWR_RTWLIB
{

	enum FileNames
	{
		export_descr_buildings,
		export_descr_unit,
		descr_strat,
		descr_regions,
		descr_sm_faction,
		names,
	}

	public partial class Form1 : Form
	{
		Dictionary<FileNames, IFile> vanfiles = new Dictionary<FileNames, IFile>(){
				{FileNames.descr_regions, new Descr_Region() },
				{FileNames.descr_strat, new Descr_Strat()},
				{FileNames.export_descr_buildings, new EDB()},
				{FileNames.export_descr_unit, new EDU()},
				{FileNames.descr_sm_faction, new SM_Factions()},
				{FileNames.names, new NamesFile() }
			};

		int seed;

		TestStore tests = new TestStore();

		public Form1()
		{
			InitializeComponent();
			Logger logger = new Logger();

			if (!logger.FileCheck(FilePaths.RTWEXE))
				logger.DisplayLog();
			else lbl_progress.Text = "RomeTW.exe Found.";

			//get current seed
			if (File.Exists("randomiser_.txt"))
			{
				StreamReader sr = new StreamReader("randomiser_.txt");
				string line = sr.ReadToEnd();
				sr.Close();
				lbl_seed.Text = "Randomiser Seed: " + line;
			}

			if (Directory.Exists(tests.DIRECTORY))
			{
				var files = Directory.GetFiles(tests.DIRECTORY);

				foreach (var file in files)
				{
					tests.tests.Add(new Test().Parse(file));

				}


			}

			if (File.Exists(@"randomiser\full_map.png"))
			{
				Image image = Image.FromFile(@"randomiser\full_map.png");

				picBox_map.Image = image;

			}

			if (!Functions_General.IsAdministrator())
			{
				chk_misc_unitInfo.Enabled = false;
			}

			if (Directory.Exists(@"randomiser\data\ui\unit_info\assets\"))
			{
				chk_misc_unitInfo.Enabled = false;
			}

		}

		async private void btn_load_Click(object sender, EventArgs e)
		{
			//start loading data
			float increment = 100 / vanfiles.Count();

			foreach (KeyValuePair<FileNames, IFile> file in vanfiles)
			{
				await LoadAll(file.Value, (int)increment);	
			}

			lbl_progress.Text = "Files Loaded.";

			pictureBox1.BackgroundImage = Properties.Resources.symbol48_romans_brutii;

			btn_load.Enabled = false;
			btn_randomise.Enabled = true;
		}

		async Task LoadAll(IFile file, int increment)
		{
			lbl_progress.Text = file.Log("Loading " + file.Description);
			statusStrip1.Refresh();
			await file.Parse();
			pb_progress.Increment(increment);
			
		}

		private void btn_randomise_Click(object sender, EventArgs e)
		{
			if (chk_seed.Checked)
			{
				int rseed;

				try
				{
					rseed = Convert.ToInt32(txt_seed.Text);

				}

				catch
				{
					rseed = txt_seed.Text.GetHashCode();

				}

				seed = rseed;
				lbl_seed.Text = "Randomiser Seed: " + rseed;
				TWRandom.rnd = new Random(rseed);
			}
			else
			{
				int rnd = TWRandom.rnd.Next(int.MaxValue);
				seed = rnd;
				lbl_seed.Text = "Current Randomiser Seed: " + rnd;
				TWRandom.rnd = new Random(rnd);
			}

			

			pb_progress.Value = 0;
			lbl_progress.Text = "Starting...";
			statusStrip1.Refresh();

			if (chk_misc_unitInfo.Checked)
			{
				DialogResult dialogResult = MessageBox.Show("The option 'Unit Info Fix' will use around 600mb~ of space!\n" +
					"The fix will open in a cmd prompt. Please wait for it to finish (it will disappear once done).\nAre you sure you want to continue?\n", "Unit Info Fix", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (dialogResult == DialogResult.Yes)
				{
					chk_misc_unitInfo.Checked = false;
					chk_misc_unitInfo.Enabled = false;
					Functions_General.ExecuteCommand(@"randomiser\data\ui\", "assets_do.bat");
				}
			}

			

			Misc_Data.RefreshRegionWater();

			SelectMaps sm = new SelectMaps();
			EDU R_EDU = (EDU)((EDU)vanfiles[FileNames.export_descr_unit]).Clone();
			EDB R_EDB = (EDB)((EDB)vanfiles[FileNames.export_descr_buildings]).Clone();
			Descr_Strat R_DS = (Descr_Strat)((Descr_Strat)vanfiles[FileNames.descr_strat]).Clone();
			Descr_Region R_DR = vanfiles[FileNames.descr_regions] as Descr_Region;
			SM_Factions R_SMF = vanfiles[FileNames.descr_sm_faction] as SM_Factions;
			NamesFile R_N = vanfiles[FileNames.names] as NamesFile;

			R_EDU.RandomiseFile<RandomEDU, EDU>(grp_settings_units, lbl_progress, statusStrip1, pb_progress, new object[] {numUpDown_unit_attributes, numUpDown_unit_ownership });
			R_EDB.SetRecruitment();
			R_DS.RandomiseFile<RandomDS, Descr_Strat>(grp_settings_factions, lbl_progress, statusStrip1, pb_progress, new object[] {R_DR, numUpDown_faction_cities, R_EDU, R_N, R_EDB});

			
			lbl_progress.Text = "Creating preview map...";
			statusStrip1.Refresh();

			Image oldImage = picBox_map.Image;
			picBox_map.Image = null;
			if (oldImage != null)
				oldImage.Dispose();

			picBox_map.Image = sm.CreateCompleteMap(R_DS, R_DR, R_SMF);

			picBox_map.Refresh();

			sm.Save(@"randomiser\full_map.png");

			Thread.Sleep(250);

			FileWrite(R_EDU as IFile);
			FileWrite(R_EDB as IFile);
			FileWrite(R_DS as IFile);

			StreamWriter sw = new StreamWriter("randomiser_.txt");
			sw.Write(seed);
			sw.Close();

			lbl_progress.Text = "Randomisation Complete!";
			pb_progress.Value = 100;
		}

		private void chk_misc_selectA_CheckedChanged(object sender, EventArgs e)
		{
			CheckBoxes(sender, grp_settings_factions);
			CheckBoxes(sender, grp_settings_units);
		}

		private void CheckBoxes(object sender, GroupBox grp)
		{
			foreach (Control c in grp.Controls)
			{
				if (c is CheckBox)
				{
					if (((CheckBox)c).Checked != ((CheckBox)sender).Checked)
						((CheckBox)c).Checked = ((CheckBox)sender).Checked;
				}
			}

		}

		private void FileWrite(IFile file)
		{
			StreamWriter sw = new StreamWriter(@"randomiser\" + file.FilePath, false);

			sw.WriteLine(file.Output());

			sw.Close();
		}

		private void chk_faction_voronoi_CheckedChanged(object sender, EventArgs e)
		{
			if (((CheckBox)sender).Checked)
				chk_faction_settlements_4.Checked = !((CheckBox)sender).Checked;
		}

		private void chk_faction_settlements_CheckedChanged(object sender, EventArgs e)
		{
			if(((CheckBox)sender).Checked)
				chk_faction_voronoi_4.Checked = !((CheckBox)sender).Checked;
		}

		private async void btn_play_Click(object sender, EventArgs e)
		{
			await Play();
			StartTests();
		}

		private Task Play()
		{
			string[] args = new string[1];

			args[0] = "-mod:randomiser -show_err -nm ";

			if (chk_ai.Checked)
				args[0] += "-ai ";

			if (chk_windowed.Checked)
				args[0] += "-ne ";

			if (chk_test.Checked)
				args[0] += "-strat:imperial_campaign ";

			RTWCore.core.StartProcess(args);

			return Task.CompletedTask;
		}

		private async void StartTests()
		{
			if (chk_test.Checked)
			{
				Test test = tests.tests[0];

				await RTWCore.core.TestLoop(test.iter, test.target, test.name, this.Play);

			}
		}
	}
}
