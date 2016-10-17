using UnityEngine;
using System.Collections;

public class WhiskAttack : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	
	}

    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyUp(KeyCode.J))
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyHealth>().Hit(10);       //Hit(10) has to be changed to Hit(dmg variable in simone script)
                //Destroy(gameObject);
            } 
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
