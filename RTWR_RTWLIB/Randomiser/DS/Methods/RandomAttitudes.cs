using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Objects.Descr_strat;
using RTWR_RTWLIB.Data;
using System.Collections.Generic;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomDS
    {
        public static void RandCoreAttitudes(Descr_Strat ds, Descr_Region dr)
        {
            LookUpTables lt = new LookUpTables();
            /*  Allied = 0
                Suspicious = 100
                Neutral = 200
                Hostile = 400
                At war = 600*/
            Dictionary<string, Dictionary<string, double>> regionDistances = new Dictionary<string, Dictionary<string, double>>();

            foreach (var a in ds.factions)
            {
                foreach (var b in a.settlements)
                {
                    foreach (var c in dr.rgbRegions)
                    {
                        string name = c.Value.name;
                        int[] coorda = { dr.rgbRegions[b.region].x, dr.rgbRegions[b.region].y };
                        int[] coordb = { c.Value.x, c.Value.y };
                        double distance = LibFuncs.DistanceTo(coorda, coordb);
                        if (!regionDistances.ContainsKey(b.region))
                            regionDistances.Add(b.region, new Dictionary<string, double> { { name, distance } });
                        else regionDistances[b.region].Add(name, distance);
                    }
                }
            }

            List<KeyValuePair<string, string>> completePairs = new List<KeyValuePair<string, string>>();

            Dictionary<string, Personality> fp = new Dictionary<string, Personality>();
            fp.Remove("slave");
            foreach (var a in ds.factions)
            {
                fp.Add(a.name, LibFuncs.RandomFlag<Personality>(TWRandom.rnd));
            }

            ds.coreAttitudes.attitudes.Clear();
            ds.factionRelationships.attitudes.Clear();

            foreach (var a in ds.factions)
            {
                string f = a.name;
                if (f == "slave")
                    continue;
                foreach (var b in a.settlements)
                {
                    foreach (var c in regionDistances[b.region])
                    {
                        string tempf = "";
                        if (c.Value < 25 && c.Value != 0)
                        {
                            foreach (var ab in ds.factions)
                                foreach (var ba in ab.settlements)
                                {
                                    if (ba.region == c.Key)
                                    {
                                        tempf = ab.name;
                                    }
                                }

                            int personalvalue = fp[f].Compare(fp[tempf]) * 100;
                            int relationValue = personalvalue + 100;


                            if (tempf == "slave" || tempf == f)
                            {
                                continue;
                            }
                            else if (ds.factionRelationships.attitudes.ContainsKey(f))
                            {
                                if (ds.factionRelationships.attitudes[f].ContainsKey(relationValue))
                                {
                                    if (ds.factionRelationships.attitudes[f][relationValue] == null)
                                        ds.factionRelationships.attitudes[f][relationValue] = new List<string>() { tempf };
                                    else if (!ds.factionRelationships.attitudes[f][relationValue].Contains(tempf))
                                        ds.factionRelationships.attitudes[f][relationValue].Add(tempf);
                                }
                                else ds.factionRelationships.attitudes[f].Add(relationValue, new List<string>() { tempf });
                            }
                            else ds.factionRelationships.attitudes.Add(f, new Dictionary<object, List<string>> { { relationValue, new List<string>() { tempf } } });


                            if (completePairs.Contains(new KeyValuePair<string, string>(f, tempf)) ||
                           completePairs.Contains(new KeyValuePair<string, string>(tempf, f)) ||
                           tempf == f || tempf == "slave")
                            {
                                continue;
                            }
                            else
                            {
                                if (ds.coreAttitudes.attitudes.ContainsKey(f))
                                {
                                    if (ds.coreAttitudes.attitudes[f].ContainsKey(personalvalue))
                                        ds.coreAttitudes.attitudes[f][personalvalue].Add(tempf);
                                    else ds.coreAttitudes.attitudes[f].Add(personalvalue, new List<string>() { tempf });
                                }
                                else ds.coreAttitudes.attitudes.Add(f, new Dictionary<object, List<string>> { { personalvalue, new List<string>() { tempf } } });
                                completePairs.Add(new KeyValuePair<string, string>(f, tempf));
                                completePairs.Add(new KeyValuePair<string, string>(tempf, f));
                            }


                        }
                    }
                }
            }

            // add slave
            

            /*foreach (var a in ds.factionRelationships.attitudes)
            {
                if (a.Key == "slave")
                    continue;
                else if (a.Value.ContainsKey(600))
                {
                    a.Value[600].Add(FactionOwnership.slave);
                
                else a.Value.Add(600, new List<FactionOwnership> { FactionOwnership.slave });
            }*/

        }

    }
}
