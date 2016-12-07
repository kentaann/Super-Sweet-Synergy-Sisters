using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Char_Selection : MonoBehaviour 
{

	public List<GameObject> m_characterList;
	public int m_index = 0;

	void Start () 
	{
		GameObject[] m_characters = Resources.LoadAll<GameObject>("Prefabs/Characters");

		foreach(GameObject c in m_characters)
		{
			GameObject _char = Instantiate(c) as GameObject;
			_char.transform.SetParent(GameObject.Find("CharacterList").transform);

			m_characterList.Add(_char);
			_char.SetActive(false);
			m_characterList[m_index].SetActive(true);
		}
	}
	
	void Update () 
	{
		m_characterList[m_index].transform.Rotate(0, 0.1337f, 0);
	}

	public void NextClick()
	{
		m_characterList[m_index].SetActive(false);
		if(m_index == m_characterList.Count -1)
		{
			m_index = 0;
		}

		else
		{
		m_index++;
		}

		m_characterList[m_index].SetActive(true);
	}

	public void PrevClick()
	{
		m_characterList[m_index].SetActive(false);
		if (m_index == 0)
		{
			m_index = m_characterList.Count - 1;
		}

		else
		{
			m_index--;
		}

		m_characterList[m_index].SetActive(true);
	}


}
