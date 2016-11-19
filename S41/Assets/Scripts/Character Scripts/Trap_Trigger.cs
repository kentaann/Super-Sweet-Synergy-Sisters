using UnityEngine;
using System.Collections;

public class Trap_Trigger : MonoBehaviour 
{
    private float trapTimer = 0;
    private float fireTimer = 0;
    private float fluffTimer = 0;
    private float fireDamage = 0.5f;
    public bool fireActivated = false;
    public bool fluffActivated = false;
    public bool trapDestroyed = false;


	// Use this for initialization
	void Start () 
    {
	}


    /// <summary>
    /// Activates when the trap is hit by Fire
    /// </summary>
    /// <param name="fireHit"></param>
    public void FiredUp(bool fireHit)
    {
        if (fireHit == true)
        {
            fireActivated = true;
        }
    }

    /// <summary>
    /// Activates when the trap is hit by the FLuffpound skill
    /// </summary>
    /// <param name="fluffHit"></param>
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

            if (fireTimer >= 10)            //As soon as the trap is on fire, it will be destroyed after 10 seconds
            {
                Destroy(gameObject);
                trapDestroyed = true;
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

    private void OnTriggerStay(Collider other)
    {
        //Bug: Only the first enemy that entered the trap can move again after the trap is destroyed. The others stay stationary on the location of the trap

        if (other.gameObject.tag == "Enemy" && trapTimer < 10)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;

            other.gameObject.SendMessage("SetMoveSpeed", 0f);

            trapTimer += Time.deltaTime;

            if (fireActivated == true)
            {
                other.gameObject.GetComponent<EnemyHealth>().Hit(fireDamage);

                if (fireTimer >= 10)
                {
                    other.gameObject.SendMessage("SetMoveSpeed", 2f);
                    Destroy(gameObject);
                    other.gameObject.SendMessage("SetMoveSpeed", 2f);
                }
            }

            if (trapTimer >= 10)
            {
                other.gameObject.SendMessage("SetMoveSpeed", 2f);
                trapDestroyed = true;
                Destroy(gameObject);
                other.gameObject.SendMessage("SetMoveSpeed", 2f);
            }

            if (trapDestroyed == true)
            {
                other.gameObject.SendMessage("SetMoveSpeed", 2f);
            }
        }
    }
}
