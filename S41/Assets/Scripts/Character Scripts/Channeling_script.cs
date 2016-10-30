#region Using Statements

using UnityEngine;
using System.Collections;

#endregion

public class Channeling_script : MonoBehaviour
{
    #region Variables

    public float m_maxRange;                            // The max range of the ability

    private const float m_GROWTHFACTOR = 2;             // The factor at which the beam grows    
    private const float m_POSITIONALOFFSET = 2;         // The offset for making the ability appear to remain in its original position
    private const float m_GROWTHRATE = 1;               // The modifier for the Y-axis scaler

    #endregion

    #region Start

    void Start () 
    {
        StartCoroutine(Expand());
	}

    #endregion

    #region Expand function

    /// <summary>
    /// Expands the gameobject over time as well as moving it the to make it appear as though it's origin is stationary
    /// </summary>
    /// <returns></returns>
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

    #endregion

    #region Update

	void Update () 
    {

    }

    #endregion
}
