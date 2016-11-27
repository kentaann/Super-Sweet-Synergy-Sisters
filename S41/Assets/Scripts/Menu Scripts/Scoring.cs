using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;




public class Scoring : MonoBehaviour
{
    
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
        score = 0;
        if (m_Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        m_Instance = this;


    }   

    void FixedUpdate()
    {
        text.text = score.ToString();
    }

    public void SaveHighScore()
    {
        Debug.Log("SAvestart");
        List<int> list = new List<int>();
        list = LoadHighScore();
        if (list.Count == 0)
        {
            list.Add(score);
        }
        else
        {
            bool isAdded = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < score)
                {
                    list.Insert(i, score);
                    Debug.Log("saveinsert");
                    isAdded = true;
                    break;
                }

            }
            if(!isAdded)
            {
                list.Add(score);
                Debug.Log("added");
            }
        }
        
        if(list.Count > 10)
        {
            list.Remove(10);
            Debug.Log("remove");
        }
        for (int i = 0; i < list.Count; i++)
        {
            string highScoreName = "HighScore_" + i.ToString();
            Debug.Log(highScoreName);
            PlayerPrefs.SetInt(highScoreName, list[i]);            
        }       
    }

    public List<int> LoadHighScore()
    {
        List<int> lista = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            string highScoreName = "HighScore_" + i.ToString();
            if (PlayerPrefs.HasKey(highScoreName))
            {
                lista.Add(PlayerPrefs.GetInt(highScoreName));                
            }
        }
        lista.Sort();
        lista.Reverse();
        return lista;
    }

}
