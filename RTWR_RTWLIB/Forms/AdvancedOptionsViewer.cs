using RTWR_RTWLIB.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTWR_RTWLIB.Forms
{
    public partial class AdvancedOptionsViewer : Form
    {
        public Options Options { get; set; }

        public AdvancedOptionsViewer(Options advancedOptions)
        {
            this.Icon = RTWR_RTWLIB.Properties.Resources.julii_icon;
            this.Options = advancedOptions;
            InitializeComponent();
        }

        public AdvancedOptionsViewer(string filePath, string fileName)
        {
            this.Icon = RTWR_RTWLIB.Properties.Resources.julii_icon;
            InitializeComponent();
            SetUpOptions(filePath, fileName);
        }

        public void SetUpOptions(string filePath, string fileName)
        {
            this.Show();
            this.Options = new Options(grp_advancedSettings, filePath, fileName);
            this.Hide();
        }

        public void Export()
        {
            this.Show();
            Options.Export(this.grp_advancedSettings);
            this.Hide();
        }

        private void btn_hideAdvancedOptions_Click(object sender, EventArgs e)
        {
            Options.Export(this.grp_advancedSettings);
            this.SetUpOptions(Options.filePath, Options.fileName);
        }
    }
}
