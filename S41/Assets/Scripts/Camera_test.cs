using UnityEngine;
using System.Collections;

public class Camera_test : MonoBehaviour
{
    //public GameObject player;
    private Vector3 offset;
    public Transform[] m_Targets;
    private Vector3 camera_startPos;
    // Use this for initialization
    public float Speed;

    void Update()
    {
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position , new Vector3(0, 20, -10), Time.deltaTime * Speed);
    }



void Start()
    {
        camera_startPos = new Vector3(3, 13.5f, -8.5f);

        offset = FindAveragePosition() + camera_startPos;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = FindAveragePosition() + offset;

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


}



