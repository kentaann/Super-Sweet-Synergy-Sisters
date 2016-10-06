﻿using UnityEngine;
using System.Collections;

public class Bullet_Collide : MonoBehaviour 
{
    public LayerMask m_EnemyMask;

    public float m_maxDamage = 100f;
    public float m_explosionForce = 1000f;
    public float m_lifeSpan = 5f;
    public float m_explosionRadius = 1f;

	// Use this for initialization
	void Start () 
    {
        Destroy(gameObject, m_lifeSpan);
	}

    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_explosionRadius, m_EnemyMask);

        for(int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(m_explosionForce, transform.position, m_explosionRadius);

            Enemy_Health enemyHealth = targetRigidbody.GetComponent<Enemy_Health>();

            if (!enemyHealth)
                continue;

            float damage = CalculateDamage(targetRigidbody.position);

            enemyHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (m_explosionRadius - explosionDistance) / m_explosionRadius;

        float damage = relativeDistance * m_maxDamage;

        damage = Mathf.Max(0f, damage);

        return damage;
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}