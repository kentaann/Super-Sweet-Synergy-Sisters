using UnityEngine;
using System.Collections;

public class Camera_test : MonoBehaviour
{
    
    private Vector3 offset;
    public Transform[] m_Targets;
    private Vector3 camera_startPos;
   
    public float Speed;
    public Vector3 camPos;
    public float changeYpos = 0;
    public int oldPos;
    public float oneDecimal = 0;
    public float oldPosOneDecimal = 0;
    public Vector3 averagePosition;
    public Vector3 camActualPosition;

    public GameObject whoIsTheObject;
    public float newdistance;


    void Start()
    {
        //camera_startPos = new Vector3(3, 13.5f, -8.5f);

        //offset = FindAveragePosition() + camera_startPos;
        averagePosition = FindAveragePosition();
        camera_startPos = new Vector3(3, 17f, -8.5f);
        offset = FindAveragePosition() + camera_startPos;
        oldPosOneDecimal = (float)System.Math.Round(newdistance, 1);
    }


    void Update()
    {
        //Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position , new Vector3(0, 20, -10), Time.deltaTime * Speed);
        camPos = Camera.main.transform.position;
        ZoomByItSelf();
        ZoomWithButtons();
    }

    void LateUpdate()
    {
        //transform.position = FindAveragePosition() + offset;
        //Nytt
        transform.position = new Vector3(FindAveragePosition().x + offset.x, FindAveragePosition().y + offset.y + changeYpos, FindAveragePosition().z + offset.z);
        //Se kamerans postion utan offset
        //transform.position = new Vector3(FindAveragePosition().x, FindAveragePosition().y + offset.y + changeYpos, FindAveragePosition().z);

    }
    private Vector3 FindAveragePosition()
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
        //averagePos.y = transform.position.y;
        return averagePos;
    }

    public void ZoomByItSelf()
    {
        Transform cameraTarget = GetFarthestPlayer(m_Targets);
        whoIsTheObject = cameraTarget.gameObject;
        if (cameraTarget)
        {
            newdistance = Vector3.Distance(FindAveragePosition(), cameraTarget.position);
            oneDecimal = (float)System.Math.Round(newdistance, 1);
            if (oneDecimal != oldPosOneDecimal && oneDecimal > oldPosOneDecimal)
            {
                changeYpos += 0.2f;
                oldPosOneDecimal = oneDecimal;
            }
            if (oneDecimal != oldPosOneDecimal && oneDecimal < oldPosOneDecimal)
            {
                changeYpos -= 0.2f;
                oldPosOneDecimal = oneDecimal;
            }
        }
    }
    private void ZoomWithButtons()
    {
        if (Input.GetKey(KeyCode.C))
        {
            changeYpos++;
        }
        else if (Input.GetKey(KeyCode.V))
        {
            changeYpos--;
        }
    }

    Transform GetFarthestPlayer(Transform[] player)
    {
        Transform largest = null;
        float maxDist = 5;
        Vector3 currentPos = FindAveragePosition();
        foreach (Transform t in m_Targets)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist > maxDist)
            {
                largest = t;
                maxDist = dist;
            }
        }
        return largest;
    }

}



