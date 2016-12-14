using UnityEngine;
using System.Collections;
using System.Collections.Generic; //Always a good idea


public class AiMovement_Range : MonoBehaviour
{

    //public Transform Player;//används ej
    //public Transform TankPlayer;
    public float MoveSpeed;
    float MinDist = 0f;
    float InRangeAggresive = 15;
    float InRangeAttackTank = 40;

    public List<Transform> Players;
    public Transform SelectedTarget;

    private float m_stunTimer = 0;
    public bool m_isStunned;
    private float range = 20f;

    GameObject[] otherObject;
    Vector3 lastPosition;
    private NavMeshAgent navComponent;

    enum GameState
    {
        Patrol,//inte användas nu
        Attack,
        AttackTank,
        Aggresive
    }

    GameState currentGamestate;

    public void Initializing(float newMoveSpeed)
    {
        MoveSpeed = newMoveSpeed;
    }

    void Start()
    {
        currentGamestate = GameState.Attack;//har så länge på Attack, byta sen till patrol ju längre vi har kommit på spelet

        SelectedTarget = null;
        Players = new List<Transform>();
        AddPlayersToList();

        otherObject = GameObject.FindGameObjectsWithTag("Enemy");
        lastPosition = transform.position;

        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        MoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        navComponent.speed = MoveSpeed;

        KeepDistanceToOtherEnemies();
        UpdatePlayerList();
        TargetedPlayer();
        KeepDistanceToPlayers();
        Stunned();        

        lastPosition = transform.position;
        //SwitchGameState();//Inte klar än


        
        //transform.LookAt(SelectedTarget);
        //if (Vector3.Distance(transform.position, SelectedTarget.position) >= MinDist) //needed for movement to work in SyneryTester
        //{
        //    transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        //}
    }

    public void AddPlayersToList()
    {
        GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in ItemsInList)
        {
            AddTarget(player.transform);
        }
    }

    public void AddTarget(Transform player)
    {
        Players.Add(player);
    }

    public void DistanceToTarget()
    {
        Players.Sort(delegate (Transform t1, Transform t2)
        {
            return Vector3.Distance(t1.transform.position, transform.position).CompareTo(Vector3.Distance(t2.transform.position, transform.position));
        });
    }

    public void TargetedPlayer()
    {
        DistanceToTarget();
        SelectedTarget = Players[0];
    }

    public void StunRange(bool fluffHit)
    {
        if (fluffHit == true)
        {
            m_isStunned = true;
        }
    }

    private void Stunned()
    {
        if (m_isStunned)
        {
            if (m_stunTimer < 3)
            {
                m_stunTimer += Time.deltaTime;
                MoveSpeed = 0f;

                if (m_stunTimer >= 3)
                {
                    MoveSpeed = 2f;
                    m_isStunned = false;
                    m_stunTimer = 0;
                }
            }
        }
    }

    private void KeepDistanceToPlayers()
    {
        float dist = Vector3.Distance(SelectedTarget.position, transform.position);
        if (SelectedTarget)
        {

            if (dist >= 20)
            {
                navComponent.Resume();
                navComponent.SetDestination(SelectedTarget.position);
            }
            else
            {
                transform.LookAt(new Vector3(SelectedTarget.transform.position.x, 0, SelectedTarget.transform.position.z));
                navComponent.Stop();
            }
        }
    }

    private void UpdatePlayerList()
    {
        if (Players.Count != GameObject.FindGameObjectsWithTag("Player").Length)
        {
            Players.Clear();
            AddPlayersToList();
        }
    }

    private void KeepDistanceToOtherEnemies()
    {
        foreach (GameObject go in otherObject)
        {
            if (go != gameObject)
            {
                if (Vector3.Distance(transform.position, go.transform.position) <= 4f)
                {
                    //Koden från början, dock funkar inte den riktigt med navmesh
                    //transform.position = (transform.position - go.transform.position).normalized + go.transform.position;
                    //go.transform.position += (transform.position - lastPosition);

                    //simpel kod, finns bättre
                    //transform.position = lastPosition;

                    //Funkar bäst hittills
                    //go.transform.position += (transform.position - lastPosition);
                }
            }
        }
    }

    //void SwitchGameState()
    //{
    //    switch (currentGamestate)
    //    {
    //        case GameState.Patrol://används ej än
    //            break;

    //        case GameState.Attack:

    //            TargetedPlayer();

    //            transform.LookAt(SelectedTarget);

    //            if (Vector3.Distance(transform.position, SelectedTarget.position) >= MinDist)
    //            {
    //                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    //            }

    //            //Inom avstånd till tanken för att attackera
    //            if (Vector3.Distance(transform.position, TankPlayer.position) <= InRangeAttackTank)
    //            {
    //                currentGamestate = GameState.AttackTank;
    //            }
    //            else if (Vector3.Distance(transform.position, SelectedTarget.position) <= InRangeAggresive)
    //            {
    //                currentGamestate = GameState.Aggresive;
    //            }

    //            break;

    //        case GameState.AttackTank:

    //            transform.LookAt(TankPlayer);

    //            if (Vector3.Distance(transform.position, TankPlayer.position) >= MinDist)
    //            {
    //                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    //            }


    //            break;

    //        case GameState.Aggresive:


    //            TargetedPlayer();

    //            transform.LookAt(SelectedTarget);

    //            MoveSpeed = 3;

    //            if (Vector3.Distance(transform.position, SelectedTarget.position) >= MinDist)
    //            {
    //                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    //            }

    //            if (Vector3.Distance(transform.position, SelectedTarget.position) >= InRangeAggresive)
    //            {
    //                currentGamestate = GameState.Attack;
    //            }

    //            break;

    //        default:
    //            break;
    //    }
    //}
}
