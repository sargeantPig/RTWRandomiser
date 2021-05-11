using System;
using System.Collections.Generic;
using System.Linq;
using RTWLib.Data;
using RTWLib.Functions;
using RTWR_RTWLIB.Data;
using System.Windows.Forms;
using RTWR_RTWLIB.Randomiser;
using RTWLib.Functions.EDU;
using System.Drawing;
using System.Threading;
using System.IO;


namespace RTWR_RTWLIB
{
    partial class Main
    {
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
                };

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

            catch (Exception ex)
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
                files[fileName].Parse(FileDestinations.paths[files[fileName].Name][loadsave], out lineNumber, out currentLine);
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
            GroupBox faction_group, NumericUpDown num_cities, ToolStripLabel lbl_progress,
            PictureBox pic_map, bool chk_unitinfo, bool chk_prefs, bool chk_removeSenate,
            bool chk_factionSelect, bool chk_randomStart, string factionSelected)
        {
            //UnitInfo_dialog(chk_unitinfo);

            pb.Value = 0;
            lbl_progress.Text = "Starting...";
            ss.Refresh();

            Misc_Data.RefreshRegionWater();
            SelectMaps sm = new SelectMaps(FileDestinations.selectMapPaths[0], FileDestinations.selectMapPaths[1]);

            if (chk_removeSenate)
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

            sm.Save(@"randomiser\previewimage.png");


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





    }
}
