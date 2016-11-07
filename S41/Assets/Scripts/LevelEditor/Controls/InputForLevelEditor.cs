﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Linq;

public class InputForLevelEditor : MonoBehaviour
{
    // Leveleditor input
    public Vector3 mousePos;
    public Vector3 placingPos;
    public GameObject mouse;
    private bool moved;
    LE_parts objects;
    private LevelManager levelManager;
    List<GameObject> list = new List<GameObject>();

    //Camera
    float smoothing = 5f;
    Vector3 offset;

    // Use this for initialization
    void Start()
    {
        mousePos = new Vector3(0.0f, 0.0f, 0.0f);
        placingPos = new Vector3(0.0f, 0.0f, 0.0f);
        moved = false;
        objects = GetComponent<LE_parts>();
        levelManager = GetComponent<LevelManager>();

        offset = transform.position - mousePos;

        foreach (GameObject go in objects.PartList)
        {
            GameObject copy = Instantiate(go);
            list.Add(copy);
        }
        onSelected(0);
    }

    void FixedUpdate()
    {
    }

    private void onSelected(int index)
    {
        Debug.Log("OnSelcted " + index);
        for (int i = 0; i < list.Count; i++)
        {
            GameObject obj = list[i];
            if (i == index)
            {
                mouse = obj;
                mouse.transform.position = mousePos;
                obj.gameObject.SetActive(true);
            }
            else
            {
                obj.gameObject.SetActive(false);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        mouse.transform.position = mousePos;
        InputCheck();

        if (Input.GetKeyDown("joystick button 1")) //B
        {
            levelManager.AddObject(objects.selectedObject, placingPos, false);
        }

        if (Input.GetKeyDown("joystick button 0")) //A
        {
            levelManager.RemoveObj(placingPos);
        }

        if (Input.GetKeyDown("joystick button 4"))  // left bumper
        {
            var newTransform = levelManager.RotateLeft(objects.selectedObject.transform);
            objects.selectedObject.transform.rotation = newTransform.rotation;
            Debug.Log("leftRotationPressed");

        }

        if (Input.GetKeyDown("joystick button 5"))  // right bumper
        {
            var newTransform = levelManager.RotateRight(objects.selectedObject.transform);
            objects.selectedObject.transform.rotation = newTransform.rotation;
            Debug.Log("rightRotationPressed");
        }
        Vector3 targetCamPos = mousePos + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);


    }

    // move the  "mouse" on x, y , z to location where I wanna place the object
    public void InputCheck()
    {
        if (!moved)
        {
            if (Input.GetAxis("MovingX") > 0)
            {
                mousePos = new Vector3(mousePos.x + 1.0f,mousePos.y, mousePos.z);
                placingPos = new Vector3(placingPos.x + 1.0f, mousePos.y, placingPos.z);
                moved = true;
            }
            else if (Input.GetAxis("MovingX") < 0)
            {
                mousePos = new Vector3(mousePos.x - 1.0f,mousePos.y, mousePos.z);
                placingPos = new Vector3(placingPos.x - 1.0f, mousePos.y, placingPos.z);
                moved = true;
            }
            else if (Input.GetAxis("MovingY") > 0)
            {
                mousePos = new Vector3(mousePos.x, mousePos.y + 1.0f, mousePos.z);
                placingPos = new Vector3(placingPos.x, placingPos.y +1.0f , placingPos.z);
                moved = true;
            }
            else if (Input.GetAxis("MovingY") < 0)
            {
                mousePos = new Vector3(mousePos.x, mousePos.y - 1.0f, mousePos.z);
                placingPos = new Vector3(placingPos.x, placingPos.y -1.0f , placingPos.z);
                moved = true;
            }
            else if (Input.GetAxis("MovingZ") > 0)
            {
                mousePos = new Vector3(mousePos.x, mousePos.y, mousePos.z + 1.0f);
                placingPos = new Vector3(placingPos.x, placingPos.y, placingPos.z + 1.0f);
                moved = true;
            }
            else if (Input.GetAxis("MovingZ") < 0)
            {
                mousePos = new Vector3(mousePos.x, mousePos.y, mousePos.z - 1.0f);
                placingPos = new Vector3(mousePos.x, mousePos.y, mousePos.z - 1.0f);
                moved = true;
            }
            objects.selectedObject.transform.position = mousePos;
        }

        if (Input.GetAxis("MovingX") == 0 && Input.GetAxis("MovingY") == 0 && Input.GetAxis("MovingZ") == 0)
        {
            moved = false;
        }

        // select the object  -> button X
        if (Input.GetKeyDown("joystick button 2"))
        {
            objects.SelectNextObject();
            onSelected(objects.selectedNumber);
        }


    }

    // I guess it will be a button function for save button
    public void SaveLevelToFile()
    {
        StreamWriter sw;
        //sw = new StreamWriter(objects.PartList);

        foreach (GameObject go in objects.PartList)
        {
            //sw.Write()
        }

        //sw.Close();
    }
}
