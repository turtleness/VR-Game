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
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;
    public SteamVR_ActionSet actionSetdefault;
    public GameObject Flash;

    public void ChangeMovement(GameObject Objectchosen)
    {
        CurrentMovementType = Objectchosen;
    }



    public void KillPlayer(GameObject Enemy, GameObject EnemyFace,GameObject mainCamera)
    {
        Enemy.GetComponent<SentryAI>().enabled = false;
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


    private void Update()
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

        if (SteamVR_Input._default.inActions.TurnRight.GetStateDown(inputSource))
        {
            transform.Rotate(0, 20, 0);
            print("right pressed");
        }

        if (SteamVR_Input._default.inActions.TurnLeft.GetStateDown(inputSource))
        {
            transform.Rotate(0, -20, 0);
        }

        if (SteamVR_Input._default.inActions.GrabGrip.GetStateDown(inputSource))
        {
            Flash.GetComponent<Flash>().Firstbitoflight();
        }


        Vector2 touchpad = (touchPadAction.GetAxis(inputSource));
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
            rb.velocity = ((forward * PlayerSpeed * Time.deltaTime));

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