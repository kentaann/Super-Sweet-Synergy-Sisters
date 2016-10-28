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

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.O) || Input.GetButtonDown("X360_B"))
        {
            E_LayTrap();
        } 

        if (Input.GetKeyDown(KeyCode.B))
        {
            E_MultiShot();
        }
	}

    private void E_LayTrap()
    {
        Collider m_trapInstance = Instantiate(m_trap, m_transformTrapOrigin.position, m_transformTrapOrigin.rotation) as Collider;
    }

    private void E_MultiShot()
    {
        Rigidbody multiBulletInstance1 = Instantiate(m_multiBullet, m_transformFireOrigin.position, m_transformFireOrigin.rotation) as Rigidbody;
        Rigidbody multiBulletInstance2 = Instantiate(m_multiBullet, m_transformFireOriginLeft.position, m_transformFireOriginLeft.rotation) as Rigidbody;
        //multiBulletInstance2.rotation = Quaternion.Euler(30, 0, 0);
        Rigidbody multiBulletInstance3 = Instantiate(m_multiBullet, m_transformFireOriginRight.position, m_transformFireOriginRight.rotation) as Rigidbody;
        //multiBulletInstance3.rotation = Quaternion.Euler(-30, 0, 0);

        multiBulletInstance1.velocity = m_multiLaunchForce * m_transformFireOrigin.forward;
        multiBulletInstance2.velocity = m_multiLaunchForce * m_transformFireOriginLeft.forward;
        multiBulletInstance3.velocity = m_multiLaunchForce * m_transformFireOriginRight.forward;
    }
}
