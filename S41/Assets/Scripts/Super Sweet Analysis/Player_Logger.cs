#region Using Statements

using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using Assets.Scripts.Super_Sweet_Analysis;

#endregion

public class Player_Logger : MonoBehaviour
{
	#region Variables

	public GameObject m_PhillippaRef;               // Reference to Phillippa
	public GameObject m_SimoneRef;                  // Reference to Simone
	public GameObject m_SolveigRef;                 // Reference to Solveig
	public GameObject m_EliseRef;                   // Reference to Elise
	public JSON_Class m_jsonObject;                 // JSON object to save for parsing 

	private Vector3 m_PhillippaPosition;            // The position of Phillippa
	private Vector3 m_SimonePosition;               // The position of Simone
	private Vector3 m_SolveigPosition;              // The position of Solveig
	private Vector3 m_ElisePosition;                // The position of Elise

	private StreamWriter m_streamWriter = null;

	private string m_path = "";                     // The path to where the data is saved	

	private float m_currentTime = 0.0f;             // The current time, used for writing incrementally
	private float m_timeToWrite = 1.0f;             // Interval for when the call to write is made



	#endregion

	#region On Enable

	private void OnEnable()
	{
		m_SimoneRef.GetComponent<Simone_Attack>();
		m_PhillippaRef.GetComponent<Transform>();
		m_SimoneRef.GetComponent<Transform>();
		m_SolveigRef.GetComponent<Transform>();
		m_EliseRef.GetComponent<Transform>();
		m_path = (long)(DateTime.Today - new DateTime(1970, 1, 1)).TotalSeconds + DateTime.Now.TimeOfDay.TotalSeconds + ".txt";           // Creates a unique ID for each test case
	}

	#endregion

	#region Start

	void Start () 
	{
		m_streamWriter = new StreamWriter(m_path);
	}

	#endregion

	#region Update

	void Update () 
	{
		m_currentTime += Time.deltaTime;

		// Gets position from each character
		m_PhillippaPosition = m_PhillippaRef.GetComponent<Transform>().position;
		m_SimonePosition = m_SimoneRef.GetComponent<Transform>().position;
		m_SolveigPosition = m_SolveigRef.GetComponent<Transform>().position;
		m_ElisePosition = m_EliseRef.GetComponent<Transform>().position;


		if (m_currentTime > m_timeToWrite)
		{
			m_jsonObject.m_elPosList.Add(m_ElisePosition);
			m_jsonObject.m_phPosList.Add(m_PhillippaPosition);
			m_jsonObject.m_soPosList.Add(m_SolveigPosition);
			m_jsonObject.m_siPosList.Add(m_SimonePosition);
			m_currentTime = 0.0f;
		}
	}    

	#endregion

	void SetCounters()
	{
		m_jsonObject.m_energyCounter = m_SimoneRef.gameObject.GetComponent<Simone_Attack>().GetEnergyCounter();
		m_jsonObject.m_spicyCounter = m_SimoneRef.gameObject.GetComponent<Simone_Attack>().GetSpicyCounter();
		m_jsonObject.m_whippedCounter = m_SimoneRef.gameObject.GetComponent<Simone_Attack>().GetWhippedCounter();
		m_jsonObject.m_trapCounter = m_EliseRef.gameObject.GetComponent<Elise_Attack>().GetTrapCounter();
		m_jsonObject.m_songCounter = m_SolveigRef.gameObject.GetComponent<Solveig_Attack>().GetSongCounter();
		m_jsonObject.m_rushCounter = m_PhillippaRef.gameObject.GetComponent<Phillippa_Attack>().GetRushCounter();
		m_jsonObject.m_multiShotCounter = m_EliseRef.gameObject.GetComponent<Elise_Attack>().GetMultiCounter();
		m_jsonObject.m_flowerCounter = m_SolveigRef.gameObject.GetComponent<Solveig_Attack>().GetFlowerCounter();
		m_jsonObject.m_fluffCounter = m_PhillippaRef.gameObject.GetComponent<Phillippa_Attack>().GetFluffCounter();
	}

	void WriteToJSON()
	{		
		string data = JsonUtility.ToJson(m_jsonObject);
		m_streamWriter.Write(data);
		m_streamWriter.Close();
	}


	#region On Application Quit

	void OnApplicationQuit()
	{
		m_jsonObject.SetAllDeathPosition();
		SetCounters();
		WriteToJSON();
	}

	#endregion
}
