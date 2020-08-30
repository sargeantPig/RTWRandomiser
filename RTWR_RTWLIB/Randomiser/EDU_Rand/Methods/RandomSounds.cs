using RTWLib.Data;
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
			//gather sounds available
			foreach (Unit unit in edu.units)
			{
				unit.voiceType = TWRandom.VoiceTypes[TWRandom.rnd.Next(TWRandom.VoiceTypes.Length)];
				unit.primaryWeapon.SoundFlags = ((SoundType)TWRandom.SoundTypes.GetRandomItemFromArray(TWRandom.rnd)).ToString();
				unit.primaryArmour.armour_sound = Functions_General.RandomFlag<ArmourSound>(TWRandom.rnd);
			}
		}
	}
}