#region Using Statements

using UnityEngine;
using System.Collections.Generic;

#endregion

public class Phillippa_Attack : MonoBehaviour
{
    #region Variables

    public List<Transform> m_targetList = new List<Transform>();
    public SphereCollider m_Spherecollider;

    public delegate void EventHandler();
    public static event EventHandler FluffEvent;
    public static event EventHandler RushEvent;
    public static event EventHandler RushEnd;
    public static event EventHandler CreamCollider;
    public static event EventHandler EnergyCollider;
    public static event EventHandler SpicyCollider;

    //private const float m_FLUFFCOOLDOWN = 6;
    //private const float m_FLUFFSTUNDURATION = 2;

    //private float m_fluffDamage = 10;    
    private float m_timer;
    private float m_rushTimer = 0;
    private float m_angerIssuesDamage = 25.0f;
    private int m_fluffCounter = 0;                         // Times Fluff Pound was used
    private int m_rushCounter = 0;                          // Times Rush was used

    private bool m_rushActive = false;
    private bool m_energyRushActive = false;
    private bool m_spicyRushActive = false;
    private bool m_whippedCreamActive = false;

    public float m_fluffCooldown = 0;
    public float m_angerCooldown = 0;

    private bool m_fluffCooldownTiming = false;
    private bool m_angerCooldownTiming = false;

    public string xbox_name_X360_A;
    public string xbox_name_X360_B;
    public string xbox_name_X360_X;
    public string xbox_name_X360_Y;


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

        if(other.gameObject.tag == "wcBeam" && m_rushActive)
        {
            m_whippedCreamActive = true;
            m_spicyRushActive = false;
            m_energyRushActive = false;
            m_angerIssuesDamage = 40.0f;
            UnityEngine.Debug.Log("WHIPPED RUSH ACTIVE FUCKER");

            if (CreamCollider != null)
            {
                CreamCollider();            //creates an event that activates when Philippa collides with Simone's whipped cream beam
            }
        }

        //Energy rush = Stuns target
        if(other.gameObject.tag == "edBeam" && m_rushActive)
        {
            m_energyRushActive = true;
            m_whippedCreamActive = false;
            m_spicyRushActive = false;
            UnityEngine.Debug.Log("ENERGY RUSH ACTIVE");

            if (EnergyCollider != null)
            {
                EnergyCollider();            //creates an event that activates when Philippa collides with Simone's energy drink beam
            }
        }

        if(other.gameObject.tag == "scBeam" && m_rushActive)
        {
            m_spicyRushActive = true;
            m_whippedCreamActive = false;
            m_energyRushActive = false;
            UnityEngine.Debug.Log("SPICY RUSH ACTIVE");

            if (SpicyCollider != null)
            {
                SpicyCollider();            //creates an event that activates when Philippa collides with Simone's spicy chocolate beam
            }
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
    /// As of right now it damages but not always hit every enemy in the AOE.
    /// SYNERGY: If a trap is present it is propelled away Phillippa.
    /// </summary>
    //public void Fluffpound()
    //{
    //   // m_timer.Start();
    //    foreach (var target in m_targetList)
    //    {
    //        RaycastHit targetConnected;
    //        Rigidbody targetBody = target.GetComponent<Rigidbody>();
            
    //        if (Physics.Raycast(transform.position, (target.position - transform.position), out targetConnected, 100))
    //        {
    //            if (targetConnected.transform == target && targetConnected.transform != null)
    //            {
    //                if (target.gameObject.tag == "Enemy")
    //                {
    //                    target.SendMessage("Hit", m_fluffDamage);
    //                    target.SendMessage("SetMoveSpeed", 0f);
    //                    target.SendMessage("Stun", true); 
    //                }

    //                if (target.gameObject.tag == "Trap")
    //                {
    //                    targetBody.AddExplosionForce(2000f, transform.position, 5f);
    //                    target.SendMessage("FlyAway", true);
    //                }
    //            }
    //        }
    //    }
    //}

    #endregion

    #region Start

    void Start()
    {
        //transform.position += transform.forward * Time.deltaTime * 1000;
        gameObject.SendMessage("SetMoveSpeed", 12f);
        //gameObject.transform.position = transform.forward * Time.deltaTime * 100;
        //gameObject.SendMessage("IsRushing", true);
        m_rushActive = false;                    //needs to start as true in order to not be activated at start, for some reason
    }

    #endregion

    public void RushAttack()
    {
        gameObject.SendMessage("SetMoveSpeed", 60f);

        m_rushActive = true;

        if (RushEvent != null)
        {
            RushEvent();            //creates an event when rush activates that the WhiskAttack class can use
        }
    }

    #region Update

    void Update()
    {
        if(m_targetList.Count > 0)
        {
            RemoveNullTarget();
        }

    
        if (Input.GetKeyDown(KeyCode.I) /*|| Input.GetButtonDown(xbox_name_X360_A)*/)
        {
            //Fluffpound();
            if (m_fluffCooldownTiming == false)
            {
                if (FluffEvent != null)
                {
                    FluffEvent();
                }
                m_fluffCounter++;
                m_fluffCooldownTiming = true;
            }
        }

        if (m_fluffCooldownTiming == true)
        {
            m_fluffCooldown += Time.deltaTime;
        }

        if (m_fluffCooldown >= 6.0f)
        {
            m_fluffCooldownTiming = false;
            m_fluffCooldown = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Q) /*|| Input.GetButtonDown(xbox_name_X360_B)*/)
        {
            if (m_angerCooldownTiming == false)
            {
                RushAttack();
                m_rushCounter++;
                m_angerCooldownTiming = true;
            }
        }

        if (m_angerCooldownTiming == true)
        {
            m_angerCooldown += Time.deltaTime;
        }

        if (m_angerCooldown >= 3.0f)
        {
            m_angerCooldownTiming = false;
            m_angerCooldown = 0f;
        }

        if (m_rushActive == true)
        {
            m_rushTimer += Time.deltaTime;
        }

        if (m_rushTimer >= 0.3f)            //makes there Rush attack stop after 0.3 seconds
        {
            gameObject.SendMessage("SetMoveSpeed", 12f);
            m_rushActive = false;
            m_rushTimer = 0;
            m_angerIssuesDamage = 25.0f;
            m_whippedCreamActive = false;
            m_spicyRushActive = false;
            m_energyRushActive = false;

            if (RushEnd != null)
            {
                RushEnd();
            }
        } 
    }

    #endregion

    public int GetRushCounter()
    {
        return m_rushCounter;
    }

    public int GetFluffCounter()
    {
        return m_fluffCounter;
    }
}
