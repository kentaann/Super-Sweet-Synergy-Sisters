using UnityEngine;
using System.Collections;
using System.IO;
using Entities;
// using serialization to be able to save in file read more about to how

public class SaveLoadLevel : MonoBehaviour {

	public void SaveMap(string fileName, Level levelData){
        //var levelDataBytes = Serialization.UnitySerializer.Serialize(levelData);
        if(!Directory.Exists (Application.persistentDataPath + "/CustomLevels/"))
            Directory.CreateDirectory(Application.persistentDataPath + "/CustomLevels/");

        var filePath = Application.persistentDataPath + "/CustomLevels/" + fileName + ".lvl";

        using (var fs = new FileStream(filePath,FileMode.Create,FileAccess.Write)){
            using (var bw = new BinaryWriter(fs)){
             //   bw.Write(levelDataBytes);
                bw.Flush ();
            }
        }

    }

    public Level LoadMap(string fileName){
        Level loadedLevel = null;

        var filePath = Application.persistentDataPath + "/CustomLevels/" + fileName + ".lvl";

        using (var fs = new FileStream(filePath,FileMode.Open,FileAccess.Read)){
            //loadedLevel = UnitySerializer.Deserialize<Level>(fs);
        }

        Debug.Log (loadedLevel.LevelName);
        Debug.Log (loadedLevel.LevelDescription);
        Debug.Log (loadedLevel.Author);
        //Debug.Log (loadedLevel.LevelParts.Count);

        return loadedLevel;
    }
}

