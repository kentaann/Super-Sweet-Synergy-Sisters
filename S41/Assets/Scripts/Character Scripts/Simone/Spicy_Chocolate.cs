#region Using Statements

using UnityEngine;
using System.Collections;

#endregion

/// <summary>
/// Spicy Chocolate element
/// Tag to utilize in editor: scBeam
/// </summary>
public class Spicy_Chocolate : MonoBehaviour
{
    #region Variables

    public LayerMask m_EnemyMask;
    public GameObject[] players;

    public float m_lifeSpan = 5f;
    public float m_explosionRadius = 1f;

    #endregion

    #region Start

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        }

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

        //Puts the target enemy on fire and also does initial damage
        if (other.gameObject.tag == "Enemy" && !other.gameObject.GetComponent<EnemyHealth>().m_isOnFire)
        {
            other.gameObject.GetComponent<EnemyHealth>().Hit(10);
            other.gameObject.GetComponent<EnemyHealth>().m_isOnFire = true;
        }

        if (other.gameObject.tag == "Environment" /*|| other.gameObject.tag == "Player"*/)
        {
            Destroy(gameObject);
        }

        // If the collided object is a Trap (Cookie Jar skill) sets it on fire. This is a placeholder solution until unique scripts for each element exist
        if (other.gameObject.tag == "Trap")
        {
            other.gameObject.GetComponent<Trap_Trigger>().FiredUp(true);
        }

        //Destroy(gameObject);
    }

    #endregion

    #region Update

    void Update()
    {

    }

    #endregion
}
