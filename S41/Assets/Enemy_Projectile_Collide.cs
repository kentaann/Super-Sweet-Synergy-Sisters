using UnityEngine;
using System.Collections;

public class Enemy_Projectile_Collide : MonoBehaviour
{

    private const float m_LIFESPAN = 3.0f;
    public GameObject[] enemies;
    private const float m_RADIUS = 0f;
    public LayerMask m_PlayerMask;
    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Collider>().isTrigger = true;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            Physics.IgnoreCollision(enemy.GetComponent<Collider>(), GetComponent<Collider>());
        }

        Destroy(gameObject, m_LIFESPAN);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,m_RADIUS);


        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<FixedPlayerHealth>().TakeDamage(20);
            Destroy(gameObject);
        }

    }
}
