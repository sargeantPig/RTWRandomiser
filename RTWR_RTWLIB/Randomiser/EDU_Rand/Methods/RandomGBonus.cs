using RTWLib.Functions;
using RTWLib.Functions.EDU;
using RTWLib.Objects;
namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomEDU
    {
		public static void RandomGBonus(EDU edu)
		{
			TWRandom.RefreshRndSeed();
			foreach (Unit unit in edu.units)
			{
				unit.ground[0] = TWRandom.rnd.Next(-6, 7);
				unit.ground[1] = TWRandom.rnd.Next(-6, 7);
				unit.ground[2] = TWRandom.rnd.Next(-6, 7);
				unit.ground[3] = TWRandom.rnd.Next(-6, 7);
			}
		}
	}
}