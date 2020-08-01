using RTWLib.Functions;
using RTWLib.Objects.Descr_strat;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomDS
    {
        public static void RagingRebels(Descr_Strat ds)
        {
            ds.brigand_spawn_value = TWRandom.advancedOptions.options["numUpDown_ragingRebelsVal"];
        }
    }
}