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
                        double distance = Functions_General.DistanceTo(coorda, coordb);
                        if (!regionDistances.ContainsKey(b.region))
                            regionDistances.Add(b.region, new Dictionary<string, double> { { name, distance } });
                        else regionDistances[b.region].Add(name, distance);
                    }
                }
            }

            List<KeyValuePair<FactionOwnership, FactionOwnership>> completePairs = new List<KeyValuePair<FactionOwnership, FactionOwnership>>();

            Dictionary<FactionOwnership, Personality> fp = new Dictionary<FactionOwnership, Personality>();
            fp.Remove(FactionOwnership.slave);
            foreach (var a in ds.factions)
            {
                fp.Add(lt.LookUpKey<FactionOwnership>(a.name), Functions_General.RandomFlag<Personality>(TWRandom.rnd));
            }

            ds.coreAttitudes.attitudes.Clear();
            ds.factionRelationships.attitudes.Clear();

            foreach (var a in ds.factions)
            {
                FactionOwnership f = lt.LookUpKey<FactionOwnership>(a.name);
                if (f == FactionOwnership.slave)
                    continue;
                foreach (var b in a.settlements)
                {
                    foreach (var c in regionDistances[b.region])
                    {
                        FactionOwnership tempf = FactionOwnership.slave;
                        if (c.Value < 25 && c.Value != 0)
                        {
                            foreach (var ab in ds.factions)
                                foreach (var ba in ab.settlements)
                                {
                                    if (ba.region == c.Key)
                                    {
                                        tempf = lt.LookUpKey<FactionOwnership>(ab.name);

                                    }
                                }

                            int personalvalue = fp[f].Compare(fp[tempf]) * 100;
                            int relationValue = personalvalue + 100;


                            if (tempf == FactionOwnership.slave || tempf == f)
                            {
                                continue;
                            }
                            else if (ds.factionRelationships.attitudes.ContainsKey(f))
                            {
                                if (ds.factionRelationships.attitudes[f].ContainsKey(relationValue))
                                {
                                    if (ds.factionRelationships.attitudes[f][relationValue] == null)
                                        ds.factionRelationships.attitudes[f][relationValue] = new List<FactionOwnership>() { tempf };
                                    else if (!ds.factionRelationships.attitudes[f][relationValue].Contains(tempf))
                                        ds.factionRelationships.attitudes[f][relationValue].Add(tempf);
                                }
                                else ds.factionRelationships.attitudes[f].Add(relationValue, new List<FactionOwnership>() { tempf });
                            }
                            else ds.factionRelationships.attitudes.Add(f, new Dictionary<int, List<FactionOwnership>> { { relationValue, new List<FactionOwnership>() { tempf } } });


                            if (completePairs.Contains(new KeyValuePair<FactionOwnership, FactionOwnership>(f, tempf)) ||
                           completePairs.Contains(new KeyValuePair<FactionOwnership, FactionOwnership>(tempf, f)) ||
                           tempf == f || tempf == FactionOwnership.slave)
                            {
                                continue;
                            }
                            else
                            {
                                if (ds.coreAttitudes.attitudes.ContainsKey(f))
                                {
                                    if (ds.coreAttitudes.attitudes[f].ContainsKey(personalvalue))
                                        ds.coreAttitudes.attitudes[f][personalvalue].Add(tempf);
                                    else ds.coreAttitudes.attitudes[f].Add(personalvalue, new List<FactionOwnership>() { tempf });
                                }
                                else ds.coreAttitudes.attitudes.Add(f, new Dictionary<int, List<FactionOwnership>> { { personalvalue, new List<FactionOwnership>() { tempf } } });
                                completePairs.Add(new KeyValuePair<FactionOwnership, FactionOwnership>(f, tempf));
                                completePairs.Add(new KeyValuePair<FactionOwnership, FactionOwnership>(tempf, f));
                            }


                        }
                    }
                }
            }

            ds.coreAttitudes.attitudes.Add(FactionOwnership.slave, new Dictionary<int, List<FactionOwnership>>
            {
                {600, new List<FactionOwnership>{
                    FactionOwnership.armenia,
                    FactionOwnership.britons,
                    FactionOwnership.carthage,
                    FactionOwnership.dacia,
                    FactionOwnership.egypt,
                    FactionOwnership.macedon,
                    FactionOwnership.numidia,
                    FactionOwnership.parthia,
                    FactionOwnership.pontus,
                    FactionOwnership.romans_brutii,
                    FactionOwnership.romans_julii,
                    FactionOwnership.romans_scipii,
                    FactionOwnership.scythia,
                    FactionOwnership.seleucid,
                    FactionOwnership.spain,
                    FactionOwnership.thrace
                } }

            });

            ds.factionRelationships.attitudes.Add(FactionOwnership.slave, new Dictionary<int, List<FactionOwnership>>
            {
                {600, new List<FactionOwnership>{
                    FactionOwnership.armenia,
                    FactionOwnership.britons,
                    FactionOwnership.carthage,
                    FactionOwnership.dacia,
                    FactionOwnership.egypt,
                    FactionOwnership.macedon,
                    FactionOwnership.numidia,
                    FactionOwnership.parthia,
                    FactionOwnership.pontus,
                    FactionOwnership.romans_brutii,
                    FactionOwnership.romans_julii,
                    FactionOwnership.romans_scipii,
                    FactionOwnership.scythia,
                    FactionOwnership.seleucid,
                    FactionOwnership.spain,
                    FactionOwnership.thrace
                } }

            });

            foreach (var a in ds.factionRelationships.attitudes)
            {
                if (a.Key == FactionOwnership.slave)
                    continue;
                else if (a.Value.ContainsKey(600))
                {
                    a.Value[600].Add(FactionOwnership.slave);
                }
                else a.Value.Add(600, new List<FactionOwnership> { FactionOwnership.slave });
            }

        }

    }
}
