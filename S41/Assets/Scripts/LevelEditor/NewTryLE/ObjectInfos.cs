using UnityEngine;
using System.Collections;

public class ObjectInfos : MonoBehaviour {

	//stores info om objecter
    public string solveigPrefab;
    public Vector3 solveigPos;
    public Quaternion solveigRot;

    public ObjectInfos()
    {

    }

    public ObjectInfos(Transform obj)
    {
        solveigPrefab = obj.name.Replace(" (Clone)", string.Empty);
        solveigPos = obj.position;
        solveigRot = obj.rotation;
    }

}
