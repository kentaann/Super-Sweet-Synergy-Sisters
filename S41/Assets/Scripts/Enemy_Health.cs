using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy_Health : MonoBehaviour {

    public float m_maxHealth = 100;
    public float m_currentHealth = 100;
    public Slider m_healthSlider;
    public Image m_fillImage;

    public Color m_fullHealthColor = Color.yellow;
    public Color m_zeroHealthColor = Color.blue;

    public float m_healthbarLength;

    private bool m_dead;

    private void OnEnable()
    {
        m_currentHealth = m_maxHealth;
        m_dead = false;

        SetHealthUI();
    }

    public void TakeDamage(float amount)
    {
        m_currentHealth -= amount;

        SetHealthUI();

        if(m_currentHealth <= 0f && !m_dead)
        {
            OnDeath();
        }
    }

    private void SetHealthUI()
    {
        m_healthSlider.value = m_currentHealth;

        m_fillImage.color = Color.Lerp(m_zeroHealthColor, m_fullHealthColor, m_currentHealth / m_maxHealth);
    }

    private void OnDeath()
    {
        m_dead = true;

        gameObject.SetActive(false);
    }

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
        GUI.Box(new Rect(10,40, m_healthbarLength, 20), m_currentHealth + "/" + m_maxHealth);
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
