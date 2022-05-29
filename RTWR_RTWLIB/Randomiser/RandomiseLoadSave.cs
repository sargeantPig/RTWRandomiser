using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTWLib.Data;
using RTWLib.Extensions;
using RTWR_RTWLIB.Forms;
using RTWRandLib.Data;

namespace RTWR_RTWLIB.Randomiser
{
    public static class  RandomiseLoadSave
    {
        public static void Save(string[] files, string name, Game game, string saveLocation, SubGame sub = SubGame.None)
        {
            string data = string.Empty;

            data += "##Randomised Antiquity##".CRL()
                + "game=" + game.ToString().CRL() 
                + "sub=" + sub.ToString().CRL()
                + "seed=" + name.CRL() 
                + "-------------------".CRL();

            foreach (string file in files)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    data += sr.ReadToEnd().CRL();
                    data += "-------------------".CRL();  
                }
            }

            using (StreamWriter sw = new StreamWriter(saveLocation))
            {
                sw.Write(data);
                sw.Flush();
            }
        }

        public static void Load(Options opt, Options adv)
        { 
        
        
        }
    }
}
