using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public Image pausePanel;
    public Image controlPanel;

    public Text pauseTextinMenu;
    public Text phillippaControlsText;
    public Text eliseControlsText;
    public Text simoneControlsText;
    public Text solveigControlsText;
    public Text commonButtonsText;

    public GameObject controlsButton;
    
    public GameObject quitButton;

    public GameObject enemySpawn;
    public GameObject solveig;
    public GameObject phillippa;
    public GameObject elise;
    public GameObject simone;

    public GameObject eliseAutoAttack;
 

    bool menuOpened = false;
    bool controlsOpened = false;


    void Awake()
    {
        quitButton = GameObject.Find("QuitButton");
        controlsButton = GameObject.Find("ControlsButton");

        enemySpawn = GameObject.Find("Spawn Manager");
        solveig = GameObject.Find("Solveig_Animated");
        elise = GameObject.Find("Elise_Animated");
        phillippa = GameObject.Find("Philippa_anim");
        simone = GameObject.Find("Simone_Animated");
       
        // players attack, enemy spawn true while pause menu is not opened 
        enemySpawn.GetComponent<WaveSpawner>().enabled = true;
        

        solveig.GetComponent<Player_Movement>().enabled = true;
        solveig.GetComponent<PlayerController>().enabled = true;
        solveig.GetComponent<Solveig_Attack>().enabled = true;
        solveig.GetComponentInChildren<Song_Script>().enabled = true;      

        elise.GetComponent<Player_Movement>().enabled = true;
        elise.GetComponent<PlayerController>().enabled = true;
        elise.GetComponent<Elise_Attack>().enabled = true;        

        simone.GetComponent<Player_Movement>().enabled = true;
        simone.GetComponent<PlayerController>().enabled = true;
        simone.GetComponent<Simone_Attack>().enabled = true;

        phillippa.GetComponent<Player_Movement>().enabled = true;
        phillippa.GetComponent<PlayerController>().enabled = true;
        phillippa.GetComponent<Phillippa_Attack>().enabled = true;
        phillippa.GetComponentInChildren<WhiskAttack>().enabled = true;
        phillippa.GetComponentInChildren<Fluff_Script>().enabled = true;
        phillippa.GetComponentInChildren<SpicyWhisk>().enabled = true;
        phillippa.GetComponentInChildren<EnergyWhisk>().enabled = true;

        pausePanel = pausePanel.GetComponent<Image>();
        controlPanel = controlPanel.GetComponent<Image>();

        pausePanel.enabled = false;
        controlPanel.enabled = false;

        quitButton.SetActive(false);
       
        controlsButton.SetActive(false);

        pauseTextinMenu.enabled = false;
        phillippaControlsText.enabled = false;
        eliseControlsText.enabled = false;
        simoneControlsText.enabled = false;
        solveigControlsText.enabled = false;
        commonButtonsText.enabled = false;

        menuOpened = false;
        controlsOpened = false;
    }

    void Update()
    {
        OpenMenu();
        QuitGameInGameMenu();
       
        OpenControls();
    }

    // Open the pause menu, the game is paused
    public void OpenMenu()
    {
        //the escape or the back button on xbox opens it
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 6"))
        {
            menuOpened = !menuOpened;

            //menu is opened
            if (menuOpened && Time.timeScale == 1.0f)
            {
                Time.timeScale = 0f;
                pausePanel.enabled = true;
                pauseTextinMenu.enabled = true;
                quitButton.SetActive(true);
               
                controlsButton.SetActive(true);

                enemySpawn.GetComponent<WaveSpawner>().enabled = false;            


                solveig.GetComponent<Player_Movement>().enabled = false;
                solveig.GetComponent<PlayerController>().enabled = false;
                solveig.GetComponent<Solveig_Attack>().enabled = false;
                solveig.GetComponentInChildren<Song_Script>().enabled = false;

                elise.GetComponent<Player_Movement>().enabled = false;
                elise.GetComponent<PlayerController>().enabled = false;
                elise.GetComponent<Elise_Attack>().enabled = false;

                simone.GetComponent<Player_Movement>().enabled = false;
                simone.GetComponent<PlayerController>().enabled = false;
                simone.GetComponent<Simone_Attack>().enabled = false;

                phillippa.GetComponent<Player_Movement>().enabled = false;
                phillippa.GetComponent<PlayerController>().enabled = false;
                phillippa.GetComponent<Phillippa_Attack>().enabled = false;
                phillippa.GetComponentInChildren<WhiskAttack>().enabled = false;
                phillippa.GetComponentInChildren<Fluff_Script>().enabled = false;
                phillippa.GetComponentInChildren<SpicyWhisk>().enabled = false;
                phillippa.GetComponentInChildren<EnergyWhisk>().enabled = false;
               
            }
            else if (!controlsOpened)
            {
                //menu is not opened
                Time.timeScale = 1.0f;
                enemySpawn.GetComponent<WaveSpawner>().enabled = true;

                solveig.GetComponent<Player_Movement>().enabled = true;
                solveig.GetComponent<PlayerController>().enabled = true;
                solveig.GetComponent<Solveig_Attack>().enabled = true;
                solveig.GetComponentInChildren<Song_Script>().enabled = true;

                elise.GetComponent<Player_Movement>().enabled = true;
                elise.GetComponent<PlayerController>().enabled = true;
                elise.GetComponent<Elise_Attack>().enabled = true;

                simone.GetComponent<Player_Movement>().enabled = true;
                simone.GetComponent<PlayerController>().enabled = true;
                simone.GetComponent<Simone_Attack>().enabled = true;

                phillippa.GetComponent<Player_Movement>().enabled = true;
                phillippa.GetComponent<PlayerController>().enabled = true;
                phillippa.GetComponent<Phillippa_Attack>().enabled = true;
                phillippa.GetComponentInChildren<WhiskAttack>().enabled = true;
                phillippa.GetComponentInChildren<Fluff_Script>().enabled = true;
                phillippa.GetComponentInChildren<SpicyWhisk>().enabled = true;
                phillippa.GetComponentInChildren<EnergyWhisk>().enabled = true;    

                pausePanel.enabled = false;
                pauseTextinMenu.enabled = false;
                quitButton.SetActive(false);
                controlsButton.SetActive(false);
            }
        }
    }

    public void OpenControls()
    {
        // Open it with Left Bumper
        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown("joystick button 5"))
        {
            controlsOpened = !controlsOpened;
            if (controlsOpened && menuOpened)
            {
                // controls are opened
                controlPanel.enabled = true;                
                phillippaControlsText.enabled = true;
                eliseControlsText.enabled = true;
                simoneControlsText.enabled = true;
                solveigControlsText.enabled = true;
                commonButtonsText.enabled = true;
            }
            else
            {
                //controls are not opened
                controlPanel.enabled = false;                
                phillippaControlsText.enabled = false;
                eliseControlsText.enabled = false;
                simoneControlsText.enabled = false;
                solveigControlsText.enabled = false;
                commonButtonsText.enabled = false;
            }
        }
    }

    // Leave the game (Closes the whole game)   -> maybe it should go back to the Main menu and do not save the game????
    public void QuitGameInGameMenu()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown("joystick button 4") && menuOpened)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }    
}
