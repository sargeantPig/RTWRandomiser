using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Functions.EDU;
using RTWLib.Objects;
using System.Runtime.CompilerServices;
using RTWLib.Extensions;
namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomEDU
    {
		public static void RandomTraining(EDU edu)
		{
			TWRandom.RefreshRndSeed();
			foreach (Unit unit in edu.units)
			{
				unit.mental.training = ExtRandom.RandomFlag<Statmental_training>(TWRandom.rnd);
				unit.mental.discipline = ExtRandom.RandomFlag<Statmental_discipline>(TWRandom.rnd);
				unit.mental.morale = TWRandom.rnd.Next(0, 15);
			}
		}
	}
}
