// Patrol.cs
using UnityEngine;
using UnityEngine.AI;


public class SentryAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject Player;
    public GameObject MainCam;

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
 
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Debug.DrawLine(gameObject.transform.position, Originpoint);

        if (DetectedPlayer)
        {
            Idle = false;
            CancelInvoke();
            if (MoveToplayer)
            {
                GoToPlayer();
            }

            //if (!facingtarget)
            //{
            //    Turn(Player.transform.position);
            //}    
        }
        else if (Idle)
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

    //private void OnCollisionEnter(Collision collision)
    //{
    //    MovearoundIdle();
    //}

    private void MovearoundIdle()
    {
        Originpoint = gameObject.transform.position;
        Originpoint.x += Random.Range(-MoveRadius, MoveRadius);
        Originpoint.z += Random.Range(-MoveRadius, MoveRadius);
        agent.destination = Originpoint;


    }

    private void GoToPlayer()
    {
        agent.destination = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);
        agent.isStopped = false;
        //if (agent.remainingDistance < stoppingDistance)
        //{
        //    MoveToplayer = false;
        //    print("stop");
        //    agent.isStopped = true;
        //    Player.GetComponentInParent<Movement>().KillPlayer(gameObject, gameObject.GetComponentInChildren<ObjectTaker>().gameObject,MainCam);

        //    //anim.SetBool("SawEnemy",true);
        //}
        //else
        //{
        //    agent.isStopped = false;
        //}

    }

    //public void Turn(Vector3 Location)
    //{
    //    Vector3 targetDir = Location - transform.position;
    //    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, RotationSpeed * Time.deltaTime, 0.0F);
    //    // newDir.x = 0;
    //    transform.rotation = Quaternion.LookRotation(newDir.normalized);
    //    if (Vector3.Angle(newDir, targetDir) < 5f)
    //    {
    //        facingtarget = true;
    
    //    }
    //    else
    //    {
    //        facingtarget = false;
    //    }
    //}
}