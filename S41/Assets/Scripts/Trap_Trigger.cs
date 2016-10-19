using UnityEngine;
using System.Collections;

public class Trap_Trigger : MonoBehaviour 
{
    float elapsedTime = 0;
    float fireDamage = 0;
    bool fireActivated = false;

	// Use this for initialization
	void Start () 
    {
	
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && elapsedTime < 3)
        {
            other.gameObject.SendMessage("SetMoveSpeed", 0f);

            elapsedTime += Time.deltaTime;

            //other.gameObject.GetComponent<EnemyHealth>().Hit(fireDamage);
            if (fireActivated == true)
            {
                fireDamage += (elapsedTime / 2);
                other.gameObject.GetComponent<EnemyHealth>().Hit(fireDamage);
            }

            if (elapsedTime > 3)
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
            //fireDamage += (elapsedTime * 100);
            fireActivated = true;
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
