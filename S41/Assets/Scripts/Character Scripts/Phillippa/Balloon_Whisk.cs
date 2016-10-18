using UnityEngine;
using System.Collections;

public class Balloon_Whisk : MonoBehaviour 
{
    int m_damage;
    public GameObject m_weaponHolder;
    Transform m_weaponPosition;


	// Use this for initialization
	void Start () 
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), m_weaponHolder.GetComponent<Collider>());
        transform.parent = m_weaponPosition;
        transform.position = m_weaponPosition.position;
        transform.rotation = m_weaponPosition.rotation;
	}

    void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        if(enemy)
        {
            enemy.Hit(m_damage);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
