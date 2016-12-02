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
	//private Vector3 m_DeathPositionPh;              // The final position of Phillippa
	//private Vector3 m_DeathPositionEl;              // The final position of Elise
	//private Vector3 m_DeathPositionSo;              // The final position of Solveig
	//private Vector3 m_DeathPositionSi;              // The final position of Simone
	//private List<Vector3> m_phPosList;              // List of Phillippas positions    
	//private List<Vector3> m_siPosList;              // List of Simones positions
	//private List<Vector3> m_soPosList;              // List of Solveigs positions
	//private List<Vector3> m_elPosList;              // List of Elises positions

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
		//m_phPosList = new List<Vector3>();
		//m_siPosList = new List<Vector3>();
		//m_soPosList = new List<Vector3>();
		//m_elPosList = new List<Vector3>();

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
			//m_phPosList.Add(m_PhillippaPosition);
			//m_siPosList.Add(m_SimonePosition);
			//m_elPosList.Add(m_ElisePosition);
			//m_soPosList.Add(m_SolveigPosition);
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

	#region Write to File

	void WriteToFile()
	{

		//for (int i = 0; i < m_phPosList.Count; i++)
		//{
		//    m_streamWriter.WriteLine("Position of Phillippa: " + " X: " + m_phPosList[i].x + " Y: " + m_phPosList[i].y + " Z: " + m_phPosList[i].z + "\n");            
		//}

		//for (int i = 0; i < m_elPosList.Count; i++)
		//{
		//    m_streamWriter.WriteLine("Position of Elise: " + " X: " + m_elPosList[i].x + " Y: " + m_elPosList[i].y + " Z: " + m_elPosList[i].z + "\n");
		//} 
		
		//for (int i = 0; i < m_soPosList.Count; i++)
		//{
		//    m_streamWriter.WriteLine("Position of Solveig: " + " X: " + m_soPosList[i].x + " Y: " + m_soPosList[i].y + " Z: " + m_soPosList[i].z + "\n");
		//} 
		
		//for (int i = 0; i < m_siPosList.Count; i++)
		//{
		//    m_streamWriter.WriteLine("Position of Simone: " + " X: " + m_siPosList[i].x + " Y: " + m_siPosList[i].y + " Z: " + m_siPosList[i].z + "\n");
		//}

		m_streamWriter.WriteLine("Whipped cream used: " + m_SimoneRef.gameObject.GetComponent<Simone_Attack>().GetWhippedCounter());
		m_streamWriter.WriteLine("Spicy chocolate used: " + m_SimoneRef.gameObject.GetComponent<Simone_Attack>().GetSpicyCounter());
		m_streamWriter.WriteLine("Energy drink used: " + m_SimoneRef.gameObject.GetComponent<Simone_Attack>().GetEnergyCounter());
		m_streamWriter.WriteLine("Flower Power used: " + m_SolveigRef.gameObject.GetComponent<Solveig_Attack>().GetFlowerCounter());
		m_streamWriter.WriteLine("Song of Love used: " + m_SolveigRef.gameObject.GetComponent<Solveig_Attack>().GetSongCounter());
		m_streamWriter.WriteLine("Fluff Pound used: " + m_PhillippaRef.gameObject.GetComponent<Phillippa_Attack>().GetFluffCounter());
		m_streamWriter.WriteLine("Anger Issues used: " + m_PhillippaRef.gameObject.GetComponent<Phillippa_Attack>().GetRushCounter());
		m_streamWriter.WriteLine("Marble Rain used: " + m_EliseRef.gameObject.GetComponent<Elise_Attack>().GetMultiCounter());
		m_streamWriter.WriteLine("Cookie Jar used: " + m_EliseRef.gameObject.GetComponent<Elise_Attack>().GetTrapCounter());
		//m_streamWriter.WriteLine("Position where Phillippa died: " + m_DeathPositionPh.ToString());
		//m_streamWriter.WriteLine("Position where Simone died: " + m_DeathPositionSi.ToString());
		//m_streamWriter.WriteLine("Position where Solveig died: " + m_DeathPositionSo.ToString());
		//m_streamWriter.WriteLine("Position where Elise died: " + m_DeathPositionEl.ToString());

		m_streamWriter.Close();                                                                                                     // Close and save the file
	}

	#endregion

	void WriteToJSON()
	{
		
		string data = JsonUtility.ToJson(m_jsonObject);
		m_streamWriter.Write(data);
		m_streamWriter.Close();

	}

	//void SetDeathPositions()
	//{
	//    m_DeathPositionEl = m_elPosList[m_elPosList.Count - 1];
	//    m_DeathPositionSi = m_siPosList[m_siPosList.Count - 1];
	//    m_DeathPositionSo = m_soPosList[m_soPosList.Count - 1];
	//    m_DeathPositionPh = m_phPosList[m_phPosList.Count - 1];
	//}

	#region On Application Quit

	void OnApplicationQuit()
	{
	   // SetDeathPositions();
		m_jsonObject.SetAllDeathPosition();
		SetCounters();
		WriteToJSON();
		//WriteToFile();
	}

	#endregion
}
