using UnityEngine;
using System.Collections;

public class FixedPlayerHealth : MonoBehaviour {

    public int health;
    public int lookForDamage;



    // Use this for initialization
    void Start()
    {
        //health = 100;


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

    public int GetHealth()
    {
        return health;
    }
}
