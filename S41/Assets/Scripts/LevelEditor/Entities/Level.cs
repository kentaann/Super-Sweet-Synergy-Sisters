using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Entities
{
    public class Level
    {
        public string levelName;
        public string LevelName { get { return levelName; } }

        public string levelDescription;
        public string LevelDescription { get { return levelDescription; } }

        public string author;
        public string Author { get { return author; } }

        public List<ScenObjects> scenObjects;
        public List<ScenObjects> scenObj { get { return scenObjects;} }

        // 2 constructor for being able to overwrite
        public Level (string thelevelName, string levelAuthor)
        {
            levelName = thelevelName;
            levelDescription = "";
            author = levelAuthor;
            scenObjects = new List<ScenObjects>();
        }

        public Level (string thelevelName, string levelDiscript, string levelAuthor, List<ScenObjects> scenObjs)
        {
            levelName = thelevelName;
            levelDescription = levelDiscript;
            author = levelAuthor;
            scenObjects = scenObjs;
        }

        public void AddObject(ScenObjects obj)
        {
            scenObjects.Add(obj);
        }

        public void RemoveObject(ScenObjects obj)
        {
            scenObjects.Remove(obj);
        }
    }
}