using UnityEngine;
using System.Collections;
using System;

public class Attakoi : MonoBehaviour {

    public GameObject m_target;
    //public Rigidbody m_bullet;
    //public Transform m_fireTransform;

    private Vector3 m_rushTarget;
    private bool m_fired;
    private float m_chargeSpeed;
    //private float m_launchForce;
    private float m_rushSpeed;


    private float m_rushCooldown = 0;

    // https://www.youtube.com/watch?v=_r1phHXODjc

    private  void OnEnable()
    {
        //m_launchForce = 30;
    }

	// Use this for initialization
	void Start () 
    {
        m_chargeSpeed = 100;
	}
	
	// Update is called once per frame
	void Update () 
    {

        if(Input.GetKeyUp(KeyCode.X))
        {
            Attacka();
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            Rush();
        }

        //if(Input.GetKeyUp(KeyCode.B) && !m_fired)
        //{
        //    Shoot();
        //}
	
	}

    //private void Shoot()
    //{
    //    m_fired = true;

    //    Rigidbody bulletInstance = Instantiate(m_bullet, m_fireTransform.position, m_fireTransform.rotation) as Rigidbody;

    //    bulletInstance.velocity = m_launchForce * m_fireTransform.forward;
    //}

    /// <summary>
    /// This teleports the character forward. As in does not traverse the space between the points.
    /// This is not a good solution but right now this is at least working.
    /// </summary>
    private void Rush()
    {       
       
        float step = m_rushSpeed * Time.deltaTime;

        m_rushTarget = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, m_rushTarget, step);

        if(m_rushCooldown == 0)
        {
            transform.Translate(transform.forward * Time.deltaTime * 350);
            
        }
    }

    /// <summary>
    /// Calculates the distance and direction of the target from the hero. If they are close enough the enemy will take damage.
    /// </summary>
    private void Attacka()
    {
        float distance = Vector3.Distance(m_target.transform.position, transform.position);

        Vector3 direction = (m_target.transform.position - transform.position).normalized;

        float dirrection = Vector3.Dot(direction, transform.forward);

        Debug.Log(distance);
        Debug.Log(dirrection);

        if(distance < 2)
        {
            Enemy_Health eh = (Enemy_Health)m_target.GetComponent("Enemy_Health");
            eh.AdjustCurrentHP(-10);
        }
    }
}
