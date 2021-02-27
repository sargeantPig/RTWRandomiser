using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Functions.EDU;
using RTWLib.Objects;
using RTWLib.Objects.Descr_strat;
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
			int ownershipPerUnit = (int)maxOwnership.Value;

			ownershipPerUnit += 1; //account for slave always taking up a slot

			if (TWRandom.advancedOptions.options[advancedOptionKeys.rdb_randomShuffle.ToString()] == 1)
			{
				SimpleOwnership(edu, ownershipPerUnit);
			}
			if (TWRandom.advancedOptions.options[advancedOptionKeys.rdb_balancedShuffle.ToString()] == 1)
			{
				BalancedOwnership(edu, ownershipPerUnit);
			}
			else if (TWRandom.advancedOptions.options[advancedOptionKeys.rdb_regionShuffling.ToString()] == 1)
			{
				RegionBasedOwnership(edu, dr, ownershipPerUnit);
			}
		}

		public static void SimpleOwnership(EDU edu, int maxOwnership)
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

				List<Unit> units = GetRandomUnitList(edu, edu.units.Count / TWRandom.factionList.Count(), maxOwnership, true);

				foreach (Unit unit in units)
				{
					unit.ownership.Add(faction);
				}

				bool hasBoats = FactionHasBoats(edu, faction);

				if (!hasBoats)
				{
					GiveBoats(edu, faction);
				}
			}
		}

		public static void BalancedOwnership(EDU edu, int maxOwnership)
		{
			float averagePoints = 0f;
			float total = 0f;
			float minPoints = 100000f;
			float maxPoints = 0;
			float lowerBoundary = 0f;
			float upperBoundary = 0f;
			foreach (Unit unit in edu.units)
			{
				unit.CalculatePointValue();
				if (unit.pointValue > maxPoints)
					maxPoints = unit.pointValue;
				if (unit.pointValue < minPoints)
					minPoints = unit.pointValue;

				total += unit.pointValue;
				unit.ownership.Clear();
				unit.ownership.Add("slave");
			}

			averagePoints = total / edu.units.Count;

			List<Unit> lowTier = new List<Unit>();
			List<Unit> midTier = new List<Unit>();
			List<Unit> highTier = new List<Unit>();
			
			lowerBoundary = (averagePoints - minPoints) / 2;
			upperBoundary = (maxPoints - averagePoints) / 2;

			foreach (Unit unit in edu.units)
			{
				if (unit.pointValue > averagePoints + upperBoundary)
					highTier.Add(unit);
				else if (unit.pointValue > averagePoints - lowerBoundary)
					midTier.Add(unit);
				else
					lowTier.Add(unit);
			}

			DistributeUnitsFromTier(lowTier, maxOwnership);
			DistributeUnitsFromTier(midTier, maxOwnership);
			DistributeUnitsFromTier(highTier, maxOwnership);
			//boats

			foreach (string faction in TWRandom.factionList)
			{
				bool hasBoats = FactionHasBoats(edu, faction);
				if (!hasBoats)
					GiveBoats(edu, faction);
			}
		}

		public static void RegionBasedOwnership(EDU edu, Descr_Region dr, int maxOwnership)
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

		static void DistributeUnitsFromTier(List<Unit> tier, int maxOwnership)
		{
			Dictionary<int, int> unitUses = new Dictionary<int, int>();

			for (int i = 0; i < tier.Count; i++)
				unitUses.Add(i, 0);

			while (tier.Count > 0)
			{
				foreach (string faction in TWRandom.factionList)
				{
					if (tier.Count == 0)
						break;


					if (faction == "slave")
						continue;

					int rnd = -1;
					while (rnd >= tier.Count || rnd < 0)
						rnd = TWRandom.rnd.Next(0, tier.Count);

					if (tier[rnd].ownership.Contains(faction))
						continue;

					if (!tier[rnd].ownership.Contains(faction))
						tier[rnd].ownership.Add(faction);

					unitUses[rnd] += 1;

					if (unitUses[rnd] >= maxOwnership)
						tier.RemoveAt(rnd);
				}
			}
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

		static void GiveBoats(EDU edu, string faction)
		{
			var boats = GetRandomUnitListByType(edu, TWRandom.factionList.Count() / 3, "ship", 5, true);
			foreach (Unit boat in boats)
			{
					boat.ownership.Add(faction);
			}
		}
	}
}
