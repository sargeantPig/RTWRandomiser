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
using System.IO;
using RTWR_RTWLIB.Forms;
using RTWR_RTWLIB.Data;
using RTWLib.Functions.EDU;
using RTWRandLib.Data;

namespace RTWR_RTWLIB.Randomiser
{
	public static class TWRandom
	{
		public static Random rnd = new Random();
		public static string[] AIMilitary = { "napoleon", "caesar", "genghis", "mao", "stalin", "smith", "henry" };
		public static string[] AIEconomy = { "comfortable", "balanced", "bureacrat", "fortified", "religous", "trade", "sailor" };
		public static string[] VoiceTypes = { "Light_1", "Medium_1", "Heavy_1", "General_1", "Female_1" };
		public static string[] M2TWVoiceTypes = { "Light", "Heavy", "General" };
		public static object[] SoundTypes = { SoundType.axe, SoundType.knife, SoundType.mace, SoundType.spear, SoundType.sword};
		public static Dictionary<string, List<string>> UnitByFaction = new Dictionary<string, List<string>>();
		public static Options advancedOptions { get; set; }
		public static string[] factionList { get; set; }
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
		public static void AddKV(this Dictionary<string, List<string>> dic, string key, string unit)
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
		public static List<string> GetFactions(this Dictionary<string, List<string>> dic, string unit)
		{
			LookUpTables lt = new LookUpTables();

			List<string> fo = new List<string>();

			foreach (KeyValuePair<string, List<string>> kv in dic)
			{
				if (kv.Value.Contains(unit))
				{
					fo.Add(kv.Key);
				}
			}
			return fo;
		}

	}

	public static class Randomise
	{
		public static void RandomiseFile<T, A>(this A file, GroupBox grp, ToolStripLabel label, StatusStrip ss, ToolStripProgressBar pb, object[] arguments)
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

			checkBoxes.Sort(new Comparison<CheckBox>(LibFuncs.CompareNameEnd));

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
							else if(o.GetType().BaseType == type && type != typeof(NumericUpDown))
								parameters[index] = o;
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
					logger.ExceptionLog(e);
					logger.PLog("Exception: " + e.Message + " in " + e.TargetSite);
				
				}
			}
		}

		public static void ApplyUnitInfoFix(this EDU edu)
		{
			foreach (Unit unit in edu.units)
			{
				unit.attributes |= Attributes.mercenary_unit;
			}
		}


	}

}
