using UnityEngine;
using System.Collections;

public class FixedPlayerHealth : MonoBehaviour {

    public int currentHealth;
    private int maxHealth;
    public int lookForDamage;


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
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
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
            TakeDamage(20);         //here is where damage is taken
            enemyBody.AddExplosionForce(1000f, transform.position, 5f);         //players are supposed to be pushed away when damaged
            Debug.Log("Hit enemy");
        }
    }
}
