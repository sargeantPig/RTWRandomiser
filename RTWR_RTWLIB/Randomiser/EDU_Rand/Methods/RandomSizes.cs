﻿using RTWLib.Functions;
using RTWLib.Functions.EDU;
using RTWLib.Objects;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomEDU
    {
        public static void RandomSizes(EDU edu)
        {

            foreach (Unit unit in edu.units)
                unit.soldier.number = TWRandom.rnd.Next(15, 40 + 1);
        }
    }
}
