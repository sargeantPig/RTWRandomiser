using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTWLib.Functions;
using RTWLib.Logger;
using RTWLib.Extensions;
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

			FileHelper.RenameFile("new_RTWR_Updater.exe", "RTWR_Updater.exe");
			Logger log = new Logger();
			bool isM2TW = log.FileCheck("medieval2.exe");
			if (args.Count() > 0)
			{
				if (args[0] == "-u")
					Application.Run(new RandomiserForm("Randomiser has been updated!", isM2TW));

				else if (args[0] == "-n")
					Application.Run(new RandomiserForm("Randomiser is fully updated.", isM2TW));

				else if (args[0] == "-a")
					Application.Run(new RandomiserForm("Randomiser update is available!", isM2TW));
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
					Application.Run(new RandomiserForm("Updater not found.", isM2TW));
			}	
		}
	}
}
