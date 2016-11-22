using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Camera_test : MonoBehaviour
{
    
    private Vector3 offset;
    public Transform[] m_Targets;
    private Vector3 camera_startPos;

    public List<Transform> findPlayers;

    public float Speed;
    public Vector3 camPos;
    public float changeYpos = 0;
    public float changeZpos = 0;
    public float changeXpos = 0;
    public int oldPos;
    public float oneDecimal = 0;
    public float oldPosOneDecimal = 0;
    public Vector3 averagePosition;
    public Vector3 camActualPosition;

    public GameObject whoIsTheObject;
    public float newdistance;

    public Camera cam;
    public float min;
    public float max;


    void Start()
    {
        //camera_startPos = new Vector3(3, 13.5f, -8.5f);

        //offset = FindAveragePosition() + camera_startPos;
        averagePosition = FindAveragePosition();
        camera_startPos = new Vector3(0, 30f, -30f);
        //camera_startPos = new Vector3(3, 17f, -8.5f);
        offset = FindAveragePosition() + camera_startPos;
        oldPosOneDecimal = (float)System.Math.Round(newdistance, 1);

        findPlayers = new List<Transform>();
        AddPlayersToList();
    }


    void Update()
    {
        UpdatePlayerList();

        camPos = Camera.main.transform.position;
        ZoomByItSelf();
        ZoomWithButtons();
    }

    void LateUpdate()
    {
        //Nytt
        //transform.position = new Vector3(FindAveragePosition().x + offset.x, FindAveragePosition().y + offset.y + changeYpos, FindAveragePosition().z + offset.z + changeZpos);
        
        //Se kamerans postion utan offset
        //transform.position = new Vector3(FindAveragePosition().x, FindAveragePosition().y + offset.y + changeYpos, FindAveragePosition().z);

        //testar olika saker(men den som nu funkar rätt)
        transform.position = new Vector3(FindAveragePosition().x + changeXpos + camera_startPos.x, FindAveragePosition().y + changeYpos + camera_startPos.y, FindAveragePosition().z + changeZpos + camera_startPos.z);
    }

    public void UpdatePlayerList()
    {
        if (findPlayers.Count != GameObject.FindGameObjectsWithTag("Player").Length)
        {
            findPlayers.Clear();
            AddPlayersToList();
        }
    }

    public void AddPlayersToList()
    {
        GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in ItemsInList)
        {
            AddTarget(player.transform);
        }
    }

    public void AddTarget(Transform player)
    {
        findPlayers.Add(player);
    }

    private Vector3 FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;
        for (int i = 0; i < findPlayers.Count; i++)
        {
            if (!findPlayers[i].gameObject.activeSelf)
                continue;
            averagePos += findPlayers[i].position;
            numTargets++;
        }
        if (numTargets > 0)
            averagePos /= numTargets;
        //averagePos.y = transform.position.y;
        return averagePos;
    }

    public void ZoomByItSelf()
    {
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, min, max);
        Transform cameraTarget = GetFarthestPlayer();
        whoIsTheObject = cameraTarget.gameObject;
        if (cameraTarget)
        {
            newdistance = Vector3.Distance(FindAveragePosition(), cameraTarget.position);
            oneDecimal = (float)System.Math.Round(newdistance, 1);
            if (oneDecimal != oldPosOneDecimal && oneDecimal > oldPosOneDecimal)
            {
                cam.fieldOfView += 0.12f;
               // changeYpos += 0.1f;
                //changeZpos -= 0.1f;
                //changeXpos += 0.1f;

                oldPosOneDecimal = oneDecimal;
            }
            if (oneDecimal != oldPosOneDecimal && oneDecimal < oldPosOneDecimal)
            {
                cam.fieldOfView -= 0.12f;
                //changeXpos -= 0.1f;
                //changeYpos -= 0.1f;
                //changeZpos += 0.1f;
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

    Transform GetFarthestPlayer()
    {
        Transform largest = null;
        float maxDist = 5;
        Vector3 currentPos = FindAveragePosition();
        foreach (Transform t in findPlayers)
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



