// Patrol.cs
using UnityEngine;
using UnityEngine.AI;

public class SentryAI : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    public NavMeshAgent agent;
    public GameObject Player;

    public bool Idle;
    public bool Patrolling;
    public bool DetectedPlayer;
    public bool NoticedPlayer;
    private bool facingtarget;
    public float stoppingDistance = 0.5f;
    public float RotationSpeed = 0.2f;
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        Idle = true;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Idle)
        {
            Idle = false;
            Patrolling = true;
            anim.SetTrigger("Walk");
        }
        else if (DetectedPlayer)
        {
            Patrolling = false;
            agent.isStopped = true;
            anim.SetBool("SawEnemy", true);
            if (!facingtarget)
            {
                Turn();
            }
        }
        else if (Patrolling)
        {
            if (!agent.pathPending && agent.remainingDistance < stoppingDistance)
            {
                GotoNextPoint();
            }
        }
        else
        {
            return;
        }
    }

    private void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    public void Turn()
    {
        Vector3 targetDir = Player.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, RotationSpeed * Time.deltaTime, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);
        if (Vector3.Angle(newDir, targetDir) < 5f)
        {
            facingtarget = true;
        }
        else
        {
            facingtarget = false;
        }
    }
}