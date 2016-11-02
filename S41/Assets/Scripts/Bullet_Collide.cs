#region Using Statements

using UnityEngine;
using System.Collections;

#endregion

public class Bullet_Collide : MonoBehaviour
{
    #region Variables

    public LayerMask m_EnemyMask;
    public GameObject[] players;

    public float m_lifeSpan = 5f;
    public float m_explosionRadius = 1f;

    #endregion

    #region Start

    void Start () 
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
    /// When the bullet collides with another object this function is called
    /// </summary>
    /// <param name="other">Object bullet collides with</param>
    private void OnTriggerEnter(Collider other) 
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, m_explosionRadius, m_EnemyMask);

        //if (other.gameObject.tag == "Player")
        //{
        //    Physics.IgnoreCollision(other.GetComponent<Collider>(), GetComponent<Collider>());
        //}

        // If the collided object is an enemy
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().Hit(10);       //Hit(10) has to be changed to Hit(dmg variable in simone script)
       
                //m_Simone.GetComponent<Simone_Attack>().SetScore(10); This is for the future scoring system and is to be moved to appropriate location when finalized
        }

        // If the collided object is Environment the bullet is removed
        if (other.gameObject.tag == "Environment" /*|| other.gameObject.tag == "Player"*/)
        {
            Destroy(gameObject);
        }

        // If the collided object is a Trap (Cookie Jar skill) sets it on fire. This is a placeholder solution until unique scripts for each element exist
        if (other.gameObject.tag == "Trap")
        {
            other.gameObject.GetComponent<Trap_Trigger>().FiredUp(true);
        }

        if(other.gameObject.tag == "wcBeam")
        {
            // Ändra material till bounce?
        }

        if(other.gameObject.tag == "scBeam")
        {
            // Lägg till spicy synergy
        }


        //Destroy(gameObject);
    }

    #endregion

    #region Update

    void Update () 
    {

    }

    #endregion
}
