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
                if(unit.primaryWeapon.missletypeFlags != MissleType.MT_no)
                {

                }

            }
        }
    }
}
