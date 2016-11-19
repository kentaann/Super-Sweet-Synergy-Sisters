#region Using Statements

using UnityEngine;
using System.Collections;

#endregion

public class Scoring : MonoBehaviour
{

    public int score;
    EnemyHealth AI_Health;

    void Start()
    {
        AI_Health = GetComponent<EnemyHealth>(); 
        score = 0;
    }

    void Update()
    {
        TakeScore();
    }

    public void TakeScore()
    {
        if (AI_Health.health <= 0)
        {
            score += 10;
            Debug.Log(AI_Health.health);
        }
    }

}
