using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTWLib.Functions;
using RTWLib.Data;
namespace RTWR_RTWLIB.Data
{
    static class FileDestinations
    {
        public static string[] selectMapPaths = new string[] { @"randomiser\data\world\maps\campaign\imperial_campaign\", @"randomiser\van_data\world\maps\campaign\imperial_campaign\radar_map1.tga" }; 
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
    }




}
