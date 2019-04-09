using UnityEngine;
using Valve.VR;

public class Movement : MonoBehaviour

{
    //[SteamVR_DefaultActionSet("TouchpadTouch")]
    //[SteamVR_DefaultActionSet("TurnRight")]
    //[SteamVR_DefaultActionSet("TurnLeft")]
    public SteamVR_Action_Vector2 touchPadAction;

    public SteamVR_Action_Boolean TurnRight;
    public SteamVR_Action_Boolean TurnLeft;
    public SteamVR_Action_Boolean CameraShot;
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
    private Vector3 playerpos;
    public SteamVR_Input_Sources RightHandSource = SteamVR_Input_Sources.RightHand;
    public SteamVR_Input_Sources LeftHandSource = SteamVR_Input_Sources.LeftHand;
    public SteamVR_ActionSet actionSetdefault;
    public GameObject Flash;

    public void ChangeMovement(GameObject Objectchosen)
    {
        CurrentMovementType = Objectchosen;
    }



    public void KillPlayer(GameObject Enemy, GameObject EnemyFace,GameObject mainCamera)
    {
       // Enemy.transform.position = gameObject.transform.position - new Vector3(1, 1, 1);

    }

    //public void turnrightwithcontroller(SteamVR_Action_In action_In)
    //{
    //    if (TurnRight.GetStateDown(inputSource) == true)
    //    {
    //        transform.Rotate(0, 20, 0);
    //        print("right pressed");
    //    }
    //}
    //public void turnleftwithcontroller(SteamVR_Action_In action_In)
    //{
    //    if (TurnLeft.GetStateDown(inputSource) == true)
    //    {
    //        transform.Rotate(0, -20, 0);
    //        print("left pressed");
    //    }
    //}





    //void OnEnable()
    //{

    //    if (TurnRight != null)
    //    {
    //        TurnRight.AddOnChangeListener(turnrightwithcontroller, inputSource);
            
    //    }
    //    if (TurnLeft != null)
    //    {
    //        TurnLeft.AddOnChangeListener(turnleftwithcontroller, inputSource);
    //    }

    //}


    //private void OnDisable()
    //{
    //    if (TurnRight != null)
    //    {
    //        TurnRight.RemoveOnChangeListener(turnrightwithcontroller, inputSource);

    //    }
    //    if (TurnLeft != null)
    //    {
    //        TurnLeft.RemoveOnChangeListener(turnleftwithcontroller, inputSource);
    //    }

    //}




    private void Start()
    {
        actionSetdefault.ActivatePrimary();
        CurrentMovementType = ControllerRight;
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        LastPosition = CurrentPosition;
        rb = gameObject.GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        CurrentPosition = transform;
        RaycastHit Hit;
        if (Physics.Raycast(HeightChecker.position, transform.TransformDirection(Vector3.down), out Hit, Mathf.Infinity, layerMask))
        {

            if (Hit.distance != 0.7f)
            {
                transform.position = new Vector3(transform.position.x, (Hit.point.y), transform.position.z);

            }

        }
        Debug.DrawLine(HeightChecker.position, Hit.point, Color.yellow);

        //playerpos = gameObject.transform.position;
        //playerpos.y = (Terrain.activeTerrain.SampleHeight(gameObject.transform.position)+1);
        //gameObject.transform.position = playerpos;

        Vector2 LeftTouchPad = (touchPadAction.GetAxis(LeftHandSource));
        if (SteamVR_Input._default.inActions.TurnLeft.GetStateDown(LeftHandSource))
        {
            if (LeftTouchPad.x > 0.4f)
            {
                transform.Rotate(0, 10, 0);

            }
            else if (LeftTouchPad.x < -0.4f)
            {
                transform.Rotate(0, -10, 0);


            }

        }


    

   

        


        if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(LeftHandSource))
        {
            Flash.GetComponent<Flash>().Firstbitoflight();
        }


        Vector2 touchpad = (touchPadAction.GetAxis(RightHandSource));
        // print(touchpad.x + "    " + touchpad.y);

        // move forward
        //Vector3 forward = CurrentMovementType.transform.forward;
        //forward.y = 0;
        //forward.Normalize();

        Vector3 direction = new Vector3( PlayerSpeed * Time.deltaTime * touchpad.x,  0,PlayerSpeed *  Time.deltaTime * touchpad.y);
        direction = transform.rotation * direction;
        rb.velocity = direction ;
        //  rb.velocity.Normalize();

        //else if (touchpad.y < -0.4f)
        //{
        //    // move backwards
        //    Vector3 forward = CurrentMovementType.transform.forward;
        //    forward.y = 0;
        //    forward.Normalize();
        //    rb.velocity = ((forward * PlayerSpeed * Time.deltaTime) * -1);

        //}
        //else if (touchpad.x > 0.4f)
        //{
        //    //move left
        //    Vector3 forward = CurrentMovementType.transform.right;
        //    forward.y = 0;
        //    forward.Normalize();
        //    rb.velocity = ((forward * PlayerSpeed * Time.deltaTime));

        //}
        //else if (touchpad.x < -0.4f)
        //{
        //    //move right
        //    Vector3 forward = CurrentMovementType.transform.right;
        //    forward.y = 0;
        //    forward.Normalize();
        //    rb.velocity = ((forward * PlayerSpeed * Time.deltaTime) * -1);

        //}


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