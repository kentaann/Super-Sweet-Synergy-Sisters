using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entities;

public class LevelManager : MonoBehaviour {

    // Adding, Removing, Rotating Methods

    public List<ScenObjects> objectsList;

	// Use this for initialization
	void Start () {
        objectsList = new List<ScenObjects>();
	}
	
	public void AddObject(GameObject obj, Vector3 pos, bool isSpawned)
    {
        RemoveObj(pos);
        var newObj = PlaceObj(obj, pos);
        objectsList.Add(newObj);
    }

    public void RemoveObj(Vector3 pos)
    {
        var count = 0;
        ScenObjects objToRemove = null;
        foreach (var obj in objectsList)
        {
            if(obj.ScenObjPos == pos)
            {
                RemoveObjectByTag(obj.ScenObjTag);
                objToRemove = obj;
                continue;
            }
            count++;
        }

        if(objToRemove != null)
        {
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
        rotateObj.Rotate(0.0f, -90.0f, 0.0f);
        return rotateObj;
    }

    public Transform RotateRight(Transform rotateObj)
    {
        rotateObj.Rotate(0.0f, 90.0f, 0.0f);
        return rotateObj;
    }

}
