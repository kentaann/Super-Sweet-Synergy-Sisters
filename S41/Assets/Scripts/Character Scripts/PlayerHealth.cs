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
    public bool m_writeThatJson = false;

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
                
        simoneHealth = fixedPlayerHealth_Simone.GetHealth();
        simoneScrollBar.size = simoneHealth / fixedPlayerHealth_Simone.GetMaxHealth();

        solveigHealth = fixedPlayerHealth_Solveig.GetHealth();
        solveigScrollBar.size = solveigHealth / fixedPlayerHealth_Solveig.GetMaxHealth();

        philippaHealth = fixedPlayerHealth_Philippa.GetHealth();
        philippaScrollBar.size = philippaHealth / fixedPlayerHealth_Philippa.GetMaxHealth();

        eliseHealth = fixedPlayerHealth_Elise.GetHealth();
        eliseScrollBar.size = eliseHealth / fixedPlayerHealth_Elise.GetMaxHealth();



        CheckHealthForGameOver();
        GameOverMenu();
    }

    public void CheckHealthForGameOver()
    {
        if (philippaHealth <= 0)
        {           
            deadPh = true;
        }

        if (simoneHealth <= 0)
        {            
            deadSi = true;
        }

        if (eliseHealth <= 0)
        {           
            deadEl = true;
        }


        if (solveigHealth <= 0)
        {           
            deadSol = true;
        }

    }
   
    public void GameOverMenu()
    {
        if (deadSol == true && deadSi == true && deadPh == true && deadEl == true)
        {
            m_writeThatJson = true;
            SceneManager.LoadScene("GamOver");
        }
    }   
}
