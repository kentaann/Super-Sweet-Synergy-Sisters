using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

    public Image pausePanel;
    public GameObject quitButton;
    public Text pauseTextinMenu;
    public GameObject controlsButton;
    public GameObject resumeGameButton;  // does not need maybe just pause and resume with the escap button
    // for pause game see : Time.timeScale or Time.fixedDeltaTime


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
    }

    public void OpenMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
}
