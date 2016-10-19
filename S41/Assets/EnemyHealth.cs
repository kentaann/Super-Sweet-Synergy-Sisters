using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float health, maxHealth;
    public GameObject enemyToDestroy;

    private Image healthBar;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    void Start()
    {
        health = 100;
        maxHealth = 100;

        healthBar = transform.FindChild("EnemyCanvas").FindChild("HealthBackGround").FindChild("Health").GetComponent<Image>();
    }

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("T key pressed");
            Hit(10);
        }
        if (health <= 10)
        {
            Destroy(enemyToDestroy);
        }
    }

    public void Hit(float damage)
    {
        health -= damage;
        healthBar.fillAmount = (float)health / (float)maxHealth;
    }

    //Kan användas i andra klasser för kollision
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<EnemyHealth>().Hit(10);
            Debug.Log("Hit enemy");
        }
    }
}
