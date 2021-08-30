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
    public enum SubGame
    {
        Rome,
        Bi
    }

    public partial class PickGame : Form
    {
        SubGame _SubGame { get; set; }
        public PickGame()
        {
            InitializeComponent();
            rdb_Rome.Checked = true;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (rdb_Rome.Checked)
                _SubGame = SubGame.Rome;
            else if (rdb_bi.Checked)
                _SubGame = SubGame.Bi;

            Close();
        }

        public SubGame SubGame
        {
            get { return _SubGame; }
        }
    }
}
