using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Xml;

public class LevelBuildInfo : MonoBehaviour {

    public List<ObjectInfos> objList;
    public LevelBuildInfo() { }

    public LevelBuildInfo(GameObject rootObject)
    {
        objList = new List<ObjectInfos>();
        //foreach(var child in rootObject)
        //{
        //    objList.Add(new ObjectInfos(child));
        //}
    }
	     
}
