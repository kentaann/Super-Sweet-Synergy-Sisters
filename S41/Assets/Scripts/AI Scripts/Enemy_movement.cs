using UnityEngine;
using System.Collections;

public class Enemy_movement : MonoBehaviour {
    public float deathDistance = 0.5f;
    public float distanceAway;
    public Transform thisObject;
    public Transform target;
    private NavMeshAgent navComponent;
	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(target.position, transform.position);
        if(target)
        {
            navComponent.SetDestination(target.position);
        }
        //else
        //{
        //    if(target = null)
        //    {
        //        target = this.gameObject.GetComponent<Transform>();
        //    }
            //else
            //{
            //    target = GameObject.FindGameObjectWithTag("Player").transform;
            //}
        //}
        //if(dist<= deathDistance)
        //{
        //    //Kill Player
        //}
	}
}
