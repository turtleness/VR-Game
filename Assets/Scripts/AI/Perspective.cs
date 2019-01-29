using System.Collections;
using UnityEngine;

public class Perspective : Sense
{
    public int FieldOfViewLeft;
    public int FieldOfViewRight;
    public int ViewDistance = 100;
    private Transform playerTrans;
    private Vector3 rayDirection;
    public GameObject Player;
    private float currCountdownValue;
    private SentryAI AI;
    private bool CR_running;

    private void Start()
    {
        //Find player position
        playerTrans = Player.transform;
        AI = gameObject.GetComponent<SentryAI>();
    }

    // Update is called once per frame
    protected override void UpdateSense()
    {
        elapsedTime += Time.deltaTime;
        // Detect perspective sense if within the detection rate
        if (elapsedTime >= detectionRate)
        {
            DetectPlayer();
        }
    }

    public void ResetAI()
    {
        AI.Patrolling = true;
        AI.agent.isStopped = false;
        AI.DetectedPlayer = false;
        CR_running = true;
    }

    public IEnumerator StartCountdown(float countdownValue = 0)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue < 2)
        {
            CR_running = true;
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(0.1f);
            currCountdownValue += 0.2f;
            if (currCountdownValue >= 2)
            {
                PlayerDetected();
                Time.timeScale = 1f;
                print("I am Running");
                // Player.GetComponent<Movement>().PlayerSpeed = 2f;
                //Invoke("ResetAI", 4f);
            }
        }
    }


    private void PlayerDetected() {
        CR_running = false;
        AI.DetectedPlayer = true;
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;

    }
        

    private void DetectPlayer()
    {
        RaycastHit hit;
        rayDirection = playerTrans.position - transform.position;
        float angleToPlayer = (Vector3.Angle(rayDirection, transform.forward));
        if (angleToPlayer >= -90 && angleToPlayer <= 90
        
        &
        
        (Physics.Raycast(transform.position, rayDirection,
            out hit, ViewDistance)))
        {
            Aspect aspect = hit.collider.GetComponent<Aspect>();
            if (aspect != null)
            {
                if (CR_running)
                {
                    print("i am waiting 2 seconds to give the player time to run away before i actually see him");
                    gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.yellow;
                }
                else if (CR_running == false & AI.DetectedPlayer == false)

                {
                    print("There You are!");
                    StartCoroutine(StartCountdown());
                    Time.timeScale = 0.25f;
                    Player.GetComponentInParent<Movement>().PlayerSpeed = 8f;
                    AI.NoticedPlayer = true;
                }
            }
        }
        else if (AI.NoticedPlayer == true)
        {
            gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.white;
            StopAllCoroutines();
            Time.timeScale = 1f;
            CR_running = false;
            print("Hes gone!");
            AI.NoticedPlayer = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (!bDebug || playerTrans == null) return;
        Debug.DrawLine(transform.position, playerTrans.position, Color.
        red);
        Vector3 frontRayPoint = transform.position + (transform.forward * ViewDistance);
        Vector3 leftRayPoint = frontRayPoint;
        leftRayPoint.x += FieldOfViewLeft;
        Vector3 rightRayPoint = frontRayPoint;
        rightRayPoint.x += FieldOfViewRight;
        Debug.DrawLine(transform.position, frontRayPoint, Color.green);
        Debug.DrawLine(transform.position, leftRayPoint, Color.green);
        Debug.DrawLine(transform.position, rightRayPoint, Color.green);
    }
}