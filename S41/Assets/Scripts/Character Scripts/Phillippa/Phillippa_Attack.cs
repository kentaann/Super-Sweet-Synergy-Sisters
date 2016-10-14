using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class Phillippa_Attack : MonoBehaviour
{
    public List<Transform> m_targetList = new List<Transform>();
    public SphereCollider m_Spherecollider;

    AiMovement m_aiMovemet;
    Stopwatch timer = new Stopwatch();

    private const float m_FLUFFCOOLDOWN = 6;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            m_targetList.Add(other.gameObject.transform);
            UnityEngine.Debug.Log(m_targetList.Count);
        }
    }
    void OnTriggerExit(Collider other)
    {
        m_targetList.Remove(other.gameObject.transform);
    }

    public void Fluffpound()
    {
        timer.Start();
        foreach (var target in m_targetList)
        {
            RaycastHit targetConnected;

            if (Physics.Raycast(transform.position, (target.position - transform.position), out targetConnected, 100))
            {
                if (targetConnected.transform == target)
                {

                    //while(timer.Elapsed.TotalSeconds > m_FLUFFCOOLDOWN)
                    //{
                    target.SendMessage("Hit", 50);
                    timer.Reset();
                    //}                    
                }
            }
        }
    }

    private void SetEnemyMoveSpeed(int movespeed)
    {
        m_aiMovemet.MoveSpeed = movespeed;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            Fluffpound();
            UnityEngine.Debug.Log("Fluffpound");
        }
    }
}
