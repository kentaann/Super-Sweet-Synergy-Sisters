using UnityEngine;
using System.Collections;

public class FixedPlayerHealth : MonoBehaviour {

    public int currentHealth;
    public int maxHealth;
    public int lookForDamage;
    public float dmgTime = 0.1f;

    private float m_timer;
    private const float m_GODTIMER = 5.0f;

    // Use this for initialization
    void Start()
    {
        maxHealth = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        lookForDamage = currentHealth;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }


        foreach (var e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            dmgTime += Time.deltaTime;

            if (gameObject.GetComponent<Collider>().bounds.Intersects(e.GetComponent<Collider>().bounds))
            {
                if (dmgTime > 0.3f)
                {
                    TakeDamage(20);
                    dmgTime = 0;
                    Debug.Log("Hit enemy");
                }
            }
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void GetHeal(float heal)
    {
        if(currentHealth < maxHealth)
            currentHealth += (int)heal;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    void OnCollisionEnter(Collision other)
    {
        Rigidbody enemyBody = other.gameObject.GetComponent<Rigidbody>();

        if (other.gameObject.tag == "Enemy")
        {
            //TakeDamage(20);         //here is where damage is taken
            enemyBody.AddExplosionForce(1000f, transform.position, 5f);         //players are supposed to be pushed away when damaged
        }
    }
}
