//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;

//public class High_Score_Manager : MonoBehaviour
//{
//    //public Text score;
//    private static High_Score_Manager m_Instance;
//    private const int ScoreBoardLength = 10;
//    //public List<Scoring> highScore_List = new List<Scoring>();

//    public static High_Score_Manager _instance
//    {
//        get
//        {
//            if (m_Instance == null)
//            {
//                m_Instance = new GameObject("High_Score_Manager").AddComponent<High_Score_Manager>();
//            }
//            return m_Instance;
//        }
//    }

//    void Awake()
//    {
//        if (m_Instance == null)
//        {
//            m_Instance = this;
//        }
//        else if (m_Instance != null)
//        {
//            Destroy(gameObject);
//        }
//        DontDestroyOnLoad(gameObject);
//    }

//    // Use this for initialization
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    //Saving the high score
//    public void SaveHighScore(int score)
//    {
//        List<Scoring> highScore_List = new List<Scoring>();

//        int i = 1;

//        while (i <= ScoreBoardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
//        {
//            Scoring temp = new Scoring();
//            temp.score = PlayerPrefs.GetInt("HighScore" + i);
//            highScore_List.Add(temp);
//            i++;
//        }
//        if (highScore_List.Count == 0)
//        {
//            Scoring _temp = new Scoring();
//            _temp.score = score;
//            highScore_List.Add(_temp);

//        }
//        else
//        {
//            for (i = 1; i <= highScore_List.Count && i <= ScoreBoardLength; i++)
//            {
//                if(score > highScore_List[i-1].score)
//                {
//                    Scoring _temp = new Scoring();
//                    _temp.score = score;
//                    highScore_List.Insert(i - 1, _temp);
//                    break;
//                }
//                if(i == highScore_List.Count && i < ScoreBoardLength)
//                {
//                    Scoring _temp = new Scoring();
//                    _temp.score = score;
//                    highScore_List.Add(_temp);
//                    break;
//                }
//            }
//        }
//        i = 1;
//        while(i <= highScore_List.Count && i <= ScoreBoardLength)
//        {
//            PlayerPrefs.SetInt("HighScore" + i + "score", highScore_List[i - 1].score);
//            i++;
//        }
//    }

//    // a list of the existing scores
//    public List<Scoring> GetHighScores()
//    {
//        List<Scoring>  highScore_List = new List<Scoring>();
//        int i = 1;
//        while(i <= ScoreBoardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
//        {
//            Scoring temp = new Scoring();
//            temp.score = PlayerPrefs.GetInt("HighScore" + i + "score");
//            highScore_List.Add(temp);
//            i++;
//        }
//        return highScore_List;
//    }

//    // Clears the scoreboard - for testing
//    public void ClearScoreBoard()
//    {
//        List<Scoring> highScores = GetHighScores();
//        for (int i = 1; i < highScores.Count; i++)
//        {
//            PlayerPrefs.DeleteKey("HighScore" + i + "score");
//        }
//    }

//    // dont know if it needs or not.

//    void OnApplicationQuit()
//    {
//        PlayerPrefs.Save();
//    }
//}
