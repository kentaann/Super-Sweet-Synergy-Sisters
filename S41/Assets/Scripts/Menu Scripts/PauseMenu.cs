using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

    public Image pausePanel;
    public GameObject quitButton;
    public Text pauseTextinMenu;
    public GameObject controlsButton;
    public GameObject resumeGameButton;

    bool menuOpened = false;


    void Awake()
    {
        quitButton = GameObject.Find("QuitButton");
        controlsButton = GameObject.Find("ControlsButton");
        resumeGameButton = GameObject.Find("ResumeButton");
        pausePanel = pausePanel.GetComponent<Image>();
        pausePanel.enabled = false;
        quitButton.SetActive(false);
        resumeGameButton.SetActive(false);
        controlsButton.SetActive(false);
        pauseTextinMenu.enabled = false;
        menuOpened = false;

    }

    void Update()
    {
        OpenMenu();
        QuitGameInGameMenu();
        ResumeGame();
    }

    public void OpenMenu()
    {
        //antingen escap eller back button on xbox back
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

    public void QuitGameInGameMenu()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown("joystick button 2"))
        {
            Application.Quit();
        }
    }

    public void ResumeGame()
    {
        if (Input.GetKeyDown(KeyCode.F1) || Input.GetKeyDown("joystick button 3"))
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
