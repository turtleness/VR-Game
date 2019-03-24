// Patrol.cs
using UnityEngine;
using UnityEngine.AI;


public class SentryAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject Player;

    public bool Idle;
    public bool ApproachPlayer;
    public bool DetectedPlayer;
    public bool NoticedPlayer;
    private bool facingtarget;
    public float stoppingDistance = 0.5f;
    public float RotationSpeed = 0.2f;
    public Animator anim;
    private float playerstarty;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {

        if (DetectedPlayer)
        {
            anim.SetTrigger("Walk");
            GoToPlayer();
            if (!facingtarget)
            {
                Turn(Player.transform.position);
            }    
        }
        else if (Idle)
        {
        }
    }

    private void GoToPlayer()
    {
        agent.destination = new Vector3(Player.transform.position.x, 0, Player.transform.position.z);       
    }

    public void Turn(Vector3 Location)
    {
        Vector3 targetDir = Location - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, RotationSpeed * Time.deltaTime, 0.0F);
        // newDir.x = 0;
        transform.rotation = Quaternion.LookRotation(newDir.normalized);
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