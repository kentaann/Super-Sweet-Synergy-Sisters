﻿#region Using Statements

using UnityEngine;
using System.Collections;

#endregion

public class Channeling_script : MonoBehaviour
{
    #region Variables

    public float m_maxRange;                            // The max range of the ability

    private const float m_GROWTHFACTOR = 3;             // The factor at which the beam grows    
    private const float m_POSITIONALOFFSET = 3;         // The offset for making the ability appear to remain in its original position
    private const float m_GROWTHRATE = 1;               // The modifier for the Y-axis scaler
    private const float m_RADIUS = 0.5f;                // Radius of the beam

    private bool destroy;                               // Bool to destroy object

    private float scaleRate = 2.2f;                     // Scale rate
    private float maxScale = 2.7f;                      // Max scale of the cylinder

    public Vector3 minScale;                            // Min scale of the cylinder
    public Vector3 scale;                               // To check the scale

    private bool scaleIncrease;                         // Tells to start increase
    private bool scaleDecrease;                         // Tells to start decrease
    private bool startIncreaseUpDown;                   // Tells to start increase and decrease on y-axis
    #endregion

    #region Start

    void Start()
    {
        destroy = false;
        StartCoroutine(Expand());
        minScale = transform.localScale;
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

        while (m_maxRange > transform.localScale.y)
        {
            timer += Time.deltaTime;
            transform.localScale += new Vector3(0, m_GROWTHRATE, 0) * Time.deltaTime * m_GROWTHFACTOR;
            transform.localPosition += new Vector3(0, 0, m_POSITIONALOFFSET) * Time.deltaTime;
            yield return null;
        }
        destroy = true;
    }

    #endregion

    #region Update

    void Update()
    {
        DestroyObject();

        BeamGrowShrink();

        scale = transform.localScale;
    }

    #endregion

    void DestroyObject()
    {
        if (destroy)
        {
            Destroy(gameObject);
        }
    }

    void BeamGrowShrink()
    {
        if (transform.localScale.x <= minScale.x)
        {
            scaleIncrease = true;
            scaleDecrease = false;

        }
        else if (transform.localScale.x >= maxScale)
        {
            scaleIncrease = false;
            scaleDecrease = true;
            startIncreaseUpDown = true;
        }

        if (scaleIncrease)
        {
            transform.localScale += Vector3.right * Time.deltaTime * scaleRate;

        }
        else if (scaleDecrease)
        {
            transform.localScale -= Vector3.right * Time.deltaTime * scaleRate;

        }

        if (startIncreaseUpDown)
        {
            if (scaleIncrease)
            {
                transform.localScale -= Vector3.forward * Time.deltaTime * scaleRate;
            }
            else if (scaleDecrease)
            {
                transform.localScale += Vector3.forward * Time.deltaTime * scaleRate;
            }
        }
    }
}
