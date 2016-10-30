using UnityEngine;
using System.Collections;

public class WhiskAttack : MonoBehaviour 
{

    public bool m_rushActive = false;

	// Use this for initialization
	void Start () 
    {
	
	}

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                other.gameObject.GetComponent<EnemyHealth>().Hit(10);       //Hit(10) has to be changed to Hit(dmg variable in simone script)
                //Destroy(gameObject);
            }

            if (m_rushActive == true)
            {
                other.gameObject.GetComponent<EnemyHealth>().Hit(10);
            }
        }
    }

    public void IsRushing(bool rushing)
    {
        m_rushActive = rushing;
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
