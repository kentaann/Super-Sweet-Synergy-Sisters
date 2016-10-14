using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int philippaHealth;
    public int simoneHealth;
    public int eliseHealth;
    public int solveigHealth;
    public Scrollbar philippaScrollBar;
    public Scrollbar simoneScrollBar;
    public Scrollbar eliseScrollBar;
    public Scrollbar solveigScrollBar;
    public string yo;
    // Bara för att testa interaktion:
    float timer = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //The timer is not supposed to be in use. It is merely to test out cross-script communication
        timer += Time.deltaTime;

        if(timer >= 1)
        {
            TakeDamagePhilippa(10);
            timer = 0;
        }
    }

    public void TakeDamagePhilippa(int amount)
    {
        philippaHealth -= amount;
        philippaScrollBar.size = philippaHealth / 200f;



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
