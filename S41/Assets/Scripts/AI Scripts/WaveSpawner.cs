using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

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
        public GameObject enemy;    //the objects spawn position
        public int count;           //enemy amount
        public float rate;          //spawn rate
        public float enemyHP;       //set enemy health
        public float enemySpeed;    //set enemy speed
        public float projectileSpeed; //set projectile speed of bullet
    }

    GameObject[] enemyObject;
    public GameObject particle;
    public GameObject particle2;
    public GameObject particle3;
    GameObject spawn_Point1;
    GameObject spawn_Point2;
    GameObject spawn_Point3;
    public GameObject spawn_Point_Cylinder1;
    public GameObject spawn_Point_Cylinder2;
    GameObject spawn_Point_Cylinder3;
    Transform _sp;

    public Wave[] waves;
    private int nextWave = 0;//index of the next wave

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;//5 seconds
    public float waveCountDown;//count down to next wave

    public Text m_counterText;
    public Text m_waveDescriptionText;
    public Color m_startColor;
    public float m_fadeColor;
    public Image m_imageFade;
    Color m_imgStartColor;
    public bool m_fadeIn;
    public float m_imgFadeColor;
    public float m_counterTextFadeColor;

    private SpawnState state = SpawnState.COUNTING;

    private float searchCountDown = 1f;


    void Start()
    {
        this.enabled = false;

        m_startColor = m_waveDescriptionText.color;
        m_imgStartColor = m_imageFade.color;
        m_fadeIn = false;

        spawn_Point1 = GameObject.Find("Spawn Point 1");
        spawn_Point2 = GameObject.Find("Spawn Point 2");
        spawn_Point3 = GameObject.Find("Spawn Point 3");
        spawn_Point_Cylinder1 = GameObject.Find("CylinderSpawnPoint1");
        spawn_Point_Cylinder2 = GameObject.Find("CylinderSpawnPoint1 (1)");
        spawn_Point_Cylinder3 = GameObject.Find("CylinderSpawnPoint1 (2)");
        
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points reference");
        }

        waveCountDown = timeBetweenWaves;
        spawn_Point_Cylinder1.transform.position = new Vector3(spawn_Point1.transform.position.x, spawn_Point1.transform.position.y - 3.5f, spawn_Point1.transform.position.z);
        spawn_Point_Cylinder2.transform.position = new Vector3(spawn_Point2.transform.position.x, spawn_Point2.transform.position.y - 0.8f, spawn_Point2.transform.position.z);
        spawn_Point_Cylinder3.transform.position = new Vector3(spawn_Point3.transform.position.x, spawn_Point3.transform.position.y - 2.5f, spawn_Point3.transform.position.z);
        Instantiate(particle, new Vector3(spawn_Point1.transform.position.x, spawn_Point1.transform.position.y - 3.5f, spawn_Point1.transform.position.z), Quaternion.identity);
        Instantiate(particle2, new Vector3(spawn_Point2.transform.position.x, spawn_Point2.transform.position.y - 3.5f, spawn_Point2.transform.position.z), Quaternion.identity);
        Instantiate(particle3, new Vector3(spawn_Point3.transform.position.x, spawn_Point3.transform.position.y - 3.5f, spawn_Point3.transform.position.z), Quaternion.identity);

    }

    void InitiateCountText()
    {
        m_counterText.text = "Time until next wave is released: " + waveCountDown.ToString();
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
            m_fadeIn = true;

            m_counterText.color = Color.red;
            m_counterText.text = 0.ToString();

            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            m_fadeIn = false;

            waveCountDown -= Time.deltaTime;

            m_counterText.color = Color.white;
            m_counterText.text = ((int)waveCountDown + 1).ToString();

            if (int.Parse(m_counterText.text) >= 4)
            {
                m_waveDescriptionText.color = new Color(1, 1, 1, 1);
                m_fadeColor = 1;

                m_imageFade.color = m_imgStartColor;
                m_imgFadeColor = m_imageFade.color.a;

                m_waveDescriptionText.text = "Name of the wave: " + waves[nextWave].name + "\n\n" +
                                             "Type of enemy: " + waves[nextWave].enemy.name + "\n\n" +
                                             "Numbers of enemies: " + waves[nextWave].count + "\n\n" +
                                             "Spawn rate: " + waves[nextWave].rate + "\n\n" +
                                             "Hp: " + waves[nextWave].enemyHP + "\n\n" +
                                             "Speed: " + waves[nextWave].enemySpeed;
            }
            else
            {
                m_fadeColor -= 0.014f;
                m_waveDescriptionText.color = new Color(1, 1, 1, m_fadeColor);
            }
        }

        if (m_fadeIn)
        {
            m_imgFadeColor -= 0.01f;
            m_imageFade.color = new Color(1, 1, 1, m_imgFadeColor);
            m_counterText.color = new Color(m_counterText.color.r, m_counterText.color.g, m_counterText.color.b, m_imgFadeColor);
        }
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
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
        state = SpawnState.SPAWNING;
        
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy, _wave.enemyHP, _wave.enemySpeed, _wave.projectileSpeed);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(GameObject _enemy, float setHealth, float setEnemySpeed, float setProjSpeed)
    {
        _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject eObj = Instantiate(_enemy, _sp.position, _sp.rotation) as GameObject;


        if (eObj.GetComponent<EnemyHealth>())
        {
            EnemyHealth eHealth = eObj.GetComponent<EnemyHealth>();
            eHealth.Initializing(setHealth, setHealth);
        }
        if (eObj.GetComponent<AiMovement>())
        {
            AiMovement eAiMovement = eObj.GetComponent<AiMovement>();
            eAiMovement.Initializing(setEnemySpeed);
        }
        if (eObj.GetComponent<AiMovement_Range>())
        {
            AiMovement_Range eAiMovementRange = eObj.GetComponent<AiMovement_Range>();
            eAiMovementRange.Initializing(setEnemySpeed);
        }
        if (eObj.GetComponent<EnemyProjectile>())
        {
            EnemyProjectile eProjectile = eObj.GetComponent<EnemyProjectile>();
            eProjectile.InitializeBulletForce(setProjSpeed);
        }
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
