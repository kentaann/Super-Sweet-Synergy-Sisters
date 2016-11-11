#region Using Statements

using UnityEngine;
using System.Collections;

#endregion

/// <summary>
/// Whipped Cream element
/// Tag to utilize in editor: wcBeam
/// </summary>
public class Whipped_Cream : MonoBehaviour
{
    #region Variables

    public GameObject[] players;

    public float m_maxRange;                            // The max range of the ability

    private const float m_GROWTHFACTOR = 2;             // The factor at which the beam grows    
    private const float m_POSITIONALOFFSET = 2;         // The offset for making the ability appear to remain in its original position
    private const float m_GROWTHRATE = 1;               // The modifier for the Y-axis scaler
    private const float m_RADIUS = 0.5f;                // Radius of the beam
    private const float m_MOVESPEEDMODIFIER = 0.15f;    // Modifier for enemies movespeed

    private float m_damage = 12.5f;                     // Damage of the beam
    private float m_creamPowerDamage = 18.0f;           // Damage while affected by Flower Power



    #endregion

    #region Start

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        }

        gameObject.GetComponent<Collider>().isTrigger = true;


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

    #region On Trigger Enter

    void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_RADIUS);

        if (other.gameObject.tag == "Enemy" && !other.gameObject.GetComponent<EnemyHealth>().m_isOnFire)
        {
            other.gameObject.GetComponent<EnemyHealth>().Hit(m_damage);
            other.gameObject.GetComponent<AiMovement>().SetMoveSpeed(m_MOVESPEEDMODIFIER);
        }

        if (other.gameObject.tag == "Environment" /*|| other.gameObject.tag == "Player"*/)
        {
            StopCoroutine(Expand());
        }

        if(other.gameObject.tag == "fpProj")
        {
            m_damage = m_creamPowerDamage;
        }

    }

    #endregion

    #region Update

    void Update()
    {

    }

    #endregion
}