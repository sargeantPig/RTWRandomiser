using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomiser
{
    public static class Data
    {
        public static int Seed = 0;

        public static Random rnd = new Random();

        public static List<string> desc_StratData = new List<string>();
        public static List<Unit> units = new List<Unit>();
        public static List<string> Factions = new List<string>();
        public static List<Character> chars = new List<Character>();
        public static List<string> strLine = new List<string>();
        public static List<string> regions = new List<string>();
        public static List<Settlement> settlements = new List<Settlement>();
        public static List<Region> rgbRegions = new List<Region>();

        public static string RtwFolderPath = "";
        public static string ModFolderPath = "";
        public static string EDUFILEPATH = @"\data\export_descr_unit.txt";
        public static string EDUFILEPATHMOD = @"\data\export_descr_unit.txt";
        public static string EDBFILEPATH = @"\data\export_desc_buildings.txt";
        public static string DESCSTRAT = @"\data\world\maps\campaign\imperial_campaign\descr_strat.txt";
        public static string VAN_REGIONS = @"just_regions_vanRTW.txt";
        public static string REGIONSFILEPATH = @"\data\world\maps\base\descr_regions.txt";
        public static string MAPREGIONSPATH = @"\data\world\maps\base\map_regions.bmp";

    }

    public static class RandomiseData
    {
       public static int OwnershipPerUnit;
       public static bool unitSizes, stats, reasonableStats, rndCost, rndSounds;

    }

    public static class Functions
    {
        public static string RemoveFirstWord(string String)
        {
            string newString = "";

            string[] Temp = String.Split(' ');

            int i = 0;

            foreach (string temp in Temp)
            {
                if (i != 0)
                    newString += temp + " ";

                i++;
            }

            return newString;
        }
    }
}
