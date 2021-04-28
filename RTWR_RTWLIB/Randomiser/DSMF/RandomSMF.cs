using RTWLib.Extensions;
using RTWLib.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTWR_RTWLIB.Randomiser
{
    public static class RandomSMF
    {

        public static void RandomCulture(this SMFactions factions)
        {
            List<object> cultures = new List<object>();

            foreach (var fac in factions.facDetails)
            {
                if(!cultures.Contains(fac.Value.culture.value))
                    cultures.Add(fac.Value.culture.value);
            }


            foreach (var fac in factions.facDetails)
                fac.Value.culture.value = cultures.GetRandomItemFromList(TWRandom.rnd).ToString();

        }

    }
}
