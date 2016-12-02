using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Super_Sweet_Analysis
{
    [Serializable]
    public class JSON_Class
    {
        public Vector3 position;
        public List<Vector3> m_phPosList;              // List of Phillippas positions    
        public List<Vector3> m_siPosList;              // List of Simones positions
        public List<Vector3> m_soPosList;              // List of Solveigs positions
        public List<Vector3> m_elPosList;              // List of Elises positions
        public Vector3 m_phDeathPos;
        public Vector3 m_elDeathPos;
        public Vector3 m_soDeathPos;
        public Vector3 m_siDeathPos;

        public int m_whippedCounter = 0;
        public int m_spicyCounter = 0;
        public int m_energyCounter = 0;
        public int m_flowerCounter = 0;
        public int m_songCounter = 0;
        public int m_fluffCounter = 0;
        public int m_rushCounter = 0;
        public int m_multiShotCounter = 0;
        public int m_trapCounter = 0;
        

        public JSON_Class()
        {
            m_phPosList = new List<Vector3>();
            m_siPosList = new List<Vector3>();
            m_soPosList = new List<Vector3>();
            m_elPosList = new List<Vector3>();
        }

        private void SetPhDeathPosition()
        {
            m_phDeathPos = m_phPosList[m_phPosList.Count - 1];
        }

        private void SetEliseDeathPosition()
        {
            m_elDeathPos = m_elPosList[m_elPosList.Count - 1];
        }

        private void SetSolveigDeathPosition()
        {
            m_soDeathPos = m_soPosList[m_soPosList.Count - 1];
        }

        private void SetSimoneDeathPosition()
        {
            m_siDeathPos = m_siPosList[m_siPosList.Count - 1];
        }

        public void SetAllDeathPosition()
        {
            SetEliseDeathPosition();
            SetPhDeathPosition();
            SetSimoneDeathPosition();
            SetSolveigDeathPosition();
        }
    }
}
