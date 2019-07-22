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
	public class RandomEDU
	{
		public static void RandomSizes(EDU edu)
		{

			foreach (Unit unit in edu.units)
				unit.soldier.number = TWRandom.rnd.Next(15, 60 + 1);
		}

		public static void RandomCosts(EDU edu)
		{
			foreach (Unit unit in edu.units)
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

		public static void RandomAttributes(EDU edu, NumericUpDown maxAttributes)
		{
			if (maxAttributes is NumericUpDown)
			{
				NumericUpDown maxA = new NumericUpDown();
				maxA = maxAttributes as NumericUpDown;

				foreach (Unit unit in edu.units)
				{
					unit.attributes = Attributes.sea_faring;
                    unit.attributes |= Attributes.mercenary_unit;

					int max = TWRandom.rnd.Next(1, (int)maxA.Value + 1);

					for (int i = 0; i < max; i++)
					{
						Attributes a = Functions_General.RandomFlag<Attributes>(TWRandom.rnd, 1, 17);

						if (!unit.attributes.HasFlag(a) && a != Attributes.general_unit && a != Attributes.general_unit_upgrade)
							unit.attributes |= a;
					}
				}
			}

			else
			{
				edu.PLog("Error: wrong param type");
				edu.DisplayLogExit();
			}

			FactionOwnership fo = FactionOwnership.romans_brutii | FactionOwnership.romans_scipii | FactionOwnership.romans_julii | FactionOwnership.seleucid | FactionOwnership.egypt | FactionOwnership.carthage | FactionOwnership.parthia
			| FactionOwnership.gauls | FactionOwnership.germans | FactionOwnership.britons | FactionOwnership.greek_cities | FactionOwnership.macedon | FactionOwnership.pontus | FactionOwnership.armenia | FactionOwnership.dacia | FactionOwnership.numidia | FactionOwnership.scythia |
			FactionOwnership.spain | FactionOwnership.thrace | FactionOwnership.slave;
			edu.units.Shuffle(TWRandom.rnd);
			foreach (Unit unit in edu.units)
			{
				if ((unit.ownership & fo) != 0 && !unit.type.Contains(new List<string> { "peasant", "navy", "boat" }))
				{
					unit.attributes |= Attributes.general_unit;
					fo = fo & ~unit.ownership;
				}



			}


			fo = FactionOwnership.romans_brutii | FactionOwnership.romans_scipii | FactionOwnership.romans_julii | FactionOwnership.seleucid | FactionOwnership.egypt | FactionOwnership.carthage | FactionOwnership.parthia
			| FactionOwnership.gauls | FactionOwnership.germans | FactionOwnership.britons | FactionOwnership.greek_cities | FactionOwnership.macedon | FactionOwnership.pontus | FactionOwnership.armenia | FactionOwnership.dacia | FactionOwnership.numidia | FactionOwnership.scythia |
			FactionOwnership.spain | FactionOwnership.thrace | FactionOwnership.slave;
			edu.units.Shuffle(TWRandom.rnd);
			foreach (Unit unit in edu.units)
			{
				if ((unit.ownership & fo) != 0 && !unit.attributes.HasFlag(Attributes.general_unit) && !unit.type.Contains(new List<string> { "peasant", "navy", "boat" }))
				{
					unit.attributes |= Attributes.general_unit_upgrade;
					fo = fo & ~unit.ownership;
				}
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

		public static void RandomOwnership(EDU edu, NumericUpDown maxOwnership)
		{
			if (maxOwnership is NumericUpDown)
			{
				NumericUpDown maxO = new NumericUpDown();
				maxO = maxOwnership as NumericUpDown;

				foreach (Unit unit in edu.units)
				{
					unit.ownership = FactionOwnership.slave;

					for (int i = 0; i < (int)maxO.Value - 1; i++)
					{
						FactionOwnership fo = FactionOwnership.slave;
						bool dup = false;

						while ((fo = Functions_General.RandomFlag<FactionOwnership>(TWRandom.rnd)) == FactionOwnership.slave
							|| (dup = FlagDuplicateCheck(fo, unit.ownership)) == true
							|| (fo = Functions_General.RandomFlag<FactionOwnership>(TWRandom.rnd)) == FactionOwnership.none)
						{

						}

						unit.ownership |= fo;

						TWRandom.UnitByFaction.AddKV(fo, unit.type);

					}

				}
			}

			else
			{
				edu.PLog("Error: wrong param type");
				edu.DisplayLogExit();
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
}
