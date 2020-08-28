using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Functions.EDU;
using RTWLib.Objects;
using RTWR_RTWLIB.Data;
using RTWRandLib.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomEDU
    {
		public static void RandomOwnership(EDU edu, Descr_Region dr, NumericUpDown maxOwnership)
		{
			if (TWRandom.advancedOptions.options[advancedOptionKeys.rdb_randomShuffle.ToString()] == 1)
			{
				SimpleOwnership(edu, maxOwnership);
			}
			else if (TWRandom.advancedOptions.options[advancedOptionKeys.rdb_regionShuffling.ToString()] == 1)
			{
				RegionBasedOwnership(edu, dr, maxOwnership);
			}

		}

		public static void SimpleOwnership(EDU edu, NumericUpDown maxOwnership)
		{
			foreach (Unit unit in edu.units)
			{
				List<object> factions = new List<object>(TWRandom.factionList);
				unit.ownership.Clear();

				for (int i = 0; i < (int)maxOwnership.Value - 1; i++)
				{
					string rndFaction = (string)factions.GetRandomItemFromList(TWRandom.rnd);

					unit.ownership.Add(rndFaction);
					factions.Remove(rndFaction);
				}

				if (factions.Contains("slave"))
					unit.ownership.Add("slave");
			}

		}

		public static void BalancedOwnership(EDU edu)
		{ 
			//distribute units into tiers (cavalry low, mid, high) based on points total etc

			//factions take in turns to select one of each.
		
		}

		public static void RegionBasedOwnership(EDU edu, Descr_Region dr, NumericUpDown maxOwnership)
		{ 
			//get cities and locations

			//set up voronoi grid

			//group cities into clusters near each point

			//group units into list by unit type

			//distribute units into the clusters 

			//setup unit table for number of uses

			//assign factions to clusters

			//set ownership
		
		}
	}
}
