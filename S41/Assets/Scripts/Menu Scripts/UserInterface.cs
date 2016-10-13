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
    public bool control = false;
    bool optionMenuOpened = false;   
    

    // Use this for initialization
    void Start ()
    {                
        optionsButton = GameObject.Find("OptionButton");
        startGameButton = GameObject.Find("StartButton");
        quitGameButton = GameObject.Find("LeaveGameButton");
        optionsMenuBg.enabled = false;      
        controlsWhatItDoesText.enabled = false;
        controlButtonsText.enabled = false;        
        controlsText.enabled = false;
        control = false;
        
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public void OpenOptions()
    {
        if (Input.GetKeyDown("X360_Start") && optionMenuOpened == false)
        {
            optionsMenuBg.enabled = true;
            controlsWhatItDoesText.enabled = true;
            controlButtonsText.enabled = true;            
            controlsText.enabled = true;            
            optionMenuOpened = true;
            Debug.Log("pressedStart");
        }
        else
        {
            optionsMenuBg.enabled = false;
            controlsWhatItDoesText.enabled = false;
            controlButtonsText.enabled = false;            
            controlsText.enabled = false;              
            optionMenuOpened = false;
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
