using UnityEngine;
using System.Collections;

public class Solveig_Projectile : MonoBehaviour 
{
    private const float m_DAMAGE = 9.0f;
    private const float m_HEAL = 10.0f;
    private const float m_RADIUS = 0.5f;


	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_RADIUS);

        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().Hit(m_DAMAGE);
        }

        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<FixedPlayerHealth>().GetHeal(-m_HEAL);
        }

        if(other.gameObject.tag == "Environment")
        {
            Destroy(gameObject);
        }

    }
}
