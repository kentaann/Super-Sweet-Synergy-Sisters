using UnityEngine;
using System.Collections;

public class Channeling_script : MonoBehaviour 
{
    public float m_maxRange;                 // The max range of the ability
    public float m_growthRate;               // The rate at which the beam grows
    public float m_waitTime;

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(Expand());
	}

    IEnumerator Expand()
    {
        float timer = 0;

        while (true)
        {
            while (m_maxRange > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(0, 1, 0) * Time.deltaTime * m_growthRate;
                transform.localPosition += new Vector3(2, 0, 0) * Time.deltaTime;
                yield return null;
            }
        }

    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
