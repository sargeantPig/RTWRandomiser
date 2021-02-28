using RTWLib.Functions;
using RTWLib.Functions.EDU;
using RTWLib.Objects;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomEDU
    {
        public static void RandomSizes(EDU edu)
        {  
            foreach (Unit unit in edu.units)
            {
                if (unit.category == "non_combatant")
                    continue;

                int maxpercent = (60 / unit.soldier.number) * 1000;
                int minpercent = (int)(LibFuncs.SafeDivide(6, unit.soldier.number) * 1000);

                float randPerc = TWRandom.rnd.RandPercent(minpercent, maxpercent);

                if (minpercent > maxpercent)
                {
                    int i = 0;
                }

                if (unit.category == "handler")
                {
                    unit.soldier.extras = (int)(unit.soldier.extras * randPerc);
                }
                unit.soldier.number = (int)(unit.soldier.number * randPerc);
            }
        }
    }
}
