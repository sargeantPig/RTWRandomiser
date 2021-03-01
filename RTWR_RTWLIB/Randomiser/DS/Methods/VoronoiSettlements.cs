using RTWLib.Functions;
using RTWLib.Objects.Descr_strat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomDS
    {
        public static void VoronoiSettlements(Descr_Strat ds, Descr_Region dr)
        {
            TWRandom.RefreshRndSeed();
            Dictionary<int[], List<ISettlement>> voronoiCoords = new Dictionary<int[], List<ISettlement>>();
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
                    voronoiCoords.Add(new int[] { x, y }, new List<ISettlement>());
                }

                //assign each settlement to closest voronoi point
                foreach (Settlement s in tempSettlements)
                {
                    int[] closestPoint = new int[2];
                    int distance = 10000;
                    int[] cityCoord = ((Descr_Region)dr).GetCityCoords(s.region);
                    foreach (KeyValuePair<int[], List<ISettlement>> kv in voronoiCoords)
                    {
                        int tempDistance = (int)LibFuncs.DistanceTo(cityCoord, kv.Key);
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
            foreach (KeyValuePair<int[], List<ISettlement>> kv in voronoiCoords)
            {
                 ds.factions[counter].settlements = new List<ISettlement>(kv.Value);
                counter++;
            }

            CharacterCoordinateFix(ds, dr);
        }
        private static bool CheckVoronoiPoints(Dictionary<int[], List<ISettlement>> dic)
        {
            foreach (KeyValuePair<int[], List<ISettlement>> kv in dic)
            {
                if (kv.Value.Count == 0)
                    return false;
            }

            if (dic.Count == 0)
                return false;

            return true;
        }
    }
}