#region Using Statements

using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

#endregion

public class Player_Logger : MonoBehaviour
{
	#region Variables

	public GameObject m_PhillippaRef;                    // Reference to Phillippa
	public GameObject m_SimoneRef;                  // Reference to Simone
	public GameObject m_SolveigRef;                 // Reference to Solveig
	public GameObject m_EliseRef;                   // Reference to Elise

	private Simone_Attack m_siAttackRef;

	private Vector3 m_PhillippaPosition;            // The position of Phillippa
	private Vector3 m_SimonePosition;               // The position of Simone
	private Vector3 m_SolveigPosition;              // The position of Solveig
	private Vector3 m_ElisePosition;                // The position of Elise
	private List<Vector3> m_phPosList;              // List of Phillippas positions    
	private List<Vector3> m_siPosList;              // List of Simones positions
	private List<Vector3> m_soPosList;              // List of Solveigs positions
	private List<Vector3> m_elPosList;              // List of Elises positions

	private StreamWriter m_streamWriter = null;

	private string m_path = "log.txt";              // The path to where the data is saved

	private float m_currentTime = 0.0f;             // The current time, used for writing incrementally
	private float m_timeToWrite = 1.0f;              // Interval for when the call to write is made
	private float m_phScore = 0.0f;                 // The score of Phillippa
	private float m_siScore = 0.0f;                 // The score of Simone
	private float m_soScore = 0.0f;                 // The score of Solveig               
	private float m_elScore = 0.0f;                 // The score of Elise
	private float m_healingDone = 0.0f;             //Amount of healing done
	private float m_phAliveTime = 0.0f;
	private float m_siAliveTime = 0.0f;
	private float m_soAliveTime = 0.0f;
	private float m_elAliveTime = 0.0f;
	private int m_phKills = 0;
	private int m_siKills = 0;
	private int m_soKills = 0;
	private int m_elKills = 0;

	

	#endregion

	#region On Enable

	private void OnEnable()
	{
		m_SimoneRef.GetComponent<Simone_Attack>();
		m_PhillippaRef.GetComponent<Transform>();
		m_SimoneRef.GetComponent<Transform>();
		m_SolveigRef.GetComponent<Transform>();
		m_EliseRef.GetComponent<Transform>();
	}

	#endregion

	#region Start

	void Start () 
	{
		m_streamWriter = new StreamWriter(m_path);
		m_phPosList = new List<Vector3>();
		m_siPosList = new List<Vector3>();
		m_soPosList = new List<Vector3>();
		m_elPosList = new List<Vector3>();
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

		m_currentTime += Time.deltaTime;
		m_phAliveTime += Time.deltaTime;
		m_siAliveTime += Time.deltaTime;
		m_soAliveTime += Time.deltaTime;
		m_elAliveTime += Time.deltaTime;

		if (m_currentTime > m_timeToWrite)
		{
			m_phPosList.Add(m_PhillippaPosition);
			m_siPosList.Add(m_SimonePosition);
			m_elPosList.Add(m_ElisePosition);
			m_soPosList.Add(m_SolveigPosition);
			m_currentTime = 0.0f;
		}

	}    

	#endregion

	#region Write to File

	void WriteToFile()
	{

		for (int i = 0; i < m_phPosList.Count; i++)
		{
			m_streamWriter.WriteLine("Position of Phillippa: " + " X: " + m_phPosList[i].x + " Y: " + m_phPosList[i].y + " Z: " + m_phPosList[i].z + "\n");            
		}

		for (int i = 0; i < m_elPosList.Count; i++)
		{
			m_streamWriter.WriteLine("Position of Elise: " + " X: " + m_elPosList[i].x + " Y: " + m_elPosList[i].y + " Z: " + m_elPosList[i].z + "\n");
		} 
		
		for (int i = 0; i < m_soPosList.Count; i++)
		{
			m_streamWriter.WriteLine("Position of Solveig: " + " X: " + m_soPosList[i].x + " Y: " + m_soPosList[i].y + " Z: " + m_soPosList[i].z + "\n");
		} 
		
		for (int i = 0; i < m_siPosList.Count; i++)
		{
			m_streamWriter.WriteLine("Position of Simone: " + " X: " + m_siPosList[i].x + " Y: " + m_siPosList[i].y + " Z: " + m_siPosList[i].z + "\n");
		}

		m_streamWriter.WriteLine("Phillippa Score: " + m_phScore);
		m_streamWriter.WriteLine("Simone Score: " + m_siScore);
		m_streamWriter.WriteLine("Solveig Score: " + m_soScore);
		m_streamWriter.WriteLine("Elise Score: " + m_elScore);
		m_streamWriter.WriteLine("Whipped cream used: " + m_SimoneRef.gameObject.GetComponent<Simone_Attack>().GetWhippedCounter());
		m_streamWriter.WriteLine("Spicy chocolate used: " + m_SimoneRef.gameObject.GetComponent<Simone_Attack>().GetSpicyCounter());
		m_streamWriter.WriteLine("Energy drink used: " + m_SimoneRef.gameObject.GetComponent<Simone_Attack>().GetEnergyCounter());
		m_streamWriter.WriteLine("Flower Power used: " + m_SolveigRef.gameObject.GetComponent<Solveig_Attack>().GetFlowerCounter());
		m_streamWriter.WriteLine("Song of Love used: " + m_SolveigRef.gameObject.GetComponent<Solveig_Attack>().GetSongCounter());
		m_streamWriter.WriteLine("Song of Love used: " + m_SolveigRef.gameObject.GetComponent<Solveig_Attack>().GetFlowerCounter());
		m_streamWriter.WriteLine("Fluff Pound used: " + m_PhillippaRef.gameObject.GetComponent<Phillippa_Attack>().GetFluffCounter());
		m_streamWriter.WriteLine("Anger Issues used: " + m_PhillippaRef.gameObject.GetComponent<Phillippa_Attack>().GetRushCounter());
		m_streamWriter.WriteLine("Marble Rain used: " + m_EliseRef.gameObject.GetComponent<Elise_Attack>().GetMultiCounter());
		m_streamWriter.WriteLine("Cookie Jar used: " + m_EliseRef.gameObject.GetComponent<Elise_Attack>().GetTrapCounter());


		m_streamWriter.Close();                                                                                                     // Close and save the file
	}

	#endregion

	#region On Application Quit

	void OnApplicationQuit()
	{
		WriteToFile();
	}

	#endregion
}
