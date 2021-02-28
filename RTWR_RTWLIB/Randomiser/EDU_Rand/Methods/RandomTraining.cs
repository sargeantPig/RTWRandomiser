using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Functions.EDU;
using RTWLib.Objects;
using System.Runtime.CompilerServices;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomEDU
    {
		public static void RandomTraining(EDU edu)
		{
			foreach (Unit unit in edu.units)
			{
				unit.mental.training = LibFuncs.RandomFlag<Statmental_training>(TWRandom.rnd);
				unit.mental.discipline = LibFuncs.RandomFlag<Statmental_discipline>(TWRandom.rnd);
				unit.mental.morale = TWRandom.rnd.Next(0, 15);
			}
		}
	}
}
