﻿#region Using Statements

using UnityEngine;
using System.Collections.Generic;

#endregion

public class Solveig_Attack : MonoBehaviour
{
	#region Variables

	public Transform m_transformOrigin;                                 // Where the projectile is instantiated
	private List<Transform> m_targetList = new List<Transform>();        // List of enemies
	private List<Transform> m_allyList = new List<Transform>();          // List of friendlies
	public Rigidbody m_Projectile;                                      // The projectile
	public Rigidbody m_FlowerPower;

	public delegate void EventHandler();
	public static event EventHandler FlowerEvent;
	public static event EventHandler LoveEvent;

	Player_Movement m_playerMove;  // Reference to the movement component of the character for manipulating
	private bool m_isAxisInUse = false;

	public string xbox_name_X360_A;
	public string xbox_name_X360_B;
	public string xbox_name_X360_X;
	public string xbox_name_X360_Y;
	public string xbox_name_Rtrigger;
	public string xbox_name_RBumper;

	public AudioClip autoAttackSound1;
	public AudioClip autoAttackSound2;
	public AudioClip flowerPowerSound1;
	public AudioClip flowerPowerSound2;
	public AudioClip songOfLoveSound1;
	public AudioClip songOfLoveSound2;

	public ParticleSystem aoe_healing_stream;

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
		aoe_healing_stream.GetComponent<ParticleSystem>();
	}
	
#endregion

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
			if (Input.GetButton(xbox_name_RBumper))   
			{
				if (m_isAxisInUse == false)
				{
					Sol_Attack();
					
					SoundManager.instance.RandomizeSfx(autoAttackSound1, autoAttackSound2);
					m_isAxisInUse = true;
				}
				
			}
			if (Input.GetAxisRaw(xbox_name_Rtrigger) == 0)
			{
				m_isAxisInUse = false;
			}

			m_attackRate = 0;
		}


		if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetButtonDown(xbox_name_X360_B))
		{
			 if (m_flowerCooldownTiming == false)
			 {
				 if (FlowerEvent != null)
				 {
					 FlowerEvent();
					SoundManager.instance.RandomizeSfx(flowerPowerSound1, flowerPowerSound2);
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

		if(Input.GetKeyDown(KeyCode.Keypad9) || Input.GetButtonDown(xbox_name_X360_X))
		{
			 if (m_loveCooldownTiming == false)
			 {
				 if (LoveEvent != null)
				 {
					 LoveEvent();
					aoe_healing_stream.Play();
					SoundManager.instance.RandomizeSfx(songOfLoveSound1, songOfLoveSound2);

				}
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
	}

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


	public int GetFlowerCounter()
	{
		return m_fpCounter;
	}

	public int GetSongCounter()
	{
		return m_songCounter;
	}

}
