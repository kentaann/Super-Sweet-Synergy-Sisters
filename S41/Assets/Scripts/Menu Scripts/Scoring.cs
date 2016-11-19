#region Using Statements

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

#endregion

public class Scoring : MonoBehaviour
{
    // creating an empty GameObject and attach "singleton" element to it. 
    public int score = 0;
    private static Scoring m_Instance;     
    public Text text;

    public int Score
    { get { return score; } set { score = value; } }

    public static Scoring Instance
    { get { return m_Instance; } }

    void Start()
    {
        if(m_Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        m_Instance = this;
    }

    void Update()
    {
        text.text = score.ToString();

    }

}
