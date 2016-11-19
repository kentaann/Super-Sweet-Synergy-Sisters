using UnityEngine;
using System.Collections;

public class WhiskAttack : MonoBehaviour
{
    public bool m_rushActive = false;
    public bool m_beamActive = false;

    public Vector3 from;
    public Vector3 to;
    public float speed;

    private Quaternion startingRotation;

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
        Phillippa_Attack.BeamCollider += AttackInBeam;
    }

    void OnDisable()
    {
        Phillippa_Attack.RushEvent -= AttackInRush;
        Phillippa_Attack.BeamCollider -= AttackInBeam;
    }

    public void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            if (Input.GetKeyDown(KeyCode.J))            //The normal melee attack
            {
                other.gameObject.GetComponent<EnemyHealth>().Hit(10);       //Hit(10) has to be changed to Hit(dmg variable in simone script)
                //Destroy(gameObject);
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (m_rushActive == true)
            {
                other.gameObject.GetComponent<EnemyHealth>().Hit(10);
            }

            if (m_beamActive == true)
            {
                other.gameObject.GetComponent<EnemyHealth>().Hit(20);
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

            if (m_beamActive == true)
            {
                m_beamActive = false;
            }
        }
    }

    //public void IsRushing(bool rushing)
    //{
    //    m_rushActive = rushing;
    //}

    public void AttackInRush()
    {
        m_rushActive = true;
    }

    public void AttackInBeam()
    {
        m_beamActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //IsRushing(m_rushActive);

        if (Input.GetKey(KeyCode.J))
        {
            float t = Mathf.PingPong(Time.time * speed * 2.0f, 1.0f);
            transform.localEulerAngles = Vector3.Lerp(from, to, t);
        }
        else
        {
            transform.localRotation = startingRotation;
        }
    }
}
