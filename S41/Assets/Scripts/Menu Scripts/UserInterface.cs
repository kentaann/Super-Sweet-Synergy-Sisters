using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class UserInterface : MonoBehaviour
{

    // Main Menu
    public GameObject optionsButton;
    public GameObject quitGameButton;
    public GameObject startGameButton;

    public Image optionsMenuBg;

    public Text eliseControlsText;
    public Text phillippaControlsText;
    public Text solveigControlsText;
    public Text simoneControlsText;
    public Text commonControlsText;

    bool optionMenuOpened = false;


    // Use this for initialization
    void Awake()
    {
        optionsButton = GameObject.Find("OptionButton");
        startGameButton = GameObject.Find("StartButton");
        quitGameButton = GameObject.Find("LeaveGameButton");
        optionsMenuBg.enabled = false;


        eliseControlsText.enabled = false;
        phillippaControlsText.enabled = false;
        solveigControlsText.enabled = false;
        simoneControlsText.enabled = false;
        commonControlsText.enabled = false;

        optionMenuOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        OpenOptions();
        QuitGame();
        StartGame();
    }

    // controls list open/close
    public void OpenOptions()
    {
        // open the controls with Left Bumper
        if (Input.GetKeyDown("joystick button 5") || Input.GetKeyDown(KeyCode.F2))
        {
            if (optionMenuOpened)
            {
                optionsMenuBg.enabled = true;

                eliseControlsText.enabled = true;
                phillippaControlsText.enabled = true;
                solveigControlsText.enabled = true;
                simoneControlsText.enabled = true;
                commonControlsText.enabled = true;
                
                optionMenuOpened = false;                
            }
            else
            {
                optionsMenuBg.enabled = false;

                eliseControlsText.enabled = false;
                phillippaControlsText.enabled = false;
                solveigControlsText.enabled = false;
                simoneControlsText.enabled = false;
                commonControlsText.enabled = false;
                
                optionMenuOpened = true;
            }
        }
    }

    // Quit the whole application
    public void QuitGame()
    {
        // need to build to be able to run it   // Quit -> Backs on controller
        if (Input.GetKeyDown("joystick button 6") || Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("QuitPressed");
        }
    }

    //Start the game
    public void StartGame()
    {
        // need to build to be able to run it   // Start the game -> Start button on the controller
        if (Input.GetKeyDown("joystick button 7") || Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("Survival_Level");
            Debug.Log("StartPressed");
        }
    }
}
