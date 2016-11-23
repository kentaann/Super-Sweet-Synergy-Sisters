using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;




public class Scoring : MonoBehaviour
{
    //high Score here?? 
    public int highScore;
    public List<int> highScoreList = new List<int>();

    string hScore = "HighScore";

    // creating an empty GameObject and attach "singleton" element to it. 
    public int score = 0;
    private static Scoring m_Instance;
    public Text text;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            PlayerPrefs.SetInt(hScore, score); PlayerPrefs.Save();
        }
    }

    public static Scoring Instance { get { return m_Instance; } }

    void Start()
    {
        highScore = 0;
        if (m_Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        m_Instance = this;        
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        text.text = score.ToString();

        //Debug.Log(score);
        // AddScoreToList();
    }

    public void AddScoreToList()
    {
        highScoreList.Add(score);
        highScoreList.Sort();
        highScoreList.Reverse();
        Debug.Log(highScoreList);
    }

}
