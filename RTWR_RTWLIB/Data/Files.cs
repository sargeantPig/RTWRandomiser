﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTWLib.Functions;
using RTWLib.Data;
using RTWLib;

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
        readonly public static string RemasterRoot = @"Mods\My Mods\";
        readonly public static string RemasterCustom = @"Mods\My Mods\randomiser\data\world\maps\campaign\custom\";
        readonly public static string RemasterCampaign = @"Mods\My Mods\randomiser\data\world\maps\campaign\imperial_campaign\";
        readonly public static string RemasterRomeData= @"Mods\My Mods\randomiser\r_data";
        readonly public static string RemasterBiData = @"Mods\My Mods\randomiser\bi_data";
        readonly public static string RemasterData = @"Mods\My Mods\randomiser\data";
        readonly public static string[] selectMapPaths = new string[] { @"randomiser\data\world\maps\campaign\imperial_campaign\", @"randomiser\van_data\world\maps\campaign\imperial_campaign\radar_map1.tga" };
        readonly public static string[] remasterSelectMaps = new string[] { @"Mods\My Mods\randomiser\data\world\maps\campaign\imperial_campaign\", @"Mods\My Mods\randomiser\data\world\maps\campaign\imperial_campaign\radar_map1.tga" };
        readonly public static string[] remasterBISelectMaps = new string[] { @"Mods\My Mods\randomiser\data\world\maps\campaign\barbarian_invasion\", @"Mods\My Mods\randomiser\data\world\maps\campaign\barbarian_invasion\radar_map1.tga" };
        readonly public static string[] M2TWselectMapPaths = new string[] { @"mods\randomiser\data\world\maps\campaign\imperial_campaign\", @"mods\randomiser\van_data\world\maps\campaign\imperial_campaign\radar_map1.tga" };
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
                    {"load", new string[] {"mods\\randomiser\\van_data\\world\\maps\\campaign\\imperial_campaign\\descr_strat.txt" } },
                    {"save", new string[] {"mods\\randomiser\\data\\world\\maps\\campaign\\imperial_campaign\\descr_strat.txt"} }
                }
            },

            {
                FileNames.export_descr_unit,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] {"mods\\randomiser\\van_data\\export_descr_unit.txt" } },
                    {"save", new string[] {"mods\\randomiser\\data\\export_descr_unit.txt" } }
                }
            },

            {
                FileNames.export_descr_buildings,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] {"mods\\randomiser\\van_data\\export_descr_buildings.txt" } },
                    {"save", new string[] {"mods\\randomiser\\data\\export_descr_buildings.txt" } }
                }
            },

           {
               FileNames.descr_regions,
               new Dictionary<string, string[]>
               {
                   {"load", new string[] { "mods\\randomiser\\van_data\\world\\maps\\base\\descr_regions.txt", "mods\\randomiser\\van_data\\world\\maps\\base\\map_regions.tga"  } },
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
        public static Dictionary<FileNames, Dictionary<string, string[]>> RemasterPaths = new Dictionary<FileNames, Dictionary<string, string[]>>
        {
             {
                FileNames.descr_strat,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER,  @"vanilla\world\maps\campaign\imperial_campaign\descr_strat.txt") } },
                    {"save", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"data\world\maps\campaign\imperial_campaign\descr_strat.txt") } }
                }
            },

             {
                FileNames.export_descr_unit,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"vanilla\export_descr_unit.txt") } },
                    {"save", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"data\export_descr_unit.txt") } }
                }
            },

            {
                FileNames.export_descr_buildings,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"vanilla\export_descr_buildings.txt")} },
                    {"save", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"data\export_descr_buildings.txt") } }
                }
            },

           {
               FileNames.descr_regions,
               new Dictionary<string, string[]>
               {
                   {"load", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, "vanilla\\world\\maps\\base\\descr_regions.txt"), RTWLIB.Folders.ConstructPath(Game.REMASTER, "vanilla\\world\\maps\\base\\map_regions.tga") } },
                   {"save", new string[] { } }
               }

           },

           {
               FileNames.names,
               new Dictionary<string, string[]>
               {
                   {"load", new string[] {  RTWLIB.Folders.ConstructPath(Game.REMASTER, "vanilla\\descr_names.txt" )} },
                   {"save", new string[] { } }
               }

           },

            {
               FileNames.descr_sm_faction,
               new Dictionary<string, string[]>
               {
                   {"load", new string[] {  RTWLIB.Folders.ConstructPath(Game.REMASTER, "vanilla\\descr_sm_factions.txt" )} },
                   {"save", new string[] { } }
               }

           },

             {
                FileNames.radar_map1,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] {  RTWLIB.Folders.ConstructPath(Game.REMASTER, "vanilla\\world\\maps\\campaign\\imperial_campaign\\radar_map1.tga") } },
                    {"save", new string[] {  RTWLIB.Folders.ConstructPath(Game.REMASTER, "data\\world\\maps\\campaign\\imperial_campaign\\radar_map1.tga") } }
                }
            },

             {
                FileNames.campaign_descr,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] {  RTWLIB.Folders.ConstructPath(Game.REMASTER, "vanilla\\text\\campaign_descriptions.txt") } },
                    {"save", new string[] {  RTWLIB.Folders.ConstructPath(Game.REMASTER, "data\\text\\campaign_descriptions.txt" )} }
                }
            }

        };
        public static Dictionary<FileNames, Dictionary<string, string[]>> RemasterOverrides = new Dictionary<FileNames, Dictionary<string, string[]>>
        {
             {
                FileNames.descr_strat,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"vanilla\original_overrides\resource_quantity\world\maps\campaign\imperial_campaign\descr_strat.txt") } },
                    {"save", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"data\original_overrides\resource_quantity\world\maps\campaign\imperial_campaign\descr_strat.txt") } }
                }
            },

             {
                FileNames.export_descr_unit,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"vanilla\original_overrides\export_descr_unit.txt") } },
                    {"save", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"data\original_overrides\export_descr_unit.txt") } }
                }
            },

            {
                FileNames.export_descr_buildings,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"vanilla\original_overrides\merchants\export_descr_buildings.txt") } },
                    {"save", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"data\original_overrides\merchants\export_descr_buildings.txt") } }
                }
            }
        };
        public static Dictionary<FileNames, Dictionary<string, string[]>> RemasterBIPaths = new Dictionary<FileNames, Dictionary<string, string[]>>
        {
             {
                FileNames.descr_strat,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"bi_vanilla\world\maps\campaign\barbarian_invasion\descr_strat.txt") } },
                    {"save", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"data\world\maps\campaign\barbarian_invasion\descr_strat.txt") } }
                }
            },

             {
                FileNames.export_descr_unit,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"bi_vanilla\export_descr_unit.txt") } },
                    {"save", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"data\export_descr_unit.txt") } }
                }
            },

            {
                FileNames.export_descr_buildings,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"bi_vanilla\export_descr_buildings.txt") } },
                    {"save", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"data\export_descr_buildings.txt") } }
                }
            },

           {
               FileNames.descr_regions,
               new Dictionary<string, string[]>
               {
                   {"load", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"bi_vanilla\world\maps\base\descr_regions.txt"), RTWLIB.Folders.ConstructPath(Game.REMASTER, "bi_vanilla\\world\\maps\\base\\map_regions.tga") } },
                   {"save", new string[] { } }
               }

           },

           {
               FileNames.names,
               new Dictionary<string, string[]>
               {
                   {"load", new string[] {  RTWLIB.Folders.ConstructPath(Game.REMASTER, @"bi_vanilla\descr_names.txt") } },
                   {"save", new string[] { } }
               }

           },

            {
               FileNames.descr_sm_faction,
               new Dictionary<string, string[]>
               {
                   {"load", new string[] {  RTWLIB.Folders.ConstructPath(Game.REMASTER, @"bi_vanilla\descr_sm_factions.txt") } },
                   {"save", new string[] { } }
               }

           },

             {
                FileNames.radar_map1,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] {  RTWLIB.Folders.ConstructPath(Game.REMASTER, @"bi_vanilla\world\maps\campaign\barbarian_invasion\radar_map1.tga") } },
                    {"save", new string[] {  RTWLIB.Folders.ConstructPath(Game.REMASTER, @"data\world\\maps\campaign\barbarian_invasion\radar_map1.tga") } }
                }
            },

             {
                FileNames.campaign_descr,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] {  RTWLIB.Folders.ConstructPath(Game.REMASTER, @"bi_vanilla\text\campaign_descriptions.txt") } },
                    {"save", new string[] {  RTWLIB.Folders.ConstructPath(Game.REMASTER, @"data\text\campaign_descriptions.txt" )} }
                }
            }

        };
        public static Dictionary<FileNames, Dictionary<string, string[]>> RemasterBIOverrides = new Dictionary<FileNames, Dictionary<string, string[]>>
        {
            {
                FileNames.export_descr_buildings,
                new Dictionary<string, string[]>
                {
                    {"load", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"bi_vanilla\original_overrides\merchants\export_descr_buildings.txt") } },
                    {"save", new string[] { RTWLIB.Folders.ConstructPath(Game.REMASTER, @"data\original_overrides\merchants\export_descr_buildings.txt") } }
                }
            }
        };
    }

}
