#region Using Statements

using UnityEngine;
using System.Collections.Generic;

#endregion

public class Solveig_Attack : MonoBehaviour
{
	#region Variables

	public Transform m_transformOrigin;                                 // Where the projectile is instantiated
	public List<Transform> m_targetList = new List<Transform>();        // List of enemies
	public List<Transform> m_allyList = new List<Transform>();          // List of friendlies
	public Rigidbody m_Projectile;                                      // The projectile
	public Rigidbody m_FlowerPower;

	public delegate void EventHandler();
	public static event EventHandler FlowerEvent;
	public static event EventHandler LoveEvent;

	Player_Movement m_playerMove;                                       // Reference to the movement component of the character for manipulating

	public string xbox_name_X360_A;
	public string xbox_name_X360_B;
	public string xbox_name_X360_X;
	public string xbox_name_X360_Y;

	private const float m_SPICYCREAMDAMAGE = 47.3f;                     // Damage modifier for Flower Power while under the Spicy Chocolate effect

	private float m_launchForce;                                        // Force the projectile is launched with
	private float m_coolDown;                                           // Cooldown of the shot
	private float m_attackRate;                                         // Rate of attack
	private int m_fpCounter = 0;                                        // Times Flower Power was used
	private int m_songCounter = 0;                                        // Times Song of Love was used

	private float m_flowerCooldown = 0f;
	private float m_loveCooldown = 0f;

	private bool m_flowerCooldownTiming = false;
	private bool m_loveCooldownTiming = false;

	private bool m_spicyCreamActive = false;
	private bool m_lovelyCreamActive = false;

	#endregion

	#region On Enable

	private void OnEnable()
	{
		m_playerMove = GetComponent<Player_Movement>();
		m_launchForce = 30f;
		m_coolDown = 0.5f;
	}
	#endregion

	#region Start
	void Start () 
	{
	
	}
	
#endregion

	#region On Trigger Enter

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			m_targetList.Add(other.gameObject.transform);
		}

		if(other.gameObject.tag == "Player")
		{
			m_allyList.Add(other.gameObject.transform);
		}

		if(other.gameObject.tag == "wcBeam")
		{
			m_lovelyCreamActive = true;
		}
	}

	#endregion

	#region On Trigger Exit

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			m_targetList.Remove(other.gameObject.transform);
		}

		if(other.gameObject.tag == "Player")
		{
			m_allyList.Remove(other.gameObject.transform);
		}
	}

	#endregion

	#region Update

	void Update () 
	{
		if(m_targetList.Count > 0)
		{
			RemoveNullTarget();
		}

		if(m_allyList.Count > 0)
		{
			RemoveNullAlly();
		}

		m_attackRate += Time.deltaTime;

		if(m_attackRate >= m_coolDown)
		{
			if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetButtonDown(xbox_name_X360_A))
			{
				Sol_Attack();
			}
		}

		#region Flower Power
		if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetButtonDown(xbox_name_X360_B))
		{
			 if (m_flowerCooldownTiming == false)
			 {
				 if (FlowerEvent != null)
				 {
					 FlowerEvent();
				 }

				 FlowerPower();
				 m_fpCounter++;
				 m_flowerCooldownTiming = true;
			 }
		}

		if (m_flowerCooldownTiming == true)
		{
			m_flowerCooldown += Time.deltaTime;
		}

		if (m_flowerCooldown >= 3.0f)
		{
			m_flowerCooldownTiming = false;
			m_flowerCooldown = 0f;
		}
		#endregion

		#region Song of Love
		if(Input.GetKeyDown(KeyCode.Keypad9) || Input.GetButtonDown(xbox_name_X360_X))
		{
			 if (m_loveCooldownTiming == false)
			 {
				 if (LoveEvent != null)
				 {
					 LoveEvent();
				 }

				 SongOfLove();
				 m_songCounter++;
				 m_loveCooldownTiming = true;
			 }
		}

		if (m_loveCooldownTiming == true)
		{
			m_loveCooldown += Time.deltaTime;
		}

		if (m_loveCooldown >= 5.0f)
		{
			m_loveCooldownTiming = false;
			m_loveCooldown = 0f;
		}
		#endregion

	}

	#endregion

	#region Attack

	private void Sol_Attack()
	{
		Rigidbody projectileInstance = Instantiate(m_Projectile, m_transformOrigin.position, m_transformOrigin.rotation) as Rigidbody;
		projectileInstance.velocity = m_launchForce * m_transformOrigin.forward;
	}
	private void FlowerPower()
	{
		Rigidbody projectileInstance = Instantiate(m_FlowerPower, m_transformOrigin.position, m_transformOrigin.rotation) as Rigidbody;
		projectileInstance.velocity = m_launchForce * m_transformOrigin.forward;
	}

	private void SongOfLove()
	{
		foreach(var target in m_targetList)
		{
			RaycastHit targetConnected;
			Rigidbody targetBody = target.GetComponent<Rigidbody>();

			if (Physics.Raycast(transform.position, (target.position - transform.position), out targetConnected, 100))
			{
				if(targetConnected.transform == target && target.transform != null)
				{
					if(target.gameObject.tag == "Enemy" && m_spicyCreamActive)
					{
						target.SendMessage("Hit", m_SPICYCREAMDAMAGE);
					}
				}
			}            
		}

		foreach(var ally in m_allyList)
		{
			RaycastHit allyConnected;
			Rigidbody allyBody = ally.GetComponent<Rigidbody>();

			if (Physics.Raycast(transform.position, (ally.position - transform.position), out allyConnected, 100))
			{
				if(allyConnected.transform == ally && allyConnected.transform != null)
				{
					if(ally.gameObject.tag == "Player")
					{
						ally.SendMessage("GetHeal", 25);
					}

					if(ally.gameObject.tag == "Player" && m_lovelyCreamActive)
					{
						ally.SendMessage("GetHeal", 15);
						ally.SendMessage("MakeInvulnerable");
					}
				}
			}                       
		}
	}

	#endregion

	#region List Handling

	void RemoveNullTarget()
	{
		foreach(var target in m_targetList)
		{
			if(target == null)
			{
				m_targetList.Remove(target);
			}
		}
	}
	
	void RemoveNullAlly()
	{
		foreach(var ally in m_allyList)
		{
			if(ally == null)
			{
				m_allyList.Remove(ally);
			}
		}
	}

	#endregion

	public int GetFlowerCounter()
	{
		return m_fpCounter;
	}

	public int GetSongCounter()
	{
		return m_songCounter;
	}

}
