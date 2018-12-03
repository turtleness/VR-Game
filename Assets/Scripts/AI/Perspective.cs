using UnityEngine;

public class Perspective : Sense
{
    public int FieldOfView = 45;
    public int ViewDistance = 100;
    private Transform playerTrans;
    private Vector3 rayDirection;
    public GameObject Player;
    SentryAI AI;

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
                    if (aspect.aspectName == aspectName)
                    {
                        print("Enemy Detected");
                        gameObject.GetComponent<Renderer>().material.color = Color.red;
                        AI.DetectedPlayer = true;
                    }
                }
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
        leftRayPoint.x += FieldOfView;
        Vector3 rightRayPoint = frontRayPoint;
        rightRayPoint.x -= FieldOfView;
        Debug.DrawLine(transform.position, frontRayPoint, Color.green);
        Debug.DrawLine(transform.position, leftRayPoint, Color.green);
        Debug.DrawLine(transform.position, rightRayPoint, Color.green);
    }
}