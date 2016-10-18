using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Rigidbody m_rigidBody;	// enhetens "fysik-kropp"
	private HeroStats m_stats;			// pekare till enhetens stats, inkl playerIndex, movementSpeed, turnspeed mm.

	private string m_moveAxisName;	// namnet på rörelse-axeln (så rätt matrix manipuleras...)
	private string m_turnAxisName;	// namnet på sväng-axeln (så sätt matrix manipuleras...)

	private float m_moveInputAmount; // förflyttnings grad/värde
	private float m_turnInputAmount; // sväng grad/värde


	/// <summary>
	/// Anropas samtidigt som scriptet skapas, alltså före start. Fungerar ungefär som intialize i XNA
	/// </summary>
	private void Awake()
	{
		m_rigidBody = GetComponent<Rigidbody>(); // hämtar Rigidbody objectet som är kopplad till enheten och sparar det lokalt.
	}

	/// <summary>
	/// Anropas när scriptet startas.
	/// </summary>
	void Start () 
	{
		m_stats = GetComponent<HeroStats>();

		Debug.Log( "m_stats.m_index = " + m_stats.m_playerIndex );

		m_moveAxisName = "Vertical" + m_stats.m_playerIndex;
		m_turnAxisName = "Horizontal" + m_stats.m_playerIndex;
	}

	/// <summary>
	/// Anropas när enheten blir tillgänglig för användning, ex. efter respawn.
	/// </summary>
	private void OnEnable()
	{
		m_rigidBody.isKinematic = false; // stänger av kinematic så fysik-events kan påverka enheten.
		m_moveInputAmount = 0.0f;	// nollställer movement input (så inte enheten börjar röra sig direkt)
		m_turnInputAmount = 0.0f;	// nollställer enhetens rotation (så inte enheten börjar snurra direkt)
	}

	/// <summary>
	/// Anropas när enheten inte längre är tillgänglig, ex. efter död
	/// </summary>
	private void OnDisable()
	{
		m_rigidBody.isKinematic = true; // startar kinematic så inga fysik-event kan påverka enheten.
	}

	/// <summary>
	/// Rullar varje frame
	/// </summary>
	void Update () 
	{
		// Tilldela värden från axlarna till input-värdena
		m_moveInputAmount = Input.GetAxis( m_moveAxisName );
		m_turnInputAmount = Input.GetAxis( m_turnAxisName );
	}

	/// <summary>
	/// Körs efter Update(), precis innan renderingen börjar
	/// </summary>
	private void FixedUpdate()
	{
		// uppdatera förflyttning och rotation
		Move();
		Turn();
	}

	/// <summary>
	/// Omvandlar spelarens input till rörelse för karaktären
	/// </summary>
	private void Move()
	{
		Vector3 movement = transform.forward * m_moveInputAmount * m_stats.m_moveSpeed * Time.deltaTime;
		m_rigidBody.MovePosition( m_rigidBody.position + movement );
	}

	/// <summary>
	/// Roterar enheten med hjälp av input från spelaren
	/// </summary>
	private void Turn()
	{
		float turn = m_turnInputAmount * m_stats.m_turnSpeed * Time.deltaTime;
		Quaternion turnQuat = Quaternion.Euler( 0.0f, turn, 0.0f );
		m_rigidBody.MoveRotation( m_rigidBody.rotation * turnQuat );
	}
}
