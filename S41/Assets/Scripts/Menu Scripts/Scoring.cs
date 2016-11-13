#region Using Statements

using UnityEngine;
using System.Collections;

#endregion

public class Scoring : MonoBehaviour
{
    #region Variables

    public float m_currentScore;            // The current score of the group
    public float m_topScore;                // The highest score saved

    private float m_scoreToSave;            // The current score at the end of the round

    #endregion

    public Scoring()
    {

    }

    void Start () 
    {
	
	}
	
	void Update () 
    {
	
	}

    public void UpdateScore(float point)
    {
        m_currentScore += point;
    }

    public void SaveScore()
    {
        m_scoreToSave = m_currentScore;
    }
}
