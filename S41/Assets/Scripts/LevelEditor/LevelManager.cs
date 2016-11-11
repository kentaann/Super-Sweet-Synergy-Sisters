using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;


using Entities;

[XmlRoot("AllObjects")]
public class LevelManager : MonoBehaviour
{

    // Adding, Removing, Rotating Methods

    [XmlArray("objectsList")]
    [XmlArrayItem("ScenObjects")]
    public List<ScenObjects> objectsList = new List<ScenObjects>();

    public Level currentLevel;

   

    // Use this for initialization
    void Start()
    {
        
        currentLevel = new Level("Random Name", "LevelEditor");

    }

    public void AddObject(GameObject obj, Vector3 pos, bool isSpawned)
    {
        RemoveObj(pos);
        var newObj = PlaceObj(obj, pos);
        objectsList.Add(newObj);
        currentLevel.AddObject(newObj);
    }

    public void RemoveObj(Vector3 pos)
    {
        var count = 0;
        ScenObjects objToRemove = null;
        foreach (var obj in objectsList)
        {
            if (obj.ScenObjPos == pos)
            {
                RemoveObjectByTag(obj.ScenObjTag);
                objToRemove = obj;
                continue;
            }
            count++;
        }

        if (objToRemove != null)
        {
            currentLevel.RemoveObject(objToRemove);
            objectsList.Remove(objToRemove);
        }
    }

    private ScenObjects PlaceObj(GameObject obj, Vector3 pos)
    {
        var newTag = GenerateGuid();
        GameObject scenObjClone = GameObject.Instantiate(obj, pos, obj.transform.rotation) as GameObject;
        scenObjClone.name = newTag;
        return new ScenObjects(scenObjClone, pos, scenObjClone.name, false);
    }

    private void RemoveObjectByTag(string tag)
    {
        var objToRemove = GameObject.Find(tag);
        Destroy(objToRemove);
    }

    private string GenerateGuid()
    {
        return System.Guid.NewGuid().ToString();
    }

    public Transform RotateLeft(Transform rotateObj)
    {
        rotateObj.Rotate(0.0f,-90.0f, 0.0f );
        return rotateObj;
    }

    public Transform RotateRight(Transform rotateObj)
    {
        rotateObj.Rotate(0.0f,90.0f, 0.0f);
        return rotateObj;
    }

}
