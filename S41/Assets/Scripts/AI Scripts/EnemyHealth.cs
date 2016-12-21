using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float currHealth, maxHealth;
    public GameObject enemyToDestroy;

    private float m_spicyChocolateDmg;
    private float m_spicyChocolateTimer = 0;

    public bool m_attackable = true;
    public bool m_creamAttackable = true;
    public bool m_isOnFire;
    private Image healthBar;

    public float wcDamageTimer;
    public bool wcAbleToDamage = false;
    public float nextShot = 0;
    private float m_rushAttackTimer;
    private float m_creamAttackTimer;
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
        currHealth = 100;
        maxHealth = 100;
        m_spicyChocolateDmg = 0.2f;
        m_isOnFire = false;

        healthBar = transform.FindChild("EnemyCanvas").FindChild("HealthBackGround").FindChild("Health").GetComponent<Image>();
    }

    void Update()
    {
        if(m_attackable == false)
        {
            m_rushAttackTimer += Time.deltaTime;

            if(m_rushAttackTimer > 1.0f)
            {
                m_attackable = true;
                m_rushAttackTimer = 0.0f;
            }
        }
        if(m_creamAttackable == false)
        {
            if(m_creamAttackTimer > 1.0f)
            {
                m_creamAttackable = true;
                m_creamAttackTimer = 0.0f;
            }
        }

        DestroyWhenDead();
        ResizeHealthBar();
        WhippedCreamDmg();
        OnFire();
    }

    public void OnFire()
    {
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
    }

    public void WhippedCreamDmg()
    {
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

    public void ResizeHealthBar()
    {
        healthBar.fillAmount = (float)currHealth / (float)maxHealth;
    }

    public void DestroyWhenDead()
    {
        if (currHealth <= 10)
        {
            OnDestroyed();
            Destroy(enemyToDestroy);
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
}
