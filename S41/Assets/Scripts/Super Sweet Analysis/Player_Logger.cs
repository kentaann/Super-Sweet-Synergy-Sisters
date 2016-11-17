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

    private string m_path = "log.txt";              // The path to where the data is saved

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
	
	}

    #endregion

    #region Update

    void Update () 
    {
        StreamWriter createText = File.CreateText(m_path);                                                                  // Create a file with the name stored in m_path

        m_PhillippaPosition = Phillippa.GetComponent<Transform>().position;
        m_SimonePosition = m_SimoneRef.GetComponent<Transform>().position;
        m_SolveigPosition = m_SolveigRef.GetComponent<Transform>().position;
        m_ElisePosition = m_EliseRef.GetComponent<Transform>().position;

        createText.WriteLine("Position of Phillippa: " + " X: " + m_PhillippaPosition.x + " Y: " + m_PhillippaPosition.y + " Z: " + m_PhillippaPosition.z + "\n");
        createText.WriteLine("Position of Simone: " + " X: " + m_SimonePosition.x + " Y: " + m_SimonePosition.y + " Z: " + m_SimonePosition.z + "\n");
        createText.WriteLine("Position of Solveig: " + " X: " + m_SolveigPosition.x + " Y: " + m_SolveigPosition.y + " Z: " + m_SolveigPosition.z + "\n");
        createText.WriteLine("Position of Elise: " + " X: " + m_ElisePosition.x + " Y: " + m_ElisePosition.y + " Z: " + m_ElisePosition.z + "\n");

        createText.Close();                                                                                                // Close and save the file
    }

    #endregion
}
