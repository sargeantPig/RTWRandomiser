using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

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
        public static bool[,] regionWater = new bool[255, 156];

        public static string RtwFolderPath = "";
        public static string ModFolderPath = "";
        public static string EDUFILEPATH = @"\data\export_descr_unit.txt";
        public static string EDUFILEPATHMOD = @"\data\export_descr_unit.txt";
        public static string EDBFILEPATH = @"\data\export_desc_buildings.txt";
        public static string DESCSTRAT = @"\data\world\maps\campaign\imperial_campaign\descr_strat.txt";
        public static string VAN_REGIONS = @"just_regions_vanRTW.txt";
        public static string REGIONSFILEPATH = @"\data\world\maps\base\descr_regions.txt";
        public static string MAPREGIONSPATH = @"\data\world\maps\base\map_regions.tga";
        public static string MAPGROUNDTYPESPATH = @"\data\world\maps\base\map_ground_types.bmp";

    }

    public static class RandomiseData
    {
        public static int OwnershipPerUnit, maxCities;
        public static bool unitSizes, stats, reasonableStats, rndCost, rndSounds, rndAI, rndTreasury;
        public static string[] AIMilitary = { "napoleon", "caesar", "genghis", "mao", "stalin", "smith", "henry" };
        public static string[] AIEconomy = {"comfortable", "balanced", "bureacrat", "fortified", "religous", "trade", "sailor" };




    }

    public static class ViewTabData
    {
        public static bool viewVan;
        public static bool viewModded;
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

        public static double DistanceTo(Vector2 a, Vector2 b)
        {
            double dis = Math.Sqrt(Math.Pow((a.X - b.X), 2) + Math.Pow((a.Y - b.Y), 2));

            return dis;
        }

        public static Vector2 getCoordsFromRegion(List<string> regions, int i)
        {
            string region = regions[i];
            int index = Data.rgbRegions.FindIndex(x => x.name == region); //get city coords
            Vector2 coords = new Vector2(Data.rgbRegions[index].x, Data.rgbRegions[index].y);

            return coords;
        }
    }
}
