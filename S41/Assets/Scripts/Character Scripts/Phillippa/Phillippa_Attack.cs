using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Phillippa_Attack : MonoBehaviour 
{
    public List<Transform> m_targetList = new List<Transform>();
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            m_targetList.Add(other.gameObject.transform);
        }
    }
    void OnTriggerExit(Collider other)
    {
        m_targetList.Remove(other.gameObject.transform);
    }
    public void Fluffpound()
    {
        foreach (var target in m_targetList)
        {
            RaycastHit targetConnected;
            if (Physics.Raycast(transform.position, (target.position - transform.position), out targetConnected, 100))
            {
                if (targetConnected.transform == target)
                {
                    target.SendMessage("Hit", 10);
                }
            }

        }
    }

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKeyUp(KeyCode.I))
        {
            Fluffpound();
            Debug.Log("Fluffpound");
        }
	}
}
