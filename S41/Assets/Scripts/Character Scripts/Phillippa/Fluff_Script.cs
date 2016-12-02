using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class Fluff_Script : MonoBehaviour
{
    public List<Transform> m_targetList = new List<Transform>();
    MeshRenderer mr;
    private bool meshActive = false;
    private float meshTimer = 0;


	// Use this for initialization
	void Start () 
    {
        mr = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (meshActive == true)
        {
            meshTimer += Time.deltaTime;

            if (meshTimer >= 0.2f)
            {
                mr.enabled = false;
                meshActive = false;
                meshTimer = 0f;
            }
        }
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
        mr.enabled = true;
        meshActive = true;

        // m_timer.Start();
        foreach (var target in m_targetList)
        {
            RaycastHit targetConnected;
            Rigidbody targetBody = target.GetComponent<Rigidbody>();

            if (Physics.Raycast(transform.position, (target.position - transform.position), out targetConnected, 1000))
            {
                if (targetConnected.transform == target && targetConnected.transform != null)
                {
                    if (target.gameObject.tag == "Enemy")
                    {
                        target.SendMessage("Hit", 10);
                        target.SendMessage("SetMoveSpeed", 0f);
                        target.SendMessage("Stun", true);
                        target.SendMessage("StunRange", true);
                    }

                    if (target.gameObject.tag == "Trap")
                    {
                        targetBody.AddExplosionForce(2000f, transform.position, 50f);
                        target.SendMessage("FlyAway", true);
                    }
                }
            }
        }
    }
}
