using UnityEngine;
using System.Collections;

public class Player_Attack : MonoBehaviour
{

    public GameObject m_player;
    public GameObject m_weaponTrigger;
    
    public Rigidbody m_weapon;
    public Transform m_attackTransform;

    public int m_playerNumber = 1;
    public float m_attackRate = 4.0f;       //After testing phase set this to private
    public float m_coolDown1 = 5.0f;        // Cooldown for skills. Must be Float to ensure fluid UI
    public float m_coolDown2 = 5.0f;        // See above


    //private string m_fireButton;
    private bool m_hasAttacked;


    void Start()
    {
        //m_fireButton = "Fire" + m_playerNumber;
       // m_weaponTrigger.SetActive(false);
        
    }

    private void Update()
    {
        //if(Input.GetButtonDown(m_fireButton))
        //{
        //    m_hasAttacked = false;
        //}

        //else if(Input.GetButtonUp(m_fireButton) && !m_hasAttacked)
        //{
        //    Attack();
        //}
    }
    private void Attack()
    {
        m_hasAttacked = true;
        Rigidbody weaponInstance = Instantiate(m_weapon, m_attackTransform.position, m_attackTransform.rotation) as Rigidbody;

        weaponInstance.velocity = m_attackRate * m_attackTransform.forward;
    }

}