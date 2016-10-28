using UnityEngine;
using System.Collections;

public class Trap_Trigger : MonoBehaviour 
{
    float trapTimer = 0;
    float fireTimer = 0;
    float fluffTimer = 0;
    float fireDamage = 0.5f;
    bool fireActivated = false;
    bool fluffActivated = false;

	// Use this for initialization
	void Start () 
    {
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && trapTimer < 5)
        {
            other.gameObject.SendMessage("SetMoveSpeed", 0f);

            trapTimer += Time.deltaTime;

            if (fireActivated == true)
            {
                other.gameObject.GetComponent<EnemyHealth>().Hit(fireDamage);
            }

            if (trapTimer >= 5)
            {
                other.gameObject.SendMessage("SetMoveSpeed", 2f);
                Destroy(gameObject);
            }
        }
    }

    public void FiredUp(bool fireHit)
    {
        if (fireHit == true)
        {
            fireActivated = true;
        }
    }

    public void FlyAway(bool fluffHit)
    {
        if (fluffHit == true)
        {
            fluffActivated = true;
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (fireActivated)
        {
            GetComponent<Renderer>().material.color = Color.red;

            fireTimer += Time.deltaTime;

            if (fireTimer >= 10)
            {
                Destroy(gameObject);
            }
        }

        if (fluffActivated)
        {
            fluffTimer += Time.deltaTime;

            if (fluffTimer >= 0.5f)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                fluffTimer = 0;
                fluffActivated = false;
            }
        }
	}
}
