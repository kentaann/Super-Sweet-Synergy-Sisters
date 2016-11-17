#region Using Statements

using UnityEngine;
using System.Collections;
using System.IO;

#endregion

public class Player_Logger : MonoBehaviour
{
    #region Variables

    public GameObject Phillippa;                    // Reference to Phillippa
    public GameObject m_SimoneRef;                  // Reference to Simone
    public GameObject m_SolveigRef;                 // Reference to Solveig
    public GameObject m_EliseRef;                   // Reference to Elise

    Vector3 m_PhillippaPosition;                    // The position of Phillippa
    Vector3 m_SimonePosition;                       // The position of Simone
    Vector3 m_SolveigPosition;                      // The position of Solveig
    Vector3 m_ElisePosition;                        // The position of Elise

    StreamWriter m_streamWriter = null;
    StreamReader m_streamReader;

    private string m_path = "log.txt";              // The path to where the data is saved

    private float m_currentTime = 0.0f;             // The current time, used for writing incrementally
    
    public float m_timeToWrite = 1.0f;              // Interval for when the call to write is made   


    #endregion

    #region On Enable

    private void OnEnable()
    {
        Phillippa.GetComponent<Transform>();
        m_SimoneRef.GetComponent<Transform>();
        m_SolveigRef.GetComponent<Transform>();
        m_EliseRef.GetComponent<Transform>();
    }

    #endregion

    #region Start

    void Start () 
    {
        m_streamWriter = new StreamWriter(m_path);
        m_streamReader = new StreamReader(m_path);
	}

    #endregion

    #region Update

    void Update () 
    {
        m_currentTime += Time.deltaTime;

        if(m_currentTime > m_timeToWrite)
        {
            WriteToFile();
            m_currentTime = 0.0f;
        }
    }

    #endregion

    void WriteToFile()
    {
        string temp = "";

        // Gets position from each character
        m_PhillippaPosition = Phillippa.GetComponent<Transform>().position;
        m_SimonePosition = m_SimoneRef.GetComponent<Transform>().position;
        m_SolveigPosition = m_SolveigRef.GetComponent<Transform>().position;
        m_ElisePosition = m_EliseRef.GetComponent<Transform>().position;

        if(m_streamReader != null)
        {
            temp = m_streamReader.ReadToEnd().ToString();
        }

        if(temp != "")
        {
            m_streamWriter.WriteLine(temp);

        }

        // Writes the information to the file
        m_streamWriter.WriteLine("Position of Phillippa: " + " X: " + m_PhillippaPosition.x + " Y: " + m_PhillippaPosition.y + " Z: " + m_PhillippaPosition.z + "\n");
        m_streamWriter.WriteLine("Position of Simone: " + " X: " + m_SimonePosition.x + " Y: " + m_SimonePosition.y + " Z: " + m_SimonePosition.z + "\n");
        m_streamWriter.WriteLine("Position of Solveig: " + " X: " + m_SolveigPosition.x + " Y: " + m_SolveigPosition.y + " Z: " + m_SolveigPosition.z + "\n");
        m_streamWriter.WriteLine("Position of Elise: " + " X: " + m_ElisePosition.x + " Y: " + m_ElisePosition.y + " Z: " + m_ElisePosition.z + "\n");        

        m_streamWriter.Close();                                                                                                     // Close and save the file
    }
}
