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

namespace SuperSweetAnalyser
{
    public partial class Form1 : Form
    {
        public ReadFromJSON read;

        public Form1()
        {
            InitializeComponent();
            MapImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if(result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                }

                catch (IOException)
                {

                }

            }
        }

    }
}
