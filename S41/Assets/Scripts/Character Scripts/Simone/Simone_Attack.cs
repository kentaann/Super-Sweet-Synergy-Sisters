#region Using Statements

using UnityEngine;
using System.Collections.Generic;

#endregion

public class Simone_Attack : MonoBehaviour
{
	#region Variables

	public Transform m_transformOrigin;                             // Where the attack will spawn on the character
	public List<Transform> m_targetList = new List<Transform>();    // List of all potential targets
	public Rigidbody m_bullet;                                      // The rigidbody of the projectile
	public Rigidbody m_spicyBullet;                                 // The rigidbody of the spicy chocolate projectile
	public Rigidbody m_whippedBullet;                               // The rigidbody of the whipped cream projectile
	public Rigidbody m_energyBullet;                                // The rigidbody of the energy drink projectile
	public GameObject m_spicyObj;                                   // Object of spicy chocolate
	public GameObject m_whippedObj;                                 // Object of whipped cream
	public GameObject m_energyObj;                                  // Object of energy drink
	Player_Movement m_playerMove;                                   // Used to manipulate movement from this class
	PlayerController m_playerMoveRef;

    public ParticleSystem m_spicyEffect;                            // Particles activated when Simone changes channeling ability
    public ParticleSystem m_whippedEffect;
    public ParticleSystem m_energyEffect;

	public delegate void EventHandler();
	public static event EventHandler ChannelEvent;

	public string xbox_name_X360_A;
	public string xbox_name_X360_B;
	public string xbox_name_X360_X;
	public string xbox_name_X360_Y;
	public string xbox_name_Rtrigger;
	public string xbox_name_RBumper;

	public AudioClip sound1;
	public AudioClip sound2;

	private bool m_isAxisInUse = false;

	private float m_bulletLaunchForce;                              // Speed of the projectile
	private float m_coolDown;                                       // Cooldown of attacks
	private float m_stunTimer;                 
	private float m_attackRate;                                     // Attackrate
	private float m_whippedCreamMoveSpeedMod;                       // Modifier for the players movespeed while using whipped cream
	private float m_channelCooldown = 0;

	private int m_whippedCounter = 0;                               // Number of times whipped cream has been fired
	private int m_energyCounter = 0;                                // Number of times energy drink has been fired 
	private int m_spicyCounter = 0;                                 // Number of times spicy chocolate has been fired


	private bool m_energyDrinkActive;                               // Flag for the Energy Drink element
	private bool m_autoAttackActive;                                // Flag for the Regular attack
	private bool m_whippedCreamActive;                              // Flag for the Whipped Cream element
	private bool m_spicyChocolateActive;                            // Flag for the Spicy Chocolate element
	private bool m_rushStunned;
	private bool m_channelCooldownTiming = false;

	//public float m_damage;                                         // Base damage per projectile


	#endregion

	#region On Enable

	/// <summary>
	/// Initiates the variables and sets the flags.
	/// </summary>
	private void OnEnable()
	{
		m_bulletLaunchForce = 30f;
		//m_damage = 10;
		m_coolDown = 0.5f;
		m_whippedCreamMoveSpeedMod = 0.75f;
		m_playerMove = GetComponent<Player_Movement>();
		m_playerMoveRef = GetComponent<PlayerController>();

		//m_bulletMaterial = new Material("EnergyDrink_Material");
		m_energyDrinkActive = false;
		m_whippedCreamActive = true;
		m_spicyChocolateActive = false;

		Phillippa_Attack.CreamCollider += RushCollide;
	}

	#endregion

	private void OnDisable()
	{
		Phillippa_Attack.CreamCollider -= RushCollide;
	}

	#region Start

	void Start()
	{

	}

	#endregion

	#region On Trigger Enter
	/// <summary>
	/// As soon as an enemy enters the sphere collider it is added to the target list.
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			m_targetList.Add(other.gameObject.transform);
		}
	}
	#endregion

	#region On Trigger Exit

	/// <summary>
	/// When an enemy leaves the Area of effect it is removed from the target list.
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerExit(Collider other)
	{
		m_targetList.Remove(other.gameObject.transform);
	}

	#endregion


	void Update()
	{
		if (m_targetList.Count > 0)
		{
			RemoveNullTarget();
		}

		m_attackRate += Time.deltaTime;

		if (m_rushStunned && m_stunTimer < 3.0f)
		{
			m_stunTimer += Time.deltaTime;

			gameObject.SendMessage("SetMoveSpeed", 0f);

			if (m_stunTimer >= 3.0f)
			{
				gameObject.SendMessage("SetMoveSpeed", 12f);
				m_stunTimer = 0f;
				m_rushStunned = false;
			}
		}

		if (m_attackRate >= m_coolDown)
		{
			if (Input.GetButton(xbox_name_RBumper))   
			{
				if (m_isAxisInUse == false)
				{

					if (GameObject.FindGameObjectsWithTag("wcBeam").Length == 0)
					{
						if (m_whippedCreamActive && !m_spicyChocolateActive && !m_energyDrinkActive)
						{
							S_WhippedCreamAttack();
							SoundManager.instance.RandomizeSfx(sound1, sound2);
							m_attackRate = 0;
							m_isAxisInUse = true;
						}
					}
				}

				if (m_energyDrinkActive && !m_spicyChocolateActive && !m_whippedCreamActive)
				{
					S_EnergyDrinkAttack();
					SoundManager.instance.RandomizeSfx(sound1, sound2);
					m_attackRate = 0;
				}

				if (m_spicyChocolateActive && !m_energyDrinkActive && !m_whippedCreamActive)
				{
					S_SpicyChocolateAttack();
					SoundManager.instance.RandomizeSfx(sound1, sound2);
					m_attackRate = 0;
				}
			}

			if (Input.GetAxisRaw(xbox_name_Rtrigger) == 0)
			{
				m_isAxisInUse = false;
			}
		}

		if (Input.GetKeyUp(KeyCode.L) || Input.GetButton(xbox_name_X360_B))
		{
			if (m_channelCooldownTiming == false)
			{
				if (ChannelEvent != null)
				{
					ChannelEvent();										
				}
				m_energyDrinkActive = true;
				m_spicyChocolateActive = false;
				m_whippedCreamActive = false;
				m_coolDown = 3f;
				m_channelCooldownTiming = true;

                GetComponentInChildren<ParticleSystem>(m_energyEffect).Play();
                //m_energyEffect.transform.GetComponentInChildren<ParticleSystem>().Play();
			}
		}

		if (Input.GetKeyUp(KeyCode.M) || Input.GetButton(xbox_name_X360_Y))
		{
			if (m_channelCooldownTiming == false)
			{
				if (ChannelEvent != null)
				{
					ChannelEvent();
				}
				m_spicyChocolateActive = true;
				m_energyDrinkActive = false;
				m_whippedCreamActive = false;
				m_coolDown = 3f;
				m_channelCooldownTiming = true;

                GetComponentInChildren<ParticleSystem>(m_spicyEffect).Play();
                //m_spicyEffect.transform.GetComponentInChildren<ParticleSystem>().Play();
			}
		}

		//I simply changed this to Whipped Cream and made it the default attack that Simone starts with //Bernhard
		if (Input.GetKeyUp(KeyCode.K) || Input.GetButton(xbox_name_X360_X))
		{
			if (m_channelCooldownTiming == false)
			{
				if (ChannelEvent != null)
				{
					ChannelEvent();
				}
				m_energyDrinkActive = false;
				m_whippedCreamActive = true;
				m_spicyChocolateActive = false;
				m_coolDown = 3f;
				m_channelCooldownTiming = true;

                GetComponentInChildren<ParticleSystem>(m_whippedEffect).Play();
                //m_whippedEffect.transform.GetComponentInChildren<ParticleSystem>().Play();
			}
		}

		if (m_channelCooldownTiming == true)
		{
			m_channelCooldown += Time.deltaTime;
		}

		if (m_channelCooldown >= 3.0f)
		{
			m_channelCooldownTiming = false;
			m_channelCooldown = 0f;
		}
	}

	/// <summary>
	/// Simones auto attack.
	/// Creates a bullet and shoots in the direction that Simone is facing.
	/// </summary>
	private void S_WhippedCreamAttack()
	{
		Vector3 playerPos = transform.position;
		Vector3 playerDirection = transform.forward;
		Quaternion playerRotation = transform.rotation;
		Instantiate(m_whippedObj, m_transformOrigin.position, transform.rotation * Quaternion.Euler(90, 0, 0), transform);
		m_whippedCounter++;
		m_whippedObj.GetComponent<Channeling_script>().whippedActive = true;
	}

	/// <summary>
	/// Energy Drink Element
	/// Player becomes stationary, damage is decreased and attackrate is increased.
	/// Should also change color of the attack to correctly correspond with the new element.
	/// </summary>
	private void S_EnergyDrinkAttack()
	{
		Vector3 playerPos = transform.position;
		Vector3 playerDirection = transform.forward;
		Quaternion playerRotation = transform.rotation;
		m_playerMoveRef.GetComponent<PlayerController>().m_energySpeed = true;
		Instantiate(m_energyObj, m_transformOrigin.position, transform.rotation * Quaternion.Euler(90, 0, 0), transform);
		m_energyCounter++;
		m_energyObj.GetComponent<Channeling_script>().energyActive = true;
		gameObject.GetComponent<Player_Movement>().energySpeed = true;
	}

	private void S_SpicyChocolateAttack()
	{
		Vector3 playerPos = transform.position;
		Vector3 playerDirection = transform.forward;
		Quaternion playerRotation = transform.rotation;
		Instantiate(m_spicyObj, m_transformOrigin.position, transform.rotation * Quaternion.Euler(90, 0, 0), transform);
		m_spicyCounter++;
		m_spicyObj.GetComponent<Channeling_script>().spicyActive = true;
	}


	public void RushCollide()
	{
		m_rushStunned = true;
	}

	public int GetWhippedCounter()
	{
		return m_whippedCounter;
	}

	public int GetEnergyCounter()
	{
		return m_energyCounter;
	}

	public int GetSpicyCounter()
	{
		return m_spicyCounter;
	}

	void AddEnemyToList()
	{
		foreach (GameObject other in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			m_targetList.Add(other.gameObject.transform);
		}
	}

	void RemoveNullTarget()
	{
		foreach (var target in m_targetList)
		{
			if (target == null)
			{
				m_targetList.Remove(target);
			}
		}
	}
}
