using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float health, maxHealth;
    public GameObject enemyToDestroy;
   // public Scoring m_ScoreRef;                    // For Scoring but later

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

    private void OnEnable()
    {
        //m_ScoreRef = GetComponent<Scoring>();
    }

    void Start()
    {
        health = 100;
        maxHealth = 100;
        m_spicyChocolateDmg = 0.2f;
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
            if(m_spicyChocolateTimer < 3)
            {
                health -= m_spicyChocolateDmg;
                if(m_spicyChocolateTimer >= 3)
                {
                    m_isOnFire = false;
                }
            }
        }

        healthBar.fillAmount = (float)health / (float)maxHealth;
    }

    public void Hit(float damage)
    {
        health -= damage;
        healthBar.fillAmount = (float)health / (float)maxHealth;
    }

    public void Heal(float heal)
    {
        if ((health + heal) > maxHealth)
        {
            health = maxHealth;
            healthBar.fillAmount = (float)health / (float)maxHealth;
        }
        else if ((health + heal) < maxHealth)
        {
            health += (int)heal;
            healthBar.fillAmount = (float)health / (float)maxHealth;
        }


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
