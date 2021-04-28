using RTWLib.Extensions;
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
        public static void RandomSettlements(Descr_Strat ds, Descr_Region dr, NumericUpDown maxSettlements)
        {
            TWRandom.RefreshRndSeed();
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
                        double tempDis = cityCoords.DistanceTo(capitalCoords);

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


    }
}