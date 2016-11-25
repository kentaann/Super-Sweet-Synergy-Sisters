using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class Fluff_Script : MonoBehaviour
{
    public List<Transform> m_targetList = new List<Transform>();

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnEnable()
    {
        Phillippa_Attack.FluffEvent += Fluffpound;
    }

    void OnDisable()
    {
        Phillippa_Attack.FluffEvent -= Fluffpound;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Trap")
        {
            m_targetList.Add(other.gameObject.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        m_targetList.Remove(other.gameObject.transform);
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

    public void Fluffpound()
    {
        // m_timer.Start();
        foreach (var target in m_targetList)
        {
            RaycastHit targetConnected;
            Rigidbody targetBody = target.GetComponent<Rigidbody>();

            if (Physics.Raycast(transform.position, (target.position - transform.position), out targetConnected, 100))
            {
                if (targetConnected.transform == target && targetConnected.transform != null)
                {
                    if (target.gameObject.tag == "Enemy")
                    {
                        target.SendMessage("Hit", 10);
                        target.SendMessage("SetMoveSpeed", 0f);
                        target.SendMessage("Stun", true);
                    }

                    if (target.gameObject.tag == "Trap")
                    {
                        targetBody.AddExplosionForce(2000f, transform.position, 5f);
                        target.SendMessage("FlyAway", true);
                    }
                }
            }
        }
    }
}
