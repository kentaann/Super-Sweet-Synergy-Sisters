using UnityEngine;
using System.Collections;


public class InputForLevelEditor : MonoBehaviour
{
    // Leveleditor input
    private Vector3 mousePos;
    private Vector3 placingPos;

    public GameObject mouse;

    private bool moved;

    LE_parts objectList;

    private LevelManager levelManager;

    // Use this for initialization
    void Start()
    {
        
        mousePos = new Vector3(0.0f, 1.0f, 0.0f);
        placingPos = new Vector3(0.0f, 0.0f, 0.0f);
        moved = false;
        objectList = GetComponent<LE_parts>();
        levelManager = GetComponent<LevelManager>();

    }

    // Update is called once per frame
    void Update()
    {
        InputCheck();
        

        if (Input.GetKeyDown("joystick button 1")) //B
        {
            levelManager.AddObject(objectList.selectedObject, placingPos, false);
        }

        if (Input.GetKeyDown("joystick button 0")) //A
        {
            levelManager.RemoveObj(placingPos);
        }

        if (Input.GetKeyDown("joystick button 4"))  // left bumper
        {
            var newTransform = levelManager.RotateLeft(objectList.selectedObject.transform);
            objectList.selectedObject.transform.rotation = newTransform.rotation;
            Debug.Log("leftRotationPressed");

        }

        if (Input.GetKeyDown("joystick button 5"))  // right bumper
        {
            var newTransform = levelManager.RotateRight(objectList.selectedObject.transform);
            objectList.selectedObject.transform.rotation = newTransform.rotation;
            Debug.Log("rightRotationPressed");
        }

      
    }

    // move the  "mouse" on x, y , z to location where I wanna place the object
    public void InputCheck()
    {
        if (!moved)
        {
            if (Input.GetAxis("MovingX") > 0)
            {
                mousePos = new Vector3(mousePos.x + 1.0f, 1.0f, mousePos.z);
                placingPos = new Vector3(placingPos.x + 1.0f, 0.0f, placingPos.z);
                moved = true;
            }
            else if (Input.GetAxis("MovingX") < 0)
            {
                mousePos = new Vector3(mousePos.x - 1.0f, 1.0f, mousePos.z);
                placingPos = new Vector3(placingPos.x - 1.0f, 0.0f, placingPos.z);
                moved = true;
            }
            else if (Input.GetAxis("MovingY") > 0)
            {
                mousePos = new Vector3(mousePos.x, mousePos.y + 1.0f, mousePos.z);
                placingPos = new Vector3(placingPos.x, placingPos.y + 1.0f, placingPos.z);
                moved = true;
            }
            else if (Input.GetAxis("MovingY") < 0)
            {
                mousePos = new Vector3(mousePos.x, mousePos.y - 1.0f, mousePos.z);
                placingPos = new Vector3(placingPos.x, placingPos.y - 1.0f, placingPos.z);
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
            mouse.transform.position = mousePos;
        }

        if (Input.GetAxis("MovingX") == 0 && Input.GetAxis("MovingY") == 0 && Input.GetAxis("MovingZ") == 0)
        {
            moved = false;
        }

        // select the object  -> button X
        if (Input.GetKeyDown("joystick button 2"))
        {
            objectList.SelectNextObject();
        }

       
    }
}
