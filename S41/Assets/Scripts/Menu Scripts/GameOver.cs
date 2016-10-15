using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {


    public GameObject quitGameButton;
    public GameObject startGameButton;
	// Use this for initialization
	void Start () {
        startGameButton = GameObject.Find("RestartButton");
        quitGameButton = GameObject.Find("Quit");
	}
	
	// Update is called once per frame
	void Update () {
        Restart();
        Quit();
	}


    public void Restart()
    {
        if (Input.GetKeyDown("joystick button 2") || Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Restart");
        }
    }

    public void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown("joystick button 6"))
        {
            Application.Quit();
        }
    }
}
