using RTWLib.Functions;
using RTWLib.Objects;
using RTWLib.Data;
using RTWLib.Objects.Descr_strat;
using System.Collections.Generic;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomDS
    {
        static private List<DSBuilding> GetBuildings(string level, EDB edb)
        {
            List<DSBuilding> dSBuildings = new List<DSBuilding>();
            List<string[]> buildings = new List<string[]>();

            buildings.Add(edb.GetSpecificBuildingFromChain("core_building", level));
            buildings.Add(edb.GetSpecificBuildingFromChain("defenses", level));
            buildings.Add(edb.GetRandomBuildingFromChain("barracks", level, TWRandom.rnd));
            buildings.Add(edb.GetRandomBuildingFromChain("equestrian", level, TWRandom.rnd));
            buildings.Add(edb.GetRandomBuildingFromChain("missles", level, TWRandom.rnd));
            buildings.Add(edb.GetRandomBuildingFromChain("market", level, TWRandom.rnd));
            buildings.Add(edb.GetRandomBuildingFromChain("health", level, TWRandom.rnd));
            buildings.Add(edb.GetRandomBuildingFromChain("hinterland_farms", level, TWRandom.rnd));

            foreach (string[] nt in buildings)
            {
                if (nt == null || nt[0] == null || nt[1] == null)
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
            foreach (KeyValuePair<string, Region> kv in dr.regions)
            {
                int index = settlements.FindIndex(x => x.region == kv.Key);
                if (index == -1)
                    settlements.Add(new Settlement("village", kv.Value.name, kv.Value.factionCreator, new List<DSBuilding>(), 0, 500));
            }

            return new List<Settlement>(settlements);
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
