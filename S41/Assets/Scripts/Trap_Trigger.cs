using UnityEngine;
using System.Collections;

public class Trap_Trigger : MonoBehaviour 
{
    float elapsedTime = 0;

	// Use this for initialization
	void Start () 
    {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        elapsedTime = Time.deltaTime;

        while (other.gameObject.tag == "Enemy" && elapsedTime < 1)
        {
            other.gameObject.SendMessage("SetMoveSpeed", 0f);

            if (elapsedTime > 1)
            {
                other.gameObject.SendMessage("SetMoveSpeed", 10f);
            }
            //if (elapsedTime > 1)
            //{
            //    other.gameObject.SendMessage("SetMoveSpeed", 10f);
            //}
            break;
        }

    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
