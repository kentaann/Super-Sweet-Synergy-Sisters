using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

namespace Entities
{
    
    public class ScenObjects
    {
        // Storing the objects
        //[XmlAttribute("objToPut")]  
        //The XmlSerializer automatically knows about each public variable or read/write property in any type you can throw at it. 
        //Primitive types like string, int, float and enums can be automatically serialized.
        //The XmlSerializer automatically knows about each public variable or read/write property in any type you can throw at it. 
        public GameObject objToPut;
        public GameObject ScenObj { get { return objToPut; } }

        public Vector3 objPos;
        public Vector3 ScenObjPos { get { return objPos; } }

        public string objTag;
        public string ScenObjTag { get { return objTag; } }

        public bool isSpawnObj;
        public bool ScenIsSpawnObj { get { return isSpawnObj; } }

        public ScenObjects()
        {

        }

        public ScenObjects(GameObject obj, Vector3 pos, string tag, bool isSpawned)
        {
            objToPut = obj;
            objPos = pos;
            objTag = tag;
            isSpawnObj = isSpawned;

        }
    }
}

[XmlRoot("AllObjects")]
public class hhhh : System.Object
{
    [XmlAttribute("test")]
    public int test;
    public hhhh()
    {
        test = 1;
    }
}

