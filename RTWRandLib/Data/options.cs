using RTWLib.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTWRandLib.Data
{
    public class Options
    {
        public string filePath { get; set; } 
        public string fileName { get; set; }
        public Dictionary<string, int> options;

        public Options(GroupBox settingsBox, string filePath, string fileName)
        {
            this.filePath = filePath;
            this.fileName = fileName;
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
                if (matches[0] is RadioButton)
                    ((RadioButton)matches[0]).Checked = Convert.ToBoolean(opt.Value);
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

                        if (opt is RadioButton)
                        {
                            RadioButton radioButton = (RadioButton)opt;
                            sw.WriteLine(radioButton.Name + "=" + radioButton.Checked.ToString());
                        }
                    }
                }

                if (box is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)box;
                    sw.WriteLine(checkBox.Name + "=" + checkBox.Checked.ToString());
                }

                if (box is NumericUpDown)
                {
                    NumericUpDown numUpDown = (NumericUpDown)box;
                    sw.WriteLine(numUpDown.Name + "=" + numUpDown.Value.ToString());
                }

                if (box is RadioButton)
                {
                    RadioButton radioButton = (RadioButton)box;
                    sw.WriteLine(radioButton.Name + "=" + radioButton.Checked.ToString());
                }

            }
            
            sw.Close();
        }

    }
}
