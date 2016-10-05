using UnityEngine;
using System.Collections;

public class Player_Health : MonoBehaviour {

    public int m_maxHealth = 100;
    public int m_currentHealth = 100;

    public float m_healthbarLength;

	// Use this for initialization
	void Start ()
    {
        m_healthbarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
        AdjustCurrentHP(0);
	}

    void OnGUI()
    {
        GUI.Box(new Rect(10,10, m_healthbarLength, 20), m_currentHealth + "/" + m_maxHealth);
    }

    public void AdjustCurrentHP(int adjustment)
    {
        m_currentHealth += adjustment;
        if(m_currentHealth <= 0)
        {
            m_currentHealth = 0;
        }

        if(m_currentHealth > m_maxHealth)
        {
            m_currentHealth = m_maxHealth;
        }

        if(m_maxHealth < 1)
        {
            m_maxHealth = 1;
        }

        m_healthbarLength = (Screen.width / 2) * (m_currentHealth / (float)m_maxHealth);
    }
}
