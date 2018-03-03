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
                {
                    UnitSizeRandomise();
                }

                if (RandomiseData.stats)
                {
                    StatsRandomise();
                }

                if (RandomiseData.reasonableStats)
                {//stats here
                }

                if (RandomiseData.rndSounds)
                { //sounds here

                }

                if (RandomiseData.rndCost)
                { //costs here 
                    costRandomise();
                }

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
                /*if(unit.primaryWeapon.missletypeFlags != MissleType.MT_no)
                {
                    Array values = Enum.GetValues(typeof(MissleType));
                    unit.primaryWeapon.missletypeFlags = (MissleType)values.GetValue(Data.rnd.Next(values.Length));
                }*/

                unit.primaryWeapon.attack[0] = Data.rnd.Next(1, 20); // attack factor
                unit.primaryWeapon.attack[1] = Data.rnd.Next(1, 20); // attack charging
                unit.secondaryWeapon.attack[0] = Data.rnd.Next(1, 20); // attack factor
                unit.secondaryWeapon.attack[1] = Data.rnd.Next(1, 20); // attack charging

                Array disciplineVals = Enum.GetValues(typeof(statmental_discipline));
                unit.mental.discipline = (statmental_discipline)disciplineVals.GetValue(Data.rnd.Next(disciplineVals.Length));
                unit.mental.morale = Data.rnd.Next(0, 15);

                Array trainVals = Enum.GetValues(typeof(statmental_training));
                unit.mental.training = (statmental_training)trainVals.GetValue(Data.rnd.Next(trainVals.Length));

                unit.primaryArmour.stat_pri_armour[0] = Data.rnd.Next(0, 20);
                unit.primaryArmour.stat_pri_armour[1] = Data.rnd.Next(0, 10);
                unit.primaryArmour.stat_pri_armour[2] = Data.rnd.Next(0, 7);

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
