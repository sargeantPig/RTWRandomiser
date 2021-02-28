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
using RTWLib.Objects.Buildings;
using RTWR_RTWLIB.Data;
using RTWLib.Functions.EDU;
using System.Runtime.CompilerServices;

namespace RTWR_RTWLIB.Randomiser
{
	public static class RandomEDB
	{
		public static void SetRecruitment(this EDB edb, EDU edu, bool ignoreIfAlreadySet = true, bool ignoreCore = true)
		{
			foreach (CoreBuilding cb in edb.buildingTrees)
			{
				if (cb.buildingType == "core_building" && ignoreCore)
					continue;
				foreach (Building b in cb.buildings)
				{
					foreach (Brecruit br in b.capability.canRecruit)
					{
						if (br.requiresFactions.Count > 0 && ignoreIfAlreadySet)
							continue;
						br.requiresFactions.Clear();
						br.requiresFactions = new List<string>(edu.FindUnit(br.name).ownership);
					}
				}
			}

		}
		public static void SetTieredRecruitment(this EDB edb, EDU edu)
		{
			foreach (CoreBuilding cb in edb.buildingTrees) //clear units from recruitment table
				foreach (Building b in cb.buildings)
				{
					b.capability.canRecruit.Clear();
				}

			object[] unitSplit = new object[4]{
				edu.FindUnitsByArgAndFaction(new string[] { "missile infantry", "siege"}),
				edu.FindUnitsByArgAndFaction(new string[] { "light cavalry", "heavy cavalry" }),
				edu.FindUnitsByArgAndFaction(new string[] { "light infantry", "heavy infantry", "spearmen" }),
				edu.FindUnitsByArgAndFaction(new string[] { "ship" })
			};

			foreach (var o in unitSplit)
			{
				foreach (var unit in (List<Unit>)o)
				{
					unit.CalculatePointValue();
				}

				SplitUnitsByBuilding(edb, (List<Unit>)o);
			}

			CoreBuildingMiltias(edb, (List<Unit>)unitSplit[2]);

		}

		static void SplitUnitsByBuilding(EDB edb, List<Unit> units)
		{
			Dictionary<UnitType, string> typeByBuildingTree = new Dictionary<UnitType, string>()
			{
				{UnitType.HeavyCavalry, "equestrian"},
				{UnitType.HeavyHandler, "barracks"},
				{UnitType.HeavyInfantry, "barracks"},
				{UnitType.HeavyNon_combatant, ""},
				{UnitType.HeavyShip, "port_buildings"},
				{UnitType.LightCavalry, "equestrian"},
				{UnitType.LightHandler, "barracks"},
				{UnitType.LightInfantry, "barracks"},
				{UnitType.LightNon_combatant, ""},
				{UnitType.LightShip, "port_buildings"},
				{UnitType.MissileCavalry, "equestrian"},
				{UnitType.MissileInfantry, "missiles"},
				{UnitType.MissileSiege, "missiles"},
				{UnitType.SpearmenInfantry, "barracks"}
			};

			LookUpTables lt = new LookUpTables();

			UnitType unitType = UnitType.LightNon_combatant;
			var sorted = units.ToArray();
			Array.Sort(sorted, Unit.ComparePoints());
			List<string> usedUnit = new List<string>();

			if (units.Count > 0)
				unitType = GetUnitRealType(units[0].uClass, units[0].category);


			var buildingTree = edb.GetBuildingTree(typeByBuildingTree[unitType]);

			int numberOfUnits = units.Count;
			int numberOfBuildings = buildingTree.buildings.Count;
			int unitsPerBuilding = numberOfUnits / numberOfBuildings;

			float tierCounter = unitsPerBuilding;
			int buildingLevel = 1;

			var barbFactionsStr = lt.LookUpString<Cultures>(Cultures.barbarian);
			var barbFactionsList = barbFactionsStr.StringToArray();
			for (int bi = 0; bi < buildingTree.buildings.Count; bi++)
			{
				if (tierCounter >= 1)
				{
					int increase = (int)Math.Floor(tierCounter);
					int experience = buildingLevel - 1;
					int experienceDecrease = unitsPerBuilding;
					int tracker = 1;
					for (int i = 0; i < increase; i += 1)
					{
						if (!buildingTree.buildings[bi].capability.ContainsUnit(sorted[i].type))
							buildingTree.buildings[bi].capability.canRecruit.Add(new Brecruit(sorted[i].type, experience >= 1 ? experience : 0));
						/*foreach (string barb in barbFactionsList)
						{
							if (sorted[i].ownership.Contains(barb) && buildingLevel >= 4)
							{
								int knockback = buildingLevel - 3;
								int newBi = bi - knockback;
								if (!buildingTree.buildings[newBi].capability.ContainsUnit(sorted[i].type))
								{
									buildingTree.buildings[newBi].capability.canRecruit.Add(new Brecruit(sorted[i].type, experience >= 1 ? experience : 0));
									buildingTree.buildings[newBi].capability.canRecruit.Last().requiresFactions.Add(barb);
								}
								else
								{
									int unitIndex = buildingTree.buildings[newBi].capability.GetIndexOfUnit(sorted[i].type);
									if (!buildingTree.buildings[newBi].capability.canRecruit[unitIndex].requiresFactions.Contains(barb))
										buildingTree.buildings[newBi].capability.canRecruit[unitIndex].requiresFactions.Add(barb);
								}
							}*/
						//}

						if (tracker > experienceDecrease)
						{
							tracker = 1;
							experience -= 1;
						}
						experience = experience.Clamp(0, int.MaxValue);
						tracker++;
					}
				}
			
				tierCounter += unitsPerBuilding;
				buildingLevel++;
			}
		}

		static void CoreBuildingMiltias(EDB edb, List<Unit> units, int maxPoints = 50)
		{
			var buildingTree = edb.GetBuildingTree("core_building");
			var sorted = units.ToArray();
			Array.Sort(sorted, Unit.ComparePoints());
			foreach (string faction in TWRandom.factionList)
			{
				bool unitChosen = false;
				int rndChance = 50;
				while (!unitChosen)
				{
					foreach (Unit u in sorted)
					{
						int rnd = TWRandom.rnd.Next(0, 101);
						if (u.ownership.Contains(faction) && rnd > rndChance && u.pointValue < maxPoints)
						{
							int exp = 0;
							
							foreach (var building in buildingTree .buildings)
							{
								if (building.capability.ContainsUnit(u.type))
									break;
								building.capability.canRecruit.Add(new Brecruit(u.type, exp));
								building.capability.canRecruit.Last().requiresFactions.Add(faction);
								exp += 1;
							}
							unitChosen = true;
						}
						if (unitChosen)
							break;

					}
					rndChance -= 1;
					maxPoints += 2;
				}
			}
		}

		static UnitType GetUnitRealType(string uclass, string category)
		{
			string realType = uclass.Capitalise() + category.Capitalise();
			UnitType realEnumType = UnitType.LightNon_combatant;
			try { realEnumType = (UnitType)Enum.Parse(typeof(UnitType), realType); }

			catch (Exception ex)
			{
				Logger log = new Logger(); 
				log.ExceptionLog(ex, false);
				log.DisplayLogExit();
			}

			return realEnumType;
		}

	}


}
	




