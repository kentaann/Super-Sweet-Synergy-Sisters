using UnityEngine;
using System.Collections;

public class Trap_Trigger : MonoBehaviour 
{
    float elapsedTime = 0;
    float fireDamage = 0.5f;
    bool fireActivated = false;

	// Use this for initialization
	void Start () 
    {
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && elapsedTime < 5)
        {
            other.gameObject.SendMessage("SetMoveSpeed", 0f);

            elapsedTime += Time.deltaTime;

            if (fireActivated == true)
            {
                other.gameObject.GetComponent<EnemyHealth>().Hit(fireDamage);
            }

            if (elapsedTime >= 5)
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
	
	// Update is called once per frame
	void Update () 
    {
        if (fireActivated)
        {
            GetComponent<Renderer>().material.color = Color.red;

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= 10)
            {
                Destroy(gameObject);
            }
        }
	}
}
