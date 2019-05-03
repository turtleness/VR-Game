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
    private readonly int layerMask = 14 << 0;
    public float maxVelocityChange = 10.0f;
    public float speed = 5.0f;
    SteamVR_TrackedObject trackedObj;
    private Vector3 playerpos;
    public SteamVR_Input_Sources RightHandSource = SteamVR_Input_Sources.RightHand;
    public SteamVR_Input_Sources LeftHandSource = SteamVR_Input_Sources.LeftHand;
    public SteamVR_ActionSet actionSetdefault;
    public GameObject Flash;
    public GameObject BodyCollider;
    RaycastHit Hit;

    private bool camerapickedup = false;
    public void ChangeCameraState()
    {
        camerapickedup = !camerapickedup;
    }


    public void ChangeMovement(GameObject Objectchosen)
    {
        CurrentMovementType = Objectchosen;
    }



    public void KillPlayer(GameObject Enemy, GameObject EnemyFace,GameObject mainCamera)
    {

    }


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

        // height checker
        Height = BodyCollider.transform.position.y + 0.2f;                                                                                                             
        if (Physics.Raycast(new Vector3 (BodyCollider.transform.position.x,Height,BodyCollider.transform.position.z),BodyCollider.transform.up *-1, out Hit,Mathf.Infinity, layerMask))
        {
            print("touched");
            Debug.DrawLine(new Vector3(BodyCollider.transform.position.x, Height, BodyCollider.transform.position.z), Hit.point, Color.yellow);


        }









        //if (Physics.Raycast(HeightChecker.position, Vector3.down, out Hit, Mathf.Infinity, layerMask))
        //{
        //   
        //    if (Vector3.Distance(Hit.point, HeightChecker.position) != 0.7f)
        //    {
        //        transform.position = new Vector3(transform.position.x, (Hit.point.y), transform.position.z);

        //    }

        //}







        //turn left when pressed on left controller
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


        if (camerapickedup == true)
        {
            if (SteamVR_Input._default.inActions.TurnRight.GetStateDown(RightHandSource))
            {

                Flash.GetComponent<Flash>().Firstbitoflight();
            }

        }



        Vector2 touchpad = (touchPadAction.GetAxis(RightHandSource));
        Vector3 direction = new Vector3( PlayerSpeed * Time.deltaTime * touchpad.x,  0,PlayerSpeed *  Time.deltaTime * touchpad.y);

        Quaternion rot = CurrentMovementType.transform.rotation;
        rot.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.x, -45, 10), rot.eulerAngles.y, Mathf.Clamp(transform.eulerAngles.z, -45, 45));
        direction = rot * direction;
        rb.velocity =  new Vector3(direction.normalized.x,rb.velocity.y,direction.normalized.z);
        }


}

