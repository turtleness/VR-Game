using System.Collections;
using UnityEngine;

public class Perspective : Sense
{
    public int FieldOfViewLeft;
    public int FieldOfViewRight;
    public int ViewDistance = 10;
    private Transform playerTrans;
    private Vector3 rayDirection;
    public GameObject Player;
    private float currCountdownValue;
    private SentryAI AI;
    private bool CR_running;
    private bool detected = false;

    private void Start()
    {
        //Find player position
        playerTrans = Player.transform;
        AI = gameObject.GetComponent<SentryAI>();
    }

    // Update is called once per frame

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        // Detect perspective sense if within the detection rate
        if (elapsedTime >= detectionRate & detected == false)
        {
            elapsedTime = 0;
            DetectPlayer();
        }
    }


    public void ResetAI()
    {
        detected = false;
        AI.DetectedPlayer = false;
        AI.Idle = true;
    }

    private void PlayerDetected() {
        AI.DetectedPlayer = true;
        AI.MoveToplayer = true;
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
        print("detected");

    }
        

    private void DetectPlayer()
    {
        RaycastHit hit;
        rayDirection = playerTrans.position - transform.position;
        float angleToPlayer = (Vector3.Angle(rayDirection, transform.forward));
        if (angleToPlayer >= -90 && angleToPlayer <= 90 & (Physics.Raycast(transform.position, rayDirection,out hit, ViewDistance)))
        {
            if (hit.collider.tag == "Player")
            {
                detected = true;
                PlayerDetected();
            }

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