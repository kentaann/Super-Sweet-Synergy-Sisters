using UnityEngine;
using System.Collections;

public class FixedPlayerHealth : MonoBehaviour {

    public int health;
    public int lookForDamage;

    private float m_timer;
    private const float m_GODTIMER = 5.0f;

    // Use this for initialization
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        lookForDamage = health;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void GetHeal(float heal)
    {
        health += (int)heal;
    }

    public int GetHealth()
    {
        return health;
    }

    public void MakeInvulnerable()
    {
        m_timer += Time.deltaTime;

        if(m_timer >= m_GODTIMER)
        {
            // NOT DONE
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Rigidbody enemyBody = other.gameObject.GetComponent<Rigidbody>();

        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(20);         //here is where damage is taken
            enemyBody.AddExplosionForce(1000f, transform.position, 5f);         //players are supposed to be pushed away when damaged
            Debug.Log("Hit enemy");
        }
    }
}
