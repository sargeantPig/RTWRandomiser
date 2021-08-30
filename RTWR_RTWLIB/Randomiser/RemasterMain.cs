using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Logger;
using RTWR_RTWLIB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RTWR_RTWLIB.Randomiser;
using System.IO;
using RTWLib.Functions.EDU;
using System.Drawing;
using System.Threading;
using RTWLib.Extensions;
using RTWR_RTWLIB.Forms;

namespace RTWR_RTWLIB
{
    partial class Main
    {
        public bool RemasterLoad(CheckBox chk_LogAll, ToolStripLabel lbl_progress, Dictionary<FileNames, Dictionary<string, string[]>> fileDest, Dictionary<FileNames, Dictionary<string, string[]>> overrideDest, SubGame sub = SubGame.Rome)
        {
            advancedOptions.SetUpOptions(advancedOptions.Options.filePath, advancedOptions.Options.fileName);
            TWRandom.advancedOptions = advancedOptions.Options;
            FileData fd = new FileData(null, EString.Array("faction"), '\t', ',', EString.Array(' '), ';', 1, "", ',');
            fd.Format = "{0}";
            try
            {

                if (sub == SubGame.Rome)
                {
                    //start loading data
                    files = new Dictionary<FileNames, IFile>(){
                        {FileNames.descr_regions, new Descr_Region(chk_LogAll.Checked, fileDest[FileNames.descr_regions]["load"][1], fileDest[FileNames.descr_regions]["load"][0]) },
                        {FileNames.descr_strat, new RemasterDescr_Strat()},
                        {FileNames.descr_sm_faction, new SMFactions()},
                        {FileNames.override_descr_strat, new RemasterDescr_Strat()}
                    };
                }

                else if (sub == SubGame.Bi)
                {
                    //start loading data
                    files = new Dictionary<FileNames, IFile>(){
                        {FileNames.descr_regions, new BIDescr_Region(chk_LogAll.Checked, fileDest[FileNames.descr_regions]["load"][1], fileDest[FileNames.descr_regions]["load"][0]) },
                        {FileNames.descr_strat, new RemasterDescr_Strat(true)},
                        {FileNames.descr_sm_faction, new FileBase(FileNames.descr_sm_faction, "","", fd)},
                    };
                }

                float increment = 100 / files.Count();

                foreach (KeyValuePair<FileNames, IFile> file in files)
                {
                    this.fileName = file.Value.Name.ToString();
                    lbl_progress.Text = "Loading: " + file.Value.Name.ToString();
                    ss.Refresh();
                    file.Value.Log("Loading " + file.Value.Name);
                    if(file.Key.ToString().Contains("override", "feral"))
                        file.Value.Parse(overrideDest[file.Value.Name]["load"], out lineNumber, out lineText);
                    else file.Value.Parse(fileDest[file.Value.Name]["load"], out lineNumber, out lineText);
                    pb.Increment((int)increment);
                }

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

        public void RemasterLoad(ToolStripLabel lbl_progress, FileNames fileName, string loadsave)
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
                    files = new Dictionary<FileNames, IFile>() { { fileName, new RemasterDescr_Strat() } };
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





        public void RemasterRandomise(GroupBox units_group, NumericUpDown unit_attr, NumericUpDown num_ownership,
            GroupBox faction_group, NumericUpDown num_cities, ToolStripLabel lbl_progress,
            PictureBox pic_map, bool chk_unitinfo, bool chk_prefs, bool chk_removeSenate,
            bool chk_factionSelect, bool chk_randomStart, string factionSelected, SubGame sub)
        {
            //UnitInfo_dialog(chk_unitinfo);

            pb.Value = 0;
            lbl_progress.Text = "Starting...";
            ss.Refresh();
            Misc_Data.RefreshRegionWater();

            SelectMaps sm = new SelectMaps(FileDestinations.remasterSelectMaps[0], FileDestinations.RemasterPaths[FileNames.radar_map1]["load"][0]);
            if(sub == SubGame.Bi)
                 sm = new SelectMaps(FileDestinations.remasterBISelectMaps[0], FileDestinations.RemasterBIPaths[FileNames.radar_map1]["load"][0]);
            Descr_Strat ds = null;
            Descr_Strat ods = null;
            var dr = files[FileNames.descr_regions];
            SMFactions smf = null;
            FileBase bismf = null;



            //((RemasterDescr_Strat)files[FileNames.descr_strat]).RandomiseFile<RandomDS, Descr_Strat>(faction_group, lbl_progress, ss, pb, new object[] { files[FileNames.descr_regions], num_cities, files[FileNames.export_descr_unit], files[FileNames.names], files[FileNames.export_descr_buildings] });
            var chkBoxes = faction_group.Controls.ToList();
            chkBoxes.Sort(new Comparison<Control>(Comparisons.CompareNameEnd));
            ds = (Descr_Strat)files[FileNames.descr_strat];
            if (sub == SubGame.Rome)
            {
                ods = (Descr_Strat)files[FileNames.override_descr_strat];
                smf = (SMFactions)files[FileNames.descr_sm_faction];
            }
            if (sub == SubGame.Bi)
            {
                bismf = (FileBase)files[FileNames.descr_sm_faction];
                bismf.data.FormulateAttributes(true, false);
            } 
            foreach (Control control in chkBoxes)
            {
                switch (control.Name)
                {
                    case "chk_faction_voronoi_4":
                        if (((CheckBox)control).Checked)
                        {
                            if (sub == SubGame.Rome)
                            {
                                RandomDS.VoronoiSettlements(ds, (Descr_Region)dr);
                                RandomDS.VoronoiSettlements(ods, (Descr_Region)dr);
                            }
                            else
                            {
                                RandomDS.VoronoiSettlements(ds, (BIDescr_Region)dr);
                            }
                        }
                        break;
                    case "chk_faction_settlements_4":
                        if (((CheckBox)control).Checked)
                        {
                            if (sub == SubGame.Rome)
                            {
                                RandomDS.RandomSettlements(ds, (Descr_Region)dr, num_cities);
                                RandomDS.RandomSettlements(ods, (Descr_Region)dr, num_cities);
                            }
                            else
                            {
                                RandomDS.RandomSettlements(ds, (BIDescr_Region)dr, num_cities);;
                            }
                        }
                        break;
                    case "chk_faction_coreA_7":
                        if (((CheckBox)control).Checked)
                        {
                            if (sub == SubGame.Rome)
                            {
                                RandomDS.RandCoreAttitudes(ds, (Descr_Region)dr);
                                RandomDS.RandCoreAttitudes(ods, (Descr_Region)dr);
                            }
                            else {
                                RandomDS.BIRandCoreAttitudes(ds, dr as BIDescr_Region);
                            }
                        }
                        break;
                    case "chk_total_war_8":
                        if (((CheckBox)control).Checked)
                        {
                            RandomDS.TotalWar(ds);
                            if (sub == SubGame.Rome)
                                RandomDS.TotalWar(ods);
                        }
                        break;
                        
                }
            }

            if (chk_removeSenate && sub == SubGame.Rome)
                ds.RemoveSPQR();
            
           TWRandom.UnitByFaction.Clear();
            lbl_progress.Text = "Creating preview map...";
            ss.Refresh();

            Image oldImage = pic_map.Image;
            pic_map.Image = null;
            if (oldImage != null)
                oldImage.Dispose();

            if (sub == SubGame.Rome)
                pic_map.Image = sm.CreateCompleteMap(ds, (Descr_Region)dr, smf);
            else if (sub == SubGame.Bi)
                pic_map.Image = sm.CreateCompleteMap(ds, (BIDescr_Region)dr, bismf);
            pic_map.Refresh();

            sm.Save(@"Mods\My Mods\randomiser\previewimage.png");


            Thread.Sleep(250);
            if (sub == SubGame.Rome)
            {
                ds.ToFile(FileDestinations.RemasterPaths[FileNames.descr_strat]["save"][0]);
                ods.ToFile(FileDestinations.RemasterOverrides[FileNames.descr_strat]["save"][0]);
            }

            else
            {
                ds.ToFile(FileDestinations.RemasterBIPaths[FileNames.descr_strat]["save"][0]);
            }

            StreamWriter sw = new StreamWriter("randomiser_.txt");
            sw.Write(seed);
            sw.Close();

            lbl_progress.Text = "Randomisation Complete!";
            pb.Value = 100;
        }
    }
}
