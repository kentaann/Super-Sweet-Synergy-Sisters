using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
    public Transform target;
    public int movespeed;
    public int rotationspeed;

    private Transform mytransform;

    void Awake()
    {
        mytransform = transform;
    }

	// Use this for initialization
	void Start () 
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        target = go.transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Debug.DrawLine(target.position, mytransform.position);

        mytransform.rotation = Quaternion.Slerp(mytransform.rotation, Quaternion.LookRotation(target.position - mytransform.position), rotationspeed * Time.deltaTime);

        mytransform.position += mytransform.forward * movespeed * Time.deltaTime;
	}
}
