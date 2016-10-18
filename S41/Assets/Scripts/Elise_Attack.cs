using UnityEngine;
using System.Collections;

public class Elise_Attack : MonoBehaviour 
{

    public Transform m_transformOrigin;
    public Collider m_trap;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.O) || Input.GetButton("X360_B"))
        {
            E_LayTrap();
        } 
	}

    private void E_LayTrap()
    {
        Collider m_trapInstance = Instantiate(m_trap, m_transformOrigin.position, m_transformOrigin.rotation) as Collider;
    }
}
