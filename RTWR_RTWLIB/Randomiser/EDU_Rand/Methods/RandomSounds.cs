using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Objects;
using RTWLib.Functions.EDU;
using System.Collections.Generic;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomEDU
    {
		public static void RandomSounds(EDU edu)
		{
			//gather sounds available
			List<object> sounds = new List<object>();
			foreach (Unit unit in edu.units)
			{
				if (!sounds.Contains(unit.primaryWeapon.SoundFlags))
					sounds.Add(unit.primaryWeapon.SoundFlags);
			}


			foreach (Unit unit in edu.units)
			{
				unit.voiceType = TWRandom.VoiceTypes[TWRandom.rnd.Next(TWRandom.VoiceTypes.Length)];
				unit.primaryWeapon.SoundFlags = (string)sounds.GetRandomItemFromList(TWRandom.rnd);
				unit.primaryArmour.armour_sound = Functions_General.RandomFlag<ArmourSound>(TWRandom.rnd);
			}
		}
	}
}