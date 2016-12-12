using UnityEngine;
using System.Collections;

public class Solveig_FlowerPower : MonoBehaviour {

	private const float m_HEALENEMIES = 20.0f;
	private const float m_HEAL = 40.0f;
	private const float m_RADIUS = 0.5f;
	private const float m_LIFESPAN = 3.0f;          // The lifespan of the object so it does not live forever to avoid edgecases where projectile does not collide with anything

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Collider>().isTrigger = true;

		Destroy(gameObject, m_LIFESPAN);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter(Collider other)
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, m_RADIUS);



		// Heal the enemy
		if (other.gameObject.tag == "Enemy")
		{
			other.gameObject.GetComponent<EnemyHealth>().Heal(m_HEALENEMIES);
			Destroy(gameObject);
		}

		//Heal friendly
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<FixedPlayerHealth>().GetHeal(m_HEAL);
			Destroy(gameObject);
		}

		if (other.gameObject.tag == "Environment")
		{
			Destroy(gameObject);
		}

	}
}
