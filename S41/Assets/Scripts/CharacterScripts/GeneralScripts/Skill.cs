using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour 
{
	public string m_name;
	public string m_description;
	public string m_effect;

	public string Description { get { return m_description + " " + m_effect; } }
	public string Name { get { return m_name; } }

	protected virtual void StartSkill()
	{	}

	protected virtual void StopSkill()
	{	}

	protected virtual void ChannelSkill()
	{	}
}
