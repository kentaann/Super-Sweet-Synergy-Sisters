using UnityEngine;
using System.Collections;

public class Elise_Attack : MonoBehaviour 
{

    public Transform m_transformTrapOrigin;
    public Transform m_transformFireOrigin;
    public Transform m_transformFireOriginLeft;
    public Transform m_transformFireOriginRight;
    public Collider m_trap;
    public Rigidbody m_multiBullet;

    public float m_multiLaunchForce;
    public string xbox_name_X360_A;
    public string xbox_name_X360_B;
    public string xbox_name_X360_X;
    public string xbox_name_X360_Y;
    // Use this for initialization
    void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetButtonDown(xbox_name_X360_X))
        {
            E_LayTrap();
        } 

        if (Input.GetKeyDown(KeyCode.B) || Input.GetButtonDown(xbox_name_X360_B))
        {
            E_MultiShot();
        }
	}

    /// <summary>
    /// Elise lays a stationary trap at her current position
    /// </summary>

    private void E_LayTrap()
    {
        Collider m_trapInstance = Instantiate(m_trap, m_transformTrapOrigin.position, m_transformTrapOrigin.rotation) as Collider;
    }

    /// <summary>
    /// Elise shoots out three separate bullets in directions corresponding to their transformOrigins
    /// </summary>

    private void E_MultiShot()
    {
        Rigidbody multiBulletInstance1 = Instantiate(m_multiBullet, m_transformFireOrigin.position, m_transformFireOrigin.rotation * Quaternion.Euler(90, 0, 0)) as Rigidbody;
        Rigidbody multiBulletInstance2 = Instantiate(m_multiBullet, m_transformFireOriginLeft.position, m_transformFireOriginLeft.rotation * Quaternion.Euler(90, 0, 0)) as Rigidbody;
        //multiBulletInstance2.rotation = Quaternion.Euler(30, 0, 0);
        Rigidbody multiBulletInstance3 = Instantiate(m_multiBullet, m_transformFireOriginRight.position, m_transformFireOriginRight.rotation * Quaternion.Euler(90, 0, 0)) as Rigidbody;
        //multiBulletInstance3.rotation = Quaternion.Euler(-30, 0, 0);

        multiBulletInstance1.velocity = m_multiLaunchForce * m_transformFireOrigin.forward;
        multiBulletInstance2.velocity = m_multiLaunchForce * m_transformFireOriginLeft.forward;
        multiBulletInstance3.velocity = m_multiLaunchForce * m_transformFireOriginRight.forward;
    }
}
