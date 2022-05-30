using RTWLib.Functions;
using RTWLib.Functions.EDU;
using RTWLib.Functions.Remaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTWLib.Extensions;
namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomEDU
    {
        public static void RandomOwnership(FileWrapper edu, Descr_Region dr, NumericUpDown maxOwnership)
        {
            TWRandom.RefreshRndSeed();
            List<string> unitNames = edu.SelectAll(edu.objects, "type");
            unitNames.Shuffle(TWRandom.rnd);

            var factionBag = TWRandom.factionList;
            var remF = new List<string>();
            foreach (string name in unitNames)
            {
                var rnd = TWRandom.rnd.Next(1, (int)maxOwnership.Value);
                var factions = TWRandom.GetRandomFactions(factionBag, (int)maxOwnership.Value, out remF);
                factions.Add("slave");
                factionBag = remF.ToArray();
                if (factionBag.Count() == 0)
                    factionBag = TWRandom.factionList;

                edu.EditValuesWhere(edu.objects, factions.ToArray(), x => x.value == name, "type", "ownership");
                edu.AppendValuesWhere(edu.objects, EStr.Array("mercenary_unit"), x => x.value == name, "type", "attributes");
            }
            

        } 
    }
}
