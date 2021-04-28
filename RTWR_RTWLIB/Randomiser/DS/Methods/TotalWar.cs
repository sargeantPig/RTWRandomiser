using RTWLib.Data;
using RTWLib.Functions;
using RTWLib.Objects.Descr_strat;
using RTWR_RTWLIB.Data;
using System.Collections.Generic;

namespace RTWR_RTWLIB.Randomiser
{
    public partial class RandomDS
    {
        public static void TotalWar(Descr_Strat ds)
        {
            ds.factionRelationships.attitudes.Clear();
            ds.coreAttitudes.attitudes.Clear();

            Dictionary<string, List<string>> completePairs = new Dictionary<string, List<string>>();
            LookUpTables lt = new LookUpTables();
            foreach (var faction in ds.factions)
            {
                string first = faction.name;
                foreach (var sec_faction in ds.factions)
                {
                    string second = sec_faction.name;
                    if (first != second)
                    {
                        //core values
                        if (completePairs.ContainsKey(first))
                        {
                            int i = completePairs[first].FindIndex(x => x == second);
                            int ia = -1;
                            if (completePairs.ContainsKey(second))
                                ia = completePairs[second].FindIndex(x => x == first);
                            else completePairs.Add(second, new List<string>());
                            if (i > -1 || ia > -1)
                                continue;
                            else if (i == -1 && ia == -1 && !ds.coreAttitudes.attitudes.ContainsKey(first))
                            {
                                ds.coreAttitudes.attitudes.Add(first, new Dictionary<object, List<string>> { { 600, new List<string>() { second } } });
                            }
                            else if (i == -1 && ia == -1 && ds.coreAttitudes.attitudes.ContainsKey(first))
                            {
                                if (ds.coreAttitudes.attitudes[first].ContainsKey(600))
                                {
                                    ds.coreAttitudes.attitudes[first][600].Add(second);
                                }
                                else
                                {
                                    ds.coreAttitudes.attitudes[first].Add(600, new List<string> { second });
                                }

                            }

                            completePairs[first].Add(second);
                            completePairs[second].Add(first);
                        }

                        else
                        {
                            ds.coreAttitudes.attitudes.Add(first, new Dictionary<object, List<string>> { { 600, new List<string>() { second } } });
                            completePairs.Add(first, new List<string> { second });
                            completePairs.Add(second, new List<string> { first });
                        }

                        //do faction relationship vales
                        if (!ds.factionRelationships.attitudes.ContainsKey(first))
                        {
                            ds.factionRelationships.attitudes.Add(first, new Dictionary<object, List<string>> { { 600, new List<string>() { second } } });
                        }
                        else if (ds.factionRelationships.attitudes.ContainsKey(first))
                        {
                            if (ds.factionRelationships.attitudes[first].ContainsKey(600))
                            {
                                ds.factionRelationships.attitudes[first][600].Add(second);
                            }
                            else
                            {
                                ds.factionRelationships.attitudes[first].Add(600, new List<string> { second });
                            }

                        }

                    }


                }
            }

        }

    }
}
