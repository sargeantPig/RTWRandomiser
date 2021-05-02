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
using RTWRandLib.Data;
using System.IO;

namespace RTWR_RTWLIB
{
    partial class Main : Logger
    {
        int seed;
        Dictionary<FileNames, IFile> files;
        public AdvancedOptionsViewer advancedOptions;
        public Options options;
        ToolStripProgressBar pb;
        StatusStrip ss;
        internal readonly bool isM2TW;

        public Game ActiveGame { get; }

        public Main(ToolStripProgressBar pb, StatusStrip ss, GroupBox settingsBox, Form parent, Game game)
        {
            Logger.AssemblyPrefix = "RTWR";
            Logger.AssemblyWatchList = new string[] { "RTWR_RTWLIB", "RTWLib" };

            this.pb = pb;
            this.ss = ss;
            this.ActiveGame = game;

            if (game == Game.MED2)
            {
                options = new Options(settingsBox, @"mods/randomiser/options.txt", "options.txt");
                advancedOptions = new AdvancedOptionsViewer(@"mods/randomiser/advancedOptions.txt", "advancedOptions.txt");
                TWRandom.advancedOptions = advancedOptions.Options;
                FileDestinations.ROOT = @"mods\randomiser\van_data";
                FileDestinations.MOD_FOLDER = @"mods\randomiser";
            }

            else if (game == Game.REMASTER)
            {
                options = new Options(settingsBox, FileDestinations.RemasterRoot + @"randomiser/options.txt", "options.txt");
                advancedOptions = new AdvancedOptionsViewer(FileDestinations.RemasterRoot + @"randomiser/advancedOptions.txt", "advancedOptions.txt");
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
