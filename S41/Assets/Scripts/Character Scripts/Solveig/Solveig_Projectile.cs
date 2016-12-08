#region Using Systems

using UnityEngine;

#endregion

public class Solveig_Projectile : MonoBehaviour
{

    #region Variables

    private const float m_DAMAGE = 9.0f;            // Damage of the projectile dealt to an enemy
    private const float m_HEAL = 10.0f;             // Healing provided for the ally
    private const float m_RADIUS = 0.5f;            // Radius of the sphere
    private const float m_LIFESPAN = 3.0f;          // The lifespan of the object so it does not live forever to avoid edgecases where projectile does not collide with anything

    #endregion

    #region Start

    void Start () 
    {
        gameObject.GetComponent<Collider>().isTrigger = true;

        Destroy(gameObject, m_LIFESPAN);
	}

    #endregion

    #region Update

    void Update () 
    {
	
	}

    #endregion

    #region On Trigger Enter
    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_RADIUS);

        // Damages the enemy
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().Hit(m_DAMAGE);
            Destroy(gameObject);
        }

        //Heal friendly
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<FixedPlayerHealth>().GetHeal(m_HEAL);
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Environment")
        {
            Destroy(gameObject);
        }
    }

    #endregion
}
