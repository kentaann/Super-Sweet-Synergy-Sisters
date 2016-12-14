using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameOver : MonoBehaviour {

    public GameObject quitGameButton;
    public GameObject startGameButton;
    public GameObject scoreListButton;    

    public Image scoreListBG;
    public Text scoreListText;

    public Text currentScoreTextNumber;

    bool isScoreListOpened;

    public Text scoreText;
    public Text newHighScore;

    public Text scoreBoardText;     

    string hScore = "HighScore";
    int score;

	// Use this for initialization
	void Start () {
        
        startGameButton = GameObject.Find("RestartButton");
        quitGameButton = GameObject.Find("Quit");
        scoreListButton = GameObject.Find("Highscore");
        scoreListBG.enabled = false;
        scoreListText.enabled = false; 

        score = Scoring.Instance.score;              

        
        
        Scoring.Instance.SaveHighScore();
        ShowHighScore();
        isScoreListOpened = false;
	}
	
	// Update is called once per frame
	void Update () {

        currentScoreTextNumber.text = score.ToString();
        Restart();
        Quit();
        HighScoreMenu();
        
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

    // Shows the last 10 games score
    public void HighScoreMenu()
    {
        if (Input.GetKeyDown("joystick button 7") || Input.GetKeyDown(KeyCode.M))
        {
            isScoreListOpened = !isScoreListOpened;
            if (isScoreListOpened)
            {
                scoreListBG.enabled = true;
                scoreListText.enabled = true;
               
                
            }
            else
            {
                scoreListBG.enabled = false;
                scoreListText.enabled = false;
                
            }
        }
    }

   public void ShowHighScore()
   {
       
       List<int> lista = new List<int>();       
       lista = Scoring.Instance.LoadHighScore();
       scoreBoardText.text = "\n";
       foreach(int s in lista)
       {
           scoreBoardText.text += s.ToString() + "\n";
       }  
   }
}
