using UnityEngine;
using System.Collections;

public class Perspective : Sense
{
    public int FieldOfView = 45;
    public int ViewDistance = 100;
    private Transform playerTrans;
    private Vector3 rayDirection;
    public GameObject Player;
    float currCountdownValue;
    SentryAI AI;
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
            DetectAspect();
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
                CR_running = false;
                AI.DetectedPlayer = true;
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                Time.timeScale = 1f;
                Invoke("ResetAI", 4f);
            }
        }
    }
    private void DetectAspect()
    {
        RaycastHit hit;
        rayDirection = playerTrans.position - transform.position;
        if ((Vector3.Angle(rayDirection, transform.forward)) <
        FieldOfView)
        {
            if (Physics.Raycast(transform.position, rayDirection,
            out hit, ViewDistance))
            {
                Aspect aspect = hit.collider.GetComponent<Aspect>();
                if (aspect != null)
                {
                    print(hit.collider.gameObject);
                    if (aspect.aspectName == aspectName)
                    {
                        
                        if (CR_running)
                        {
                            print("i am waiting 2 seconds");

                        }
                        else if (CR_running == false & AI.DetectedPlayer == false)

                        {
                            print("There You are!");
                            StartCoroutine(StartCountdown());
                            Time.timeScale = 0.25f;
                            AI.NoticedPlayer = true;
                            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                        }
                    }
                }
                else
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.white;
                    StopAllCoroutines();
                    CR_running = false;
                    Time.timeScale = 1f;
                  //  print("Hes gone!2");
                }
            }

        }

        else if (AI.NoticedPlayer == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            StopAllCoroutines();
            Time.timeScale = 1f;
            CR_running = false;
            print("Hes gone!2");
        }

    }

    private void OnDrawGizmos()
    {
        if (!bDebug || playerTrans == null) return;
        Debug.DrawLine(transform.position, playerTrans.position, Color.
        red);
        Vector3 frontRayPoint = transform.position + (transform.forward * ViewDistance);
        Vector3 leftRayPoint = frontRayPoint;
        leftRayPoint.x += FieldOfView;
        Vector3 rightRayPoint = frontRayPoint;
        rightRayPoint.x -= FieldOfView;
        Debug.DrawLine(transform.position, frontRayPoint, Color.green);
        Debug.DrawLine(transform.position, leftRayPoint, Color.green);
        Debug.DrawLine(transform.position, rightRayPoint, Color.green);
    }
}