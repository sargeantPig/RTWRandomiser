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
			int increment = 100/grp.Controls.Count;

			foreach (Control control in grp.Controls)
			{
				CheckBox cb = new CheckBox();
				if (control is CheckBox)
					cb = control as CheckBox;
				else continue;

				if (!cb.Checked)
					continue;

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

					for (int i = 1; i < objs; i++)
					{
						parameters[i] = arguments[i - 1];
					}

					label.Text = m.Name;
					pb.Increment(increment);
					ss.Refresh();

					m.Invoke(null, parameters);
				}

				catch (Exception e)
				{
					Logger logger = new Logger();
					logger.PLog("Exception: " + e.Message + " in " + e.TargetSite);
					logger.DisplayLog();
				}
			}

			return Task.CompletedTask;

		}
		
	}

	public class RandomEDU
	{
		public static void RandomSizes(EDU edu) {

			foreach (Unit unit in edu.units)
				unit.soldier.number = TWRandom.rnd.Next(15, 60 + 1);
		}

		public static void RandomCosts(EDU edu)
		{
			foreach(Unit unit in edu.units)
			{
				unit.cost[1] = TWRandom.rnd.Next(200, 3000); // cost to build 
				unit.cost[2] = (int)(unit.cost[1] * 0.25); // cost to upkeep 
			}
		}

		public static void RandomStats(EDU edu)
		{
			foreach (Unit unit in edu.units)
			{
				if (unit.primaryWeapon.WeaponFlags != WeaponType.WT_no)
				{
					unit.primaryWeapon.attack[0] = TWRandom.rnd.Next(1, 20); // attack factor
					unit.primaryWeapon.attack[1] = TWRandom.rnd.Next(1, 20); // attack charging
				}

				if (unit.secondaryWeapon.WeaponFlags != WeaponType.WT_no)
				{
					unit.secondaryWeapon.attack[0] = TWRandom.rnd.Next(1, 20); // attack factor
					unit.secondaryWeapon.attack[1] = TWRandom.rnd.Next(1, 20); // attack charging
				}

				unit.primaryArmour.stat_pri_armour[0] = TWRandom.rnd.Next(0, 20);
				unit.primaryArmour.stat_pri_armour[1] = TWRandom.rnd.Next(0, 10);
				unit.primaryArmour.stat_pri_armour[2] = TWRandom.rnd.Next(0, 7);

			}

		}

		public static void RandomSounds(EDU edu)
		{
			foreach (Unit unit in edu.units)
			{
				unit.voiceType = TWRandom.VoiceTypes[TWRandom.rnd.Next(TWRandom.VoiceTypes.Length)];
				unit.primaryWeapon.SoundFlags = Functions_General.RandomFlag<SoundType>(TWRandom.rnd);
				unit.primaryArmour.armour_sound = Functions_General.RandomFlag<ArmourSound>(TWRandom.rnd);
			}
		}

		public static void RandomTraining(EDU edu)
		{
			foreach (Unit unit in edu.units)
			{
				unit.mental.training = Functions_General.RandomFlag<Statmental_training>(TWRandom.rnd);
				unit.mental.discipline = Functions_General.RandomFlag<Statmental_discipline>(TWRandom.rnd);
				unit.mental.morale = TWRandom.rnd.Next(0, 15);

			}
		}

		public static void RandomAttributes(EDU edu, object maxAttributes)
		{
			if (maxAttributes is NumericUpDown)
			{
				NumericUpDown maxA = new NumericUpDown();
				maxA = maxAttributes as NumericUpDown;

				foreach (Unit unit in edu.units)
				{
					unit.attributes = Attributes.sea_faring;

					int max = TWRandom.rnd.Next(1, (int)maxA.Value + 1);

					for (int i = 0; i < max; i++)
					{

						Attributes a = Functions_General.RandomFlag<Attributes>(TWRandom.rnd, 1, 17);

						if (!unit.attributes.HasFlag(a))
							unit.attributes |= a;

					}
				}
			}

			else
			{
				edu.PLog("Error: wrong param type");
				edu.DisplayLog();
			}

		}

		public static void RandomGBonus(EDU edu)
		{
			foreach (Unit unit in edu.units)
			{
				unit.ground[0] = TWRandom.rnd.Next(-6, 7);
				unit.ground[1] = TWRandom.rnd.Next(-6, 7);
				unit.ground[2] = TWRandom.rnd.Next(-6, 7);
				unit.ground[3] = TWRandom.rnd.Next(-6, 7);
			}
		}

		public static void RandomOwnership(EDU edu, object maxOwnership)
		{
			if (maxOwnership is NumericUpDown)
			{
				NumericUpDown maxO = new NumericUpDown();
				maxO = maxOwnership as NumericUpDown;

				foreach (Unit unit in edu.units)
				{
					unit.ownership = FactionOwnership.slave;

					for (int i = 0; i < (int)maxO.Value; i++)
					{
						FactionOwnership fo = FactionOwnership.slave;
						bool dup = false;

						while ((fo = Functions_General.RandomFlag<FactionOwnership>(TWRandom.rnd)) == FactionOwnership.slave
							|| (dup = FlagDuplicateCheck(fo, unit.ownership)) == true
							|| (fo = Functions_General.RandomFlag<FactionOwnership>(TWRandom.rnd)) == FactionOwnership.none) ;

						unit.ownership |= fo;

						TWRandom.UnitByFaction.AddKV(fo, unit.type);

					}

				}
			}

			else
			{
				edu.PLog("Error: wrong param type");
				edu.DisplayLog();
			}

		}

		private static bool FlagDuplicateCheck<T>(T newFlag, T currFlags)
		{
			var nf = newFlag as Enum;
			var cf = currFlags as Enum;

			if (cf.HasFlag(nf))
				return true;
			else return false;


		}

	}

	public class RandomDS
	{
		public static void RandomTreasury(Descr_Strat ds)
		{
			foreach (Faction f in ds.factions)
			{
				f.denari = TWRandom.rnd.Next(0, 6000 + 1);
			}
		}

		public static void RandomAI(Descr_Strat ds)
		{
			foreach (Faction f in ds.factions)
			{
				f.ai[0] = TWRandom.GetRandomAIEconomy();
				f.ai[1] = TWRandom.GetRandomAIMilitary();
			}
		}

		public static void UnlockFactions(Descr_Strat ds)
		{
			foreach (string p in ds.unlockableFactions)
			{
				ds.playableFactions.Add(p);
			}

			ds.unlockableFactions.Clear();

			foreach (string p in ds.campaignNonPlayable)
			{
				ds.playableFactions.Add(p);
			}

			ds.campaignNonPlayable.Clear();
		}

		public static void RandomSettlements(Descr_Strat ds, object dr, object maxSettlements)
		{
			if (maxSettlements is NumericUpDown && dr is Descr_Region)
			{

				NumericUpDown maxS = new NumericUpDown();
				maxS = maxSettlements as NumericUpDown;

				Descr_Region tempDR = new Descr_Region(dr as Descr_Region);

				List<Settlement> tempSettlements = new List<Settlement>();

				Action<Faction> AddSettlement = (f) =>
				{
					int index = TWRandom.rnd.Next(tempSettlements.Count());
					Settlement rndS = tempSettlements[index];
					f.settlements.Add(new Settlement(rndS));
					tempSettlements.RemoveAt(index);
				};

				//get all settlements
				foreach (Faction f in ds.factions)
				{
					foreach (Settlement s in f.settlements)
					{
						tempSettlements.Add(new Settlement(s));
					}
				}

				//redistribute settlements
				foreach (Faction f in ds.factions)
				{
					f.settlements.Clear();
					AddSettlement(f); //add first settlement, (this will be the capital)
					int[] capitalCoords = tempDR.GetCityCoords(tempSettlements.First().region);

					for (int i = 0; i < maxS.Value - 1; i++)
					{
						double distance = 10000;
						Settlement cityToAdd = new Settlement();

						foreach (Settlement s in tempSettlements)
						{
							int[] cityCoords = tempDR.GetCityCoords(s.region);
							double tempDis = Functions_General.DistanceTo(cityCoords, capitalCoords);

							if (tempDis < distance)
							{
								distance = tempDis;
								cityToAdd = new Settlement(s);
							}
						}

						AddSettlement(f);
					}

				}
			}
			else
			{
				ds.PLog("Error: wrong param type");
				ds.DisplayLog();
			}





		}

	}

	public static class RandomEDB
	{
		public static void SetRecruitment(this EDB edb)
		{
			foreach (CoreBuilding cb in edb.buildingTrees)
				foreach (Building b in cb.buildings)
					foreach (Brecruit br in b.capability.canRecruit)
						br.requiresFactions = new List<string>( TWRandom.UnitByFaction.GetFactions(br.name));
		}

	}
}
