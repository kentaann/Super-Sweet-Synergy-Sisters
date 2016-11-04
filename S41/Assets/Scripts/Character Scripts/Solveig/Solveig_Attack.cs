using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Solveig_Attack : MonoBehaviour
{
    #region Variables

    public Transform m_transformOrigin;
    public List<Transform> m_targetList = new List<Transform>();
    public List<Transform> m_allyList = new List<Transform>();
    public Rigidbody m_Projectile;

    Player_Movement m_playerMove;

    private float m_launchForce;
    private float m_coolDown;
    private float m_attackRate;

    public float m_damage;

    #endregion

    #region On Enable

    private void OnEnable()
    {
        m_playerMove = GetComponent<Player_Movement>();
        m_launchForce = 30f;
        m_coolDown = 0.5f;
    }
    #endregion

    #region Start
    void Start () 
    {
	
	}
	
#endregion

    #region On Trigger Enter

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            m_targetList.Add(other.gameObject.transform);
        }

        if(other.gameObject.tag == "Player")
        {
            m_allyList.Add(other.gameObject.transform);
        }
    }

    #endregion

    #region On Trigger Exit

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            m_targetList.Remove(other.gameObject.transform);
        }

        if(other.gameObject.tag == "Player")
        {
            m_allyList.Remove(other.gameObject.transform);
        }
    }

    #endregion

    #region Update

    void Update () 
    {
	    if(m_targetList.Count > 0)
        {
            RemoveNullTarget();
        }

        if(m_allyList.Count > 0)
        {
            RemoveNullAlly();
        }

        m_attackRate += Time.deltaTime;

        if(m_attackRate >= m_coolDown)
        {
            if(Input.GetKey(KeyCode.Keypad0))
            {
                Sol_Attack();
            }
        }

	}

    #endregion

    #region Attack

    private void Sol_Attack()
    {
        Rigidbody projectileInstance = Instantiate(m_Projectile, m_transformOrigin.position, m_transformOrigin.rotation) as Rigidbody;
        projectileInstance.velocity = m_launchForce * m_transformOrigin.forward;
    }

    #endregion

    #region List Handling

    void RemoveNullTarget()
    {
        foreach(var target in m_targetList)
        {
            if(target == null)
            {
                m_targetList.Remove(target);
            }
        }
    }
    
    void RemoveNullAlly()
    {
        foreach(var ally in m_allyList)
        {
            if(ally == null)
            {
                m_allyList.Remove(ally);
            }
        }
    }

    #endregion
}
