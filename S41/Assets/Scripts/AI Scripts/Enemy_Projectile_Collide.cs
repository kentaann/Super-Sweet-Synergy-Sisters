using UnityEngine;
using System.Collections;

public class Enemy_Projectile_Collide : MonoBehaviour
{

    private const float m_LIFESPAN = 10.0f;
    public GameObject[] enemies;
    private const float m_RADIUS = 0f;
    public LayerMask m_PlayerMask;
    private IEnumerator coroutine;
    bool gotHit = false;
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
        Collider[] colliders = Physics.OverlapSphere(transform.position,m_RADIUS,m_PlayerMask);


        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<FixedPlayerHealth>().TakeDamage(20);
            //coroutine = TakeDmgBlink(2.0f);
            //StartCoroutine(coroutine);
            Destroy(gameObject);
        }
        
        if(other.gameObject.tag == "Environment")
        {
            Destroy(gameObject);
        }

    }

    //public IEnumerator TakeDmgBlink(float waitTime)
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(waitTime);
    //    }
    //    //wait for x seconds
    //    //yield return new WaitForSeconds(waitTime);
    //    //after x seconds, the player can get hit again
    //    //gotHit = false;
    //}

    
}
