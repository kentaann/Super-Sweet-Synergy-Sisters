using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class GameDescription : MonoBehaviour {

    public Text goalDescription;
    float timeLeft = 5.0f;
    
	// Use this for initialization
	void Start () {

        goalDescription.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            goalDescription.enabled = false;
        }
	}


    
}
