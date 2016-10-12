using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState
    {
        SPAWNING,
        WAITING,
        COUNTING
    };

    [System.Serializable]           //with this you could add amount of waves in unity
    public class Wave
    {
        public string name;         //name of the wave
        public Transform enemy;     //the objects spawn position
        public int count;           //enemy amount
        public float rate;          //spawn rate
    }

    GameObject[] enemyObject;

    public Wave[] waves;
    private int nextWave = 0;//index of the next wave

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;//5 seconds
    public float waveCountDown;//count down to next wave

    private SpawnState state = SpawnState.COUNTING;

    private float searchCountDown = 1f;

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points reference");
        }

        waveCountDown = timeBetweenWaves;
        Debug.Log("The class WaveSpawner started");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R key pressed");
            DestroyAllEnemyObjects();
        }

        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
                
            }
            else
            {
                return;
            }
        }

        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }           
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All waves complete looping");
        }
        else
        {
            nextWave++;

        }

    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;

        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            } 
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(_enemy, _sp.position, _sp.rotation);

        Debug.Log("Spawning Enemy" + _enemy.name);
    }

    void DestroyAllEnemyObjects()
    {
        enemyObject = GameObject.FindGameObjectsWithTag("Enemy");

        for (var i = 0; i < enemyObject.Length; i++)
        {
            Destroy(enemyObject[i]);
        }
    }
}
