using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RTWLib.Functions;
using System.Windows.Forms;
using RTWLib.Logger;

namespace RTWR_RTWLIB.Data
{
    public enum Option
    { 
        UnitSize,
        UnitAutoBalance,
        UnitCostBalance,
        UnitTraining,
        UnitOwnershipReshuffle,
        UnitAttributeRealism,
        RagingRebels,
        VictoryCondition 
    }

    public class AdvancedOptions : Logger
    {
        public Dictionary<Option, int> options;
        readonly string filePath = @"randomiser/advancedOptions.txt";
        public AdvancedOptions() 
        {

            this.fileName = "advancedOptions.txt";
            options = new Dictionary<Option, int>()
            {
                {Option.RagingRebels, 5},
                {Option.UnitAttributeRealism, 1},
                {Option.UnitAutoBalance, 1},
                {Option.UnitCostBalance, 1 },
                {Option.UnitOwnershipReshuffle, 0},
                {Option.UnitSize, 0},
                {Option.UnitTraining, 1},
                {Option.VictoryCondition, 0}
            };
        }

        public void Export()
        {
            StreamWriter sw = new StreamWriter(filePath);

            foreach (var option in options)
            {
                sw.Write(option.Key.ToString() + "=" + option.Value + "\r\n");
            }

            sw.Close();
        }

        public void Import()
        {
            StreamReader sr = new StreamReader(filePath);

            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] split = line.Split('=');
                Option opt = (Option)Enum.Parse(typeof(Option), split[0].Trim());

                if (Enum.TryParse(split[0].Trim(), out opt))
                {
                    if (options.ContainsKey(opt))
                    {
                        options[opt] = Convert.ToInt32(split[1].Trim());
                    }
                }

                else 
                {
                    PLog(this.fileName + ": Error parsing " + split[0].Trim() + " option does not exist.");
                    DisplayLog();
                }
            }

            sr.Close();
        }

        public object GetOption(Option option)
        {
            if (options.ContainsKey(option))
                return options[option];
            else return null;
        }

    }
}
