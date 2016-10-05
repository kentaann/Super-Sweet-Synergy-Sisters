using UnityEngine;
using System.Collections;

public class AiSpawningScript : MonoBehaviour {

    public GameObject[] spawnPoints;
    public GameObject Enemy;

    // Use this for initialization
    void Start ()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length >= 10)
        {
            print("Too many enemies on the dance floor");
        }
        else
        {
            InvokeRepeating("spawnEnemies", 1, 5f);
        }
	}

    void spawnEnemies()
    {
        int SpawnPos = Random.Range(0, (spawnPoints.Length - 0));

        Instantiate(Enemy, spawnPoints[SpawnPos].transform.position, transform.rotation);
        CancelInvoke();

    }
}
