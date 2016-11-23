using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {


    public GameObject quitGameButton;
    public GameObject startGameButton;
    public GameObject scoreListButton;

    public Image scoreListBG;
    public Text scoreListText;

    public Text finalScoreText;

    bool isScoreListOpened;



    string hScore = "HighScore";
    int score;
	// Use this for initialization
	void Start () {        
        
        score = PlayerPrefs.GetInt(hScore, 0);
        startGameButton = GameObject.Find("RestartButton");
        quitGameButton = GameObject.Find("Quit");
        scoreListButton = GameObject.Find("Highscore");
        Debug.Log(score);
        
        scoreListBG.enabled = false;
        scoreListText.enabled = false;           

        

        isScoreListOpened = false;
	}
	
	// Update is called once per frame
	void Update () {

       
        Restart();
        Quit();
        HighScoreMenu();
        finalScoreText.text = score.ToString();
	}

    // Restart the game
    public void Restart()
    {
        if (Input.GetKeyDown("joystick button 2") || Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Restart");
        }
    }

    // Leave the game (close)
    public void Quit()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown("joystick button 6"))
        {
            Application.Quit();
        }
    }

    // Shows the last 5 games score
    public void HighScoreMenu()
    {
        if (Input.GetKeyDown("joystick button 7"))
        {
            if (isScoreListOpened)
            {
                scoreListBG.enabled = true;
                scoreListText.enabled = true;
                //scoring.AddScoreToList();    how to write the list???
                //for (int i = 0; i < scoring.highScoreList.Count; i++)
                //{
                //    scoreListText.text = scoring.highScoreList.ToString();
                //}
                isScoreListOpened = false;
            }
            else
            {
                scoreListBG.enabled = false;
                scoreListText.enabled = false;
                isScoreListOpened = true;
            }
        }
    }
}
