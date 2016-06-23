using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomiser
{
    public static class Data
    {
        public static Random rnd = new Random();

        public static List<Unit> units = new List<Unit>();

        public static string RtwFolderPath = "";
        public static string ModFolderPath = "";
        public static string EDUFILEPATH = @"\data\export_descr_unit.txt";
        public static string EDUFILEPATHMOD = @"\data\export_descr_unit.txt";
        public static string EDBFILEPATH = @"\data\export_desc_buildings.txt";
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
