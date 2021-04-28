using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Logger;
using RTWR_RTWLIB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RTWR_RTWLIB.Randomiser;
using RTWR_RTWLIB.Forms;
using RTWLib.Functions.EDU;
using RTWRandLib.Data;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using RTWLib.Medieval2;

namespace RTWR_RTWLIB
{
    class Main : Logger
    {
        int seed;
        Dictionary<FileNames, IFile> files;
        public AdvancedOptionsViewer advancedOptions;
        public Options options;
        ToolStripProgressBar pb;
        StatusStrip ss;
        public bool isM2TW { get; }
        public Main(ToolStripProgressBar pb, StatusStrip ss, GroupBox settingsBox, Form parent, bool isM2TW)
        {
            Logger.AssemblyPrefix = "RTWR";
            Logger.AssemblyWatchList = new string[] { "RTWR_RTWLIB", "RTWLib" };

            this.pb = pb;
            this.ss = ss;
            this.isM2TW = isM2TW;

            if (isM2TW)
            {
                options = new Options(settingsBox, @"mods/randomiser/options.txt", "options.txt");
                advancedOptions = new AdvancedOptionsViewer(@"mods/randomiser/advancedOptions.txt", "advancedOptions.txt");
                TWRandom.advancedOptions = advancedOptions.Options;
                FileDestinations.ROOT = @"mods\randomiser\van_data";
                FileDestinations.MOD_FOLDER = @"mods\randomiser";
            }

            else
            {
                options = new Options(settingsBox, @"randomiser/options.txt", "options.txt");
                advancedOptions = new AdvancedOptionsViewer(@"randomiser/advancedOptions.txt", "advancedOptions.txt");
                TWRandom.advancedOptions = advancedOptions.Options;
                SMFactions factionFile = new SMFactions();
                factionFile.Parse(FileDestinations.paths[FileNames.descr_sm_faction]["load"], out Logger.lineNumber, out Logger.lineText);
                ((ComboBox)parent.Controls["panel1"].Controls["cmb_factionSelect"]).DataSource = factionFile.facDetails.Keys.ToArray();
            }
        }
        public bool Load(CheckBox chk_LogAll, ToolStripLabel lbl_progress)
        {
            advancedOptions.SetUpOptions(advancedOptions.Options.filePath, advancedOptions.Options.fileName);
            TWRandom.advancedOptions = advancedOptions.Options;
            try
            {
                //start loading data
                files = new Dictionary<FileNames, IFile>(){
                {FileNames.descr_regions, new Descr_Region(chk_LogAll.Checked, FileDestinations.paths[FileNames.descr_regions]["load"][1], FileDestinations.M2TWpaths[FileNames.descr_regions]["load"][0]) },
                {FileNames.descr_strat, new Descr_Strat()},
                {FileNames.export_descr_buildings, new EDB(chk_LogAll.Checked)},
                {FileNames.export_descr_unit, new EDU(chk_LogAll.Checked)},
                {FileNames.descr_sm_faction, new SMFactions()},
                {FileNames.names, new NamesFile(chk_LogAll.Checked) }
                } ;

                float increment = 100 / files.Count();

                foreach (KeyValuePair<FileNames, IFile> file in files)
                {
                    this.fileName = file.Value.Name.ToString();
                    lbl_progress.Text = "Loading: " + file.Value.Name.ToString();
                    ss.Refresh();
                    file.Value.Log("Loading " + file.Value.Name);
                    file.Value.Parse(FileDestinations.paths[file.Value.Name]["load"], out lineNumber, out lineText);
                    pb.Increment((int)increment);
                }

                TWRandom.factionList = ((SMFactions)files[FileNames.descr_sm_faction]).facDetails.Keys.ToArray();

                pb.Value = 100;
            }

            catch(Exception ex)
            {
                this.ExceptionLog(ex);
                this.DisplayLog();
                return false;
            }

            return true;

        }

        public void Load(ToolStripLabel lbl_progress, FileNames fileName, string loadsave)
        {
            pb.Value = 0;
            string fileStr = "";
            string currentLine = "";
            int lineNumber = 0;
            try
            {
                if (fileName == FileNames.export_descr_unit)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new EDU(true) } };
                else if (fileName == FileNames.export_descr_buildings)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new EDB(true) } };
                else if (fileName == FileNames.descr_strat)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new Descr_Strat() } };
                else if (fileName == FileNames.descr_regions)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new Descr_Region(true, FileDestinations.paths[FileNames.descr_regions]["load"][1], FileDestinations.paths[FileNames.descr_regions]["load"][0]) } };
                else if (fileName == FileNames.descr_sm_faction)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new SMFactions() } };
                else if (fileName == FileNames.names)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new NamesFile(true) } };
                fileStr = files[fileName].Name.ToString();
                lbl_progress.Text = "Loading: " + files[fileName].Name.ToString();
                ss.Refresh();
                files[fileName].Log("Loading " + files[fileName].Name);
                files[fileName].Parse(FileDestinations.paths[files[fileName].Name][loadsave], out lineNumber, out currentLine ) ;
                pb.Value = 100;
                lbl_progress.Text = "Load Complete";
                ss.Refresh();
            }
            catch(Exception ex)
            {
                this.ExceptionLog(ex);
                this.DisplayLog();
            }
        }

        public bool M2TWLoad(CheckBox chk_LogAll, ToolStripLabel lbl_progress)
        {
            advancedOptions.SetUpOptions(advancedOptions.Options.filePath, advancedOptions.Options.fileName);
            TWRandom.advancedOptions = advancedOptions.Options;
            try
            {
                //start loading data
                files = new Dictionary<FileNames, IFile>(){
                {FileNames.descr_regions, new Descr_Region(chk_LogAll.Checked, FileDestinations.M2TWpaths[FileNames.descr_regions]["load"][1], FileDestinations.M2TWpaths[FileNames.descr_regions]["load"][0]) },
                {FileNames.descr_strat, new M2DS()},
                {FileNames.export_descr_buildings, new M2EDB(chk_LogAll.Checked)},
                {FileNames.export_descr_unit, new M2EDU(chk_LogAll.Checked)},
                {FileNames.descr_sm_faction, new SMFactions()},
                {FileNames.names, new NamesFile(chk_LogAll.Checked) },
                {FileNames.battle_models, new M2ModelBattle() }
                };

                float increment = 100 / files.Count();

                foreach (KeyValuePair<FileNames, IFile> file in files)
                {
                    this.fileName = file.Value.Name.ToString();
                    lbl_progress.Text = "Loading: " + file.Value.Name.ToString();
                    ss.Refresh();
                    file.Value.Log("Loading " + file.Value.Name);
                    file.Value.Parse(FileDestinations.M2TWpaths[file.Value.Name]["load"], out lineNumber, out lineText);
                    pb.Increment((int)increment);
                }

                TWRandom.factionList = ((SMFactions)files[FileNames.descr_sm_faction]).facDetails.Keys.ToArray();

                pb.Value = 100;
            }

            catch (Exception ex)
            {
                this.ExceptionLog(ex);
                this.DisplayLog();
                return false;
            }

            return true;

        }

        public void M2TWLoad(ToolStripLabel lbl_progress, FileNames fileName, string loadsave)
        {
            pb.Value = 0;
            string fileStr = "";
            string currentLine = "";
            int lineNumber = 0;
            try
            {
                if (fileName == FileNames.export_descr_unit)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new M2EDU(false) } };
                else if (fileName == FileNames.export_descr_buildings)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new M2EDB(false) } };
                else if (fileName == FileNames.descr_strat)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new M2DS() } };
                else if (fileName == FileNames.descr_regions)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new Descr_Region(false, FileDestinations.M2TWpaths[FileNames.descr_regions]["load"][1], FileDestinations.M2TWpaths[FileNames.descr_regions]["load"][0]) } };
                else if (fileName == FileNames.descr_sm_faction)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new SMFactions() } };
                else if (fileName == FileNames.names)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new NamesFile(false) } };
                fileStr = files[fileName].Name.ToString();
                lbl_progress.Text = "Loading: " + files[fileName].Name.ToString();
                ss.Refresh();
                files[fileName].Log("Loading " + files[fileName].Name);
                files[fileName].Parse(FileDestinations.M2TWpaths[files[fileName].Name][loadsave], out lineNumber, out currentLine);
                pb.Value = 100;
                lbl_progress.Text = "Load Complete";
                ss.Refresh();
            }
            catch (Exception ex)
            {
                this.ExceptionLog(ex);
                this.DisplayLog();
            }
        }



        public void Randomise(GroupBox units_group, NumericUpDown unit_attr, NumericUpDown num_ownership,
            GroupBox faction_group, NumericUpDown num_cities,ToolStripLabel lbl_progress,
            PictureBox pic_map, bool chk_unitinfo, bool chk_prefs, bool chk_removeSenate, 
            bool chk_factionSelect, bool chk_randomStart, string factionSelected)
        {
            //UnitInfo_dialog(chk_unitinfo);

            pb.Value = 0;
            lbl_progress.Text = "Starting...";
            ss.Refresh();

            Misc_Data.RefreshRegionWater();
            SelectMaps sm = new SelectMaps(FileDestinations.selectMapPaths[0], FileDestinations.selectMapPaths[1]);
            
            if(chk_removeSenate)
                ((Descr_Strat)files[FileNames.descr_strat]).RemoveSPQR();
            
            
            ((EDU)files[FileNames.export_descr_unit]).RandomiseFile<RandomEDU, EDU>(units_group, lbl_progress, ss, pb, new object[] { unit_attr, num_ownership });
            RandomEDU.SetFactionUnitList(((EDU)files[FileNames.export_descr_unit]));
            ((EDB)files[FileNames.export_descr_buildings]).SetTieredRecruitment(((EDU)files[FileNames.export_descr_unit]));
            ((EDB)files[FileNames.export_descr_buildings]).SetRecruitment(((EDU)files[FileNames.export_descr_unit]));
            ((Descr_Strat)files[FileNames.descr_strat]).RandomiseFile<RandomDS, Descr_Strat>(faction_group, lbl_progress, ss, pb, new object[] { files[FileNames.descr_regions], num_cities, files[FileNames.export_descr_unit], files[FileNames.names], files[FileNames.export_descr_buildings] });

            TWRandom.UnitByFaction.Clear();

            if (chk_factionSelect)
                ((Descr_Strat)files[FileNames.descr_strat]).MoveFactionToTopOfStrat(factionSelected);

            if (chk_unitinfo)
                ((EDU)files[FileNames.export_descr_unit]).ApplyUnitInfoFix();

            if (chk_prefs)
                new PreferencesFile().ImportPreferences(@"randomiser\preferences\preferences.txt");

            lbl_progress.Text = "Creating preview map...";
            ss.Refresh();

            Image oldImage = pic_map.Image;
            pic_map.Image = null;
            if (oldImage != null)
                oldImage.Dispose();

            pic_map.Image = sm.CreateCompleteMap((Descr_Strat)files[FileNames.descr_strat], (Descr_Region)files[FileNames.descr_regions], (SMFactions)files[FileNames.descr_sm_faction]);

            pic_map.Refresh();

            sm.Save(@"randomiser\full_map.png");
            

            Thread.Sleep(250);

            files[FileNames.export_descr_unit].ToFile(FileDestinations.paths[FileNames.export_descr_unit]["save"][0]);
            files[FileNames.export_descr_buildings].ToFile(FileDestinations.paths[FileNames.export_descr_buildings]["save"][0]);
            files[FileNames.descr_strat].ToFile(FileDestinations.paths[FileNames.descr_strat]["save"][0]);


            StreamWriter sw = new StreamWriter("randomiser_.txt");
            sw.Write(seed);
            sw.Close();

            lbl_progress.Text = "Randomisation Complete!";
            pb.Value = 100;
        }


        public void M2TWRandomise(GroupBox units_group, NumericUpDown unit_attr, NumericUpDown num_ownership,
          GroupBox faction_group, NumericUpDown num_cities, ToolStripLabel lbl_progress,
          PictureBox pic_map, bool chk_unitinfo, bool chk_prefs)
        {
            //UnitInfo_dialog(chk_unitinfo);

            pb.Value = 0;
            lbl_progress.Text = "Starting...";
            ss.Refresh();

            Misc_Data.RefreshRegionWater();
            SelectMaps sm = new SelectMaps(FileDestinations.M2TWselectMapPaths[0], FileDestinations.M2TWselectMapPaths[1]);
            //((Descr_Strat)files[FileNames.descr_strat]).RemoveSPQR();
            ((M2EDU)files[FileNames.export_descr_unit]).RandomiseFile<RandomEDU, M2EDU>(units_group, lbl_progress, ss, pb, new object[] { unit_attr, num_ownership });
            RandomEDU.SetFactionUnitList(((EDU)files[FileNames.export_descr_unit]));
            ((M2EDB)files[FileNames.export_descr_buildings]).SetRecruitment(((EDU)files[FileNames.export_descr_unit]));
            ((M2DS)files[FileNames.descr_strat]).RandomiseFile<RandomDS, M2DS>(faction_group, lbl_progress, ss, pb, new object[] { files[FileNames.descr_regions], num_cities, files[FileNames.export_descr_unit], files[FileNames.names], files[FileNames.export_descr_buildings] });

            TWRandom.UnitByFaction.Clear();

            if (chk_unitinfo)
                ((M2EDU)files[FileNames.export_descr_unit]).ApplyUnitInfoFix();
            lbl_progress.Text = "Creating preview map...";
            ss.Refresh();

            Image oldImage = pic_map.Image;
            pic_map.Image = null;
            if (oldImage != null)
                oldImage.Dispose();

            pic_map.Image = sm.CreateCompleteMap((M2DS)files[FileNames.descr_strat], (Descr_Region)files[FileNames.descr_regions], (SMFactions)files[FileNames.descr_sm_faction]);

            pic_map.Refresh();

            sm.Save(@"mods\randomiser\full_map.png");


            Thread.Sleep(250);

            files[FileNames.export_descr_unit].ToFile(FileDestinations.M2TWpaths[FileNames.export_descr_unit]["save"][0]);
            files[FileNames.export_descr_buildings].ToFile(FileDestinations.M2TWpaths[FileNames.export_descr_buildings]["save"][0]);
            files[FileNames.descr_strat].ToFile(FileDestinations.M2TWpaths[FileNames.descr_strat]["save"][0]);
            files[FileNames.battle_models].ToFile(FileDestinations.M2TWpaths[FileNames.battle_models]["save"][0]);

            StreamWriter sw = new StreamWriter("randomiser_.txt");
            sw.Write(seed);
            sw.Close();

            lbl_progress.Text = "Randomisation Complete!";
            pb.Value = 100;
        }

        public void SetUp_seed(CheckBox cb_seed, TextBox txt_seed, Label lbl_seed)
        {
            if (cb_seed.Checked)
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
                TWRandom.seed = rseed;
            }
            else
            {
                int rnd = TWRandom.rnd.Next(int.MaxValue);
                seed = rnd;
                lbl_seed.Text = "Current Randomiser Seed: " + rnd;
                TWRandom.rnd = new Random(rnd);
                TWRandom.seed = rnd;
            }

        }


        private void UnitInfo_dialog(CheckBox chk_misc_unitInfo)
        {
            /*if (chk_misc_unitInfo.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("The option 'Unit Info Fix' fixes the ui pictures for unit_info and unit_cards.\n" +
                    "The fix will open in a cmd prompt. Please wait for it to finish (it will disappear once done).\nAre you sure you want to continue?\n", "Unit Info Fix", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    chk_misc_unitInfo.Checked = false;
                    chk_misc_unitInfo.Enabled = false;
                    Functions_General.ExecuteCommand(@"randomiser\data\ui\", "assets_do.bat");
                }
            }*/
        }

        private void FileWrite(IFile file)
		{
			StreamWriter sw = new StreamWriter(FileDestinations.paths[file.Name]["save"][0], false);

			sw.WriteLine(file.Output());

			sw.Close();
		}

        public IFile GetFile(FileNames file)
        {
            if (files.ContainsKey(file))
                return files[file];
            else return null;
        }
    }
}  
