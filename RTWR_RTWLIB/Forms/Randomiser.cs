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
using RTWLib.Medieval2;
using ImageMagick;
using System.ComponentModel.Design;

namespace RTWR_RTWLIB
{
	public partial class RandomiserForm : Form
	{
		Main main;
		EDU_viewer edu;
		StratViewer strat;
		MapGeneratorForm mapGen;
		public RandomiserForm(string updateMessage, Game game)
		{
            this.Icon = RTWR_RTWLIB.Properties.Resources.julii_icon;
			InitializeComponent();
			picBox_map.SizeMode = PictureBoxSizeMode.Zoom;
			if (game == Game.MED2)
			{
				this.Text = "Medieval 2 Randomiser";
				this.chk_preferences.Checked = false;
				this.chk_preferences.Enabled = false;
				this.chk_removeSPQR.Checked = false;
				this.chk_removeSPQR.Enabled = false;
				this.menuStrip1.Items[1].Enabled = false;
				this.BackgroundImage = Properties.Resources.M2TWBackdrop;
				this.btn_play.BackgroundImage = Properties.Resources.backdrop;
				this.btn_load.BackgroundImage = Properties.Resources.backdrop;
				this.btn_advancedOptions.BackgroundImage = Properties.Resources.backdrop;
				if (File.Exists(@"mods\randomiser\full_map.png"))
				{
					Image image = Image.FromFile(@"mods\randomiser\full_map.png");
					picBox_map.Image = image;
				}
			}

			else if (game == Game.REMASTER)
			{ 
				foreach (Control ctrl in grp_settings_units.Controls)
				{
					ctrl.Enabled = false;

					if (ctrl.GetType() == typeof(CheckBox))
					{
						((CheckBox)ctrl).Checked = false;
					}

				}

				foreach (Control ctrl in grp_settings_misc.Controls)
				{
					ctrl.Enabled = false;

					if (ctrl.GetType() == typeof(CheckBox))
					{
						((CheckBox)ctrl).Checked = false;
					}
				}

				foreach (Control ctrl in grp_settings_factions.Controls)
				{
					ctrl.Enabled = false;

					if (ctrl.GetType() == typeof(CheckBox))
					{
						((CheckBox)ctrl).Checked = false;
					}

				}

				chk_wipeDS.Enabled = true;
				chk_faction_voronoi_4.Enabled = true;
				chk_faction_settlements_4.Enabled = true;
				numUpDown_faction_cities.Enabled = true;
				menuStrip1.Enabled = false;
				chk_windowed.Enabled = false;

				if (File.Exists(@"Mods\My Mods\randomiser\full_map.png"))
				{
					Image image = Image.FromFile(@"Mods\My Mods\randomiser\full_map.png");
					picBox_map.Image = image;
				}


			}
			else
			{
				if (File.Exists(@"randomiser\full_map.png"))
				{
					Image image = Image.FromFile(@"randomiser\full_map.png");
					picBox_map.Image = image;
				}
			}

		
			main = new Main(pb_progress, statusStrip1, grp_box_settings, this, game);
            main.CleanLog();

			if (!main.AdminCheck())
			{
				main.PLog("Not running as Administrator.\r\n" +
					"If you crash before battle, at end turn or when saving, consider running as admin.");
				main.DisplayLog();
			}
			//get current seed
			if (File.Exists("randomiser_.txt"))
			{
				StreamReader sr = new StreamReader("randomiser_.txt");
				string line = sr.ReadToEnd();
				sr.Close();
				lbl_seed.Text = line;
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


			switch (main.ActiveGame)
			{
				case Game.OGRome:
					if (main.Load(chk_LogAll, lbl_progress))
					{
						main.Randomise(grp_settings_units, numUpDown_unit_attributes, numUpDown_unit_ownership, grp_settings_factions, numUpDown_faction_cities,
						lbl_progress, picBox_map, chk_misc_unitInfo.Checked, chk_preferences.Checked, chk_removeSPQR.Checked, chk_startWith.Checked, chk_rndFationStart.Checked, (string)cmb_factionSelect.SelectedValue);
					}
					else main.LoadError();
					break;
				case Game.MED2:
					if (main.M2TWLoad(chk_LogAll, lbl_progress))
					{
						main.M2TWRandomise(grp_settings_units, numUpDown_unit_attributes, numUpDown_unit_ownership, grp_settings_factions, numUpDown_faction_cities,
						lbl_progress, picBox_map, chk_misc_unitInfo.Checked, chk_preferences.Checked);
					}
					else main.LoadError();
					break;
				case Game.REMASTER:
					if (main.RemasterLoad(chk_LogAll, lbl_progress))
					{
						main.RemasterRandomise(grp_settings_units, numUpDown_unit_attributes, numUpDown_unit_ownership, grp_settings_factions, numUpDown_faction_cities,
						lbl_progress, picBox_map, chk_misc_unitInfo.Checked, chk_preferences.Checked, chk_removeSPQR.Checked, chk_startWith.Checked, chk_rndFationStart.Checked, (string)cmb_factionSelect.SelectedValue);
					}
					else main.LoadError();
					break;
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

			if (chk_startWith.Checked || chk_rndFationStart.Checked)
			{
				args[0] = "-strat:imperial_campaign ";
				SetFactionChosen();
			}
			switch (main.ActiveGame)
			{
				case Game.MED2:
					args[0] = "--features.mod=mods/randomiser";
					RTWCore.core.StartProcess(args, "medieval2.exe");
					break;
				case Game.OGRome:
					args[0] += "-mod:randomiser -show_err -nm ";
					if (chk_ai.Checked)
						args[0] += "-ai ";
					if (chk_windowed.Checked)
						args[0] += "-ne ";
					RTWCore.core.StartProcess(args, "RomeTW.exe", true);
					break;
				case Game.REMASTER:
					if (chk_ai.Checked)
						args[0] += "-ai ";
					args[0] += " -show_err -nm ";
					RTWCore.core.StartProcess(args, "Application.lnk");
					break;
			}

		}

		private void SetFactionChosen()
		{
			IDescrStrat ds = null;
			string[] path = new string[2];
			switch (main.ActiveGame)
			{
				case Game.MED2:
					ds = new M2DS();
					path = FileDestinations.M2TWpaths[FileNames.descr_strat]["save"];
					ds.Parse(path, out Logger.lineNumber, out Logger.lineText);
					break;
				case Game.OGRome:
					ds = new Descr_Strat();
					path = FileDestinations.paths[FileNames.descr_strat]["save"];
					ds.Parse(path, out Logger.lineNumber, out Logger.lineText);
					break;
				case Game.REMASTER:
					ds = new RemasterDescr_Strat();
					path = FileDestinations.RemasterPaths[FileNames.descr_strat]["save"];
					ds.Parse(path, out Logger.lineNumber, out Logger.lineText);
					break;
			}

			if (chk_startWith.Checked && chk_startWith.Enabled)
				ds.MoveFactionToTopOfStrat((string)cmb_factionSelect.SelectedValue);
			else if (chk_rndFationStart.Checked)
			{
				var playable = ds.GetAllPlayableFactions;
				ds.MoveFactionToTopOfStrat(playable[TWRandom.rnd.Next(0, playable.Count())]);
			} 
			ds.CleanUp();
			ds.ToFile(path[0]);
		}


		private void viewerToolStripMenuItem_Click(object sender, EventArgs e)
		{

			switch (main.ActiveGame)
			{
				case Game.MED2:
					main.M2TWLoad(lbl_progress, FileNames.export_descr_unit, "save");
					break;
				case Game.OGRome:
					main.Load(lbl_progress, FileNames.export_descr_unit, "save");
					break;
				case Game.REMASTER:
					main.RemasterLoad(lbl_progress, FileNames.export_descr_unit, "save");
					break;
			}
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
			strat.sm_factions = (SMFactions)main.GetFile(FileNames.descr_sm_faction);
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
		private bool exeCheck()
		{
			if ((main.FileCheck(FilePaths.RTWEXE)))
			{
				lbl_progress.Text = "RomeTW.exe Found.";
				return true;
			}

			if (!main.FileCheck("medieval2.exe"))
				main.DisplayLogExit();
			else
			{
				lbl_progress.Text = "medieval2.exe Found.";
				return true;
			}

			return false;
		}

		private void chk_rndFationStart_CheckedChanged(object sender, EventArgs e)
		{

			chk_startWith.Enabled = !chk_rndFationStart.Checked;
			cmb_factionSelect.Enabled = !chk_rndFationStart.Checked;
		}

		private void chk_test_CheckedChanged(object sender, EventArgs e)
		{
			chk_rndFationStart.Checked = false;
		}

		private void cmb_factionSelect_SelectedIndexChanged(object sender, EventArgs e)
		{
			MagickImage image = null;

			if (main == null)
				return;

			switch (main.ActiveGame)
			{
				case Game.MED2:
					image = new MagickImage(String.Format(@"mods\randomiser\data\world\maps\campaign\imperial_campaign\map_{0}.tga", cmb_factionSelect.SelectedValue));
					break;
				case Game.OGRome:
					image = new MagickImage(String.Format(@"randomiser\data\world\maps\campaign\imperial_campaign\map_{0}.tga", cmb_factionSelect.SelectedValue));
					break;

				case Game.REMASTER:
					image = new MagickImage(String.Format(@"Mods\My Mods\randomiser\data\world\maps\campaign\imperial_campaign\map_{0}.tga", cmb_factionSelect.SelectedValue));
					break;
			}
			
			Image bitmap = image.ToBitmap();
			picBox_map.Image = bitmap;
		}

		private void btn_showAll_Click(object sender, EventArgs e)
		{
			MagickImage image = null;

			if (main == null)
				return;

			switch (main.ActiveGame)
			{
				case Game.MED2:
					image = new MagickImage(String.Format(@"mods\randomiser\full_map.png", cmb_factionSelect.SelectedValue));
					break;
				case Game.OGRome:
					image = new MagickImage(String.Format(@"randomiser\full_map.png", cmb_factionSelect.SelectedValue));
					break;

				case Game.REMASTER:
					image = new MagickImage(String.Format(@"Mods\My Mods\randomiser\full_map.png", cmb_factionSelect.SelectedValue));
					break;
			}

			Image bitmap = image.ToBitmap();
			picBox_map.Image = bitmap;
		}

		private void btn_showSelected_Click(object sender, EventArgs e)
		{
			MagickImage image = null;

			if (main == null)
				return;

			switch (main.ActiveGame)
			{
				case Game.MED2:
					image = new MagickImage(String.Format(@"mods\randomiser\data\world\maps\campaign\imperial_campaign\map_{0}.tga", cmb_factionSelect.SelectedValue));
					break;
				case Game.OGRome:
					image = new MagickImage(String.Format(@"randomiser\data\world\maps\campaign\imperial_campaign\map_{0}.tga", cmb_factionSelect.SelectedValue));
					break;

				case Game.REMASTER:
					image = new MagickImage(String.Format(@"Mods\My Mods\randomiser\data\world\maps\campaign\imperial_campaign\map_{0}.tga", cmb_factionSelect.SelectedValue));
					break;
			}

			Image bitmap = image.ToBitmap();
			picBox_map.Image = bitmap;
		}

		private void mapGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			mapGen = new MapGeneratorForm();
			mapGen.Show();
		}
	}
}
