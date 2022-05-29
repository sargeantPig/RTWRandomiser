using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using RTWLib.Logger;
using RTWLib.Data;
using RTWLib.Functions;
using RTWR_RTWLIB.Randomiser;
using RTWLib.Memory;
using RTWR_RTWLIB.Data;
using RTWR_RTWLIB.Forms;
using RTWLib.Functions.EDU;
using RTWLib.Medieval2;
using ImageMagick;
using Microsoft.VisualBasic;
using System.Text;
using Microsoft.VisualBasic.Devices;
using RTWLib.Extensions;
using System.Security.Cryptography.X509Certificates;
using RTWLib.Functions.Remaster;
using System.Collections.Generic;

namespace RTWR_RTWLIB
{
	public partial class RandomiserForm : Form
	{
		Main main;
		EDU_viewer edu;
		StratViewer strat;
		MapGeneratorForm mapGen;
		SubGame subGame;

		public RandomiserForm(string updateMessage, Game game)
		{
            this.Icon = RTWR_RTWLIB.Properties.Resources.julii_icon;	
			InitializeComponent();
			this.lbl_mode.Text = updateMessage;
			picBox_map.SizeMode = PictureBoxSizeMode.Zoom;
			ConstructGameLbl(game.ToString());


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
				if (File.Exists(@"mods\randomiser\previewimage.png"))
				{
					
					picBox_map.Image = Image.FromFile(@"mods\randomiser\previewimage.png");

				}
			}

			else if (game == Game.REMASTER)
			{
				if (FileHelper.FolderExists(FileDest.RemasterBiData))
					subGame = SubGame.Rome;
				if (FileHelper.FolderExists(FileDest.RemasterRomeData))
					subGame = SubGame.Bi;

				ConstructGameLbl(subGame.ToString());

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
				chk_faction_coreA_7.Enabled = true;
				menuStrip1.Enabled = true;
				chk_windowed.Enabled = false;
				chk_removeSPQR.Enabled = true;
				chk_total_war_8.Enabled = true;

				if (File.Exists(@"Mods\My Mods\randomiser\previewimage.png"))
				{

					picBox_map.Image = ExtMagick.LoadBitmap(@"Mods\My Mods\randomiser\previewimage.png");
					
				}
			}
			else
			{
				if (File.Exists(@"randomiser\previewimage.png"))
				{
					picBox_map.Image = Image.FromFile(@"randomiser\previewimage.png");
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

			if(main.ActiveGame == Game.REMASTER)
			using (PickGame pickGame = new PickGame())
			{
				pickGame.ShowDialog();
				subGame = pickGame.SubGame;

			}

			switch_expansion(subGame);

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
					if (subGame == SubGame.Rome)
					{
						if (main.RemasterLoad(chk_LogAll, lbl_progress, FileDest.RemasterPaths, FileDest.RemasterOverrides))
						{
							main.RemasterRandomise(grp_settings_units, numUpDown_unit_attributes, numUpDown_unit_ownership, grp_settings_factions, numUpDown_faction_cities,
							lbl_progress, picBox_map, chk_misc_unitInfo.Checked, chk_preferences.Checked, chk_removeSPQR.Checked, chk_startWith.Checked, chk_rndFationStart.Checked, (string)cmb_factionSelect.SelectedValue, subGame);
						}
					}
					else if(subGame == SubGame.Bi)
					{
						if (main.RemasterLoad(chk_LogAll, lbl_progress, FileDest.RemasterBIPaths, FileDest.RemasterBIOverrides, subGame))
						{
							main.RemasterRandomise(grp_settings_units, numUpDown_unit_attributes, numUpDown_unit_ownership, grp_settings_factions, numUpDown_faction_cities,
							lbl_progress, picBox_map, chk_misc_unitInfo.Checked, chk_preferences.Checked, chk_removeSPQR.Checked, chk_startWith.Checked, chk_rndFationStart.Checked, (string)cmb_factionSelect.SelectedValue, subGame);
						}

					}

					else main.LoadError();
					break;
			}

		}

		private void switch_expansion(SubGame sub)
		{
			switch (sub)
			{
				case SubGame.Bi:
					if (FileHelper.FolderExists(FileDest.RemasterBiData))
					{
						FileHelper.RenameDirectory(FileDest.RemasterData, FileDest.RemasterRomeData);
						FileHelper.RenameDirectory(FileDest.RemasterBiData, FileDest.RemasterData);
					}
					break;
				case SubGame.Rome:
					if (FileHelper.FolderExists(FileDest.RemasterRomeData))
					{
						FileHelper.RenameDirectory(FileDest.RemasterData, FileDest.RemasterBiData);
						FileHelper.RenameDirectory(FileDest.RemasterRomeData, FileDest.RemasterData);
					}
					break;
			}

			ConstructGameLbl(subGame.ToString());
			ReloadFactionList();
		}

		private void ReloadFactionList()
		{
			FileBase file = new FileBase(FileNames.none, null, null);
			switch (main.ActiveGame)
			{
				case Game.REMASTER:
					file = FileWrapper.CreateSMF(FileDest.RemasterPaths[FileNames.descr_sm_faction]["save"]);
					var factions = ((FileWrapper)file).objects[0];
					cmb_factionSelect.DataSource = ((Group<string>)factions).objects.Select(x => x.tag).ToList();
					break;
				case Game.MED2:
					file = GenericFile.CreateSMF(FileDest.M2TWpaths[FileNames.descr_sm_faction]["save"][0]);
					cmb_factionSelect.DataSource = file.data.attributes.Keys.ToArray();
					break;
				case Game.OGRome:
					file = GenericFile.CreateSMF(FileDest.paths[FileNames.descr_sm_faction]["save"][0]);
					cmb_factionSelect.DataSource = file.data.attributes.Keys.ToArray();
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
			StreamWriter sw = new StreamWriter(FileDest.paths[file.Name]["save"][0], false);

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
					path = FileDest.M2TWpaths[FileNames.descr_strat]["save"];
					ds.Parse(path, out Logger.lineNumber, out Logger.lineText);
					break;
				case Game.OGRome:
					ds = new Descr_Strat();
					path = FileDest.paths[FileNames.descr_strat]["save"];
					ds.Parse(path, out Logger.lineNumber, out Logger.lineText);
					break;
				case Game.REMASTER:
					ds = new RemasterDescr_Strat();
					path = FileDest.RemasterPaths[FileNames.descr_strat]["save"];
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
			if (main.ActiveGame == Game.REMASTER)
				return;

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
			if (main.ActiveGame == Game.REMASTER)
				return;

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
					if(subGame == SubGame.Rome)
						image = new MagickImage(String.Format(@"Mods\My Mods\randomiser\data\world\maps\campaign\imperial_campaign\map_{0}.tga", cmb_factionSelect.SelectedValue));
					else image = new MagickImage(String.Format(@"Mods\My Mods\randomiser\data\world\maps\campaign\barbarian_invasion\map_{0}.tga", cmb_factionSelect.SelectedValue));
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
					image = new MagickImage(String.Format(@"Mods\My Mods\randomiser\previewimage.png", cmb_factionSelect.SelectedValue));
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
					if (subGame == SubGame.Rome)
						image = new MagickImage(String.Format(@"Mods\My Mods\randomiser\data\world\maps\campaign\imperial_campaign\map_{0}.tga", cmb_factionSelect.SelectedValue));
					else image = new MagickImage(String.Format(@"Mods\My Mods\randomiser\data\world\maps\campaign\barbarian_invasion\map_{0}.tga", cmb_factionSelect.SelectedValue));
					break;
			}

			Image bitmap = image.ToBitmap();
			picBox_map.Image = bitmap;
		}

		private void mapGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (main.ActiveGame == Game.REMASTER)
				return;

			mapGen = new MapGeneratorForm();
			mapGen.Show();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string name = lbl_seed.Text;

			main.options.Export(grp_box_settings);
			main.advancedOptions.Export();

			switch (main.ActiveGame)
			{
				case Game.MED2:
					RandomiseLoadSave.Save(EStr.Array(FileDest.M2TWRoot + FileDest.optionsLoc, FileDest.M2TWRoot + FileDest.advancedOptionsLoc),
						name, main.ActiveGame, FileDest.SeedSaveLoc + name + ".txt");
					break;
				case Game.OGRome:
					RandomiseLoadSave.Save(EStr.Array(FileDest.optionsLoc, FileDest.advancedOptionsLoc),
						name, main.ActiveGame, FileDest.SeedSaveLoc + name + ".txt");
					break;
				case Game.REMASTER:
					RandomiseLoadSave.Save(EStr.Array(FileDest.RemasterRoot + FileDest.optionsLoc, FileDest.RemasterRoot + FileDest.advancedOptionsLoc),
						name, main.ActiveGame, FileDest.SeedSaveLoc + name + ".txt", subGame);
					break;
			} 

			

			/*if (Directory.Exists(FileDestinations.RemasterCustom + @"\" + name))
			{
				main.PLog("Cant save, randomisation with that seed already exists.");
				main.DisplayLog();
				return;
			}*/
			/*new Computer().FileSystem.CopyDirectory(FileDestinations.RemasterCampaign, FileDestinations.RemasterCustom + @"\" + name);
			FileBase file = new FileBase(RTWLib.Data.FileNames.campaign_descr, string.Empty, string.Empty);
			FileBase descr = new FileBase(RTWLib.Data.FileNames.campaign_descr, string.Empty, string.Empty);
			int lineno;
			string line;
			string descriptionpath = FileDestinations.RemasterPaths[FileNames.campaign_descr]["save"][0].Replace(".txt", "");
			file.data.dataTags = new char[] { '{' };
			file.data.commentTag = '¬';
			file.Parse(new string[] { FileDestinations.RemasterPaths[FileNames.campaign_descr]["save"][0] }, out lineno, out line);
			file.data.Format = "{{{0}}}{1}";
			file.data.FormulateAttributes(new char[] { '}' }, '{', '}');
			file.data.AddAttribute(name + "_TITLE", "Randomised with seed: " + name + ".................");
			file.data.AddAttribute(name + "_DESCR", "randomised: DISPLAY OPTIONS HERE");


			descr.data.dataTags = new char[] { '{' };
			descr.data.commentTag = '¬';
			descr.data = new DataString(file.data._ConsoleOutputAttribute(name + "_DESCR"), descr.data);
			descr.ToFile(FileDestinations.RemasterCustom + name + @"\description.txt", Encoding.Unicode);
			file.ToFile(descriptionpath + ".txt", Encoding.Unicode);
			file.ToFile(descriptionpath + "_mac_de.txt", Encoding.Unicode);
			file.ToFile(descriptionpath + "_mac_es.txt", Encoding.Unicode);
			file.ToFile(descriptionpath + "_mac_fr.txt", Encoding.Unicode);
			file.ToFile(descriptionpath + "_mac_it.txt", Encoding.Unicode);
			file.ToFile(descriptionpath + "_mac_ru.txt", Encoding.Unicode);
			file.ToFile(descriptionpath + "_mac_zh_cn.txt", Encoding.Unicode);*/
		}

		private void ConstructGameLbl(string game)
		{
			lbl_game.Text = string.Format("Using{0}{1}{2}Data Folder", EStr.CRL(), game, EStr.CRL());
		}

		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}
	}
}
