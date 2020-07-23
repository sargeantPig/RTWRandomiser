using RTWLib.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTWR_RTWLIB.Data
{
    class Options : Logger
    {
        readonly string filePath = @"randomiser\options.txt";

        public Dictionary<string, int> options;

        public Options(GroupBox settingsBox)
        {
            this.fileName = "options.txt";
            options = new Dictionary<string, int>();
            if (!File.Exists(filePath))
                Export(settingsBox);
            else Import();

            Apply(settingsBox);
        }

        public void Import()
        {
            StreamReader sr = new StreamReader(filePath);

            string line = "";

            while ((line = sr.ReadLine()) != null)
            {
                string[] split = line.Split('=');

                if (split[1] == "False" || split[1] == "True")
                    options.Add(split[0], Convert.ToInt32(Convert.ToBoolean(split[1])));
                else options.Add(split[0], Convert.ToInt32(split[1]));
            }

            sr.Close();
        }

        public void Apply(GroupBox settingsBox)
        {
            foreach (var opt in options)
            {
                Control[] matches = settingsBox.Controls.Find(opt.Key, true);
                if (matches[0] is CheckBox)
                    ((CheckBox)matches[0]).Checked = Convert.ToBoolean(opt.Value);
                if (matches[0] is NumericUpDown)
                    ((NumericUpDown)matches[0]).Value = opt.Value; 
            }
        }

        public void Export(GroupBox settingsBox)
        {
            StreamWriter sw = new StreamWriter(filePath);

            foreach (var box in settingsBox.Controls)
            {
                if (box is GroupBox)
                {
                    foreach (var opt in ((GroupBox)box).Controls)
                    {

                        if (opt is CheckBox)
                        {
                            CheckBox checkBox = (CheckBox)opt;
                            sw.WriteLine(checkBox.Name + "=" + checkBox.Checked.ToString());
                        }

                        if (opt is NumericUpDown)
                        {
                            NumericUpDown numUpDown = (NumericUpDown)opt;
                            sw.WriteLine(numUpDown.Name + "=" + numUpDown.Value.ToString());
                        }
                    }
                }
            }
            
            sw.Close();
        }

    }
}
