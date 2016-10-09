using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int philippaHealth;
    public Phillippa_Health philly_Health;     
    public int simoneHealth;
    public int eliseHealth;
    public int solveigHealth;
    public Scrollbar philippaScrollBar;
    public Scrollbar simoneScrollBar;
    public Scrollbar eliseScrollBar;
    public Scrollbar solveigScrollBar;

    void Start()
    {
        philippaHealth = philly_Health.m_currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void TakeDamagePhilippa(int amount)
    {
        philippaHealth -= amount;
        philippaScrollBar.size = philippaHealth / 200f;
        Debug.Log(philippaScrollBar.size);


        if (philippaHealth <= 0)
        {
            PhilippaIsDead();
        }
    }

    public void TakeDamageSimone(int amount)
    {
        simoneHealth -= amount;
        simoneScrollBar.size = simoneHealth / 100f;
       

        if(simoneHealth <= 0)
        {
            SimoneIsDead();
        }
    }

    public void TakeDamageElise(int amount)
    {
        eliseHealth -= amount;
        eliseScrollBar.size = eliseHealth / 100f;


        if (eliseHealth <= 0)
        {
            EliseIsDead();
        }
    }

    public void TakeDamageSolveig(int amount)
    {
        eliseHealth -= amount;
        solveigScrollBar.size = eliseHealth / 100f;


        if (eliseHealth <= 0)
        {
            SolveigIsDead();
        }
    }

    public void PhilippaIsDead()
    {
        //animation
        //sound
    }

    public void SimoneIsDead()
    {
        //animation
        //sound
    }

    public void EliseIsDead()
    {
        //animation
        //sound
    }
    public void SolveigIsDead()
    {
        //animation
        //sound
    }

}
