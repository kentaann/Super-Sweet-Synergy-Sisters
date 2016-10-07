#region Using Statements

using UnityEngine;
using System.Collections;

#endregion

public class Simone_Attack : MonoBehaviour
{
    #region Variables

    public Transform m_transformOrigin; // Where the attack will spawn on the character
    public Rigidbody m_bullet;

    private float m_bulletLaunchForce;

    #endregion

    #region On Enable

    /// <summary>
    /// Sets the force which will propel the bullet
    /// </summary>
    private void OnEnable()
    {
        m_bulletLaunchForce = 30f;
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
        if (Input.GetKeyUp(KeyCode.P))
        {
            S_autoAttack();
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

    #endregion

}
