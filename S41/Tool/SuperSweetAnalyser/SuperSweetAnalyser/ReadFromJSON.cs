using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace SuperSweetAnalyser
{
    public class ReadFromJSON
    {
        public int m_phFluffCount = 0;
        public int m_phRushCount = 0;
        public int m_siWhippCount = 0;
        public int m_siEnerCount = 0;
        public int m_siSpicyCount = 0;
        public int m_soFlowerCount = 0;
        public int m_soSongCount = 0;
        public int m_elTrapCount = 0;
        public int m_elMultiCount = 0;


        public string m_printStats = "";

        public ReadFromJSON()
        {
            m_printStats = "Fluffpound used: " + m_phFluffCount + "\n Anger Issues used: " + m_phRushCount + "\n Whipped Cream used: " + m_siWhippCount
                + "\n Energy Drink used: " + m_siEnerCount + "\n Spicy Chocolate used: " + m_siSpicyCount;
        }
    }
}
