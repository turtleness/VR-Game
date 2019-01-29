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
    public float PlayerSpeed = 2f;
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
    public float speed = 10.0f;

    private void Start()
    {
        LastPosition = CurrentPosition;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CurrentPosition = transform;
        RaycastHit Hit;
        Vector2 touchpadValue = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);
        Vector3 forward = Head.transform.forward;
        forward.y = 0;
        if (Physics.Raycast(HeightChecker.position, transform.TransformDirection(Vector3.down), out Hit, Mathf.Infinity))
        {
            LastPosition = CurrentPosition;

            if (touchpadValue.y > 0.2f || touchpadValue.y < -0.2f)
            {
                // Move Forward

                // zero out y, leaving only x & z
                // transform.Translate(forward *Time.deltaTime*(-touchpadValue.y * PlayerSpeed));

                rb.velocity = forward.normalized * 5;
                print(forward * Time.deltaTime * (-touchpadValue.y * PlayerSpeed));

                //Vector3 targetVelocity = Head.transform.forward;

                // rb.AddForce(forward * (touchpadValue.y * PlayerSpeed), ForceMode.VelocityChange);

                //   transform.position += forward * Time.deltaTime * (touchpadValue.y * PlayerSpeed);
            }
            if (SteamVR_Input._default.inActions.TurnRight.GetStateDown(SteamVR_Input_Sources.Any))
                transform.Rotate(0, 40, 0);
            //if (SteamVR_Input._default.inActions.TurnLeft.GetStateDown(SteamVR_Input_Sources.Any))
            //    transform.Rotate(0, -40, 0);

            Debug.DrawLine(HeightChecker.position, Hit.point, Color.yellow);

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
        else
        {
            print("i went back");
            transform.position = LastPosition.position;
        }
    }
}