using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTWLib.Functions;
using RTWLib.Data;
namespace RTWR_RTWLIB.Data
{

    public enum advancedOptionKeys
    {
        chk_realisticAttributes,
        rdb_randomShuffle,
        rdb_balancedShuffle,
        rdb_regionShuffling,
        chk_balanceCosts,
        chk_balanceUnitStats,
        chk_usizeConstraints,
        numUpDown_ragingRebelsVal,
    }

    static class FileDestinations
    {
        public static string MOD_FOLDER = @"randomiser";
        public static string ROOT = @"randomiser\van_data";
        readonly public static string ASSETS = @"randomiser\data\ui\unit_info\merc\";
        readonly public static string[] selectMapPaths = new string[] { @"randomiser\data\world\maps\campaign\imperial_campaign\", @"randomiser\van_data\world\maps\campaign\imperial_campaign\radar_map1.tga" };
        readonly public static string[] M2TWselectMapPaths = new string[] { @"mods\mrandomiser\data\world\maps\campaign\imperial_campaign\", @"mods\mrandomiser\van_data\world\maps\campaign\imperial_campaign\radar_map1.tga" };
        public static Dictionary<FileNames, Dictionary<string, string[]>> paths = new Dictionary<FileNames, Dictionary<string, string[]>>
        {
            {
                FileNames.descr_strat,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] {"randomiser\\van_data\\world\\maps\\campaign\\imperial_campaign\\descr_strat.txt" } },
                    {"save", new string[] {"randomiser\\data\\world\\maps\\campaign\\imperial_campaign\\descr_strat.txt"} }
                }
            },

            {
                FileNames.export_descr_unit,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] {"randomiser\\van_data\\export_descr_unit.txt" } },
                    {"save", new string[] {"randomiser\\data\\export_descr_unit.txt" } }
                }
            },

            {
                FileNames.export_descr_buildings,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] {"randomiser\\van_data\\export_descr_buildings.txt" } },
                    {"save", new string[] {"randomiser\\data\\export_descr_buildings.txt" } }
                }
            },

           {
               FileNames.descr_regions,
               new Dictionary<string, string[]>
               {
                   {"load", new string[] { "randomiser\\van_data\\world\\maps\\base\\descr_regions.txt", "randomiser\\van_data\\world\\maps\\base\\map_regions.tga"  } },
                   {"save", new string[] { } }
               }

           },

           {
               FileNames.names,
               new Dictionary<string, string[]>
               {
                   {"load", new string[] { "randomiser\\van_data\\descr_names.txt" } },
                   {"save", new string[] { } }
               }

           },

            {
               FileNames.descr_sm_faction,
               new Dictionary<string, string[]>
               {
                   {"load", new string[] { "randomiser\\van_data\\descr_sm_factions.txt" } },
                   {"save", new string[] { } }
               }

           }
        };
        public static Dictionary<FileNames, Dictionary<string, string[]>> M2TWpaths = new Dictionary<FileNames, Dictionary<string, string[]>>
        {
            {
                FileNames.descr_strat,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] {"mods\\mrandomiser\\van_data\\world\\maps\\campaign\\imperial_campaign\\descr_strat.txt" } },
                    {"save", new string[] {"mods\\mrandomiser\\data\\world\\maps\\campaign\\imperial_campaign\\descr_strat.txt"} }
                }
            },

            {
                FileNames.export_descr_unit,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] {"mods\\mrandomiser\\van_data\\export_descr_unit.txt" } },
                    {"save", new string[] {"mods\\mrandomiser\\data\\export_descr_unit.txt" } }
                }
            },

            {
                FileNames.export_descr_buildings,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] {"mods\\mrandomiser\\van_data\\export_descr_buildings.txt" } },
                    {"save", new string[] {"mods\\mrandomiser\\data\\export_descr_buildings.txt" } }
                }
            },

           {
               FileNames.descr_regions,
               new Dictionary<string, string[]>
               {
                   {"load", new string[] { "mods\\mrandomiser\\van_data\\world\\maps\\base\\descr_regions.txt", "mods\\mrandomiser\\van_data\\world\\maps\\base\\map_regions.tga"  } },
                   {"save", new string[] { } }
               }

           },

           {
               FileNames.names,
               new Dictionary<string, string[]>
               {
                   {"load", new string[] { "mods\\randomiser\\van_data\\descr_names.txt" } },
                   {"save", new string[] { } }
               }

           },

            {
               FileNames.descr_sm_faction,
               new Dictionary<string, string[]>
               {
                   {"load", new string[] { "mods\\randomiser\\van_data\\descr_sm_factions.txt" } },
                   {"save", new string[] { } }
               }

           },
           {
               FileNames.battle_models,
               new Dictionary<string, string[]>
               {
                   {"load", new string[] { "mods\\randomiser\\van_data\\unit_models\\battle_models.modeldb" } },
                   {"save", new string[] { "mods\\randomiser\\data\\unit_models\\battle_models.modeldb"} }
               }

           }
        };
    }

}
