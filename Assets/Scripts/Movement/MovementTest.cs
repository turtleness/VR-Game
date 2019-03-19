using UnityEngine;
using Valve.VR;

public class MovementTest : MonoBehaviour

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
    public GameObject CurrentMovementType;
    public GameObject Face;
    public GameObject ControllerLeft;
    public GameObject ControllerRight;
    private float sensitivityX = 1.5F;
    private readonly int layerMask = 1 << 0;
    public float maxVelocityChange = 10.0f;
    public float speed = 5.0f;
    SteamVR_TrackedObject trackedObj;



    private void Start()
    {
        CurrentMovementType = ControllerLeft;
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        LastPosition = CurrentPosition;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CurrentPosition = transform;
        RaycastHit Hit;
        //Vector2 touchpadValue = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);


        if (SteamVR_Input._default.inActions.TurnRight.GetStateDown(SteamVR_Input_Sources.Any))
        {
            transform.Rotate(0, 20, 0);
            print("right pressed");
        }

        if (SteamVR_Input._default.inActions.TurnLeft.GetStateDown(SteamVR_Input_Sources.Any))
        {
            transform.Rotate(0, -20, 0);
        }



        Vector2 touchpad = (touchPadAction.GetAxis(SteamVR_Input_Sources.Any));
        if (touchpad.y > 0.4f)
        {
            // move forward
            Vector3 forward = CurrentMovementType.transform.forward;
            forward.y = 0;
            rb.velocity = (forward * PlayerSpeed * Time.deltaTime);
            rb.velocity.Normalize();
            print("forward pressed" + rb.velocity);
        }
        else if (touchpad.y < -0.4f)
        {
            // move backwards
            Vector3 forward = CurrentMovementType.transform.forward;
            forward.y = 0;
            rb.velocity = ((forward * PlayerSpeed * Time.deltaTime) * -1);

        }
        else if (touchpad.x > 0.4f)
        {
            //move left
            Vector3 forward = CurrentMovementType.transform.right;
            forward.y = 0;
            rb.velocity = ((forward * PlayerSpeed * Time.deltaTime ));

        }
        else if (touchpad.x < -0.4f)
        {
            //move right
            Vector3 forward = CurrentMovementType.transform.right;
            forward.y = 0;
            rb.velocity = ((forward * PlayerSpeed * Time.deltaTime) * -1);

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