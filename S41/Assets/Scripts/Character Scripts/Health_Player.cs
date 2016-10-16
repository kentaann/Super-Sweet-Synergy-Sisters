using UnityEngine;
using System.Collections;

public class Health_Player : MonoBehaviour 
{
    public int m_startingHealth = 100;
    public int m_currentHealth;
    
    private bool isDead;
    private bool isDamaged;

    Player_Movement playerMovement;
    PlayerHealth ph;
    Simone_Attack simoneAttack;
    Phillippa_Attack phillippaAttack;

    void Awake()
    {
        playerMovement = GetComponent<Player_Movement>();
        simoneAttack = GetComponent<Simone_Attack>();
        phillippaAttack = GetComponent<Phillippa_Attack>();

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
        isDamaged = true;

        m_currentHealth -= amount;

        //if(m_currentHealth <= 0 && !isDead)
        //{
        //    Death();
        //}
    }

    void Death()
    {
        isDead = true;
        phillippaAttack.enabled = false;
        playerMovement.enabled = false;
    }
}
