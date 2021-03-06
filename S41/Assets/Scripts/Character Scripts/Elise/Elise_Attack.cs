﻿using UnityEngine;

public class Elise_Attack : MonoBehaviour 
{

	public Transform m_transformTrapOrigin;
	public Transform m_transformFireOrigin;
	public Transform m_transformFireOriginLeft;
	public Transform m_transformFireOriginRight;
	public Collider m_trap;
	public Rigidbody m_multiBullet;

	public delegate void EventHandler();
	public static event EventHandler TrapEvent;
	public static event EventHandler MultiEvent;

	public float m_eliNormalCooldown = 0;
	public float m_trapCooldown = 0;
	public float m_multiCooldown = 0;

	private bool m_eliNormalCooldownTiming = false;
	private bool m_trapCooldownTiming = false;
	private bool m_multiCooldownTiming = false;

	public float m_multiLaunchForce;
	public string xbox_name_X360_A;
	public string xbox_name_X360_B;
	public string xbox_name_X360_X;
	public string xbox_name_X360_Y;
	public string xbox_name_Rtrigger;
	public string xbox_name_RBumper;


	public AudioClip aASound1;
	public AudioClip aASound2;
	public AudioClip marbleRainSound1;
	public AudioClip marbleRainSound2;
	public AudioClip trapSound1;
	public AudioClip trapSound2;


	private bool m_isAxisInUse = false;
	private int m_trapCounter = 0;              // Times Cookie Jar was used
	private int m_multiShotCounter = 0;         // Times Marble rain was used
	private float m_attackRate;
	private float m_coolDown;
	// Use this for initialization
	void Start () 
	{
	
	}

	void OnEnable()
	{
		m_coolDown = 0.25f;
	}

	// Update is called once per frame
	void Update()
	{
		m_attackRate += Time.deltaTime;

		if (Input.GetAxisRaw(xbox_name_Rtrigger) != 0)
		{
			if (m_eliNormalCooldownTiming == false)
			{
				if (m_isAxisInUse == false)
				{
					E_Normal_Attack();
					SoundManager.instance.RandomizeSfx(aASound1, aASound2);
					m_isAxisInUse = true;
				}
				m_eliNormalCooldownTiming = true;
			}
			if (m_eliNormalCooldownTiming == true)
			{
				m_eliNormalCooldown += Time.deltaTime;
			}
		}
		if (m_eliNormalCooldown >= 0.25f)
		{
			if (Input.GetAxisRaw(xbox_name_Rtrigger) == 0)
			{
				m_isAxisInUse = false;
				m_eliNormalCooldownTiming = false;
				m_eliNormalCooldown = 0f;
			}
		}
		#region Elise Normal Attack
		if (Input.GetButton(xbox_name_RBumper))         //for keyboard usage
		{
			if (m_attackRate > m_coolDown)
			{
				E_Normal_Attack();
				
			}
			m_attackRate = 0;
		}
		#endregion

		#region Cookie Jar Trap
		if (Input.GetKeyDown(KeyCode.O) || Input.GetButtonDown(xbox_name_X360_X))
		{
			if (m_trapCooldownTiming == false)
			{
				if (TrapEvent != null)
				{
					TrapEvent();
					SoundManager.instance.RandomizeSfx(trapSound1, trapSound2);
				}
				E_LayTrap();
				m_trapCounter++;
				m_trapCooldownTiming = true;
			}
		}

		if (m_trapCooldownTiming == true)
		{
			m_trapCooldown += Time.deltaTime;
		}

		if (m_trapCooldown >= 8.0f)
		{
			m_trapCooldownTiming = false;
			m_trapCooldown = 0f;
		}
		#endregion

		#region Multi Shot
		if (Input.GetKeyDown(KeyCode.B) || Input.GetButtonDown(xbox_name_X360_B))
		{
			if (m_multiCooldownTiming == false)
			{
				if (MultiEvent != null)
				{
					MultiEvent();
					SoundManager.instance.RandomizeSfx(marbleRainSound1, marbleRainSound2);
				}
				E_MultiShot();
				m_multiShotCounter++;
				m_multiCooldownTiming = true;
			}
		}

		if (m_multiCooldownTiming == true)
		{
			m_multiCooldown += Time.deltaTime;
		}

		if (m_multiCooldown >= 4.0f)
		{
			m_multiCooldownTiming = false;
			m_multiCooldown = 0f;
		}
		#endregion
	}

	private void E_Normal_Attack()
	{
		Rigidbody bulletInstance = Instantiate(m_multiBullet, m_transformFireOrigin.position, m_transformFireOrigin.rotation * Quaternion.Euler(90, 0, 0)) as Rigidbody;

		bulletInstance.velocity = m_multiLaunchForce * m_transformFireOrigin.forward;
	}

	/// <summary>
	/// Elise lays a stationary trap at her current position
	/// </summary>

	private void E_LayTrap()
	{
		m_transformTrapOrigin.position = new Vector3(m_transformTrapOrigin.position.x, m_transformTrapOrigin.position.y, m_transformTrapOrigin.position.z);
		Collider m_trapInstance = Instantiate(m_trap, m_transformTrapOrigin.position, m_transformTrapOrigin.rotation * Quaternion.Euler(270,0,0)) as Collider;
	}

	/// <summary>
	/// Elise shoots out three separate bullets in directions corresponding to their transformOrigins
	/// </summary>

	private void E_MultiShot()
	{
		Rigidbody multiBulletInstance1 = Instantiate(m_multiBullet, m_transformFireOrigin.position, m_transformFireOrigin.rotation * Quaternion.Euler(90, 0, 0)) as Rigidbody;
		Rigidbody multiBulletInstance2 = Instantiate(m_multiBullet, m_transformFireOriginLeft.position, m_transformFireOriginLeft.rotation * Quaternion.Euler(90, 0, 0)) as Rigidbody;
		//multiBulletInstance2.rotation = Quaternion.Euler(30, 0, 0);
		Rigidbody multiBulletInstance3 = Instantiate(m_multiBullet, m_transformFireOriginRight.position, m_transformFireOriginRight.rotation * Quaternion.Euler(90, 0, 0)) as Rigidbody;
		//multiBulletInstance3.rotation = Quaternion.Euler(-30, 0, 0);

		multiBulletInstance1.velocity = m_multiLaunchForce * m_transformFireOrigin.forward;
		multiBulletInstance2.velocity = m_multiLaunchForce * m_transformFireOriginLeft.forward;
		multiBulletInstance3.velocity = m_multiLaunchForce * m_transformFireOriginRight.forward;
		multiBulletInstance1.gameObject.GetComponent<Bullet_Collide>().multiActive = true;
		multiBulletInstance2.gameObject.GetComponent<Bullet_Collide>().multiActive = true;
		multiBulletInstance3.gameObject.GetComponent<Bullet_Collide>().multiActive = true;
	}

	public int GetMultiCounter()
	{
		return m_multiShotCounter;
	}

	public int GetTrapCounter()
	{
		return m_trapCounter;
	}
}
