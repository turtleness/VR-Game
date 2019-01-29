using UnityEngine;
using Valve.VR;

public class Movement : MonoBehaviour

{
    [SteamVR_DefaultActionSet("TouchpadTouch")]
    [SteamVR_DefaultActionSet("TurnRight")]
    [SteamVR_DefaultActionSet("TurnLeft")]
    public SteamVR_Action_Vector2 touchPadAction;

    public SteamVR_Action_Boolean TurnRight;
    public SteamVR_Action_Boolean TurnLeft;
    public float PlayerSpeed;
    public Transform HeightChecker;
    public float Height;
    public float StepSpeed;
    private Transform LastPosition;
    private Transform CurrentPosition;
    private Rigidbody rb;
    public GameObject Head;
    private float sensitivityX = 1.5F;
    private readonly int layerMask = 1 << 9;
    public float maxVelocityChange = 10.0f;
    public float speed = 5.0f;
    SteamVR_TrackedObject trackedObj;

    private void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        LastPosition = CurrentPosition;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CurrentPosition = transform;
        RaycastHit Hit;
        //Vector2 touchpadValue = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);

        if (Physics.Raycast(HeightChecker.position, transform.TransformDirection(Vector3.down), out Hit, Mathf.Infinity))
        {

            if (Hit.distance < Height - 0.05f & Hit.distance > Height - 0.3f)
            {
                transform.position += new Vector3(0, 0.1f, 0);
                print(Hit.distance);
            }
            else if (Hit.distance > Height + 0.05f)
            {
                transform.position -= new Vector3(0, 0.1f, 0);
                print(Hit.distance);
            }
        }
        if (SteamVR_Input._default.inActions.TurnRight.GetStateDown(SteamVR_Input_Sources.Any))
            transform.Rotate(0, 40, 0);
        if (SteamVR_Input._default.inActions.TurnLeft.GetStateDown(SteamVR_Input_Sources.Any))
            transform.Rotate(0, -40, 0);
        Debug.DrawLine(HeightChecker.position, Hit.point, Color.yellow);



        Vector2 touchpad = (touchPadAction.GetAxis(SteamVR_Input_Sources.Any));
            if (touchpad.y > 0.7f)
            {
            Vector3 forward = Head.transform.forward;
            forward.y = 0;
            rb.velocity = (forward * PlayerSpeed *Time.deltaTime);
            print(rb.velocity);

        }

            else if (touchpad.y < -0.7f)
            {
            Vector3 forward = Head.transform.forward;
            forward.y = 0;
            rb.velocity = ((forward * PlayerSpeed * Time.deltaTime)*-1);
            print(rb.velocity);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    
}


//if (touchpadValue.y > 0.2f || touchpadValue.y < -0.2f)
//{
//    //// Move Forward

//    //// zero out y, leaving only x & z
//    //// transform.Translate(forward *Time.deltaTime*(-touchpadValue.y * PlayerSpeed));

//    //rb.velocity = forward.normalized * 5;
//    //print(forward * Time.deltaTime * (-touchpadValue.y * PlayerSpeed));

//    //Vector3 targetVelocity = Head.transform.forward;



//    ////   transform.position += forward * Time.deltaTime * (touchpadValue.y * PlayerSpeed);
//}