using UnityEngine;
using System.Collections;

public class Spicy_Chocolate : MonoBehaviour {

    public LayerMask m_EnemyMask;
    

    public float m_lifeSpan = 5f;
    public float m_explosionRadius = 1f;

    void Start()
    {
        Destroy(gameObject, m_lifeSpan);
    }

    private void OnTriggerEnter(Collider other) 
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, m_explosionRadius, m_EnemyMask);

        if (other.gameObject.tag == "Enemy" && !other.gameObject.GetComponent<EnemyHealth>().m_isOnFire)
        {
            other.gameObject.GetComponent<EnemyHealth>().Hit(10);
            other.gameObject.GetComponent<EnemyHealth>().m_isOnFire = true;
        }

        if (other.gameObject.tag == "Environment" || other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
