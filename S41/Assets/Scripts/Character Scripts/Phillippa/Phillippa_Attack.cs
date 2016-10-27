#region Using Statements

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
        if (other.gameObject.tag == "Enemy")
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
    /// As of right now it damages AND permastuns.
    /// </summary>
    public void Fluffpound()
    {
       // m_timer.Start();
        foreach (var target in m_targetList)
        {
            RaycastHit targetConnected;
            float elapsedTime = 0;
            
            if (Physics.Raycast(transform.position, (target.position - transform.position), out targetConnected, 100))
            {
                if (targetConnected.transform == target && targetConnected.transform != null && elapsedTime < 3)
                {
                    target.SendMessage("Hit", m_fluffDamage);
                    target.SendMessage("SetMoveSpeed", 0f);

                    elapsedTime += Time.deltaTime;

                    if (elapsedTime >= 3)
                    {
                        target.SendMessage("SetMoveSpeed", 2f);
                        //elapsedTime = 0;
                    }
                }
            }
        }
    }

    public void RushAttack()
    {

    }

    #endregion


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
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
}
