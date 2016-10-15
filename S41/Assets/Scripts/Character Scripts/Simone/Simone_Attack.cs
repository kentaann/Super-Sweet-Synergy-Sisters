#region Using Statements

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
    public Rigidbody m_Simone;
    public Material m_bulletMaterial;

    Player_Movement m_playerMove;                                   // Used to manipulate movement from this class
    Bullet_Collide m_bulletCollision;

    private float m_bulletLaunchForce;                              // Speed of the projectile

    private bool m_energyDrinkActive;                               // Flag for the Energy Drink element
    private bool m_autoAttackActive;                                // Flag for the Regular attack

    public double m_damage;                                         // Base damage per projectile
    private float timeStamp;
    private float coolDown;

    #endregion

    #region On Enable

    /// <summary>
    /// Initiates the variables and sets the flags.
    /// </summary>
    private void OnEnable()
    {
        m_bulletLaunchForce = 30f;
        m_damage = 10;
        timeStamp = Time.time + coolDown;
        coolDown = 2;
        m_Simone = GetComponent<Rigidbody>();
        m_playerMove = GetComponent<Player_Movement>();
        //m_bulletMaterial = new Material("EnergyDrink_Material");
        m_energyDrinkActive = false;
        m_autoAttackActive = true;
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


        if (Input.GetKeyUp(KeyCode.P) && m_autoAttackActive)
        {
            S_autoAttack();
        }

        if (Input.GetKey(KeyCode.P) && m_energyDrinkActive && !m_autoAttackActive)
        {
            S_EnergyDrinkAttack();
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            m_energyDrinkActive = true;
            m_autoAttackActive = false;
            m_playerMove.m_moveSpeed = 0;
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            m_energyDrinkActive = false;
            m_autoAttackActive = true;
            m_playerMove.m_moveSpeed = 12;
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
        m_damage = m_damage * 0.8;
        Rigidbody bulletInstance = Instantiate(m_bullet, m_transformOrigin.position, m_transformOrigin.rotation) as Rigidbody;
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
}
