using UnityEngine;
using System.Collections;
using System.Collections.Generic; //Always a good idea
using System;

public class AiMovement : MonoBehaviour
{

    //public Transform Player;//anv�nds ej
    //public Transform TankPlayer;
    public float MoveSpeed;
    float MinDist = 0f;
    float InRangeAggresive = 15;
    float InRangeAttackTank = 40;

    public List<Transform> Players;
    public Transform SelectedTarget;
    public ParticleSystem m_stunSystem;

    private float m_stunTimer = 0;
    public bool m_isStunned;

    GameObject[] otherObject;
    Vector3 lastPosition;
    private NavMeshAgent navComponent;

    public int numberOfPlayers;
    enum GameState
    {
        Patrol,//inte anv�ndas nu
        Attack,
        AttackTank,
        Aggresive
    }

    GameState currentGamestate;

    public void Initializing(float newMoveSpeed)
    {
        MoveSpeed = newMoveSpeed;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        MoveSpeed = moveSpeed;
    }

    void Start()
    {
        currentGamestate = GameState.Attack;//har s� l�nge p� Attack, byta sen till patrol ju l�ngre vi har kommit p� spelet

        SelectedTarget = null;
        Players = new List<Transform>();
        AddPlayersToList();
        otherObject = GameObject.FindGameObjectsWithTag("Enemy");
        lastPosition = transform.position;
        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
        m_stunSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        navComponent.speed = MoveSpeed;
        numberOfPlayers = GameObject.FindGameObjectsWithTag("Player").Length;

        UpdatePlayerList();
        //KeepDistanceToOtherEnemies();
        TargetedPlayer();
        MoveToPlayer();
        Stunned();

        lastPosition = transform.position;
        //SwitchGameState();//Inte klar �n
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

    public void Stun(bool fluffHit)
    {
        if (fluffHit == true)
        {
            m_isStunned = true;
            GetComponentInChildren<ParticleSystem>().Play();
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
                m_stunSystem.Play();


                if (m_stunTimer >= 3)
                {
                    MoveSpeed = 2f;
                    m_isStunned = false;
                    //m_stunSystem.Stop();
                    m_stunTimer = 0;
                }
            }
        }
    }

    private void MoveToPlayer()
    {
        float dist = Vector3.Distance(SelectedTarget.position, transform.position);
        if (SelectedTarget)
        {
            navComponent.SetDestination(SelectedTarget.position);
        }
    }

    //private void KeepDistanceToOtherEnemies()
    //{
    //    foreach (GameObject go in otherObject)
    //    {
    //        if (go != gameObject)
    //        {
    //            if (Vector3.Distance(transform.position, go.transform.position) <= 4f)
    //            {
    //                //Koden fr�n b�rjan, dock funkar inte den riktigt med navmesh
    //                //transform.position = (transform.position - go.transform.position).normalized + go.transform.position;
    //                //go.transform.position += (transform.position - lastPosition);

    //                //simpel kod, finns b�ttre, men anv�nder den �nd�
    //                //transform.position = lastPosition;

    //                //Funkar b�st hittills
    //                //go.transform.position += (transform.position - lastPosition);
    //            }
    //        }
    //    }
    //}

    private void UpdatePlayerList()
    {
        if (Players.Count != GameObject.FindGameObjectsWithTag("Player").Length)
        {
            Players.Clear();
            AddPlayersToList();
        }
    }

    //void SwitchGameState()
    //{
    //    switch (currentGamestate)
    //    {
    //        case GameState.Patrol://anv�nds ej �n
    //            break;

    //        case GameState.Attack:

    //            TargetedPlayer();

    //            transform.LookAt(SelectedTarget);

    //            if (Vector3.Distance(transform.position, SelectedTarget.position) >= MinDist)
    //            {
    //                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    //            }

    //            //Inom avst�nd till tanken f�r att attackera
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
