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
            foreach (Unit unit in Data.units)
            {
                if (RandomiseData.unitSizes)
                    UnitSizeRandomise();

                if (RandomiseData.stats)
                    StatsRandomise();

                if (RandomiseData.rndTraining)
                    TrainingRandomise();

                if (RandomiseData.rndAttri)
                    AttributeRandomise();

                if (RandomiseData.reasonableStats)
                {

                }

                if (RandomiseData.rndSounds)
                    SoundsRandomise();

                if (RandomiseData.rndCost)
                    costRandomise();

            }
        }

        static void UnitSizeRandomise()
        {
            foreach (Unit unit in Data.units)
            {
                unit.soldier.number = Data.rnd.Next(15, 60);
            }

        }

        static void StatsRandomise()
        {
            foreach (Unit unit in Data.units)
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
            foreach (Unit unit in Data.units)
            {
                unit.mental.training = Functions.RandomFlag<statmental_training>();
                unit.mental.discipline = Functions.RandomFlag<statmental_discipline>();
                unit.mental.morale = Data.rnd.Next(0, 15);

            }


        }

        static void FormationRandomise()
        {
            foreach (Unit unit in Data.units)
            {
                if (!unit.priAttri.HasFlag(stat_pri_attr.long_pike) || !unit.priAttri.HasFlag(stat_pri_attr.short_pike) || !unit.priAttri.HasFlag(stat_pri_attr.pa_spear))
                {
                    unit.formation.FormationFlags = Functions.RandomFlag<FormationTypes>(0, 3);

                    if (unit.formation.FormationFlags != FormationTypes.Formation_Phalanx)
                        unit.formation.FormationFlags |= Functions.RandomFlag<FormationTypes>(4, 7);

                }
            }
        }

        static void AttributeRandomise()
        {
            foreach (Unit unit in Data.units)
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

        }
        static void SoundsRandomise()
        {
            foreach(Unit unit in Data.units)
            {
                unit.voiceType = RandomiseData.VoiceTypes[Data.rnd.Next(RandomiseData.VoiceTypes.Length)];
                unit.primaryWeapon.SoundFlags = Functions.RandomFlag<SoundType>();
                unit.primaryArmour.armour_sound = Functions.RandomFlag<ArmourSound>();
            }
        }

        static void costRandomise()
        {
            foreach (Unit unit in Data.units)
            {
                unit.cost[1] = Data.rnd.Next(200, 3000); // cost to build 
                unit.cost[2] = (int)(unit.cost[1] * 0.25); // cost to upkeep 
            }
        }

    }
}
