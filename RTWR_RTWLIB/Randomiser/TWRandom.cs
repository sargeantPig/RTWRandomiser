using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using RTWLib.Functions;
using RTWLib.Objects;
using RTWLib.Data;
using RTWLib.Logger;
using System.Threading;

namespace RTWR_RTWLIB.Randomiser
{
	public static class TWRandom
	{
		public static Random rnd = new Random();
		public static string[] AIMilitary = { "napoleon", "caesar", "genghis", "mao", "stalin", "smith", "henry" };
		public static string[] AIEconomy = { "comfortable", "balanced", "bureacrat", "fortified", "religous", "trade", "sailor" };
		public static string[] VoiceTypes = { "Light_1", "Medium_1", "Heavy_1", "General_1", "Female_1" };
		public static Dictionary<FactionOwnership, List<string>> UnitByFaction = new Dictionary<FactionOwnership, List<string>>();

		public static string GetRandomAIEconomy()
		{
			return AIEconomy[rnd.Next(0, AIEconomy.Count())];
		}
		public static string GetRandomAIMilitary()
		{
			return AIMilitary[rnd.Next(0, AIMilitary.Count())];
		}
		public static string GetRandomVoiceTypes()
		{
			return VoiceTypes[rnd.Next(0, VoiceTypes.Count())];
		}

		public static void AddKV(this Dictionary<FactionOwnership, List<string>> dic, FactionOwnership key, string unit)
		{
			if (!dic.ContainsKey(key))
			{
				dic.Add(key, new List<string>() { unit });
			}

			else
			{
				dic[key].Add(unit);
			}
		}
		public static List<string> GetFactions(this Dictionary<FactionOwnership, List<string>> dic, string unit)
		{
			LookUpTables lt = new LookUpTables();

			List<string> fo = new List<string>();

			foreach (KeyValuePair<FactionOwnership, List<string>> kv in dic)
			{
				if (kv.Value.Contains(unit))
				{
					fo.Add(lt.LookUpString(kv.Key));
				}
			}

			return fo;

		}
	}

	public static class Randomise
	{
		public static Task RandomiseFile<T, A>(this A file, GroupBox grp, ToolStripLabel label, StatusStrip ss, ToolStripProgressBar pb, object[] arguments)
		{
			Type t = typeof(T);
			int increment = 100 / grp.Controls.Count;

			List<CheckBox> checkBoxes = new List<CheckBox>();

			foreach (Control control in grp.Controls)
			{
				CheckBox cb = new CheckBox();
				if (control is CheckBox)
				{
					cb = control as CheckBox;

					if (cb.Checked)
						checkBoxes.Add(cb);
				}
				else continue;

				if (!cb.Checked)
					continue;

			}

			checkBoxes.Sort(new Comparison<CheckBox>(Functions_General.CompareNameEnd));

			foreach (CheckBox cb in checkBoxes)
			{
				try
				{
					MethodInfo m = t.GetMethod(cb.Tag.ToString());
					int objs = m.GetParameters().Count();
					object[] parameters = new object[objs];
					parameters[0] = file;

					var mparameters = m.GetParameters();

					List<Type> requiredTypes = new List<Type>();

					foreach (ParameterInfo pi in mparameters)
					{
						requiredTypes.Add(pi.ParameterType);
					}

					int index = 0;
					foreach (Type type in requiredTypes)
					{
						foreach (object o in arguments)
						{
							if (o.GetType() == type && type != typeof(NumericUpDown))
								parameters[index] = o;  //add correct argument for the method
							else if(o.GetType() == type && type == typeof(NumericUpDown))
							{
								if ((string)((NumericUpDown)o).Tag == m.Name)
								{
									parameters[index] = o;
								}
							}
						}

						index++;
					}

					label.Text = m.Name;
					pb.Increment(increment);
					ss.Refresh();

					Thread.Sleep(250);
					m.Invoke(null, parameters);
				}

				catch (Exception e)
				{
					Logger logger = new Logger();
					logger.PLog("Exception: " + e.Message + " in " + e.TargetSite);
				
				}
			}

			return Task.CompletedTask;
		}

	}

}
