using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Functions.EDU;
using RTWLib.Objects;
using RTWR_RTWLIB.Data;
using RTWRandLib.Data;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
				unit.ownership.Clear();
				unit.ownership.Add("slave");
			}

			foreach (string faction in TWRandom.factionList)
			{
				if (faction == "slave")
					continue;

				List<Unit> units = GetRandomUnitList(edu, edu.units.Count / TWRandom.factionList.Count(), (int)maxOwnership.Value + 1, true);

				foreach (Unit unit in units)
				{
					unit.ownership.Add(faction);
				}

				bool hasBoats = FactionHasBoats(edu, faction);

				if (!hasBoats)
				{
					var boats = GetRandomUnitListByType(edu, TWRandom.factionList.Count() / 3, "ship", 5, true); 
					foreach (Unit boat in boats)
					{
						boat.ownership.Add(faction);
					}
				}
			}
			
			/*foreach (Unit unit in edu.units)
			{
				List<object> factions = new List<object>(TWRandom.factionList);
				unit.ownership.Clear();

				for (int i = 0; i < (int)maxOwnership.Value; i++)
				{
					string rndFaction = (string)factions.GetRandomItemFromList(TWRandom.rnd);
					unit.ownership.Add(rndFaction);
					factions.Remove(rndFaction);
				}

				if (factions.Contains("slave"))
					unit.ownership.Add("slave");
			}*/



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

		static List<Unit> GetRandomUnitListByType(EDU edu, int maxOwnership, string type, int maxToReturn, bool forceUnits = false)
		{
			List<Unit> units = edu.FindUnitsByArgAndFaction(new string[]{type});
			List<Unit> returnList = new List<Unit>();
			units.Shuffle(TWRandom.rnd);

			int maxUnits = TWRandom.rnd.Next(1, maxToReturn);
			foreach (Unit u in units)
			{
				if (u.ownership.Count >= maxOwnership)
					continue;
				else
				{
					returnList.Add(u);
				}

				if (returnList.Count >= maxUnits)
					return returnList;
			}

			if(returnList.Count == 0 && forceUnits)
			{
				returnList = GetRandomUnitListByType(edu, 100, type, 2, false);
			}

			return returnList;
		}

		static List<Unit> GetRandomUnitList(EDU edu, int numberOfUnits, int maxOwnership = 0, bool useMaxOwnership = false) 
		{
			List<Unit> units = edu.units;
			List<int> usedUnit = new List<int>();
			List<Unit> returnList = new List<Unit>();

			while(returnList.Count < numberOfUnits && units.Count > 0)
			{
				int randIndex = TWRandom.rnd.Next(0, units.Count);

				Unit u = units[randIndex];

				if (usedUnit.Contains(randIndex))
					continue;

				if (useMaxOwnership && u.ownership.Count > maxOwnership)
				{
					usedUnit.Add(randIndex);
					continue;
				}

				else returnList.Add(u);
			}

			return returnList;
		}

		static bool FactionHasBoats(EDU edu, string faction)
		{
			var boatList = edu.FindUnitsByArgAndFaction(new string[] { "ship" }, faction, true);

			if (boatList.Count > 0)
				return true;
			else return false;
		}
	}
}
