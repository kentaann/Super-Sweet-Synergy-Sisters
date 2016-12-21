using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WhiskAttack : MonoBehaviour
{
    private bool m_rushActive = false;
    private bool m_creamActive = false;
    private bool m_energyActive = false;
    private bool m_spicyActive = false;

    public delegate void EventHandler();
    public static event EventHandler SpicySplash;
    public static event EventHandler EnergyStun;

    public Vector3 from;
    public Vector3 to;
    public float speed;

    private Quaternion startingRotation;
    public List<GameObject> m_enemyList = new List<GameObject>();

    Phillippa_Attack philippa;

    // Use this for initialization
    void Start()
    {
        m_rushActive = false;

        from = new Vector3(-60.41f, 0, 0);
        to = new Vector3(0, 0, 0);

        speed = 2;

        startingRotation = transform.localRotation;
    }

    void OnEnable()
    {
        Phillippa_Attack.RushEvent += AttackInRush;
        Phillippa_Attack.RushEnd += EndOfRush;
        Phillippa_Attack.CreamCollider += AttackInCream;
        Phillippa_Attack.EnergyCollider += AttackInEnergy;
        Phillippa_Attack.SpicyCollider += AttackInSpicy;
    }

    void OnDisable()
    {
        Phillippa_Attack.RushEvent -= AttackInRush;
        Phillippa_Attack.RushEnd -= EndOfRush;
        Phillippa_Attack.CreamCollider -= AttackInCream;
        Phillippa_Attack.EnergyCollider -= AttackInEnergy;
        Phillippa_Attack.SpicyCollider -= AttackInSpicy;
    }

    public void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            if (m_rushActive || m_creamActive)
            {
            m_enemyList.Add(other.gameObject);
            }

            if (Input.GetKeyDown(KeyCode.J))            //The normal melee attack
            {
                other.gameObject.GetComponent<EnemyHealth>().Hit(10);       //Hit(10) has to be changed to Hit(dmg variable in simone script)
                //Destroy(gameObject);
            }
            foreach (GameObject enemy in  m_enemyList)
            {
                if (m_enemyList.Count > 0)
                {
                    RemoveNullTarget();
                }

                if (m_rushActive == true)
                {
                    if (enemy.GetComponent<EnemyHealth>().m_attackable == true)
                    {
                        enemy.GetComponent<EnemyHealth>().Hit(10);
                        enemy.GetComponent<EnemyHealth>().m_attackable = false;
                    } 
                    if (m_creamActive == true)
                    {
                       if (enemy.GetComponent<EnemyHealth>().m_creamAttackable == true)
                       {
                           enemy.GetComponent<EnemyHealth>().Hit(20);
                           enemy.GetComponent<EnemyHealth>().m_creamAttackable = false;
                       } 
                   }
                } 
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (m_energyActive == true)
            {
                if (EnergyStun != null)
                {
                    EnergyStun();
                }
            }

            if (m_spicyActive == true)
            {
                if (SpicySplash != null)
                {
                    SpicySplash();
                }
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (m_rushActive == true)
            {
                m_rushActive = false;
            }
        }

        if (other.gameObject.tag == "wcBeam")
        {
            if (m_creamActive == true)
            {
                m_creamActive = false;
            }
        }

        if (other.gameObject.tag == "scBeam")
        {
            if (m_spicyActive == true)
            {
                m_spicyActive = false;
            }
        }

        if (other.gameObject.tag == "edBeam")
	    {
		    if (m_energyActive == true)
            {
                m_energyActive = false;
            } 
	    }
    }

    public void AttackInRush()
    {
        m_rushActive = true;
    }

    public void EndOfRush()
    {
        m_rushActive = false;
        m_creamActive = false;
        m_energyActive = false;
        m_spicyActive = false;
    }

    public void AttackInCream()
    {
        m_creamActive = true;
    }

    public void AttackInEnergy()
    {
        m_energyActive = true;
    }

    public void AttackInSpicy()
    {
        m_spicyActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            float t = Mathf.PingPong(Time.time * speed * 2.0f, 1.0f);
            transform.localEulerAngles = Vector3.Lerp(from, to, t);
        }
        else
        {
            transform.localRotation = startingRotation;
        }

        ResetList();
    }

    void ResetList()
    {
        if(!m_rushActive && !m_creamActive)
        {
            foreach(var e in m_enemyList)
            {
                m_enemyList.Remove(e);
            }
        }
    }

    void RemoveNullTarget()
    {
        foreach (var target in m_enemyList)
        {
            if (target == null)
            {
                m_enemyList.Remove(target);
            }
        }
    }
}
