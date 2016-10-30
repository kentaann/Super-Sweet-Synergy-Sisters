using UnityEngine;
using System.Collections;

public class Channeling_script : MonoBehaviour 
{
    public float m_maxRange;                            // The max range of the ability

    private const float m_GROWTHFACTOR = 2;             // The factor at which the beam grows    
    private const float m_POSITIONALOFFSET = 2;         // The offset for making the ability appear to remain in its original position
    private const float m_GROWTHRATE = 1;               // The modifier for the Y-axis scaler


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
                transform.localScale += new Vector3(0, m_GROWTHRATE, 0) * Time.deltaTime * m_GROWTHFACTOR;
                transform.localPosition += new Vector3(m_POSITIONALOFFSET, 0, 0) * Time.deltaTime;
                yield return null;
            }
        }

    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
