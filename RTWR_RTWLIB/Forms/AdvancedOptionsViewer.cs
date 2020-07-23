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
        AdvancedOptions advancedOptions;

        public AdvancedOptionsViewer(AdvancedOptions advancedOptions)
        {
            this.Icon = RTWR_RTWLIB.Properties.Resources.julii_icon;
            this.advancedOptions = advancedOptions;
            InitializeComponent();
        }





    }
}
