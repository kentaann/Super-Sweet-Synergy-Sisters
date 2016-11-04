#region Using Systems

using UnityEngine;
using System.Collections;

#endregion

public class Solveig_Projectile : MonoBehaviour
{

    #region Variables

    private const float m_DAMAGE = 9.0f;
    private const float m_HEAL = 10.0f;
    private const float m_RADIUS = 0.5f;

    #endregion

    #region Start

    void Start () 
    {
	
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
        }

        //Heal friendly
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<FixedPlayerHealth>().GetHeal(m_HEAL);
        }

        if(other.gameObject.tag == "Environment")
        {
            Destroy(gameObject);
        }
    }

    #endregion
}
