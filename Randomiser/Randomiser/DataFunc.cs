using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;
using System.Windows.Forms;
using ImageMagick;

namespace Randomiser
{
	public static class Data
	{
		//cross compaitable variables 
		public static bool isM2TWMode = false;
		public static bool isRTWMode = false;

		public static string MainFolderPath = "";
		public static string ModFolderPath = "";
		public static string ModFolderMapSelect = "";
		public static string EDUFILEPATH = @"\data\export_descr_unit.txt";
		public static string EDUFILEPATHMOD = @"\data\export_descr_unit.txt";
		public static string EDBFILEPATH = @"\data\export_descr_buildings.txt";
		public static string VAN_REGIONS = @"just_regions_vanRTW.txt";
		public static string REGIONSFILEPATH = @"\data\world\maps\base\descr_regions.txt";
		public static string MAPREGIONSPATH = @"\data\world\maps\base\map_regions.tga";
		public static string MAPGROUNDTYPESPATH = @"\data\world\maps\base\map_ground_types.bmp";
		public static string RADARMAP = @"\data\world\maps\campaign\imperial_campaign\radar_map1.tga";
		public static string FACTIONSELECTMAPS = @"\data\world\maps\campaign\imperial_campaign\";
		public static string SMFACTIONS = @"\data\descr_sm_factions.txt";

		public static bool dataIsLoaded = false;
		public static int Seed = 0;
		public static Random rnd = new Random();
		public static List<string> desc_StratData = new List<string>();
		public static List<Unit> ModdedUnits = new List<Unit>();
		public static List<Unit> Vanunits = new List<Unit>();
		public static List<FactionOwnership> RomeFactions = new List<FactionOwnership>();
		public static List<M2TWFactionOwnership> M2TWFactions = new List<M2TWFactionOwnership>();
		public static List<Character> chars = new List<Character>();
		public static List<string> strLine = new List<string>();
		public static List<string> regions = new List<string>();
		public static List<Settlement> settlements = new List<Settlement>();
		public static List<Region> rgbRegions = new List<Region>();
		public static bool[,] regionWater = new bool[255, 156];
		public static EDB EDBData = new EDB();
		public static string[] EDBTabSpacers = { "    ", "        ", "            ", "                " };  // the edb uses spaces instead of tabs
		public static Dictionary<FactionOwnership, List<string>> settlementOwnership = new Dictionary<FactionOwnership, List<string>>() {

			{FactionOwnership.armenia, new List<string>()},
			{FactionOwnership.britons, new List<string>() },
			{FactionOwnership.carthage, new List<string>() },
			{FactionOwnership.dacia, new List<string>() },
			{FactionOwnership.egypt, new List<string>() },
			{FactionOwnership.gauls, new List<string>() },
			{FactionOwnership.germans, new List<string>() },
			{FactionOwnership.greek_cities, new List<string>() },
			{FactionOwnership.macedon, new List<string>() },
			{FactionOwnership.numidia, new List<string>() },
			{FactionOwnership.parthia, new List<string>() },
			{FactionOwnership.pontus, new List<string>() },
			{FactionOwnership.romans_brutii, new List<string>() },
			{FactionOwnership.romans_julii, new List<string>() },
			{FactionOwnership.romans_scipii, new List<string>() },
			{FactionOwnership.romans_senate, new List<string>() },
			{FactionOwnership.scythia, new List<string>() },
			{FactionOwnership.seleucid, new List<string>() },
			{FactionOwnership.slave, new List<string>() },
			{FactionOwnership.spain, new List<string>() },
			{FactionOwnership.thrace, new List<string>() }
		};
		public static Dictionary<FactionOwnership, Color[]> factionColours = new Dictionary<FactionOwnership, Color[]>()
		{
			{FactionOwnership.armenia, new Color[]{Color.DarkGreen, Color.Red } },
			{FactionOwnership.britons, new Color[]{Color.LightBlue, Color.Orange } },
			{FactionOwnership.carthage, new Color[] { Color.Gray, Color.Wheat } },
			{FactionOwnership.dacia, new Color[]{Color.Brown, Color.Green } },
			{FactionOwnership.egypt, new Color[]{ Color.LightYellow, Color.Purple } },
			{FactionOwnership.gauls, new Color[]{ Color.DarkOliveGreen, Color.Red } },
			{FactionOwnership.germans, new Color[]{Color.MediumPurple, Color.Yellow } },
			{FactionOwnership.greek_cities, new Color[]{Color.MediumPurple, Color.Yellow } },
			{FactionOwnership.macedon,new Color[]{Color.MediumPurple, Color.Yellow }},
			{FactionOwnership.numidia,new Color[]{Color.MediumPurple, Color.Yellow } },
			{FactionOwnership.parthia,new Color[]{Color.MediumPurple, Color.Yellow } },
			{FactionOwnership.pontus,new Color[]{Color.MediumPurple, Color.Yellow }},
			{FactionOwnership.romans_brutii, new Color[]{Color.MediumPurple, Color.Yellow } },
			{FactionOwnership.romans_julii, new Color[]{Color.MediumPurple, Color.Yellow } },
			{FactionOwnership.romans_scipii,new Color[]{Color.MediumPurple, Color.Yellow } },
			{FactionOwnership.romans_senate, new Color[]{Color.MediumPurple, Color.Yellow } },
			{FactionOwnership.scythia,new Color[]{Color.MediumPurple, Color.Yellow } },
			{FactionOwnership.seleucid,new Color[]{Color.MediumPurple, Color.Yellow } },
			{FactionOwnership.slave,new Color[]{Color.MediumPurple, Color.Yellow }},
			{FactionOwnership.spain,new Color[]{Color.MediumPurple, Color.Yellow }},
			{FactionOwnership.thrace,new Color[]{Color.MediumPurple, Color.Yellow }}
		};


		//Rome only variables
		public static string DESCSTRAT = @"\data\world\maps\campaign\imperial_campaign\descr_strat.txt";

        //m2tw only variables
        public static string M2TWDESCSTRAT = @"\data\world\maps\campaign\imperial_campaign\descr_strat.txt";
        public static bool[,] M2TWregionWater = new bool[295, 189];



    }

    public static class RandomiseData
    {
        public static int OwnershipPerUnit, maxCities, maxAttri;
        public static bool unitSizes, stats, reasonableStats, rndCost, rndSounds, rndAI, rndTreasury, rndTraining, rndAttri, rndGroundBonus, rndRosters, balanced;
        public static List<UnitFaction> UnitsFaction = new List<UnitFaction>();
        //ROME ONLY
        public static string[] AIMilitary = { "napoleon", "caesar", "genghis", "mao", "stalin", "smith", "henry" };
        public static string[] AIEconomy = {"comfortable", "balanced", "bureacrat", "fortified", "religous", "trade", "sailor" };
        public static string[] VoiceTypes = { "Light_1", "Medium_1", "Heavy_1", "General_1", "Female_1" };
        public static string[] M2TWVoiceTypes = { "Light", "Heavy", "General" };
    }

    public static class ViewTabData
    {
        public static bool viewVan;
        public static bool viewModded;
    }

    public static class Functions
    {
        public static T RandomFlag<T>(int min, int max)
        {
            Array flags = Enum.GetValues(typeof(T));
            var a  = (T)flags.GetValue(Data.rnd.Next(min, max));

            return a;
        }

        public static T RandomFlag<T>()
        {
            Array flags = Enum.GetValues(typeof(T));
            var a = (T)flags.GetValue(Data.rnd.Next(flags.Length));

            return a;
        }

        public static int GetIndex<T>(T searchFor, List<Unit> listToSearch)
        {
            int find = listToSearch.FindIndex(x => x.dictionary.Trim() == (object)searchFor);

            return find;
        }

        public static int GetIndex<T>(T searchFor, List<UnitFaction> listToSearch)
        {
            int find = listToSearch.FindIndex(x => x.dicName == (object)searchFor);

            return find;
        }

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

        public static string RemoveLastWord(string String)
        {
            string newString = "";

            string[] Temp = String.Split(' ');

            int i = 0;

            foreach (string temp in Temp)
            {
                if (i != Temp.Count() - 1)
                    newString += temp + " ";

                i++;
            }

            return newString;
        }

        public static string GetFirstWord(string String)
        {
            string newString = "";

            string[] Temp = String.Split(' ');

            return Temp[0];
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

        public static object DeepClone(object obj)
        {
            object objResult = null;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }
            return objResult;
        }

		public static Dictionary<TEnum, string> ToDictionary<TEnum>()
		{
			Type enumType = typeof(TEnum);

			if (!enumType.IsEnum)
				throw new ArgumentException("Not enum type.");

			var values = (TEnum[])Enum.GetValues(enumType);

			var dictionary = new Dictionary<TEnum, string>();

			foreach (var value in values)
			{
				dictionary.Add(value, Enum.GetName(enumType, value));
			}

			return dictionary;
		}

		public static void ListUniqueAdd<T>(T[] items, ref List<T> list)
		{
			foreach (T item in items)
			{
				int index = list.IndexOf(item);

				if (index == -1)
				{
					list.Add(item);

				}
			}
		}

		public static ushort[] Blend(MagickColor color, MagickColor backColor, double amount)
		{
			ushort R = (ushort)((color.R * amount) + backColor.R * (1 - amount));
			ushort G = (ushort)((color.G * amount) + backColor.G * (1 - amount));
			ushort B = (ushort)((color.B * amount) + backColor.B * (1 - amount));

			return new ushort[]{R, G, B};
		}

		public static Color SMFGetColour(string line)
		{
			string[] split = line.Split(' ');

			for(int i = 0; i < split.Count() -1; i++)
			{
				split[i] = split[i].Trim(',');
			}
			return Color.FromArgb(Convert.ToInt32(split[1]), Convert.ToInt32(split[3]), Convert.ToInt32(split[5]));

		}

		public static bool CheckIfNull<T>(T item, string msg)
		{
			if (item == null)
			{
				MessageBox.Show(msg);
				return true;

			}

			return false;

		}

		public static void ApplyGlow(ref IPixelCollection pixels,
			ref IPixelCollection regionPixels,
			int radius,
			Vector2 origin,
			Vector2 mapSize,
			MagickColor ucolour,
			double Gamount,
			ref List<Pixel> excludePix,
			double dropOff,
			MagickImage regionMap,
			List<string> regions)
		{
			int maxX = Clamp((int)(origin.X + radius), 0, (int)(mapSize.X-1));
			int maxY = Clamp((int)(origin.Y + radius), 0, (int)(mapSize.Y-1));
			int minX = Clamp((int)(origin.X - radius), 0, (int)(mapSize.X-1));
			int minY = Clamp((int)(origin.Y - radius), 0, (int)(mapSize.X-1));

			for (int x = minX; x <= maxX; x++)
				for (int y = minY; y <= maxY; y++)
				{
					double dis = DistanceTo(new Vector2(x, y), origin);
					if (dis <= radius)
					{
						double blendAmount = Gamount - dis*dropOff;

						if (!ContainsPixel(excludePix, pixels[x, y]))
						{
							if (!CheckRegionsForPixel(regionMap, regions, regionPixels, new Vector2(x, y)))
							{
								excludePix.Add(pixels[x, y]);
								DoGlow(pixels[x, y], blendAmount, ucolour);

							}
							else Console.WriteLine("pixel found");

						}

						else
						{
							Console.WriteLine("invalid pixel");

						}
					}


				}
		}

		public static bool ContainsPixel(List<Pixel> pixels, Pixel toCheck)
		{
			foreach (Pixel pixel in pixels)
			{
				if (toCheck.X == pixel.X && toCheck.Y == pixel.Y)
					return true;
			}

			return false;
		}

		public static void DoGlow(Pixel pixel, double amount, MagickColor prim)
		{
			MagickColor mcol = pixel.ToColor();
			pixel.Set(Blend(prim, mcol, amount));

		}

		public static ushort[] ColToUshort(Color col)
		{
			MagickColor mc = MagickColor.FromRgb(col.R, col.G, col.B);

			return new ushort[] {mc.R, mc.G, mc.B };
		}

		public static MagickColor ushortToMagickColor(ushort[] ucol)
		{
			MagickColor mc = new MagickColor(ucol[0], ucol[1], ucol[2]);
			return mc;

		}

		public static int Clamp(int num, int min, int max)
		{
			if (num < min)
				num = min;
			if (num > max)
				num = max;

			return num;

		}

		public static bool CheckRegionsForPixel(MagickImage regionMap, List<string> regions, IPixelCollection pixels,  Vector2 loc)
		{
			MagickColor pixCol = pixels[(int)loc.X, (int)loc.Y].ToColor();
			foreach (string region in regions)
			{
				var reg = Data.rgbRegions.Find(x => x.name == region);
				MagickColor mc = MagickColor.FromRgb((byte)reg.r, (byte)reg.g, (byte)reg.b);

				//check pixel matches
				
				if (pixCol == mc)
					return true;
			}

			return false;
		}

		
	}



}
