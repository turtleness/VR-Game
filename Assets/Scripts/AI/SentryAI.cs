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
    public float maxfollowdistance = 15;
    public GameObject enemyHand;

    private void Start()
    {
        Idle = true;
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 0.2f;
    }

    //private void Update()
    //{
    //    Debug.DrawLine(gameObject.transform.position, Originpoint);
    //    if (Idle)
    //    {
    //        if (agent.remainingDistance <= agent.stoppingDistance)
    //        {
    //            PositionReached = true;
    //            agent.ResetPath();
    //        }
    //        else
    //        {
    //            PositionReached = false;
    //        }
    //        if (PositionReached)
    //        {
    //            MovearoundIdle();
    //        }
    //    }
    //}

    public void ResetAI()
    {
        agent.stoppingDistance = 0.2f;
        anim.SetBool("SawEnemy", false);
        DetectedPlayer = false;
        CancelInvoke();
        agent.ResetPath();
        Idle = true;
    }

    //public float range = 2.0f;
    //bool RandomPoint(out Vector3 result)
    //{
    //    for (int i = 0; i < 30; i++)
    //    {
    //        Vector3 randomPoint = gameObject.transform.position + UnityEngine.Random.insideUnitSphere * MoveRadius;
    //        NavMeshHit hit;
    //        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
    //        {
    //            result = hit.position;

    //            return true;
    //        }
    //    }
    //    result = Vector3.zero;
    //    return false;
    //}

    //private void MovearoundIdle()
    //{
    //    Vector3 point;
    //    if (RandomPoint(out point))
    //    {
    //        Originpoint = point;
    //        //Originpoint.y = 1;

    //    }
    //    agent.destination = Originpoint;
    //   // Invoke("RedoPath",1);

    //}

    //private void RedoPath()
    //{
    //    if (agent.remainingDistance > 4)
    //    {
    //        MovearoundIdle();
    //    }
    //}



    public void PlayerDetected()
    {
        DetectedPlayer = true;
        anim.SetBool("SawEnemy", true);
        agent.stoppingDistance = 2f;
        InvokeRepeating("GoToPlayer", 0.2f, 0.2f);
        InvokeRepeating("Checkdistance", 0.05f, 0.05f);
    }


    private void GoToPlayer()
    {    
        agent.destination = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);
    }


    private void SuckSoul()
    {
        Instantiate(lifeforce, LifeForceTarget.transform.position + UnityEngine.Random.insideUnitSphere * 0.2f, new Quaternion()).GetComponent<LifeForce>().EnemyInstance = enemyHand;
    }


    private void Checkdistance()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                anim.SetBool("NearPlayer", true);
                SuckSoul();
                }
            }
      
        else if ((Vector3.Distance(Player.transform.position,gameObject.transform.position) > maxfollowdistance))
        {
            ResetAI();
        }
        else
        {
            anim.SetBool("NearPlayer", false);
        }
        
    }


    private bool SittingIdle;
    private bool StandingIdle;
    private bool WanderingIdle;
    private bool ChasingPlayer;
    private bool StealingSoul;
























}