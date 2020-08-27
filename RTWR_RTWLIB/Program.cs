using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTWLib.Functions;
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

			Functions_General.RenameFile("new_RTWR_Updater.exe", "RTWR_Updater.exe");

			if (args.Count() > 0)
			{
				if (args[0] == "-u")
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.Run(new RandomiserForm("Randomiser has been updated!"));
				}

				else if (args[0] == "-n")
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.Run(new RandomiserForm("Randomiser is fully updated."));
				}

				else if (args[0] == "-a")
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.Run(new RandomiserForm("Randomiser update is available!"));
				}
			}

			else
			{
				System.Diagnostics.Process.Start("RTWR_Updater.exe");
				Environment.Exit(0);
			}
			
		}


	}
}
