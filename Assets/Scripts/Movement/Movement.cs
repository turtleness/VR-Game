using System.Collections;
using System.Collections.Generic;
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

    public GameObject Head;
    private float sensitivityX = 1.5F;



    private void Start()
    {
    }
    private void Update()
    {
        Vector2 touchpadValue = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);

        if (touchpadValue != Vector2.zero)
        {
            // print(touchpadValue);
        }

        // Handle movement via touchpad
        if (touchpadValue.y > 0.2f || touchpadValue.y < -0.2f)
        {
            // Move Forward
            Vector3 forward = Head.transform.forward;
            forward.y = 0;  // zero out y, leaving only x & z
            transform.position += forward * Time.deltaTime * (touchpadValue.y * PlayerSpeed);
        }



        if (SteamVR_Input._default.inActions.TurnRight.GetStateDown(SteamVR_Input_Sources.Any))
        {

            transform.Rotate(0, 40, 0);
        }


        //UN COMMENT THIS ONCE U ADD THE BINDING FOR IT IN THE WEBSITE.
        //if (SteamVR_Input._default.inActions.TurnLeft.GetStateDown(SteamVR_Input_Sources.Any))
        //{

        //    transform.Rotate(0, -90, 0);
        //}


    }
}
  
