using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperSweetAnalyser
{
    public partial class SuperSweetAnalyser : Form
    {

        Pen m_pen;
        Graphics m_formGraphics;
        public SuperSweetAnalyser()
        {
            InitializeComponent();
            m_pen = new Pen(Color.CadetBlue);
            m_formGraphics = this.CreateGraphics();
            m_formGraphics.DrawLine(m_pen, 0, 0, 200, 200);
            m_pen.Dispose();
            m_formGraphics.Dispose();
        }


    }
}
