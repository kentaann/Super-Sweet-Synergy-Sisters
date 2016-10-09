using UnityEngine;
using System.Collections;

public class Phillippa_Health : MonoBehaviour
{
    public int m_startingHealth = 100;
    public int m_currentHealth;

    private bool m_isDead;
   
    void Awake()
    {
        m_currentHealth = m_startingHealth;
    }
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void TakeDamage(int amount)
    {
        m_currentHealth -= amount;
    }
}
