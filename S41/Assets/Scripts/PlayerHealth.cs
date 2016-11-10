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

    public GameObject simone;
    public GameObject solveig;
    public GameObject philippa;
    public GameObject elise;

    FixedPlayerHealth fixedPlayerHealth_Simone;
    FixedPlayerHealth fixedPlayerHealth_Solveig;
    FixedPlayerHealth fixedPlayerHealth_Philippa;
    FixedPlayerHealth fixedPlayerHealth_Elise;

    void Start()
    {
        //all visual feedback about the players' health in this class gets connected to what is actually happening to the objects in the FixedPlayerHealth class

        fixedPlayerHealth_Simone = simone.GetComponent<FixedPlayerHealth>();
        fixedPlayerHealth_Solveig = solveig.GetComponent<FixedPlayerHealth>();
        fixedPlayerHealth_Philippa = philippa.GetComponent<FixedPlayerHealth>();
        fixedPlayerHealth_Elise = elise.GetComponent<FixedPlayerHealth>();


        simoneHealth = fixedPlayerHealth_Simone.GetHealth();
        solveigHealth = fixedPlayerHealth_Solveig.GetHealth();
        philippaHealth = fixedPlayerHealth_Philippa.GetHealth();
        eliseHealth = fixedPlayerHealth_Elise.GetHealth();

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

        //if (timer >= 1)
        //{
        //    TakeDamagePhilippa(30);
        //    TakeDamageElise(20);
        //    TakeDamageSimone(20);
        //    TakeDamageSolveig(20);
        //    timer = 0;
        //}

        simoneHealth = fixedPlayerHealth_Simone.GetHealth();
        simoneScrollBar.size = simoneHealth / 100f;

        solveigHealth = fixedPlayerHealth_Solveig.GetHealth();
        solveigScrollBar.size = solveigHealth / 100f;

        philippaHealth = fixedPlayerHealth_Philippa.GetHealth();
        philippaScrollBar.size = philippaHealth / 100f;

        eliseHealth = fixedPlayerHealth_Elise.GetHealth();
        eliseScrollBar.size = eliseHealth / 100f;

        //GameOverMenu();
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

    //void OnCollisionEnter(Collision other)            //spelar ingen roll, för den ligger inte i själva karaktärernas prefab
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        TakeDamagePhilippa(20);
    //        TakeDamageElise(20);
    //        TakeDamageSimone(20);
    //        TakeDamageSolveig(20);
    //        Debug.Log("Hit player");
    //    }
    //}

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
