using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using RTWLib.Functions;
using RTWLib.Objects;
using RTWLib.Data;
using RTWLib.Logger;
using System.Threading;

namespace RTWR_RTWLIB.Randomiser
{
	public class RandomDS
	{
		public static void RandomTreasury(Descr_Strat ds)
		{
			foreach (Faction f in ds.factions)
			{
				f.denari = TWRandom.rnd.Next(0, 6000 + 1);
			}
		}

		public static void RandomAI(Descr_Strat ds)
		{
			foreach (Faction f in ds.factions)
			{
				f.ai[0] = TWRandom.GetRandomAIEconomy();
				f.ai[1] = TWRandom.GetRandomAIMilitary();
			}
		}

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

		public static void RandomSettlements(Descr_Strat ds, Descr_Region dr, NumericUpDown maxSettlements)
		{

			List<Settlement> tempSettlements = new List<Settlement>();

			Action<Faction> AddRSettlement = (f) =>
			{
				int index = TWRandom.rnd.Next(tempSettlements.Count());
				Settlement rndS = tempSettlements[index];
				f.settlements.Add(new Settlement(rndS));
				tempSettlements.RemoveAt(index);
			};

			Action<Settlement, Faction> AddSettlement = (s, f) =>
			{
				f.settlements.Add(new Settlement(s));
				tempSettlements.Remove(s);
			};

			//get all settlements
			foreach (Faction f in ds.factions)
			{
				foreach (Settlement s in f.settlements)
				{
					tempSettlements.Add(new Settlement(s));
				}
			}

			tempSettlements = CreateMissingSettlements(tempSettlements, dr);

			//set capitals for each faction
			foreach (Faction f in ds.factions)
			{
				f.settlements.Clear();
				AddRSettlement(f); //add first settlement, (this will be the capital)
			}

			ds.ShuffleFactions(TWRandom.rnd);

			foreach (Faction f in ds.factions)
			{
				int maxrnd = TWRandom.rnd.Next((int)maxSettlements.Value + 1);
				int[] capitalCoords = dr.GetCityCoords(f.settlements.First().region);
				for (int i = 0; i < maxrnd - 1; i++)
				{
					double distance = 100;
					Settlement cityToAdd = null;

					foreach (Settlement s in tempSettlements)
					{
						int[] cityCoords = dr.GetCityCoords(s.region);
						double tempDis = Functions_General.DistanceTo(cityCoords, capitalCoords);

						if (tempDis < distance)
						{
							distance = tempDis;
							cityToAdd = s;

						}
					}

					if (cityToAdd != null)
						AddSettlement(cityToAdd, f);
				}

			}
			CharacterCoordinateFix(ds, dr);
		}

		public static void VoronoiSettlements(Descr_Strat ds, Descr_Region dr)
		{
			Dictionary<int[], List<Settlement>> voronoiCoords = new Dictionary<int[], List<Settlement>>();
			List<Settlement> tempSettlements = new List<Settlement>();

			ds.ShuffleFactions(TWRandom.rnd);

			//get all settlements
			foreach (Faction f in ds.factions)
			{
				foreach (Settlement s in f.settlements)
				{
					tempSettlements.Add(new Settlement(s));
				}
			}

			tempSettlements = CreateMissingSettlements(tempSettlements, (Descr_Region)dr);

			while (!CheckVoronoiPoints(voronoiCoords))
			{
				//set voronoi points 
				for (int i = 0; i < ds.factions.Count; i++)
				{

					int x = TWRandom.rnd.Next(20, 231);
					int y = TWRandom.rnd.Next(20, 131);

					while (voronoiCoords.ContainsKey(new int[] { x, y }))
					{
						x = TWRandom.rnd.Next(20, 231);
						y = TWRandom.rnd.Next(20, 131);
					}
					voronoiCoords.Add(new int[] { x, y }, new List<Settlement>());
				}

				//assign each settlement to closest voronoi point
				foreach (Settlement s in tempSettlements)
				{
					int[] closestPoint = new int[2];
					int distance = 10000;
					int[] cityCoord = ((Descr_Region)dr).GetCityCoords(s.region);
					foreach (KeyValuePair<int[], List<Settlement>> kv in voronoiCoords)
					{
						int tempDistance = (int)Functions_General.DistanceTo(cityCoord, kv.Key);
						if (tempDistance < distance)
						{
							distance = tempDistance;
							closestPoint = kv.Key;
						}
					}

					voronoiCoords[closestPoint].Add(s);
				}

				if (!CheckVoronoiPoints(voronoiCoords))
				{
					voronoiCoords.Clear();
				}
			}



			//give factions settlements
			int counter = 0;
			foreach (KeyValuePair<int[], List<Settlement>> kv in voronoiCoords)
			{
				ds.factions[counter].settlements = new List<Settlement>(kv.Value);
				counter++;
			}

			CharacterCoordinateFix(ds, dr);
		}

		public static void RagingRebels(Descr_Strat ds)
		{
			ds.brigand_spawn_value = 0;
		}

		public static void MightyEmpires(Descr_Strat ds, EDU edu, NamesFile names, Descr_Region dr, EDB edb)
		{
			foreach (Faction f in ds.factions)
			{
				if (f.name == "slave") //  skip slave
				{
					f.characters.Clear();
					f.relatives.Clear();
					f.characterRecords.Clear();
					continue;
				}

				List<string> usedNames = new List<string>();

				int CWithArmies = 0;
				foreach (DSCharacter c in f.characters)
				{
					if (c.type == "named character" || c.type == "general")
						CWithArmies++;
					usedNames.Add(c.name.Trim());
				}

				foreach (CharacterRecord cr in f.characterRecords)
				{
					usedNames.Add(cr.name);
				}

				int power = f.settlements.Count() * 2;
				int armyDeficit = f.settlements.Count() - CWithArmies;
				int armySize = power;
				if (armySize > 20)
					armySize = 20;

				List<Unit> factionUnits = ((EDU)edu).FindUnitsByFaction(f.name);

				int emptySettlements = f.settlements.Count() - f.characters.Count();

				int rndSize = TWRandom.rnd.Next(armySize / 2, armySize);

				for (int i = 0; i < armyDeficit; i++)
				{
					string name = names.GetRandomUniqueName(TWRandom.rnd, f.name, usedNames);

					f.characters.Add(new DSCharacter(name, TWRandom.rnd));

				}

				foreach (DSCharacter character in f.characters)
				{
					rndSize = TWRandom.rnd.Next(armySize / 2, armySize);
					if (rndSize == 0)
						rndSize = 1;
					if (character.type == "general" || character.type == "named character")
					{
						character.army.Clear();
						for (int i = 0; i < rndSize; i++)
						{
							character.army.Add(new DSUnit(factionUnits[TWRandom.rnd.Next(factionUnits.Count)].type, 0, 0, 0));
						}
					}

				}

				LookUpTables lt = new LookUpTables();

				Cultures culture = lt.LookUpKey<Cultures>(f.name);

				if (culture == Cultures.barbarian)
					power = 4;

				foreach (Settlement s in f.settlements)
				{
					Action<string, int, List<DSBuilding>, int> ChangeSettlement = (string level, int pop, List<DSBuilding> dSBuildings, int mod) =>
					{
						s.s_level = level;
						s.population = pop;
						s.b_types = new List<DSBuilding>(dSBuildings);
						power -= mod;
					};

					if (power > 32)
					{
						s.b_types.Clear();

						string levels = "huge_city";
						int population = 25000;

						List<DSBuilding> dsbs = GetBuildings(levels, edb);

						ChangeSettlement(levels, population, dsbs, 8);


					}

					else if (power > 16)
					{
						s.b_types.Clear();

						string levels = "large_city";
						int population = 20000;

						List<DSBuilding> dsbs = GetBuildings(levels, edb);

						ChangeSettlement(levels, population, dsbs, 4);
					}

					else if (power > 8)
					{
						s.b_types.Clear();

						string levels = "city";
						int population = 15000;

						List<DSBuilding> dsbs = GetBuildings(levels, edb);

						ChangeSettlement(levels, population, dsbs, 2);


					}

					else if (power > 4)
					{
						s.b_types.Clear();

						string levels = "large_town";
						int population = 9000;

						List<DSBuilding> dsbs = GetBuildings(levels, edb);

						ChangeSettlement(levels, population, dsbs, 1);


					}

					else if (power > 2)
					{
						s.b_types.Clear();

						string levels = "town";
						int population = 3500;

						List<DSBuilding> dsbs = GetBuildings(levels, edb);

						ChangeSettlement(levels, population, dsbs, 0);


					}

					else if (power > 1)
					{
						s.b_types.Clear();

						string levels = "village";
						int population = 1000;

						//List<DSBuilding> dsbs = GetBuildings(levels, edb);

						ChangeSettlement(levels, population, new List<DSBuilding>(), 0);

					}


				}
			}

			CharacterCoordinateFix(ds, dr);
		}

		static private List<DSBuilding> GetBuildings(string level, EDB edb)
		{
			List<DSBuilding> dSBuildings = new List<DSBuilding>();
			List<string[]> buildings = new List<string[]>();

			buildings.Add(edb.GetSpecificBuildingFromChain("core_building", level));
			buildings.Add(edb.GetRandomBuildingFromChain("defenses", level, TWRandom.rnd));
			buildings.Add(edb.GetRandomBuildingFromChain("barracks", level, TWRandom.rnd));
			buildings.Add(edb.GetRandomBuildingFromChain("equestrian", level, TWRandom.rnd));
			buildings.Add(edb.GetRandomBuildingFromChain("missles", level, TWRandom.rnd));
			buildings.Add(edb.GetRandomBuildingFromChain("market", level, TWRandom.rnd));
			buildings.Add(edb.GetRandomBuildingFromChain("health", level, TWRandom.rnd));
			buildings.Add(edb.GetRandomBuildingFromChain("hinterland_farms", level, TWRandom.rnd));

			foreach (string[] nt in buildings)
			{
				if (nt == null)
					continue;

				DSBuilding dsb = new DSBuilding();

				dsb.name = nt[0];
				dsb.type = nt[1];

				dSBuildings.Add(dsb);
			}

			return dSBuildings;
		}
		private static List<Settlement> CreateMissingSettlements(List<Settlement> settlements, Descr_Region dr)
		{
			foreach (KeyValuePair<string, Region> kv in dr.rgbRegions)
			{
				int index = settlements.FindIndex(x => x.region == kv.Key);
				if (index == -1)
					settlements.Add(new Settlement("village", kv.Value.name, kv.Value.faction_creator, new List<DSBuilding>(), 0, 500));
			}

			return new List<Settlement>(settlements);
		}

		private static bool CheckVoronoiPoints(Dictionary<int[], List<Settlement>> dic)
		{
			foreach (KeyValuePair<int[], List<Settlement>> kv in dic)
			{
				if (kv.Value.Count == 0)
					return false;
			}

			if (dic.Count == 0)
				return false;

			return true;
		}

		private static void CharacterCoordinateFix(Descr_Strat ds, Descr_Region dr)
		{
			foreach (Faction f in ds.factions)
			{
				List<int[]> coordList = new List<int[]>();

				foreach (Settlement s in f.settlements)
				{
					coordList.Add(dr.GetCityCoords(s.region));
				}

				int counter = 0;
				foreach (DSCharacter c in f.characters)
				{
					if (c.type == "admiral")
						c.coords = Misc_Data.GetClosestWater(coordList[0]);
					else if (c.type == "spy" || c.type == "diplomat")
						c.coords = coordList[counter];
					else
					{
						c.coords = coordList[counter];
						counter++;

						if (counter >= coordList.Count)
							counter = 0;

					}
				}

				coordList.Clear();
			}
		}

	}

}
