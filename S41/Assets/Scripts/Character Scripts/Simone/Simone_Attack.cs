#region Using Statements

using UnityEngine;
using System.Collections;

#endregion

public class Simone_Attack : MonoBehaviour
{
    #region Variables

    public Transform m_transformOrigin; // Where the attack will spawn on the character
    public Rigidbody m_bullet;
    public Rigidbody m_Simone;
    public Material m_bulletMaterial;
    Player_Movement m_playerMove;

    private float m_bulletLaunchForce;
    private bool m_energyDrinkActive;
    private bool m_autoAttackActive;

    public double m_damage;
    private float timeStamp;
    private float coolDown;

    #endregion

    #region On Enable

    /// <summary>
    /// Sets the force which will propel the bullet
    /// </summary>
    private void OnEnable()
    {
        m_bulletLaunchForce = 30f;
        m_damage = 10;
        timeStamp = Time.time + coolDown;
        coolDown = 2;
        m_Simone = GetComponent<Rigidbody>();
        m_playerMove = GetComponent<Player_Movement>();
        m_bulletMaterial = new Material("EnergyDrink_Material");
        m_energyDrinkActive = false;
        m_autoAttackActive = true;
    }

    #endregion

    #region Start

    void Start()
    {

    }

    #endregion

    #region Update

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P) && m_autoAttackActive)
        {
                    S_autoAttack();                
        }

        if(Input.GetKeyDown(KeyCode.P) && m_energyDrinkActive && !m_autoAttackActive)
        {
            S_EnergyDrinkAttack();
        }

        if(Input.GetKeyUp(KeyCode.L))
        {
            m_energyDrinkActive = true;
            m_autoAttackActive = false;
            m_playerMove.m_moveSpeed = 0;
        }

        if(Input.GetKeyUp(KeyCode.K))
        {
            m_energyDrinkActive = false;
            m_autoAttackActive = true;
            m_playerMove.m_moveSpeed = 12;
        }
    }

    #endregion

    #region Simone Auto Attack
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

}
