// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System;


public class SentryAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject Player;
    public GameObject MainCam;
    public GameObject lifeforce;
    public GameObject LifeForceTarget;

    public bool Idle;
    public bool ApproachPlayer;
    public bool DetectedPlayer;
    public bool NoticedPlayer;
    private bool facingtarget;
    public float stoppingDistance = 0.5f;
    public float RotationSpeed = 0.2f;
    public Animator anim;
    private float playerstarty;
    public bool MoveToplayer;
    private Vector3 Originpoint;
    private bool PositionReached = true;
    public float MoveRadius = 5f;
    public NavMeshPath navMeshPath;

    private void Start()
    {
        Idle = true;
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Debug.DrawLine(gameObject.transform.position, Originpoint);
        if (Idle)
        {
            if (agent.remainingDistance <= 0.2)
            {
                PositionReached = true;

                agent.ResetPath();
            }
            else
            {
                PositionReached = false;
            }
            if (PositionReached)
            {
                MovearoundIdle();
            }
        }
    }

    private void ResetAI()
    {
        CancelInvoke();
        Idle = true;
    }




    private void MovearoundIdle()
    {
        Originpoint = gameObject.transform.position;
        Originpoint.x += UnityEngine.Random.Range(-MoveRadius, MoveRadius);
        Originpoint.z += UnityEngine.Random.Range(-MoveRadius, MoveRadius);
        agent.destination = Originpoint;


    }

    public void PlayerDetected()
    {
        Idle = false;
        InvokeRepeating("GoToPlayer", 0.2f, 0.2f);
        InvokeRepeating("Checkdistance", 0.05f, 0.05f);
    }


    private void GoToPlayer()
    {
       
        agent.destination = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);

    }

    private void Checkdistance()
    {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                Instantiate(lifeforce, LifeForceTarget.transform.position + UnityEngine.Random.insideUnitSphere * 0.2f, new Quaternion()).GetComponent<LifeForce>().EnemyInstance = gameObject;
                }
            }      
    }


}