using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTWLib.Logger;
using RTWLib.Data;
using RTWLib.Functions;
using RTWR_RTWLIB.Randomiser;
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
		Dictionary<FileNames, IFile> files = new Dictionary<FileNames, IFile>(){
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

			chk_misc_selectA.CheckedChanged += CheckChanged;
			chk_misc_selectF.CheckedChanged += CheckChanged;
			chk_misc_selectU.CheckedChanged += CheckChanged;
		}

		async private void btn_load_Click(object sender, EventArgs e)
		{
			//start loading data
			float increment = 100 / files.Count();

			foreach (KeyValuePair<FileNames, IFile> file in files)
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
			pb_progress.Value = 0;
			lbl_progress.Text = "Starting...";
			statusStrip1.Refresh();

			EDU R_EDU =  files[FileNames.export_descr_unit] as EDU;
			EDB R_EDB = files[FileNames.export_descr_buildings] as EDB;
			Descr_Strat R_DS = files[FileNames.descr_strat] as Descr_Strat;
			Descr_Region R_DR = files[FileNames.descr_regions] as Descr_Region;
			SM_Factions R_SMF = files[FileNames.descr_sm_faction] as SM_Factions;

			R_EDU.RandomiseFile<RandomEDU, EDU>(grp_settings_units, lbl_progress, statusStrip1, pb_progress, new object[] {numUpDown_unit_attributes, numUpDown_unit_ownership });
			R_EDB.SetRecruitment();

			R_DS.RandomiseFile<RandomDS, Descr_Strat>(grp_settings_factions, lbl_progress, statusStrip1, pb_progress, new object[] {R_DR, numUpDown_faction_cities});



			files[FileNames.export_descr_unit] = R_EDU as IFile;

			Console.ReadLine();
		}

		private void chk_misc_selectA_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void CheckChanged(object sender, EventArgs e)
		{
			CheckBox cb = new CheckBox();

			if (sender is CheckBox)
				cb = sender as CheckBox;

			foreach (Control ctrl in grp_settings_misc.Controls)
			{
				CheckBox ctrlBox = new CheckBox();

				if (ctrl is CheckBox)
				{
					var type = ctrl.GetType();
					var props = ctrl.GetType().GetProperties();

					foreach (var obj in props)
					{
						
					}
					if (cb.Name != ctrlBox.Name)
						ctrlBox.Checked = false;
				}


			}

		}
	}
}
