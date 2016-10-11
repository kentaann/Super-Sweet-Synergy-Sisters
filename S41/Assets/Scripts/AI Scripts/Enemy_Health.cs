using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour {

    public float m_maxHealth = 100;
    public float m_currentHealth = 100;

    private bool m_dead;

    private void OnEnable()
    {
        m_currentHealth = m_maxHealth;
        m_dead = false;

    }

    public void TakeDamage(float amount)
    {
        Debug.Log("SKADAD MAFFAGGA!!!");
        m_currentHealth -= amount;

        if(m_currentHealth <= 0f && !m_dead)
        {
            OnDeath();
        }
    }



    private void OnDeath()
    {
        m_dead = true;

        gameObject.SetActive(false);
    }

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        AdjustCurrentHP(0);
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

    }
}
