using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher1
{
    public partial class Namechange : Form
    {
        public Namechange()
        {
            InitializeComponent();
        }




        private void Namechange_Load(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines("Rust/LumaEmu.ini");
            // comboBox1.Text = lines[2];
            var line = lines[1];
            if (line == null)
                return;

            // split string to first and last names
            var parts = line.Split('=');
            if (parts.Length != 2)
                return;

            // send them to textBox.Text property
            comboBox1.Text = parts[1];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines("Rust/LumaEmu.ini");
            lines[1] = "PlayerName = " + comboBox1.Text;
            File.WriteAllLines("Rust/LumaEmu.ini", lines);


            Namechange set = this;
            set.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
