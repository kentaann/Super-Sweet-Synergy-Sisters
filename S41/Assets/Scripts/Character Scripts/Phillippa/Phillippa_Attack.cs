﻿#region Using Statements

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

public class Phillippa_Attack : MonoBehaviour
{
    #region Variables

    public List<Transform> m_targetList = new List<Transform>();
    public SphereCollider m_Spherecollider;

    private const float m_FLUFFCOOLDOWN = 6;
    private const float m_FLUFFSTUNDURATION = 2;

    private float m_fluffDamage = 10;    
    private float m_timer;

    #endregion

    #region On Trigger Enter
    /// <summary>
    /// As soon as an enemy enters the sphere collider it is added to the target list.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Trap")
        {
            m_targetList.Add(other.gameObject.transform);
        }
    }
    #endregion

    #region On Trigger Exit

    /// <summary>
    /// When an enemy leaves the Area of effect it is removed from the target list.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        m_targetList.Remove(other.gameObject.transform);
    }

    #endregion

    #region Remove Null Target

    void RemoveNullTarget()
    {
        foreach(var target in m_targetList)
        {
            if(target == null)
            {
                m_targetList.Remove(target);
            }
        }
    }

    #endregion

    #region Phillippa attacks

    /// <summary>
    /// Area Of Effect attack that does damage and stuns the enemy.
    /// As of right now it damages but not always every enemy in the AOE.
    /// SYNERGY: If a trap is present it is propelled away Phillippa.
    /// </summary>
    public void Fluffpound()
    {
       // m_timer.Start();
        foreach (var target in m_targetList)
        {
            RaycastHit targetConnected;
            Rigidbody targetBody = target.GetComponent<Rigidbody>();
            
            if (Physics.Raycast(transform.position, (target.position - transform.position), out targetConnected, 100))
            {
                if (targetConnected.transform == target && targetConnected.transform != null)
                {
                    if (target.gameObject.tag == "Enemy")
                    {
                        target.SendMessage("Hit", m_fluffDamage);
                        target.SendMessage("SetMoveSpeed", 0f);
                        target.SendMessage("Stun", true); 
                    }

                    if (target.gameObject.tag == "Trap")
                    {
                        targetBody.AddExplosionForce(2000f, transform.position, 5f);
                        target.SendMessage("FlyAway", true);
                    }
                }
            }
        }
    }

    #endregion

    #region Start

    void Start()
    {

    }

    #endregion

    #region Update

    void Update()
    {
        if(m_targetList.Count > 0)
        {
            RemoveNullTarget();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Fluffpound();
        }
    }

    #endregion
}
