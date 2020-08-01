using RTWLib.Functions;
using RTWLib.Objects.Descr_strat;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomDS
    {
        public static void UnlockFactions(Descr_Strat ds)
        {
            foreach (string p in ds.unlockableFactions)
            {
                ds.playableFactions.Add(p);
            }

            ds.unlockableFactions.Clear();

            foreach (string p in ds.campaignNonPlayable)
            {
                ds.playableFactions.Add(p);
            }

            ds.campaignNonPlayable.Clear();
        }

    }
}