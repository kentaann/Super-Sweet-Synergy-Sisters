#region Using Statements

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

#endregion

public class Player_Movement : MonoBehaviour
{
    #region Variables

    public int m_PlayerNumber = 1;          // Player number. Used for assigning controls etc
    public float m_moveSpeed = 12f;         // Movespeed
    public float m_turnSpeed = 180f;        // Turnspeed
    public float m_PitchRange = 0.2f;       // Range for the pitch in audio clip. 

    public AudioSource m_playerAudio;       //Source for outputting audioclips
    //public AudioClip m_playerClip1;       These are merely placeholders for when we put audio in the game
    //public AudioClip m_playerClip2;

    private string m_moveAxisName;          // This is used in the editor to assign the correct controls
    private string m_turnAxisName;          // Same as above

    private Rigidbody m_Rigidbody;

    private float m_movementInputValue;
    private float m_turnInputValue;
    private float m_OriginalPitch;

    #endregion

    #region Awake

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    #endregion

    #region On Enable
    /// <summary>
    /// When the player is enabled it is standing still and is accepting input. 
    /// </summary>
    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_movementInputValue = 0f;
        m_turnInputValue = 0f;
    }

    #endregion

    #region On Disable
    /// <summary>
    /// When we disable the player it can no longer move
    /// </summary>
    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }

    #endregion

    #region Start
    /// <summary>
    /// This is where we assigns the controls!
    /// In the Input Manager we create 4 Axes pairs to use for input. Vertical1 for player 1 and so on. 
    /// </summary>
    private void Start()
    {
        m_moveAxisName = "Vertical" + m_PlayerNumber;
        m_turnAxisName = "Horizontal" + m_PlayerNumber;

        m_OriginalPitch = m_playerAudio.pitch;          // Assigns the initial pitch of the audio
    }

    #endregion

    #region Update
    /// <summary>
    /// Runs every frame and assigns the correct values from the players input.
    /// </summary>
    private void Update()
    {
        // Store the player's input
        m_movementInputValue = Input.GetAxis(m_moveAxisName);
        m_turnInputValue = Input.GetAxis(m_turnAxisName);

        //PlayerAudio();
    }

    #endregion

    #region Player Audio (Not in use as of this version)
    //private void PlayerAudio()
    //{
    //    // Play the correct audio clip based on whether or not the tank is moving and what audio is currently playing.

    //    if (Mathf.Abs(m_MovementInputValue) < 0.1f && Mathf.Abs(m_TurnInputValue) < 0.1f)
    //    {
    //        if (m_MovementAudio.clip == m_EngineDriving)
    //        {
    //            m_MovementAudio.clip = m_EngineIdling;
    //            m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
    //            m_MovementAudio.Play();
    //        }
    //    }

    //    else
    //    {
    //        if (m_MovementAudio.clip == m_EngineIdling)
    //        {
    //            m_MovementAudio.clip = m_EngineDriving;
    //            m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
    //            m_MovementAudio.Play();
    //        }
    //    }
    //}

    #endregion

    #region Fixed Update
    /// <summary>
    /// Runs every frame after update has run
    /// Moves and rotates the player
    /// </summary>
    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    #endregion

    #region Movement functions
    /// <summary>
    /// Take the input from the player and moves the character.
    /// </summary>
    private void Move()
    {
        Vector3 movement = transform.forward * m_movementInputValue * m_moveSpeed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    /// <summary>
    /// Takes the input from the player and rotates the character.
    /// </summary>
    private void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.

        float turn = m_turnInputValue * m_turnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }

    #endregion
}