using UnityEngine;
using System.Collections;

public class Elise_Attack : MonoBehaviour 
{

    public Transform m_transformOrigin;
    public Collider m_trap;
    public Rigidbody m_multiBullet;

    private float m_multiLaunchForce;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.O) || Input.GetButton("X360_B"))
        {
            E_LayTrap();
        } 
	}

    private void E_LayTrap()
    {
        Collider m_trapInstance = Instantiate(m_trap, m_transformOrigin.position, m_transformOrigin.rotation) as Collider;
    }

    private void E_MultiShot()
    {
        Rigidbody multiBulletInstance1 = Instantiate(m_multiBullet, m_transformOrigin.position, m_transformOrigin.rotation) as Rigidbody;
        Rigidbody multiBulletInstance2 = Instantiate(m_multiBullet, m_transformOrigin.position, m_transformOrigin.rotation) as Rigidbody;
        Rigidbody multiBulletInstance3 = Instantiate(m_multiBullet, m_transformOrigin.position, m_transformOrigin.rotation) as Rigidbody;
        multiBulletInstance1.velocity = m_multiLaunchForce * m_transformOrigin.forward;
        multiBulletInstance2.velocity = m_multiLaunchForce * m_transformOrigin.forward;
        multiBulletInstance3.velocity = m_multiLaunchForce * m_transformOrigin.forward;
    }
}
