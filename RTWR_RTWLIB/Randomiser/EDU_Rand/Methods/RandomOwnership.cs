using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Functions.EDU;
using RTWLib.Objects;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomEDU
    {
		public static void RandomOwnership(EDU edu, NumericUpDown maxOwnership)
		{
			if (maxOwnership is NumericUpDown)
			{
				NumericUpDown maxO = new NumericUpDown();
				maxO = maxOwnership as NumericUpDown;

				foreach (Unit unit in edu.units)
				{
					List<object> factions = new List<object>(TWRandom.factionList);
					unit.ownership.Clear();

					for (int i = 0; i < (int)maxO.Value - 1; i++)
					{
						string rndFaction = (string)factions.GetRandomItemFromList(TWRandom.rnd);

						unit.ownership.Add(rndFaction);
						factions.Remove(rndFaction);
					}

					if (factions.Contains("slave"))
						unit.ownership.Add("slave");
				}
			}

			else
			{
				edu.PLog("Error: wrong param type");
				edu.DisplayLogExit();
			}
		}
	}
}
