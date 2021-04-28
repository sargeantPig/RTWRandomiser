using RTWLib.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RTWR_RTWLIB.Randomiser.DR.Methods
{
    public static partial class RandomDR
    {
        public static void RandomFarmLevel(this Descr_Region dr)
        {
            foreach (var reg in dr.regions)
            {
                reg.Value.farmLevel = TWRandom.rnd.Next(0, 11);
            }
        }

        public static void EqualiseFFarmLevels(this Descr_Region dr, int value = 0)
        {
            foreach (var reg in dr.regions)
            {
                reg.Value.farmLevel = value;
            }
        }
    }
}
