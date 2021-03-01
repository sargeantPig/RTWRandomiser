﻿using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Objects;
using RTWLib.Functions.EDU;
using System.Collections.Generic;
using System.Linq;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomEDU
    {
		public static void RandomSounds(EDU edu)
		{
			TWRandom.RefreshRndSeed();
			//gather sounds available
			foreach (Unit unit in edu.units)
			{
				unit.voice = TWRandom.VoiceTypes[TWRandom.rnd.Next(TWRandom.VoiceTypes.Length)];
				unit.priWep.SoundFlags = ((SoundType)TWRandom.SoundTypes.GetRandomItemFromArray(TWRandom.rnd)).ToString();
				unit.priArm.armSound = LibFuncs.RandomFlag<ArmourSound>(TWRandom.rnd);
			}
		}
	}
}