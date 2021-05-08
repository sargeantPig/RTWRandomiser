using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTWLib.Functions;
using RTWLib.Logger;
using RTWLib.Extensions;
using RTWLib.Data;

namespace RTWR_RTWLIB
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		[STAThread]
		static void Main(string[] args)
		{
#if DEBUG
			args = new string[] {"-n"};
#endif
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			//FileHelper.RenameFile("new_RTWR_Updater.exe", "RTWR_Updater.exe");
			Logger log = new Logger();

			Game game = Game.Missing;

			string modeText = "";

			if (log.FileCheck("medieval2.exe"))
			{
				game = Game.MED2;
				modeText = "Medieval 2 Detected";
			}
			else if (log.FileCheck("Application.lnk"))
			{
				modeText = "Rome Remaster Detected";
				game = Game.REMASTER;
			}
			if (log.FileCheck("RomeTW.exe"))
			{
				modeText = "Rome TW Detected";
				game = Game.OGRome;
			}

			if (game == Game.Missing)
			{
				log.PLog("Cannot find compaitable Total War, is the randomiser in the right folder?");
				log.DisplayLogExit();
			}

			Application.Run(new RandomiserForm(modeText, game));

			/*if (args.Count() > 0)
			{
				if (args[0] == "-u")
					Application.Run(new RandomiserForm("Randomiser has been updated!", game));

				else if (args[0] == "-n")
					Application.Run(new RandomiserForm("Randomiser is fully updated.", game));

				else if (args[0] == "-a")
					Application.Run(new RandomiserForm("Randomiser update is available!", game));
			}

			else
			{
				bool updaterFound = log.FileCheck("RTWR_Updater.exe");
				if (updaterFound)
				{
					System.Diagnostics.Process.Start("RTWR_Updater.exe");
					Environment.Exit(0);
				}
				else
					Application.Run(new RandomiserForm("Updater not found.", game));
			}	*/
		}
	}
}
