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

using RTWR_RTWLIB.Data;
using RTWR_RTWLIB.Forms;
using RTWLib.Functions.EDU;

namespace RTWR_RTWLIB
{
	public partial class RandomiserForm : Form
	{
		Main main;
		EDU_viewer edu;
		StratViewer strat;
		public RandomiserForm()
		{
            this.Icon = RTWR_RTWLIB.Properties.Resources.julii_icon;
			InitializeComponent();
			main = new Main(pb_progress, statusStrip1, grp_box_settings);
            main.CleanLog();

			if (!main.FileCheck(FilePaths.RTWEXE) || !main.DirectoryCheck(FileDestinations.MOD_FOLDER))
				main.DisplayLogExit();
			else lbl_progress.Text = "RomeTW.exe Found.";

			//get current seed
			if (File.Exists("randomiser_.txt"))
			{
				StreamReader sr = new StreamReader("randomiser_.txt");
				string line = sr.ReadToEnd();
				sr.Close();
				lbl_seed.Text = "Randomiser Seed: " + line;
				txt_seed.Text = line;
			}

			if (File.Exists(@"randomiser\full_map.png"))
			{
				Image image = Image.FromFile(@"randomiser\full_map.png");
				picBox_map.Image = image;
			}

			/*if (!main.AdminCheck())
			{
				chk_misc_unitInfo.Enabled = false;
				main.DisplayLog();
			}*/

			if (Directory.Exists(@"randomiser\data\ui\unit_info\assets\"))
			{
				chk_misc_unitInfo.Enabled = false;
			}

			chk_dev_chosen.Checked = false;
		}

		private void btn_load_Click(object sender, EventArgs e)
		{
			main.SetUp_seed(chk_seed, txt_seed, lbl_seed);
			if (main.Load(chk_LogAll, lbl_progress))
			{
				main.Randomise(grp_settings_units, numUpDown_unit_attributes, numUpDown_unit_ownership, grp_settings_factions, numUpDown_faction_cities,
				lbl_progress, picBox_map, chk_misc_unitInfo.Checked, chk_preferences.Checked);

			}
			else
			{
				main.PLog("Load failed - Check log for details.");
				main.DisplayLog();
			}
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
			StreamWriter sw = new StreamWriter(FileDestinations.paths[file.Name]["save"][0], false);

			sw.WriteLine(file.Output());

			sw.Close();
		}

		private void chk_faction_voronoi_CheckedChanged(object sender, EventArgs e)
		{
            if (((CheckBox)sender).Checked)
            {
                chk_faction_settlements_4.Checked = !((CheckBox)sender).Checked;
                numUpDown_faction_cities.Enabled = false;
            }


		}

		private void chk_faction_settlements_CheckedChanged(object sender, EventArgs e)
		{
            if (((CheckBox)sender).Checked)
            {
                chk_faction_voronoi_4.Checked = !((CheckBox)sender).Checked;
                numUpDown_faction_cities.Enabled = true;
            }

		}

		private void btn_play_Click(object sender, EventArgs e)
		{
			Play();
		}

		private void Play()
		{
			string[] args = new string[1];

			args[0] = "-mod:randomiser -show_err -nm ";

			if (chk_ai.Checked)
				args[0] += "-ai ";

			if (chk_windowed.Checked)
				args[0] += "-ne ";

			RTWCore.core.StartProcess(args);
		}

		private void viewerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			main.Load(lbl_progress, FileNames.export_descr_unit, "save");
			edu = new EDU_viewer((EDU)main.GetFile(FileNames.export_descr_unit));
			if (strat != null)
			{
				strat.Edu_viewer = edu;
				edu.StratViewer = strat;
			}
			edu.Show();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			About about = new About();
			about.Show();
		}

		private void stratViewerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			strat = new StratViewer(edu);
			main.Load(lbl_progress, FileNames.descr_strat, "save");
			strat.descr_strat = (Descr_Strat)main.GetFile(FileNames.descr_strat);
			main.Load(lbl_progress, FileNames.descr_regions, "load");
			strat.descr_region = (Descr_Region)main.GetFile(FileNames.descr_regions);
			main.Load(lbl_progress, FileNames.descr_sm_faction, "load");
			strat.sm_factions = (SM_Factions)main.GetFile(FileNames.descr_sm_faction);
			strat.PopulateTree();
			strat.Show();		
		}

		private void chk_dev_chosen_CheckedChanged(object sender, EventArgs e)
		{
			chk_units_sizes_1.Checked = false;
			chk_unit_stats_2.Checked = false;
			chk_unit_costs_3.Checked = false;
			chk_unit_sounds_4.Checked = false;
			chk_unit_training_5.Checked = true;
			chk_unit_groundb_6.Checked = false;
			chk_faction_rosters_7.Checked = true;
			chk_unit_attributes_9.Checked = true;
			numUpDown_unit_attributes.Value = 3;
			numUpDown_unit_ownership.Value = 3;

			chk_faction_treasury_1.Checked = true;
			chk_faction_ai_2.Checked = true;
			chk_misc_Ufactions_3.Checked = true;
			chk_faction_settlements_4.Checked = false;
			chk_faction_voronoi_4.Checked = true;
			chk_faction_ragingRebels_5.Checked = false;
			chk_faction_mempires_6.Checked = true;
			chk_faction_coreA_7.Checked = true;
			chk_total_war_8.Checked = false;

		}

		private void btn_advancedOptions_Click(object sender, EventArgs e)
		{
			main.advancedOptions.Show();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			main.options.Export(grp_box_settings);
			main.advancedOptions.Export();
			base.OnClosing(e);
		}
	}
}
