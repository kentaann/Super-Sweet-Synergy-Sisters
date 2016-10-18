using UnityEngine;
using System.Collections;

public class Trap_Trigger : MonoBehaviour 
{
    float elapsedTime = 0;

	// Use this for initialization
	void Start () 
    {
	
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && elapsedTime < 1)
        {
            other.gameObject.SendMessage("SetMoveSpeed", 0f);

            elapsedTime += Time.deltaTime;

            if (elapsedTime > 1)
            {
                other.gameObject.SendMessage("SetMoveSpeed", 10f);
            }
        }

    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
