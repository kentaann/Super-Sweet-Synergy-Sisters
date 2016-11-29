using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSweetAnalyser
{
    public class HeatMapColorGenerator
    {
        public HeatMapColorGenerator()
        {

        }

        public Color GenerateColor(decimal value, decimal min_value, decimal max_value)
        {
            decimal val = (value - min_value) / (max_value - min_value);
            int redValue = Convert.ToByte(255 * val);
            int greenValue = Convert.ToByte(255 * (1 - val));
            int blueValue = 0;

            return Color.FromArgb(255, redValue, greenValue, blueValue);
        }
    }
}
