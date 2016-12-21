using UnityEngine;
using System.Collections;

public class WhiskAttack : MonoBehaviour
{
	public bool m_rushActive = false;
	public bool m_creamActive = false;
	public bool m_energyActive = false;
	public bool m_spicyActive = false;

	public delegate void EventHandler();
	public static event EventHandler SpicySplash;
	public static event EventHandler EnergyStun;

	public Vector3 from;
	public Vector3 to;
	public float speed;

	private Quaternion startingRotation;

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

			if (m_creamActive == true)
			{
				other.gameObject.GetComponent<EnemyHealth>().Hit(20);
			}

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

	//public void IsRushing(bool rushing)
	//{
	//    m_rushActive = rushing;
	//}

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
