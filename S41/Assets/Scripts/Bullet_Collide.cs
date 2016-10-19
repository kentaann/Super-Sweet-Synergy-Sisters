using UnityEngine;
using System.Collections;

public class Bullet_Collide : MonoBehaviour 
{
    public LayerMask m_EnemyMask;
    //private Simone_Attack m_Simone;

    public float m_lifeSpan = 5f;
    public float m_explosionRadius = 1f;

	// Use this for initialization
	void Start () 
    {
        //m_Simone = GetComponent<Simone_Attack>();
        Destroy(gameObject, m_lifeSpan);
	}

    private void OnTriggerEnter(Collider other) //råkar kallas så fort skottet instansieras
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, m_explosionRadius, m_EnemyMask);

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().Hit(10);       //Hit(10) has to be changed to Hit(dmg variable in simone script)
       
                //m_Simone.GetComponent<Simone_Attack>().SetScore(10);

            //Destroy(gameObject);
        }

        if (other.gameObject.tag == "Environment" || other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Trap")
        {
            other.gameObject.GetComponent<Trap_Trigger>().FiredUp(true);
        }


        Destroy(gameObject);
    }

	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
