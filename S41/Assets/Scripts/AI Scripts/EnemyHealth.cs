using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float currHealth = 100, maxHealth = 100;
    public GameObject enemyToDestroy;



    private float m_spicyChocolateDmg;
    private float m_spicyChocolateTimer = 0;

    public bool m_isOnFire;
    private Image healthBar;

    public float wcDamageTimer;
    public bool wcAbleToDamage = false;
    public float nextShot = 0;
    public bool ableToDamage = false;

    private void OnEnable()
    {
        //m_ScoreRef = GetComponent<Scoring>();
    }

    public void Initializing(float newHealth, float newMaxHealth)
    {
        currHealth = newHealth;
        maxHealth = newMaxHealth;
    }

    void Start()
    {
        //Instantiate();


        //currHealth = 100;
        //maxHealth = 100;
        m_spicyChocolateDmg = 0.2f;
        m_isOnFire = false;

        healthBar = transform.FindChild("EnemyCanvas").FindChild("HealthBackGround").FindChild("Health").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            currHealth = 0;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("T key pressed");
            Hit(10);
        }
        if (currHealth <= 10)
        {
            OnDestroyed();
            Destroy(enemyToDestroy);

        }



        if (m_isOnFire)
        {
            m_spicyChocolateTimer += Time.deltaTime;
            if (m_spicyChocolateTimer < 3)
            {
                currHealth -= m_spicyChocolateDmg;
                if (m_spicyChocolateTimer >= 3)
                {
                    m_isOnFire = false;
                }
            }
        }

        healthBar.fillAmount = (float)currHealth / (float)maxHealth;

        if (wcAbleToDamage)
        {
            wcDamageTimer += Time.deltaTime;

            if (wcDamageTimer >= nextShot)
            {
                ableToDamage = true;
                nextShot = wcDamageTimer + 1;
            }
        }

    }

    public void setHealth(float k)
    {
        currHealth = k;
    }

    // adding points to the score when the object is destroyed
    public void OnDestroyed()
    {
        Scoring.Instance.Score += 10;
    }

    public void Hit(float damage)
    {
        currHealth -= damage;
        healthBar.fillAmount = (float)currHealth / (float)maxHealth;
    }

    public void Heal(float heal)
    {
        if ((currHealth + heal) > maxHealth)
        {
            currHealth = maxHealth;
            healthBar.fillAmount = (float)currHealth / (float)maxHealth;
        }
        else if ((currHealth + heal) < maxHealth)
        {
            currHealth += (int)heal;
            healthBar.fillAmount = (float)currHealth / (float)maxHealth;
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
