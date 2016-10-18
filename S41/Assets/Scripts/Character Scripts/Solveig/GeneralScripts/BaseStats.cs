using UnityEngine;
using System.Collections;

public class BaseStats : MonoBehaviour 
{
	// --== Variables ==--
	// -= Editor Variables =-
	public string m_name;
	public string m_info = "";

	public int m_level;
	
	public float m_strength;
	public float m_intellect;
	public float m_agility;
	public float m_stamina;

	public bool m_autoGenerateCalclulatedStats = false;

	[HideInInspector] public bool m_isDead = false;

	// -= Calculated Variables =-
	public float m_curHP, m_maxHP;

	public float m_attackDamage;

	public float m_spellDamage;

	public float m_damageReductionInPercent;

	public float m_dodge;

	public float m_hitChanceInPercent;

	public float m_curXP, m_maxXP;

	protected float m_modValue_Level;


	//// Use this for initialization
	//void Start () 
	//{
	//	if( m_autoGenerateCalclulatedStats )
	//		CalculateAttributes();
	//}
	
	//// Update is called once per frame
	//void Update () 
	//{
	
	//}

	protected void CalculateAttributes()
	{
		m_modValue_Level = 1 + ( (float)m_level / 10 );

		Calculate_HP();
		Calculate_AttackDamage();
		Calclulate_SpellDamage();
		Calculate_DamageReduction();
		Calculate_Dodge();
		Calculate_HitChance();
	}

	private void Calculate_HP()
	{
		float modValue = m_stamina / 10 < 1 ? 1 + ( m_stamina / 10 ) : m_stamina / 10;
		m_curHP = m_maxHP = 150.0f * modValue * m_modValue_Level;
	}

	private void Calculate_AttackDamage()
	{
		float modValue = m_strength / 10 < 1 ? 1 + ( m_strength / 10 ) : m_strength / 10;
		m_attackDamage = 100 * modValue * m_modValue_Level;
	}

	private void Calclulate_SpellDamage()
	{
		float modValue = m_intellect / 10 < 1 ? 1 + ( m_intellect / 10 ) : m_intellect / 10;
		m_spellDamage = 50 * modValue * m_modValue_Level;
	}

	private void Calculate_DamageReduction()
	{
		float modValue;

		if( ( m_strength + m_stamina ) / 10 < 1 )
			modValue = 1 + ( ( m_strength + m_stamina ) / 10 );
		else
			modValue = ( m_strength + m_stamina ) / 10;

		m_damageReductionInPercent = ( 5 * modValue * m_modValue_Level ) / 100.0f;
	}

	private void Calculate_Dodge()
	{
		float modValue = m_agility / 10 < 1 ? 1 + m_agility / 10 : m_agility / 10;
		m_dodge = 1 * modValue * 1 + ( m_modValue_Level - 1 ) / 2;
	}

	private void Calculate_HitChance()
	{
		m_hitChanceInPercent = 1.0f;
	}
}
