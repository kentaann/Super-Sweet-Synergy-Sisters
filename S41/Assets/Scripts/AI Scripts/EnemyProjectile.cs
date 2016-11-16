using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyProjectile : MonoBehaviour
{


    public Transform m_transformOrigin;
    public Rigidbody m_EnemyBullet;
    private float m_bulletLaunchForce;
    private float shootInterval = 1.0f;
    private float nextShot = 0;
    public Transform[] m_Targets;
    
    public float distance;
    // Use this for initialization
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(m_Targets.Length != GameObject.FindGameObjectsWithTag("Player").Length)
        {
            GroupResize(GameObject.FindGameObjectsWithTag("Player").Length, ref m_Targets);
        }
        

        distance = Vector3.Distance(gameObject.transform.position, GetClosestPlayers(m_Targets).position);

        if (distance <= 20)
        {
            if (Time.time > nextShot)
            {
                EnemyShooting();
                nextShot = Time.time + shootInterval;

            }
        }

    }

    private void OnEnable()
    {
        m_bulletLaunchForce = 5f;
    }

    private void EnemyShooting()
    {
        Rigidbody projectileInstance = Instantiate(m_EnemyBullet, m_transformOrigin.position, m_transformOrigin.rotation) as Rigidbody;
        projectileInstance.velocity = m_bulletLaunchForce * m_transformOrigin.forward;
    }

    Transform GetClosestPlayers(Transform[] m_Targets)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in m_Targets)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }
    public void GroupResize(int Size, ref Transform[] Group)
    {

        Transform[] temp = new Transform[Size];
        for (int c = 0; c < Mathf.Min(Size, Group.Length); c++)
        {
            temp[c] = Group[c];
        }
        Group = temp;
    }
}
