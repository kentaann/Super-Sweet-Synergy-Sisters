using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Song_Script : MonoBehaviour 
{
	private MeshRenderer m_songRenderer;
	private List<Transform> m_allyList = new List<Transform>();

	private bool m_activeMesh = false;
	private float m_timer = 0;

	void Start () 
	{
		m_songRenderer = GetComponent<MeshRenderer>();
	}
	
	void Update () 
	{
		if(m_activeMesh == true)
		{
			m_timer += Time.deltaTime;

			if(m_timer >= 5f)
			{
				m_songRenderer.enabled = false;
				m_activeMesh = false;
				m_timer = 0f;
			}
		}	
	}

	void OnEnable()
	{
		Solveig_Attack.LoveEvent += Song;
	}

	void OnDisable()
	{
		Solveig_Attack.LoveEvent -= Song;
	}

	void OnTriggerEnter(Collider other)
	{
	   if(other.gameObject.tag == "Player")
	   {

	   }
	}

	void RemoveNullTarget()
	{
		foreach(var ally in m_allyList)
		{
			if(ally == null)
			{
				m_allyList.Remove(ally);
			}
		}
	}

	public void Song()
	{
		m_songRenderer.enabled = true;
		m_activeMesh = true;

		foreach (var ally in m_allyList)
		{
			RaycastHit allyConnected;
			Rigidbody allyBody = ally.GetComponent<Rigidbody>();

			if (Physics.Raycast(transform.position, (ally.position - transform.position), out allyConnected, 100))
			{
				if (allyConnected.transform == ally && allyConnected.transform != null)
				{
					if (ally.gameObject.tag == "Player")
					{
						ally.SendMessage("GetHeal", 25);
					}
				}
			}
		}
	}
}
