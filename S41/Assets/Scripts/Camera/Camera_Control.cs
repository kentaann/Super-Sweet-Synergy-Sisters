#region Using Statements

using UnityEngine;
using System.Collections;

#endregion

/// <summary>
/// This is the class for the overview camera.
/// </summary>
public class Camera_Control : MonoBehaviour {

    #region Variables

    public float m_DampTime = 0.2f;                     // Dampening of the camera movement to create a fluid motion
    public float m_ScreenEdgeBuffer = 4f;               // Buffer so that the player is never at the edge of the camera
    public float m_MinSize = 6.5f;  
   /* [HideInInspector] */  public Transform[] m_Targets; //This will be uncommented when it's working with a proper manager script.

    private Camera m_Camera;
    private float m_ZoomSpeed;
    private Vector3 m_MoveVelocity;
    private Vector3 m_DesiredPosition;

    #endregion

    #region Awake

    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }

    #endregion

    #region Fixed Update

    private void FixedUpdate()
    {
        Move();
        Zoom();
    }

    #endregion

    #region Functions

    /// <summary>
    /// Moves the camera.
    /// </summary>
    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }

    /// <summary>
    /// Finds the average position of the players added to the list inside Unity.
    /// </summary>
    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        for (int i = 0; i < m_Targets.Length; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            averagePos += m_Targets[i].position;
            numTargets++;
        }

        if (numTargets > 0)
            averagePos /= numTargets;

        averagePos.y = transform.position.y;

        m_DesiredPosition = averagePos;
    }


    /// <summary>
    /// Zooms in and out depending on the Required size.
    /// </summary>
    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
    }

    /// <summary>
    /// Calculates the required size of the window to fit all players.
    /// </summary>
    /// <returns></returns>
    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);

        float size = 0f;

        for (int i = 0; i < m_Targets.Length; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            Vector3 targetLocalPos = transform.InverseTransformPoint(m_Targets[i].position);

            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));

            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / m_Camera.aspect);
        }

        size += m_ScreenEdgeBuffer;

        size = Mathf.Max(size, m_MinSize);

        return size;
    }


    /// <summary>
    /// Sets the starting position and size of the camera.
    /// </summary>
    public void SetStartPositionAndSize()
    {
        FindAveragePosition();

        transform.position = m_DesiredPosition;

        m_Camera.orthographicSize = FindRequiredSize();
    }
}

    #endregion

    #region Test Camera (Not in use)

/* The following code is if you want to use a camera that follows the object.
 * Perhaps for testing purposes
 * 
 * public class Camera_Control : MonoBehaviour
 * {
 *      public GameObject player:
 *      private Vector3 offset;
 *      
 *      void Start()
 *      {
 *          offset = transform.position - player.transform.position;
 *      }
 *      
 *      void LateUpdate()
 *      {
 *          transform.position = player.transform.position + offset;
 *      }
 * }
 */
#endregion