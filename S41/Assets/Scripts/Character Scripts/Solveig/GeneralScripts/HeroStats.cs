using UnityEngine;
using System.Collections;

public class HeroStats : BaseStats 
{
	public int m_playerIndex; // used for assigning controls
	[HideInInspector]	public float m_moveSpeed = 12.0f;
	[HideInInspector] public float m_turnSpeed = 180.0f;

	// TODO: Add movement Audio...fikci nte skitne å funka så jag tog bort det atm...


	// Use this for initialization
	void Start () 
	{
		if( m_autoGenerateCalclulatedStats )
			CalculateAttributes();
	}
}
