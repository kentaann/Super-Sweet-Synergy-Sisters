using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LE_parts : MonoBehaviour
{
    // making list for the scen objects
    // select next object 

    public List<GameObject> PartList = new List<GameObject>();
    public GameObject selectedObject;
    int selectedNumber;
   

	// Use this for initialization
	void Start () {

        
        selectedNumber = 0;
        selectedObject = PartList[selectedNumber];

	}

    public void SelectNextObject()
    {
        selectedNumber++;
        if(selectedNumber >= PartList.Count)
        {
            selectedNumber = 0;
        }
        selectedObject = PartList[selectedNumber];
    }
}
