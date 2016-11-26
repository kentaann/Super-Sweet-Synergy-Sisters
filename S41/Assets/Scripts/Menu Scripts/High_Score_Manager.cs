using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class High_Score_Manager : MonoBehaviour
{

    private static High_Score_Manager m_Instance;
    private const int ScoreBoardLength = 10;

    public static High_Score_Manager _instance
    {
        get
        {
            if(m_Instance == null)
            {
                m_Instance = new GameObject("High_Score_Manager").AddComponent<High_Score_Manager>();
            }
            return m_Instance;
        }
    }

    void Awake()
    {
        if(m_Instance == null)
        {
            m_Instance = this;
        }
        else if (m_Instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
