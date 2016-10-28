using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float health, maxHealth;
    public GameObject enemyToDestroy;

    private float m_spicyChocolateDmg;
    private float m_spicyChocolateTimer = 0;

    public bool m_isOnFire;
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
        m_spicyChocolateDmg = 1f;
        m_isOnFire = false;

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

        if(m_isOnFire)
        {
            m_spicyChocolateTimer += Time.deltaTime;
            if(m_spicyChocolateTimer < 5)
            {
                health -= m_spicyChocolateDmg;
                if(m_spicyChocolateTimer >= 5)
                {
                    m_isOnFire = false;
                }
            }
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
