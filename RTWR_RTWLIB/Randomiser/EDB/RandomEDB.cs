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
		public static void SetRecruitment(this EDB edb, EDU edu)
		{
			foreach (CoreBuilding cb in edb.buildingTrees)
			{
				foreach (Building b in cb.buildings)
				{
					foreach (Brecruit br in b.capability.canRecruit)
					{
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

				splitUnitsByBuilding(edb, (List<Unit>)o);
			}
		}

		static void splitUnitsByBuilding(EDB edb, List<Unit> units)
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
					int experience = buildingLevel;
					int experienceDecrease = increase - (unitsPerBuilding*buildingLevel);
					int tracker = 1;
					for (int i = 0; i < increase; i += 1)
					{
						buildingTree.buildings[bi].capability.canRecruit.Add(new Brecruit(sorted[i].type, experience >= 1 ? experience : 0));

						foreach (string barb in barbFactionsList)
						{
							if (sorted[i].ownership.Contains(barb) && buildingLevel >= 4)
							{
								int knockback = buildingLevel - 3;
								int newBi = bi - knockback;
								buildingTree.buildings[newBi].capability.canRecruit.Add(new Brecruit(sorted[i].type, experience >= 1 ? experience : 0));
							}
						}

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

		static UnitType GetUnitRealType(string uclass, string category)
		{
			Logger log = new Logger();
			string realType = uclass.Capitalise() + category.Capitalise();
			UnitType realEnumType = UnitType.LightNon_combatant;
			try { realEnumType = (UnitType)Enum.Parse(typeof(UnitType), realType); }

			catch (Exception ex)
			{
				log.ExceptionLog(ex, false);
				log.DisplayLogExit();
			}

			return realEnumType;
		}

	}


}
	




