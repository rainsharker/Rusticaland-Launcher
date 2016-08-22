using System;
using System.IO;
using System.Windows.Forms;


namespace Launcher1
{
    public partial class VideoSettings : Form
    {
        public VideoSettings()
        {
            InitializeComponent();
        }

        private void VideoSettings_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Ambient == "new")
            {
                Properties.Settings.Default.Ambient = "False";

            }

            if (Properties.Settings.Default.Ambient == "True")
            {
                Ambient.Checked = true;

            }
            else
            {
                Ambient.Checked = false;
            }
            if (Properties.Settings.Default.Blur == "new")
            {
                Properties.Settings.Default.Blur = "False";

            }
            if (Properties.Settings.Default.Blur == "True")
            {
                Bloomfx.Checked = true;

            }
            else
            {
                Bloomfx.Checked = false;
            }
            if (Properties.Settings.Default.Anti == "new")
            {
                Properties.Settings.Default.Anti = "False";

            }
            if (Properties.Settings.Default.Anti == "True")
            {
                Antifx.Checked = true;

            }
            else
            {
                Antifx.Checked = false;
            }
            if (Properties.Settings.Default.Bloom == "new")
            {
                Properties.Settings.Default.Bloom = "False";

            }

            if (Properties.Settings.Default.Bloom == "True")
            {
                checkBox1.Checked = true;

            }
            else
            {
                checkBox1.Checked = false;
            }
            if (Properties.Settings.Default.Dof == "new")
            {
                Properties.Settings.Default.Dof = "False";

            }

            if (Properties.Settings.Default.Dof == "True")
            {
                checkBox2.Checked = true;

            }
            else
            {
                checkBox2.Checked = false;
            }

            GrassBar.Value = Properties.Settings.Default.Gras;
            TerrainBar.Value = Properties.Settings.Default.Terrain;
            MeshBar.Value = Properties.Settings.Default.Mesh;
            ShaderBar.Value = Properties.Settings.Default.Shader;
            DistanceBar.Value = Properties.Settings.Default.Distance;
            trackValue = Properties.Settings.Default.Gras;
            trackValue2 = Properties.Settings.Default.Terrain;
            trackValue3 = Properties.Settings.Default.Mesh;
            trackValue4 = Properties.Settings.Default.Shader;
            trackValue5 = Properties.Settings.Default.Distance;
            Properties.Settings.Default.Save();
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Antifx.Checked == true)
            {
                Properties.Settings.Default.Anti = "True";
            }
            else
            {
                Properties.Settings.Default.Anti = "False";
            }

            if (Bloomfx.Checked == true)
            {
                Properties.Settings.Default.Blur = "True";
            }
            else
            {
                Properties.Settings.Default.Blur = "False";
            }

            if (Ambient.Checked == true)
            {
                Properties.Settings.Default.Ambient = "True";
            }
            else
            {
                Properties.Settings.Default.Ambient = "False";
            }
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.Bloom = "True";
            }
            else
            {
                Properties.Settings.Default.Bloom = "False";
            }
            if (checkBox2.Checked == true)
            {
                Properties.Settings.Default.Dof = "True";
            }
            else
            {
                Properties.Settings.Default.Dof = "False";
            }
            Properties.Settings.Default.Gras = trackValue;
            Properties.Settings.Default.Terrain = trackValue2;
            Properties.Settings.Default.Mesh = trackValue3;
            Properties.Settings.Default.Shader = trackValue4;
            Properties.Settings.Default.Distance = trackValue5;





            var thisLine = File.ReadAllLines(@"Rust\cfg\client.cfg");
            thisLine[8] = "effect.aa " + "\"" + Properties.Settings.Default.Anti + "\"";
            thisLine[12] = "effect.motionblur " + "\"" + Properties.Settings.Default.Blur + "\"";
            thisLine[9] = "effect.ao " + "\"" + Properties.Settings.Default.Ambient + "\"";
            thisLine[10] = "effect.bloom " + "\"" + Properties.Settings.Default.Bloom + "\"";
            thisLine[31] = "graphics.dof " + "\"" + Properties.Settings.Default.Dof + "\"";
            thisLine[38] = "grass.quality " + "\"" + trackValue + "\"";
            thisLine[45] = "terrain.quality " + "\"" + trackValue2 + "\"";
            thisLine[43] = "mesh.quality " + "\"" + trackValue3 + "\"";
            thisLine[33] = "graphics.shaderlod " + "\"" + trackValue4 + "\"";
            thisLine[27] = "graphics.drawdistance " + "\"" + trackValue5 + "\"";
            File.WriteAllLines(@"Rust\cfg\client.cfg", thisLine);




            Properties.Settings.Default.Save();


            VideoSettings set = this;
            set.Close();
            button1.Enabled = true;
        }



        private void Bloomfx_CheckedChanged(object sender, EventArgs e)
        {
            if (Bloomfx.Checked == true)
            {
                Properties.Settings.Default.Blur = "True";

            }
            else
            {
                Properties.Settings.Default.Blur = "False";
            }
        }

        private void Antifx_CheckedChanged(object sender, EventArgs e)
        {
            if (Antifx.Checked == true)
            {
                Properties.Settings.Default.Anti = "True";

            }
            else
            {
                Properties.Settings.Default.Anti = "False";
            }
        }
        private void Ambient_CheckedChanged(object sender, EventArgs e)
        {
            if (Ambient.Checked == true)
            {
                Properties.Settings.Default.Ambient = "True";
            }
            else
            {
                Properties.Settings.Default.Ambient = "False";
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.Bloom = "True";
            }
            else
            {
                Properties.Settings.Default.Bloom = "False";
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                Properties.Settings.Default.Dof = "True";
            }
            else
            {
                Properties.Settings.Default.Dof = "False";
            }

        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            var thisLine = File.ReadAllLines("Rust/cfg/client.cfg");
            thisLine[18] = "fps.limit " + "\"-1\"";
            File.WriteAllLines("Rust/cfg/client.cfg", thisLine);

            MessageBox.Show("Unlocked, Done");

            button1.Enabled = false;
        }







        int trackValue = 0;
        private void GrassBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            trackValue = GrassBar.Value;
        }

        int trackValue2 = 0;
        private void TerrainBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            trackValue2 = TerrainBar.Value;
        }

        int trackValue3 = 0;
        private void MeshBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            trackValue3 = MeshBar.Value;
        }
        int trackValue4 = 0;
        private void ShaderBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            trackValue4 = ShaderBar.Value;
        }
        int trackValue5 = 0;
        private void DistanceBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            trackValue5 = DistanceBar.Value;
        }

        private void ShaderBar_Scroll(object sender, EventArgs e)
        {

        }

        private void TerrainBar_Scroll(object sender, EventArgs e)
        {

        }

        private void MeshBar_Scroll(object sender, EventArgs e)
        {

        }

        private void DistanceBar_Scroll(object sender, EventArgs e)
        {

        }
    }
}
