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

namespace RTWR_RTWLIB
{

	enum FileNames
	{
		export_descr_buildings,
		export_descr_unit,
		descr_strat,
		descr_regions,
		descr_sm_faction
	}

	public partial class Form1 : Form
	{
		Dictionary<FileNames, IFile> vanfiles = new Dictionary<FileNames, IFile>(){
				{FileNames.descr_regions, new Descr_Region() },
				{FileNames.descr_strat, new Descr_Strat()},
				{FileNames.export_descr_buildings, new EDB()},
				{FileNames.export_descr_unit, new EDU()},
				{FileNames.descr_sm_faction, new SM_Factions()},
			};

		Dictionary<FileNames, IFile> randfiles = new Dictionary<FileNames, IFile>(){
				{FileNames.descr_regions, new Descr_Region() },
				{FileNames.descr_strat, new Descr_Strat()},
				{FileNames.export_descr_buildings, new EDB()},
				{FileNames.export_descr_unit, new EDU()},
				{FileNames.descr_sm_faction, new SM_Factions()},
			};

		public Form1()
		{
			InitializeComponent();
			Logger logger = new Logger();

			if (!logger.FileCheck(FilePaths.RTWEXE))
				logger.DisplayLog();
			else lbl_progress.Text = "RomeTW.exe Found.";
		}

		async private void btn_load_Click(object sender, EventArgs e)
		{
			//start loading data
			float increment = 100 / vanfiles.Count();

			foreach (KeyValuePair<FileNames, IFile> file in vanfiles)
			{
				await LoadAll(file.Value, (int)increment);	
			}

			//get unit data
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
			if(chk_seed.Checked)
				TWRandom.rnd = new Random(txt_seed.Text.GetHashCode());

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
					Functions_General.ExecuteCommand(@"randomiser\data\ui\unit_info\", "copy_all_units.bat");
				}
			}

			

			Misc_Data.RefreshRegionWater();

			SelectMaps sm = new SelectMaps();
			EDU R_EDU = (EDU)((EDU)vanfiles[FileNames.export_descr_unit]).Clone();
			EDB R_EDB = (EDB)((EDB)vanfiles[FileNames.export_descr_buildings]).Clone();
			Descr_Strat R_DS = (Descr_Strat)((Descr_Strat)vanfiles[FileNames.descr_strat]).Clone();
			Descr_Region R_DR = vanfiles[FileNames.descr_regions] as Descr_Region;
			SM_Factions R_SMF = vanfiles[FileNames.descr_sm_faction] as SM_Factions;

			R_EDU.RandomiseFile<RandomEDU, EDU>(grp_settings_units, lbl_progress, statusStrip1, pb_progress, new object[] {numUpDown_unit_attributes, numUpDown_unit_ownership });
			R_EDB.SetRecruitment();
			R_DS.RandomiseFile<RandomDS, Descr_Strat>(grp_settings_factions, lbl_progress, statusStrip1, pb_progress, new object[] {R_DR, numUpDown_faction_cities});

			
			lbl_progress.Text = "Creating preview map...";
			statusStrip1.Refresh();

			Thread.Sleep(250);

			Image image = sm.CreateCompleteMap(R_DS, R_DR, R_SMF);

			if(picBox_map.Image != null)
				picBox_map.Image.Dispose();

			picBox_map.Image = image;
			picBox_map.Refresh();

			FileWrite(R_EDU as IFile);
			FileWrite(R_EDB as IFile);
			FileWrite(R_DS as IFile);

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
				chk_faction_settlements.Checked = !((CheckBox)sender).Checked;
		}

		private void chk_faction_settlements_CheckedChanged(object sender, EventArgs e)
		{
			if(((CheckBox)sender).Checked)
				chk_faction_voronoi.Checked = !((CheckBox)sender).Checked;
		}
	}
}
