using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Functions.EDU;
using RTWLib.Objects;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomEDU
    {
        public static void RandomSizes(EDU edu)
        {
            int maxSoldier = 60;

            TWRandom.RefreshRndSeed();
            foreach (Unit unit in edu.units)
            {
                if (unit.category == "non_combatant")
                    continue;

                if (unit.attributes.HasFlag(Attributes.general_unit) || unit.attributes.HasFlag(Attributes.general_unit_upgrade))
                    maxSoldier = 31;
                else maxSoldier = 60;
                int maxpercent = (maxSoldier / unit.soldier.number) * 1000;
                int minpercent = (int)(LibFuncs.SafeDivide(6, unit.soldier.number) * 1000);

                float randPerc = TWRandom.rnd.RandPercent(minpercent, maxpercent);
                
                unit.soldier.number = (int)(unit.soldier.number * randPerc);
                unit.soldier.number = LibFuncs.Clamp(unit.soldier.number, 6, 60);

                if (unit.category == "handler")
                    unit.soldier.extras = unit.soldier.number * 3;

                if (unit.mount == null)
                    continue;
                if (unit.mount.Contains("chariot"))
                {
                    while (unit.soldier.number % 3 != 0)
                    {
                        if (unit.soldier.number < 60)
                            unit.soldier.number++;
                        else unit.soldier.number--;
                    }

                    unit.soldier.extras = unit.soldier.number / 3;
                }
            }
        }
    }
}
