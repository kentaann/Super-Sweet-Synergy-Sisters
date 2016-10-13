using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserInterface : MonoBehaviour {
        
    public GameObject optionsButton;
    public GameObject quitGameButton;    
    public GameObject startGameButton;
    public Image optionsMenuBg;    
    public Text controlsWhatItDoesText;
    public Text controlButtonsText;    
    public Text controlsText;    
    bool optionMenuOpened = false;   
    

    // Use this for initialization
    void Awake ()
    {                
        optionsButton = GameObject.Find("OptionButton");
        startGameButton = GameObject.Find("StartButton");
        quitGameButton = GameObject.Find("LeaveGameButton");
        optionsMenuBg.enabled = false;      
        controlsWhatItDoesText.enabled = false;
        controlButtonsText.enabled = false;        
        controlsText.enabled = false;
        optionMenuOpened = false; 
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        OpenOptions();
        QuitGame();
        StartGame();
    }

    public void OpenOptions()
    {
        if (Input.GetKeyDown("joystick button 7"))
        {
            if (optionMenuOpened)
            {
                optionsMenuBg.enabled = true;
                controlsWhatItDoesText.enabled = true;
                controlButtonsText.enabled = true;
                controlsText.enabled = true;
                optionMenuOpened = false;
                Debug.Log("pressedStart");
            }
            else
            {
                optionsMenuBg.enabled = false;
                controlsWhatItDoesText.enabled = false;
                controlButtonsText.enabled = false;
                controlsText.enabled = false;
                optionMenuOpened = true;
            } 
            
        }
              
    }      

    public void QuitGame()
    {
        // need to build to be able to run it
        Application.Quit();        
    }

    public void StartGame()
    {
        // need to build to be able to run it
        //Application.LoadLevel(1);
    }
}
