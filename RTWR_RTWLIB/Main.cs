﻿using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Logger;
using RTWR_RTWLIB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTWR_RTWLIB.Randomiser;
using System.Drawing;
using System.Threading;
using System.IO;

namespace RTWR_RTWLIB
{
    class Main : Logger
    {
        int seed;
        Dictionary<FileNames, IFile> files;
        ToolStripProgressBar pb;
        StatusStrip ss;
        public Main(ToolStripProgressBar pb, StatusStrip ss)
        {
            this.pb = pb;
            this.ss = ss;
        }
        public void Load(CheckBox chk_LogAll, ToolStripLabel lbl_progress)
        {
            try
            {
                //start loading data
                files = new Dictionary<FileNames, IFile>(){
                {FileNames.descr_regions, new Descr_Region(chk_LogAll.Checked) },
                {FileNames.descr_strat, new Descr_Strat()},
                {FileNames.export_descr_buildings, new EDB(chk_LogAll.Checked)},
                {FileNames.export_descr_unit, new EDU(chk_LogAll.Checked)},
                {FileNames.descr_sm_faction, new SM_Factions()},
                {FileNames.names, new NamesFile(chk_LogAll.Checked) }
                } ;

                float increment = 100 / files.Count();

                foreach (KeyValuePair<FileNames, IFile> file in files)
                {
                    lbl_progress.Text = "Loading: " + file.Value.Name.ToString();
                    ss.Refresh();
                    file.Value.Log("Loading " + file.Value.Description);
                    file.Value.Parse(FileDestinations.paths[file.Value.Name]["load"]);
                    pb.Increment((int)increment);
                }
            }

            catch(Exception ex)
            {
                this.PLog(ex.Message);
                this.PLog(ex.InnerException.Message);
                this.DisplayLogExit();
            }

        }

        public void Load(ToolStripLabel lbl_progress, FileNames fileName)
        {
            try
            {
                if (fileName == FileNames.export_descr_unit)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new EDU(false) } };
                else if (fileName == FileNames.export_descr_buildings)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new EDB(false) } };
                else if (fileName == FileNames.descr_strat)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new Descr_Strat() } };
                else if (fileName == FileNames.descr_regions)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new Descr_Region(false) } };
                else if (fileName == FileNames.descr_sm_faction)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new SM_Factions() } };
                else if (fileName == FileNames.names)
                    files = new Dictionary<FileNames, IFile>() { { fileName, new NamesFile(false) } };

                lbl_progress.Text = "Loading: " + files[fileName].Name.ToString();
                ss.Refresh();
                files[fileName].Log("Loading " + files[fileName].Description);
                files[fileName].Parse(FileDestinations.paths[files[fileName].Name]["load"]);
                pb.Value = 100;
                lbl_progress.Text = "Load Complete";
                ss.Refresh();
            }
            catch(Exception ex)
            {
                this.PLog(ex.Message);
                this.PLog(ex.InnerException.Message);
                this.DisplayLogExit();
            }
        }

        public void Randomise(GroupBox units_group, NumericUpDown unit_attr, NumericUpDown num_ownership,
            GroupBox faction_group, NumericUpDown num_cities,ToolStripLabel lbl_progress,
            PictureBox pic_map, CheckBox chk_unitinfo)
        {
            UnitInfo_dialog(chk_unitinfo);

            pb.Value = 0;
            lbl_progress.Text = "Starting...";
            ss.Refresh();

            Misc_Data.RefreshRegionWater();
            SelectMaps sm = new SelectMaps();
         
            ((Descr_Strat)files[FileNames.descr_strat]).RemoveSPQR();

            ((EDU)files[FileNames.export_descr_unit]).RandomiseFile<RandomEDU, EDU>(units_group, lbl_progress, ss, pb, new object[] { unit_attr, num_ownership });
            RandomEDU.SetFactionUnitList(((EDU)files[FileNames.export_descr_unit]));
            ((EDB)files[FileNames.export_descr_buildings]).SetRecruitment();
            ((Descr_Strat)files[FileNames.descr_strat]).RandomiseFile<RandomDS, Descr_Strat>(faction_group, lbl_progress, ss, pb, new object[] { files[FileNames.descr_regions], num_cities, files[FileNames.export_descr_unit], files[FileNames.names], files[FileNames.export_descr_buildings] });

            TWRandom.UnitByFaction.Clear();

            lbl_progress.Text = "Creating preview map...";
            ss.Refresh();

            Image oldImage = pic_map.Image;
            pic_map.Image = null;
            if (oldImage != null)
                oldImage.Dispose();

            pic_map.Image = sm.CreateCompleteMap((Descr_Strat)files[FileNames.descr_strat], (Descr_Region)files[FileNames.descr_regions], (SM_Factions)files[FileNames.descr_sm_faction]);

            pic_map.Refresh();

            sm.Save(@"randomiser\full_map.png");

            Thread.Sleep(250);

            FileWrite(files[FileNames.export_descr_unit] as IFile);
            FileWrite(files[FileNames.export_descr_buildings] as IFile);
            FileWrite(files[FileNames.descr_strat] as IFile);

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
            }
            else
            {
                int rnd = TWRandom.rnd.Next(int.MaxValue);
                seed = rnd;
                lbl_seed.Text = "Current Randomiser Seed: " + rnd;
                TWRandom.rnd = new Random(rnd);
            }

        }

        private void UnitInfo_dialog(CheckBox chk_misc_unitInfo)
        {
            if (chk_misc_unitInfo.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("The option 'Unit Info Fix' fixes the ui pictures for unit_info and unit_cards.\n" +
                    "The fix will open in a cmd prompt. Please wait for it to finish (it will disappear once done).\nAre you sure you want to continue?\n", "Unit Info Fix", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    chk_misc_unitInfo.Checked = false;
                    chk_misc_unitInfo.Enabled = false;
                    Functions_General.ExecuteCommand(@"randomiser\data\ui\", "assets_do.bat");
                }
            }
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