using RTWLib.Functions;
using RTWLib.Objects.Descr_strat;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomDS
    {
        public static void RandomTreasury(Descr_Strat ds)
        {
            foreach (Faction f in ds.factions)
            {
                f.denari = TWRandom.rnd.Next(0, 6000 + 1);
            }
        }
    }
}
