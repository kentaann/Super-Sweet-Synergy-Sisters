using System;
using System.IO;
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

                    ReadFromJSON reader = new ReadFromJSON();
                    Newtonsoft.Json.JsonConvert.PopulateObject(text, reader);
                    ResultTextBox.Text = reader.m_printStats;
                }

                catch (IOException)
                {
                    MessageBox.Show("Unable to load that for you");
                }

            }
        }

    }
}
