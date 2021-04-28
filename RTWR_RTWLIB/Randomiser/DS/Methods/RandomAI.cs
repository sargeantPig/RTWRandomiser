using RTWLib.Functions;
using RTWLib.Objects.Descr_strat;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomDS
    {
        public static void RandomAI(Descr_Strat ds)
        {
            TWRandom.RefreshRndSeed();
            foreach (Faction f in ds.factions)
            {
                f.ai[0] = TWRandom.GetRandomAIEconomy();
                f.ai[1] = TWRandom.GetRandomAIMilitary();
            }
        }
    }
}
