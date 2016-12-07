using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
    public GameObject resumeGameButton;
    public GameObject quitButton;

    public GameObject enemySpawn;
    public GameObject solveig;
    public GameObject phillippa;
    public GameObject elise;
    public GameObject simone;
    public GameObject phillippaWhisk;

    bool menuOpened = false;
    bool controlsOpened = false;


    void Awake()
    {
        quitButton = GameObject.Find("QuitButton");
        controlsButton = GameObject.Find("ControlsButton");
        resumeGameButton = GameObject.Find("ResumeButton");

        enemySpawn = GameObject.Find("Spawn Manager");
        solveig = GameObject.Find("Player");
        elise = GameObject.Find("Player3");
        phillippa = GameObject.Find("Player4");
        simone = GameObject.Find("Player2");
        phillippaWhisk = GameObject.Find("BalloonWhisk");

        enemySpawn.GetComponent<WaveSpawner>().enabled = true;

        solveig.GetComponent<Player_Movement>().enabled = true;
        solveig.GetComponent<PlayerController>().enabled = true;
        solveig.GetComponent<Solveig_Attack>().enabled = true;
        // health should be disabled?

        elise.GetComponent<Player_Movement>().enabled = true;
        elise.GetComponent<PlayerController>().enabled = true;
        elise.GetComponent<Elise_Attack>().enabled = true;

        simone.GetComponent<Player_Movement>().enabled = true;
        simone.GetComponent<PlayerController>().enabled = true;
        simone.GetComponent<Simone_Attack>().enabled = true;

        phillippa.GetComponent<Player_Movement>().enabled = true;
        phillippa.GetComponent<PlayerController>().enabled = true;
        phillippa.GetComponent<Phillippa_Attack>().enabled = true;

        phillippaWhisk.GetComponent<WhiskAttack>().enabled = true;

        pausePanel = pausePanel.GetComponent<Image>();
        controlPanel = controlPanel.GetComponent<Image>();

        pausePanel.enabled = false;
        controlPanel.enabled = false;

        quitButton.SetActive(false);
        resumeGameButton.SetActive(false);
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
        ResumeGame();
        OpenControls();
    }

    // Open the pause menu, the game is paused
    public void OpenMenu()
    {
        //the escape or the back button on xbox opens it
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 6"))
        {
            if (menuOpened && Time.timeScale == 1.0f)
            {
                Time.timeScale = 0f;
                pausePanel.enabled = true;
                pauseTextinMenu.enabled = true;
                quitButton.SetActive(true);
                resumeGameButton.SetActive(true);
                controlsButton.SetActive(true);

                enemySpawn.GetComponent<WaveSpawner>().enabled = false;

                solveig.GetComponent<Player_Movement>().enabled = false;
                solveig.GetComponent<PlayerController>().enabled = false;
                solveig.GetComponent<Solveig_Attack>().enabled = false;

                elise.GetComponent<Player_Movement>().enabled = false;
                elise.GetComponent<PlayerController>().enabled = false;
                elise.GetComponent<Elise_Attack>().enabled = false;

                simone.GetComponent<Player_Movement>().enabled = false;
                simone.GetComponent<PlayerController>().enabled = false;
                simone.GetComponent<Simone_Attack>().enabled = false;

                phillippa.GetComponent<Player_Movement>().enabled = false;
                phillippa.GetComponent<PlayerController>().enabled = false;
                phillippa.GetComponent<Phillippa_Attack>().enabled = false;

                phillippaWhisk.GetComponent<WhiskAttack>().enabled = false;


                menuOpened = false;
                Debug.Log("pressedOpenPause");

            }
            else
            {
                Time.timeScale = 1.0f;

                enemySpawn.GetComponent<WaveSpawner>().enabled = true;

                solveig.GetComponent<Player_Movement>().enabled = true;
                solveig.GetComponent<PlayerController>().enabled = true;
                solveig.GetComponent<Solveig_Attack>().enabled = true;

                elise.GetComponent<Player_Movement>().enabled = true;
                elise.GetComponent<PlayerController>().enabled = true;
                elise.GetComponent<Elise_Attack>().enabled = true;

                simone.GetComponent<Player_Movement>().enabled = true;
                simone.GetComponent<PlayerController>().enabled = true;
                simone.GetComponent<Simone_Attack>().enabled = true;

                phillippa.GetComponent<Player_Movement>().enabled = true;
                phillippa.GetComponent<PlayerController>().enabled = true;
                phillippa.GetComponent<Phillippa_Attack>().enabled = true;

                phillippaWhisk.GetComponent<WhiskAttack>().enabled = true;


                pausePanel.enabled = false;
                pauseTextinMenu.enabled = false;
                quitButton.SetActive(false);
                controlsButton.SetActive(false);
                resumeGameButton.SetActive(false);
                menuOpened = true;
            }
        }
    }

    public void OpenControls()
    {
        // Open it with Left Bumper
        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown("joystick button 5"))
        {
            if (controlsOpened && !menuOpened)
            {

                controlPanel.enabled = true;                
                phillippaControlsText.enabled = true;
                eliseControlsText.enabled = true;
                simoneControlsText.enabled = true;
                solveigControlsText.enabled = true;
                commonButtonsText.enabled = true;
                controlsOpened = false;

            }
            else
            {
                controlPanel.enabled = false;                
                phillippaControlsText.enabled = false;
                eliseControlsText.enabled = false;
                simoneControlsText.enabled = false;
                solveigControlsText.enabled = false;
                commonButtonsText.enabled = false;
                controlsOpened = true;
            }
        }

    }

    // Leave the game (Closes the whole game)   -> maybe it should go back to the Main menu and do not save the game????
    public void QuitGameInGameMenu()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown("joystick button 4"))
        {
            Application.Quit();
        }
    }

    // The game continues
    public void ResumeGame()
    {
        // Resume with start
        if (Input.GetKeyDown(KeyCode.F1) || Input.GetKeyDown("joystick button 7"))
        {
            Time.timeScale = 1.0f;
            pausePanel.enabled = false;
            pauseTextinMenu.enabled = false;
            quitButton.SetActive(false);
            controlsButton.SetActive(false);
            resumeGameButton.SetActive(false);
        }
    }
}
