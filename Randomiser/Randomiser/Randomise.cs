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
        public static void RandomiseEdu()
        {
            Data.ModdedUnits = new List<Unit>(Data.Vanunits);

            foreach (Unit unit in Data.ModdedUnits)
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
                    UnitFactionRandmise();

                if (RandomiseData.reasonableStats)
                {

                }

                if (RandomiseData.rndSounds)
                    SoundsRandomise();

                if (RandomiseData.rndCost)
                    costRandomise();

            }
        }

        public static void RandomiseEDB()
        {
            if (RandomiseData.rndRosters)
                RosterRandomise();


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
                        if (Data.isRTWMode)
                        {

                            int index = uf.FindIndex(x => x.dicName == br.name);
                            int index2 = br.requiresFactions.FindIndex(x => x == "slave");

                            if (index == -1 && index2 == -1)
                            {

                                UnitFaction unit = new UnitFaction();
                                unit.dicName = br.name;
                                FactionOwnership prev = FactionOwnership.none;
                                int rnd = Data.rnd.Next(1, RandomiseData.OwnershipPerUnit);

                                for (int i = 0; i < rnd; i++)
                                {
                                    FactionOwnership fo = Functions.RandomFlag<FactionOwnership>();
                                    while (fo == FactionOwnership.slave || fo == FactionOwnership.none || fo == prev)
                                    {

                                        fo = Functions.RandomFlag<FactionOwnership>();

                                    }

                                    prev = fo;
                                    string faction = enumsToStrings.FactionToString(fo);
                                    unit.factions.Add(faction);
                                }
                                uf.Add(new UnitFaction(unit));
                                RandomiseData.UnitsFaction.Add(new UnitFaction(unit));
                            }

                        }

                        else if (Data.isM2TWMode)
                        {
                            int index = uf.FindIndex(x => x.dicName == br.name);
                            int index2 = br.requiresFactions.FindIndex(x => x == "slave");

                            if (index == -1 && index2 == -1)
                            {

                                UnitFaction unit = new UnitFaction();
                                unit.dicName = br.name;
                                M2TWFactionOwnership prev = M2TWFactionOwnership.none;
                                int rnd = Data.rnd.Next(1, RandomiseData.OwnershipPerUnit);

                                for (int i = 0; i < rnd; i++)
                                {
                                    M2TWFactionOwnership fo = Functions.RandomFlag<M2TWFactionOwnership>();
                                    while (fo == M2TWFactionOwnership.slave || fo == M2TWFactionOwnership.none || fo == prev)
                                    {

                                        fo = Functions.RandomFlag<M2TWFactionOwnership>();

                                    }

                                    prev = fo;
                                    string faction = enumsToStrings.M2TWFactionToString(fo);
                                    unit.factions.Add(faction);
                                }
                                uf.Add(new UnitFaction(unit));
                                RandomiseData.UnitsFaction.Add(new UnitFaction(unit));
                            }


                        }
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

        static void UnitFactionRandmise()
        {
            foreach (Unit unit in Data.ModdedUnits)
            {
                if (Data.isRTWMode)
                {

                    int index = RandomiseData.UnitsFaction.FindIndex(x => x.dicName == unit.type);
                    bool isSlave = false;

                    if (unit.ownership.HasFlag(FactionOwnership.slave))
                    {
                        isSlave = true;

                    }

                    if (index > -1)
                    {

                        foreach (string str in RandomiseData.UnitsFaction[index].factions)
                        {
                            unit.ownership |= enumsToStrings.StringToFaction(str);

                        }
                        unit.ownership |= FactionOwnership.slave;
                    }

                }

                if (Data.isM2TWMode)
                {

                    int index = RandomiseData.UnitsFaction.FindIndex(x => x.dicName == unit.type);
                    bool isSlave = false;

                    if (unit.M2TWOwnership.HasFlag(M2TWFactionOwnership.slave))
                    {
                        isSlave = true;

                    }

                    if (index > -1)
                    {

                        foreach (string str in RandomiseData.UnitsFaction[index].factions)
                        {
                            unit.M2TWOwnership |= enumsToStrings.M2TWStringToFaction(str);

                        }
                        unit.M2TWOwnership |= M2TWFactionOwnership.slave;
                    }

                }

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

    }
}
