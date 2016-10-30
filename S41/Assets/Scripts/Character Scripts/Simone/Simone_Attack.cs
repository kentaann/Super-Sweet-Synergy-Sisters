﻿#region Using Statements

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#endregion

public class Simone_Attack : MonoBehaviour
{
    #region Variables

    public Transform m_transformOrigin;                             // Where the attack will spawn on the character
    public List<Transform> m_targetList = new List<Transform>();    // List of all potential targets
    public Rigidbody m_bullet;                                      // The rigidbody of the projectile
    public Rigidbody m_spicyBullet;                                 // The rigidbody of the spicy chocolate projectile
    public Rigidbody m_whippedBullet;                               // The rigidbody of the whipped cream projectile
    public Rigidbody m_energyBullet;                                // The rigidbody of the energy drink projectile
    public Material m_bulletMaterial;

    Player_Movement m_playerMove;                                   // Used to manipulate movement from this class


    private float m_bulletLaunchForce;                              // Speed of the projectile
    private float m_coolDown;                                       // Cooldown of attacks                     
    private float m_attackRate;                                     // Attackrate
    private float m_whippedCreamMoveSpeedMod;                       // Modifier for the players movespeed while using whipped cream
    private int m_Score;                                            // Player score

    private bool m_energyDrinkActive;                               // Flag for the Energy Drink element
    private bool m_autoAttackActive;                                // Flag for the Regular attack
    private bool m_whippedCreamActive;                              // Flag for the Whipped Cream element
    private bool m_spicyChocolateActive;                            // Flag for the Spicy Chocolate element

    public double m_damage;                                         // Base damage per projectile

    #endregion

    #region On Enable

    /// <summary>
    /// Initiates the variables and sets the flags.
    /// </summary>
    private void OnEnable()
    {
        m_bulletLaunchForce = 30f;
        m_damage = 10;
        m_coolDown = 0.5f;
        m_Score = 0;
        m_whippedCreamMoveSpeedMod = 0.75f;
        m_playerMove = GetComponent<Player_Movement>();
        //m_bulletMaterial = new Material("EnergyDrink_Material");
        m_energyDrinkActive = false;
        m_whippedCreamActive = false;
        m_autoAttackActive = true;
        m_spicyChocolateActive = false;
    }

    #endregion

    #region Start

    void Start()
    {

    }

    #endregion

    #region On Trigger Enter
    /// <summary>
    /// As soon as an enemy enters the sphere collider it is added to the target list.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            m_targetList.Add(other.gameObject.transform);
        }
    }
    #endregion

    #region On Trigger Exit

    /// <summary>
    /// When an enemy leaves the Area of effect it is removed from the target list.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        m_targetList.Remove(other.gameObject.transform);
    }

    #endregion

    #region Update

    void Update()
    {
        if (m_targetList.Count > 0)
        {
            RemoveNullTarget();
        }

        m_attackRate += Time.deltaTime;

        if (m_attackRate >= m_coolDown)
	    {
		    if (Input.GetKey(KeyCode.P) || Input.GetButton("X360_A") && m_autoAttackActive && !m_whippedCreamActive && !m_spicyChocolateActive && !m_energyDrinkActive)
            {
                S_autoAttack();
                m_attackRate = 0;
            } 
	    }

        if (m_attackRate >= m_coolDown)
        {
            if (Input.GetKey(KeyCode.P) && m_energyDrinkActive && !m_autoAttackActive && !m_spicyChocolateActive && !m_whippedCreamActive)
            {
                S_EnergyDrinkAttack();
                m_attackRate = 0;
            }
        }

        if(m_attackRate >= m_coolDown)
        {
            if(Input.GetKey(KeyCode.P) && m_whippedCreamActive && !m_autoAttackActive && !m_energyDrinkActive && !m_spicyChocolateActive)
            {
                S_WhippedCreamAttack();
                m_attackRate = 0;
            }
        }

        if(m_attackRate > m_coolDown)
        {
            if(Input.GetKeyUp(KeyCode.P) && m_spicyChocolateActive && !m_autoAttackActive && !m_energyDrinkActive && !m_whippedCreamActive)
            {
                S_SpicyChocolateAttack();
                m_attackRate = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            m_energyDrinkActive = true;
            m_autoAttackActive = false;
            m_whippedCreamActive = false;
            m_playerMove.m_moveSpeed = 0;
            m_damage = m_damage * 0.8;
            m_coolDown = 0.15f;
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            m_energyDrinkActive = false;
            m_autoAttackActive = true;
            m_whippedCreamActive = false;
            m_playerMove.m_moveSpeed = 12;
            m_coolDown = 0.5f;
            m_damage = 10f;
        }

        if(Input.GetKeyUp(KeyCode.Z))
        {
            m_whippedCreamActive = true;
            m_autoAttackActive = false;
            m_energyDrinkActive = false;
            m_damage = m_damage * 1.2;
            m_playerMove.m_moveSpeed = m_playerMove.m_moveSpeed * m_whippedCreamMoveSpeedMod;
            m_coolDown = 0.5f;
            Debug.Log(m_damage);
        }

        if(Input.GetKeyUp(KeyCode.M))
        {
            m_spicyChocolateActive = true;
            m_energyDrinkActive = false;
            m_autoAttackActive = false;
            m_whippedCreamActive = false;
            m_coolDown = 0.5f;
            m_damage = 10f;
            Debug.Log("SPICY CHOCOLATE ACTIVE");
        }
    }

    #endregion

    #region Simone Attacks
    /// <summary>
    /// Simones auto attack.
    /// Creates a bullet and shoots in the direction that Simone is facing.
    /// </summary>
    private void S_autoAttack()
    {
        Rigidbody bulletInstance = Instantiate(m_bullet, m_transformOrigin.position, m_transformOrigin.rotation) as Rigidbody;
        bulletInstance.velocity = m_bulletLaunchForce * m_transformOrigin.forward;
    }

    /// <summary>
    /// Energy Drink Element
    /// Player becomes stationary, damage is decreased and attackrate is increased.
    /// Should also change color of the attack to correctly correspond with the new element.
    /// </summary>
    private void S_EnergyDrinkAttack()
    {
        Rigidbody bulletInstance = Instantiate(m_bullet, m_transformOrigin.position, Quaternion.identity) as Rigidbody;
        bulletInstance.velocity = m_bulletLaunchForce * m_transformOrigin.forward;

    }
    
    private void S_WhippedCreamAttack()
    {
        Rigidbody bulletInstance = Instantiate(m_bullet, m_transformOrigin.position, m_transformOrigin.rotation) as Rigidbody;
        bulletInstance.velocity = m_bulletLaunchForce * m_transformOrigin.forward;
    }

    private void S_SpicyChocolateAttack()
    {
        Rigidbody bulletInstance = Instantiate(m_spicyBullet, m_transformOrigin.position, m_transformOrigin.rotation) as Rigidbody;
        bulletInstance.velocity = m_bulletLaunchForce * m_transformOrigin.forward;
    }

    #endregion

    #region List Handling

    void AddEnemyToList()
    {
        foreach (GameObject other in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            m_targetList.Add(other.gameObject.transform);
        }
    }

    void RemoveNullTarget()
    {
        foreach (var target in m_targetList)
        {
            if (target == null)
            {
                m_targetList.Remove(target);
            }
        }
    }

    #endregion

    public void SetScore(int score)
    {
        m_Score += score;
        Debug.Log(m_Score);
    }
}
