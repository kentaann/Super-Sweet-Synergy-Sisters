using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

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
    float health;

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
                if (Input.GetKeyDown("joystick button 4")) // left bumper        
                {
                    obj.transform.Rotate(0.0f, -90.0f, 0.0f);
                }
                if (Input.GetKeyDown("joystick button 5"))
                {
                    obj.transform.Rotate(0.0f, -90.0f, 0.0f);
                }
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

        // Add object
        if (Input.GetKeyDown("joystick button 1")) //B
        {
            levelManager.AddObject(objects.selectedObject, placingPos, false);
        }

        //Removeobject
        if (Input.GetKeyDown("joystick button 0")) //A
        {
            levelManager.RemoveObj(placingPos);
        }

        // rotate left
        if (Input.GetKeyDown("joystick button 4"))  // left bumper
        {
            var newTransform = levelManager.RotateLeft(objects.selectedObject.transform);
            objects.selectedObject.transform.rotation = newTransform.rotation;
            Debug.Log("leftRotationPressed");

        }

        //rotate right
        if (Input.GetKeyDown("joystick button 5"))  // right bumper
        {
            var newTransform = levelManager.RotateRight(objects.selectedObject.transform);
            objects.selectedObject.transform.rotation = newTransform.rotation;
            Debug.Log("rightRotationPressed");
        }
        //camera stuff but does not work
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

    //saving the objects in an XML File
    public void SaveToXML(List<GameObject> objList, string filename)
    {

        var serializer = new XmlSerializer(typeof(LevelManager));
        //var stream = new FileStream(C:\Users\Spellabbet\Documents\GitHub\Super-Sweet-Synergy-Sisters\S41, FileMode.Create));

        //LevelManager levelM = new LevelManager();
       
        //XmlSerializer serializer = new XmlSerializer(typeof(LevelManager));
        //TextWriter writer = new StreamWriter(filename);
        //serializer.Serialize(writer, levelM);
        //writer.Close();
        
    }

    //Loading the saved objects from XML file to another scen
    public void LoadToXML(List<GameObject> objList, string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(LevelManager));
        TextReader reader = new StreamReader(fileName);
        LevelManager levelM = serializer.Deserialize(reader) as LevelManager;
        //levelM.Instantiate(objList);
    }

    // I guess it will be a button function for save and load button (is right)  and binaryformatter is not the best maybe to save list in
    public void SaveLevelToFile()
    {
        // gameobject.find -> not good to use and its very slow
        // dictionary to file? what is dictionary?
        // object references
        // 2 ways for serialization: 1. c# data serialization or 2. unity serialization: allow build assets ~25:00 , ( language serialization 28:00)
        // object cannot be saved in text file and its a monobehaviour class. we need a clean class that contains the data forming
        // other way playerpreferences
        // not necessary .dat file
        // hard to serialize list -> check it out how ( he did not tested serialize a list) 
        // 
        BinaryFormatter bf = new BinaryFormatter(); // unreadable for the player
        FileStream file = File.Create(Application.persistentDataPath + "/LevelInfo.dat");      // where to save it LevelInfo is the filename and Application.persis... where its going (not good vause its an android application path.)
        
        // 
        InfoData data = new InfoData();
        data.health = health;

        // save data in file
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadLevelFromFile()
    {
        if (File.Exists(Application.persistentDataPath + "/LevelInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/LevelInfo.dat", FileMode.Open); // i videon står bara path och ingen Filemode. för mig krävs men inte för honom 43:13 // load file
            //PLayerData data = bf.Deserialize(file);  need a container to pull the data out  (creating an object but we dont know what)
            file.Close();

            //health = data.health;
        }
    }
}

[Serializable]
class InfoData // datacontainer ( allows me to write the data into a file
{
    //serialized
    //how the system organize the data so it fits in a text file
    public float health;
    public float experience;
}
