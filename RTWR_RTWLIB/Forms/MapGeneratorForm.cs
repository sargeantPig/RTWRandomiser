using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
using RTWLib.Extensions;
using RTWLib.MapGen;
using RTWLib.Memory;
using RTWR_RTWLIB.Randomiser;

namespace RTWR_RTWLIB.Forms
{
    public partial class MapGeneratorForm : Form
    {
        MapGenerator mapGen;
        LThreadManager threads = new LThreadManager();
        int index = 0;

        public MapGeneratorForm()
        {
            InitializeComponent();
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {//511 313
            threads.ClearThreads();

            mapGen = new MapGenerator(255, 156, (float)numUpD_freq.Value, (int)numUpD_seaLevel.Value, (int)numUpD_roughness.Value,
                "randomiser\\van_data\\world\\maps\\base\\descr_regions.txt", "randomiser\\van_data\\world\\maps\\base\\map_regions.tga", 
                (int)numUpDown_elevation.Value, threads, TWRandom.rnd, (int)numUpD_Threads.Value, picbox_maps);

            threads.CreateThread(() => mapGen.Generate(TWRandom.rnd));
            threads.Start();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            index += 1;
            index = index.Clamp(0, mapGen.images.Count() - 1);
            UpdateImage();
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            index -= 1;
            index = index.Clamp(0, mapGen.images.Count() - 1);
            UpdateImage();
        }

        private void UpdateImage()
        {
            if (mapGen.images.Count == 0)
                return;

            picbox_maps.Image = mapGen.images[index].ToBitmap();
        }
    }
}
