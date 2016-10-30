﻿#region Using Statements

using UnityEngine;
using System.Collections;

#endregion

public class Spicy_Chocolate : MonoBehaviour
{
    #region Variables

    public LayerMask m_EnemyMask;    

    public float m_lifeSpan = 5f;
    public float m_explosionRadius = 1f;

    #endregion

    #region Start

    void Start()
    {
        Destroy(gameObject, m_lifeSpan);
    }

    #endregion

    #region On Trigger Enter

    /// <summary>
    /// Check collision between the spicy chocolate projectile and another object.
    /// </summary>
    /// <param name="other">Collider of another GameObject</param>
    private void OnTriggerEnter(Collider other) 
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, m_explosionRadius, m_EnemyMask);

        if (other.gameObject.tag == "Enemy" && !other.gameObject.GetComponent<EnemyHealth>().m_isOnFire)
        {
            other.gameObject.GetComponent<EnemyHealth>().Hit(10);
            other.gameObject.GetComponent<EnemyHealth>().m_isOnFire = true;
        }

        if (other.gameObject.tag == "Environment" || other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }

    #endregion

    #region Update

    void Update()
    {

    }

    #endregion
}
