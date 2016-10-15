using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

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
    //public string yo;
    //public string test;
    // Bara för att testa interaktion:
    float timer = 0;
    public bool deadPh = false;
    public bool deadEl = false;
    public bool deadSi = false;
    public bool deadSol = false;

    void Start()
    {
        
        deadPh = false;
        deadEl = false;
        deadSi = false;
        deadSol = false;
       
    }

    // Update is called once per frame
    void Update()
    {

        //The timer is not supposed to be in use. It is merely to test out cross-script communication
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            TakeDamagePhilippa(30);
            TakeDamageElise(20);
            TakeDamageSimone(20);
            TakeDamageSolveig(20);
            timer = 0;
        }

        GameOverMenu();
    }

    public void TakeDamagePhilippa(int amount)
    {
        philippaHealth -= amount;
        philippaScrollBar.size = philippaHealth / 200f;



        if (philippaHealth <= 0)
        {
            PhilippaIsDead();
            deadPh = true;
        }
    }

    public void TakeDamageSimone(int amount)
    {
        simoneHealth -= amount;
        simoneScrollBar.size = simoneHealth / 100f;


        if (simoneHealth <= 0)
        {
            SimoneIsDead();
            deadSi = true;
        }
    }

    public void TakeDamageElise(int amount)
    {
        eliseHealth -= amount;
        eliseScrollBar.size = eliseHealth / 100f;


        if (eliseHealth <= 0)
        {
            EliseIsDead();
            deadEl = true;
        }
    }

    public void TakeDamageSolveig(int amount)
    {
        eliseHealth -= amount;
        solveigScrollBar.size = eliseHealth / 100f;


        if (eliseHealth <= 0)
        {
            SolveigIsDead();
            deadSol = true;
        }
    }

    public void GameOverMenu()
    {
        if (deadSol == true && deadSi == true && deadPh == true && deadEl == true)
        {
            SceneManager.LoadScene("GamOver");
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
