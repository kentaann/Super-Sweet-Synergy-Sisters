using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

    public Image pausePanel;
    public Image controlPanel;
    
    public Text pauseTextinMenu;
    public Text controlsText;

    public GameObject controlsButton;
    public GameObject resumeGameButton;
    public GameObject quitButton;

    bool menuOpened = false;
    bool controlsOpened = false;


    void Awake()
    {
        quitButton = GameObject.Find("QuitButton");
        controlsButton = GameObject.Find("ControlsButton");
        resumeGameButton = GameObject.Find("ResumeButton");

        pausePanel = pausePanel.GetComponent<Image>();
        controlPanel = controlPanel.GetComponent<Image>();

        pausePanel.enabled = false;
        controlPanel.enabled = false;

        quitButton.SetActive(false);
        resumeGameButton.SetActive(false);
        controlsButton.SetActive(false);

        pauseTextinMenu.enabled = false;
        controlsText.enabled = false;

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
                menuOpened = false;
                Debug.Log("pressedOpenPause");

            }
            else
            {
                Time.timeScale = 1.0f;
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
                controlsText.enabled = true;
                controlsOpened = false;

            }
            else
            {
                controlPanel.enabled = false;
                controlsText.enabled = false;
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
