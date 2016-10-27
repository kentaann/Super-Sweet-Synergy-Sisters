using UnityEngine;
using System.Collections;

namespace Entities
{
   public class ScenObjects
   {
       GameObject objToPut;
       public GameObject ScenObj { get { return objToPut; } }

       Vector3 objPos;
       public Vector3 ScenObjPos { get { return objPos; } }

       string objTag;
       public string ScenObjTag { get { return objTag; } }

       bool isSpawnObj;
       public bool ScenIsSpawnObj { get { return isSpawnObj; } }

       public ScenObjects(GameObject obj, Vector3 pos, string tag, bool isSpawned)
       {
           objToPut = obj;
           objPos = pos;
           objTag = tag;
           isSpawnObj = isSpawned;

       }
   }
}

