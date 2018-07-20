using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomiser
{
    public static class TypeLists
    {
        public static List<MissleType>  MissleListInfantry = new List<MissleType>();
    }

    public static class Randomise
    {

		public static List<Unit> highTierUnits = new List<Unit>();
		public static List<Unit> midTierUnits = new List<Unit>();
		public static List<Unit> lowTierUnits = new List<Unit>();


		static void SetOwnership(Unit unit)
		{
			int index = RandomiseData.UnitsFaction.FindIndex(x => x.dicName == unit.type);
			bool isSlave = false;

			dynamic ownership = FactionOwnership.slave;

			if (Data.isRTWMode)
				ownership = FactionOwnership.slave;

			if (Data.isM2TWMode)
				ownership = M2TWFactionOwnership.slave;

			if (unit.ownership.HasFlag(FactionOwnership.slave))
			{
				isSlave = true;

			}


			if (unit.M2TWOwnership.HasFlag(M2TWFactionOwnership.slave))
			{
				isSlave = true;
			}

			if (index > -1)
			{

				foreach (string str in RandomiseData.UnitsFaction[index].factions)
				{
					if (Data.isRTWMode)
						unit.ownership |= enumsToStrings.StringToFaction(str);
					else if (Data.isM2TWMode)
						unit.M2TWOwnership |= enumsToStrings.M2TWStringToFaction(str);

				}

				if (Data.isRTWMode)
					unit.ownership |= FactionOwnership.slave;
				else if (Data.isM2TWMode)
					unit.M2TWOwnership |= M2TWFactionOwnership.slave;
			}
		}

		static void SetEDBOwnership(Brecruit br, ref List<UnitFaction> uf)
		{
			int index = uf.FindIndex(x => x.dicName == br.name);
			int index2 = br.requiresFactions.FindIndex(x => x == "slave");

			if (index == -1 && index2 == -1)
			{

				UnitFaction unit = new UnitFaction();
				unit.dicName = br.name;
				dynamic prev = FactionOwnership.none;

				if(Data.isRTWMode)
					prev = FactionOwnership.none;
				else if(Data.isM2TWMode)
					prev = M2TWFactionOwnership.none;


				int rnd = Data.rnd.Next(1, RandomiseData.OwnershipPerUnit);

				for (int i = 0; i < rnd; i++)
				{
					dynamic fo = Functions.RandomFlag<FactionOwnership>();

					if (Data.isRTWMode)
					{
						fo = Functions.RandomFlag<FactionOwnership>();
						while (fo == FactionOwnership.slave || fo == FactionOwnership.none || fo == prev)
						{
							fo = Functions.RandomFlag<FactionOwnership>();
						}
					}
					else if (Data.isM2TWMode)
					{
						fo = Functions.RandomFlag<M2TWFactionOwnership>();
						while (fo == M2TWFactionOwnership.slave || fo == M2TWFactionOwnership.none || fo == prev)
						{
							fo = Functions.RandomFlag<M2TWFactionOwnership>();
						}
					}

					prev = fo;
					string faction = enumsToStrings.FactionToString(fo);
					unit.factions.Add(faction);
				}
				uf.Add(new UnitFaction(unit));
				RandomiseData.UnitsFaction.Add(new UnitFaction(unit));
			}

		}

		public static void RandomiseEdu()
        {
           

			if (RandomiseData.unitSizes)
				UnitSizeRandomise();

			if (RandomiseData.stats)
				StatsRandomise();

			if (RandomiseData.rndTraining)
				TrainingRandomise();

			if (RandomiseData.rndAttri)
				AttributeRandomise();

			if (RandomiseData.rndGroundBonus)
				GroundBonusRandomise();

			if (RandomiseData.rndRosters)
			{
				

				if (RandomiseData.balanced)
					BalancedEDURandomise();

				else 
					UnitFactionRandomise();


			}
			if (RandomiseData.reasonableStats)
			{

			}

			if (RandomiseData.rndSounds)
				SoundsRandomise();

			if (RandomiseData.rndCost)
				costRandomise();


		}

		public static void RandomiseEDB()
        {
			Data.ModdedUnits = new List<Unit>(Data.Vanunits);

			if (RandomiseData.rndRosters)
			{
				AssignUnitTiers();

				if (RandomiseData.balanced)
					BalancedRosterRandomise();
				else 
					RosterRandomise();
			}
        }

		static void BalancedEDURandomise()
		{
			foreach (Unit unit in Data.ModdedUnits)
			{
				unit.ownership = FactionOwnership.slave;
				
				foreach (KeyValuePair<FactionOwnership, List<Unit>> kv in FactionRosters.RTWrosters)
				{
					foreach (Unit kvu in kv.Value)
					{
						if (kvu.dictionary == unit.dictionary)
						{
							Console.WriteLine(unit.dictionary + " -> " + enumsToStrings.SpecialFactionToString(kv.Key));
							unit.ownership |= kv.Key;
						}
					}
				}
			}
		}

		static void BalancedEDBRandomise()
		{
			foreach (coreBuilding cb in Data.EDBData.buildingTrees)
			{
				foreach (Building building in cb.buildings)
				{
					foreach (Brecruit br in building.capability.canRecruit)
					{
						br.requiresFactions.Clear();
						foreach (KeyValuePair<FactionOwnership, List<Unit>> kv in FactionRosters.RTWrosters)
						{
							foreach (Unit unit in kv.Value)
							{
								if (unit.type == br.name)
								{
									string[] faction = enumsToStrings.SpecialFactionToString(kv.Key);
									
									Functions.ListUniqueAdd<string>(faction, ref br.requiresFactions);	
								}
							}
						}
					}
				}
			}



		}

		static void BalancedRosterRandomise()
		{
			//go through each faction, add units to a list, add the faction/units to dictionary

			List<Unit> factionUnits = new List<Unit>();
			List<Unit> tempHigh = new List<Unit>();
			List<Unit> tempMid = new List<Unit>();
			List<Unit> tempLow = new List<Unit>();
			int lowTierCount = (lowTierUnits.Count() / FactionRosters.RTWrosters.Count() +1);
			int midTierCount = (midTierUnits.Count() / FactionRosters.RTWrosters.Count() - 2);
			int highTierCount = (highTierUnits.Count() / FactionRosters.RTWrosters.Count() + 1) * 2;

			Console.WriteLine(Convert.ToInt32(highTierUnits.Count() + midTierUnits.Count() + lowTierUnits.Count()));
			foreach (KeyValuePair<FactionOwnership, List<Unit>> faction in FactionRosters.RTWrosters)
			{
				while (faction.Value.Count() < 25)
				{
					for (int i = 0; i < lowTierCount; i++)
					{

						if (lowTierUnits.Count() == 0)
						{
							lowTierUnits.AddRange(tempLow);
							tempLow.Clear();
						}

						int randomIndex = Data.rnd.Next(lowTierUnits.Count());
						factionUnits.Add(lowTierUnits[randomIndex]);
						faction.Value.Add(lowTierUnits[randomIndex]);

						tempLow.Add(lowTierUnits[randomIndex]);
						lowTierUnits.RemoveAt(randomIndex);

					}

					for (int i = 0; i < midTierCount; i++)
					{
						if (midTierUnits.Count() == 0)
						{
							midTierUnits.AddRange(tempMid);
							tempMid.Clear();
						}

						int randomIndex = Data.rnd.Next(midTierUnits.Count());

						factionUnits.Add(midTierUnits[randomIndex]);
						faction.Value.Add(midTierUnits[randomIndex]);

						tempMid.Add(midTierUnits[randomIndex]);
						midTierUnits.RemoveAt(randomIndex);

					}

					for (int i = 0; i < highTierCount; i++)
					{
						if (highTierUnits.Count() == 0)
						{
							highTierUnits.AddRange(tempHigh);
							tempHigh.Clear();
						}

						int randomIndex = Data.rnd.Next(highTierUnits.Count());

						factionUnits.Add(highTierUnits[Data.rnd.Next(highTierUnits.Count())]);
						faction.Value.Add(highTierUnits[Data.rnd.Next(highTierUnits.Count())]);

						tempHigh.Add(highTierUnits[randomIndex]);
						highTierUnits.RemoveAt(randomIndex);

					}
				}

			}

			if (highTierUnits.Count() == 0)
			{
				highTierUnits.AddRange(tempHigh);
				tempHigh.Clear();
			}

			if (midTierUnits.Count() == 0)
			{
				midTierUnits.AddRange(tempMid);
				tempMid.Clear();
			}

			if (lowTierUnits.Count() == 0)
			{
				lowTierUnits.AddRange(tempLow);
				tempLow.Clear();
			}

			BalancedEDBRandomise();

		}

        static void RosterRandomise()
        {
            //get all unique recruits into a list
            List<UnitFaction> uf = new List<UnitFaction>();

            foreach (coreBuilding cb in Data.EDBData.buildingTrees)
            {
                foreach (Building building in cb.buildings)
                {
                    foreach (Brecruit br in building.capability.canRecruit)
                    {
						SetEDBOwnership(br, ref uf);
                    }
                }
            }

            //set factions according to unique entries

            foreach (coreBuilding cb in Data.EDBData.buildingTrees)
            {
                foreach (Building building in cb.buildings)
                {
                    foreach (Brecruit br in building.capability.canRecruit)
                    {
                        int index = uf.FindIndex(x => x.dicName == br.name);
                        int index2 = br.requiresFactions.FindIndex(x => x == "slave");

                        if (index2 == -1)
                        {
                            br.requiresFactions.Clear();

                            foreach (string str in uf[index].factions)
                            {
                                br.requiresFactions.Add(str);
                            }

                        }
                    }
                }

            }


        }

        static void UnitFactionRandomise()
        {
            foreach (Unit unit in Data.ModdedUnits)
            {
				SetOwnership(unit);
            }

        }

        static void GroundBonusRandomise()
        {
            foreach (Unit unit in Data.ModdedUnits)
            {
                unit.ground[0] = Data.rnd.Next(-6, 7);
                unit.ground[1] = Data.rnd.Next(-6, 7);
                unit.ground[2] = Data.rnd.Next(-6, 7);
                unit.ground[3] = Data.rnd.Next(-6, 7);


            }

        }

        static void UnitSizeRandomise()
        {
            foreach (Unit unit in Data.ModdedUnits)
            {
                unit.soldier.number = Data.rnd.Next(15, 60);
            }

        }

        static void StatsRandomise()
        {
            foreach (Unit unit in Data.ModdedUnits)
            {
                if (unit.primaryWeapon.WeaponFlags != WeaponType.WT_no)
                {
                    unit.primaryWeapon.attack[0] = Data.rnd.Next(1, 20); // attack factor
                    unit.primaryWeapon.attack[1] = Data.rnd.Next(1, 20); // attack charging
                }

                if (unit.secondaryWeapon.WeaponFlags != WeaponType.WT_no)
                {
                    unit.secondaryWeapon.attack[0] = Data.rnd.Next(1, 20); // attack factor
                    unit.secondaryWeapon.attack[1] = Data.rnd.Next(1, 20); // attack charging
                }

                unit.primaryArmour.stat_pri_armour[0] = Data.rnd.Next(0, 20);
                unit.primaryArmour.stat_pri_armour[1] = Data.rnd.Next(0, 10);
                unit.primaryArmour.stat_pri_armour[2] = Data.rnd.Next(0, 7);

            }
        }

        static void TrainingRandomise()
        {
            foreach (Unit unit in Data.ModdedUnits)
            {
                unit.mental.training = Functions.RandomFlag<statmental_training>();
                unit.mental.discipline = Functions.RandomFlag<statmental_discipline>();
                unit.mental.morale = Data.rnd.Next(0, 15);

            }


        }

        static void FormationRandomise()
        {
            foreach (Unit unit in Data.ModdedUnits)
            {
                if (Data.isRTWMode)
                {
                    if (!unit.priAttri.HasFlag(stat_pri_attr.long_pike) || !unit.priAttri.HasFlag(stat_pri_attr.short_pike) || !unit.priAttri.HasFlag(stat_pri_attr.pa_spear))
                    {
                        unit.formation.FormationFlags = Functions.RandomFlag<FormationTypes>(0, 3);

                        if (unit.formation.FormationFlags != FormationTypes.Formation_Phalanx)
                            unit.formation.FormationFlags |= Functions.RandomFlag<FormationTypes>(4, 7);

                    }

                }
                if (Data.isM2TWMode)
                {
                    if (!unit.priAttri.HasFlag(stat_pri_attr.long_pike) || !unit.priAttri.HasFlag(stat_pri_attr.short_pike) || !unit.priAttri.HasFlag(stat_pri_attr.pa_spear))
                    {
                        unit.formation.FormationFlags = Functions.RandomFlag<FormationTypes>(0, 3);

                        if (unit.formation.FormationFlags != FormationTypes.Formation_Phalanx)
                            unit.formation.FormationFlags |= Functions.RandomFlag<FormationTypes>(4, 7);

                    }

                }

            }
        }

        static void AttributeRandomise()
        {
            foreach (Unit unit in Data.ModdedUnits)
            {

                if (Data.isRTWMode)
                {
                    unit.attributes = Attributes.sea_faring;

                    int max = Data.rnd.Next(1, RandomiseData.maxAttri + 1);

                    for (int i = 0; i < max; i++)
                    {

                        Attributes a = Functions.RandomFlag<Attributes>(1, 17);

                        if (!unit.attributes.HasFlag(a))
                            unit.attributes |= a;

                    }

                }

                else if (Data.isM2TWMode)
                {
                    unit.M2TWAttributes = M2TWAttributes.sea_faring;

                    int max = Data.rnd.Next(1, RandomiseData.maxAttri + 1);

                    for (int i = 0; i < max; i++)
                    {

                        M2TWAttributes a = Functions.RandomFlag<M2TWAttributes>(1, 17);

                        if (!unit.M2TWAttributes.HasFlag(a))
                            unit.M2TWAttributes |= a;

                    }

                }

            }

        }

        static void SoundsRandomise()
        {
            foreach(Unit unit in Data.ModdedUnits)
            {
                if (Data.isRTWMode)
                {
                    unit.voiceType = RandomiseData.VoiceTypes[Data.rnd.Next(RandomiseData.VoiceTypes.Length)];
                    unit.primaryWeapon.SoundFlags = Functions.RandomFlag<SoundType>();
                    unit.primaryArmour.armour_sound = Functions.RandomFlag<ArmourSound>();
                }
                if (Data.isM2TWMode)
                {
                    unit.voiceType = RandomiseData.VoiceTypes[Data.rnd.Next(RandomiseData.M2TWVoiceTypes.Length)];
                    unit.primaryWeapon.SoundFlags = Functions.RandomFlag<SoundType>();
                    unit.primaryArmour.armour_sound = Functions.RandomFlag<ArmourSound>();
                }

            }
        }

        static void costRandomise()
        {
            foreach (Unit unit in Data.ModdedUnits)
            {
                if (Data.isRTWMode)
                {
                    unit.cost[1] = Data.rnd.Next(200, 3000); // cost to build 
                    unit.cost[2] = (int)(unit.cost[1] * 0.25); // cost to upkeep 
                }
                else if (Data.isM2TWMode)
                {
                    unit.M2TWcost[1] = Data.rnd.Next(200, 3000); // cost to build 
                    unit.M2TWcost[2] = (int)(unit.cost[1] * 0.25); // cost to upkeep 

                }
            }
        }

		static void AssignUnitTiers()
		{
			float totalPoints = 0;
			float maxPoints = 0;
			float lowestPoints = 100;
			float averagePoints = 0;

			//sum up point values for each unit
			foreach (Unit unit in Data.ModdedUnits)
			{
				unit.unitPointValue =
					unit.primaryWeapon.attack[0] +
					unit.primaryWeapon.attack[1] +
					unit.primaryArmour.stat_pri_armour[0] +
					unit.primaryArmour.stat_pri_armour[1] +
					unit.secondaryWeapon.attack[0] +
					unit.secondaryWeapon.attack[1] +
					unit.heatlh[0];

				if (unit.unitPointValue > maxPoints)
					maxPoints = unit.unitPointValue;
				if (unit.unitPointValue < lowestPoints)
					lowestPoints = unit.unitPointValue;

				totalPoints += unit.unitPointValue;

			}

			averagePoints = totalPoints / Data.ModdedUnits.Count();


			float differenceHighMid = maxPoints - averagePoints;
			float differenceMidLow = averagePoints - lowestPoints;
			//place units in tiers that are dynamically created using the average points.
			foreach (Unit unit in Data.ModdedUnits)
			{
				if (unit.unitPointValue > (averagePoints + (differenceHighMid / 2)))
					highTierUnits.Add(unit);
				else if (unit.unitPointValue > averagePoints || unit.unitPointValue > averagePoints - (differenceMidLow / 2))
					Functions.ListUniqueAdd<Unit>(new Unit[] { unit }, ref midTierUnits);
				else
					lowTierUnits.Add(unit);
			}

		}

    }
}
