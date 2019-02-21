using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using Valve.VR;


public class Tutorial : MonoBehaviour {
    public Text MainText;
    public int arraypointer = -1;
    private Transform playertrans;
    public GameObject bluezone;
    public GameObject tutorial;


    //movement start
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
    // movement end


    private bool Taskcomplete = false;


    // Use this for initialization
    void Start () {
        MainText.text = ("Welcome to the VR Horror Game");
        Invoke("NextText",5);

        trackedObj = GetComponent<SteamVR_TrackedObject>();
        LastPosition = CurrentPosition;
        rb = gameObject.GetComponent<Rigidbody>();

        playertrans = gameObject.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("BlueZone"))
        {
            Taskcomplete = true;
            other.gameObject.SetActive(false);
            TaskComplete();

        }
    }

    public void TaskComplete()
    {

        rb.velocity = new Vector3(0, 0, 0);
        MainText.text = ("GoodJob");
        Invoke("NextText", 1f);

    }
    // Update is called once per frame
    void Update () {
   //     CurrentPosition = transform;
        Vector2 touchpad = (touchPadAction.GetAxis(SteamVR_Input_Sources.Any));

        if (Taskcomplete == false)
        {


            switch (arraypointer)
            {
                case 0: // walk forward

                    if (touchpad.y > 0.4f)
                    {
                        Vector3 forward = Head.transform.forward;
                        forward.y = 0;
                        rb.velocity = (forward * PlayerSpeed * Time.deltaTime);
                    }
                    else
                    {
                        rb.velocity = new Vector3(0, 0, 0);
                    }
                    break;
                case 1: // walk back
                    if (touchpad.y < -0.4f)
                    {
                        Vector3 forward = Head.transform.forward;
                        forward.y = 0;
                        rb.velocity = ((forward * PlayerSpeed * Time.deltaTime) * -1);
                    }
                    else
                    {
                        rb.velocity = new Vector3(0, 0, 0);
                    }
                    break;
                case 2:
                           if (touchpad.x < -0.4f)
                    {
                        //move left
                        Vector3 forward = Head.transform.right;
                        forward.y = 0;
                        rb.velocity = ((forward * PlayerSpeed * Time.deltaTime) * -1);
                    }
                    else
                    {
                        rb.velocity = new Vector3(0, 0, 0);
                    }
                    break;
                case 3:
                            if (touchpad.x > 0.4f)
                    {
                        //move right
                        Vector3 forward = Head.transform.right;
                        forward.y = 0;
                        rb.velocity = ((forward * PlayerSpeed * Time.deltaTime) );
                    }
                    else
                    {
                        rb.velocity = new Vector3(0, 0, 0);
                    }
                    break;
                case 4:
                    if (SteamVR_Input._default.inActions.TurnLeft.GetStateDown(SteamVR_Input_Sources.Any))
                    {
                        transform.Rotate(0, -20, 0);
                        TaskComplete();
                    }


                    break;
                case 5:
                    if (SteamVR_Input._default.inActions.TurnRight.GetStateDown(SteamVR_Input_Sources.Any))
                    {
                        transform.Rotate(0, 20, 0);
                        TaskComplete();
                    }

                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    tutorial.SetActive(false);
                    gameObject.GetComponent<Movement>().enabled = true;
                    gameObject.GetComponent<Tutorial>().enabled = false;
                    break;
            }
        }

    }




    public void NextText()
    {
        Taskcomplete = false;
        arraypointer++;
        switch (arraypointer)
        {
            case 0:
                MainText.text = ("Please Walk Forward into the Blue zone by touching the top part of your trackpad");
                break;
            case 1:
                MainText.text = ("Please Walk backwards by touching the bottom part of your trackpad");
                bluezone.transform.position += new Vector3(0, 0, -4f);
                bluezone.SetActive(true);
                break;
            case 2:
                MainText.text = ("Please Walk to the left by touching the left part of your trackpad");
                bluezone.transform.position += new Vector3(-3, 0, 0f);
                bluezone.SetActive(true);
                break;
            case 3:
                MainText.text = ("Please Walk to the right by touching the right part of your trackpad");
                bluezone.transform.position += new Vector3(3, 0, 0f);
                bluezone.SetActive(true);
                break;
            case 4:
                MainText.text = ("Please Rotate to the left: press the middle of your trackpad on your left controller");
                break;
            case 5:
                MainText.text = ("Please Rotate to the right: press the middle of your trackpad on your right controller");
                break;
            case 6:
                MainText.text = ("Now crouch in real life and pickup the ball that is on the floor with your trigger(point) finger. ");
                break;
            case 7:
                MainText.text = ("Now throw it by releasing your trigger finger whilst flinging.  ");
                break;
            case 8:
                MainText.text = ("You now know the basics, goodluck!  ");
                break;
        }

    }


}
