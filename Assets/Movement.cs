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

    public GameObject Head;
    private float sensitivityX = 1.5F;

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
            transform.position += Head.transform.forward * Time.deltaTime * (touchpadValue.y * 5f);
        }
        // handle rotation via touchpad
        if (touchpadValue.x > 0.3f)
        {
            transform.Rotate(0, 45, 0);
        }
        else if (touchpadValue.x < -0.3f)
        {
            transform.Rotate(0, -45, 0);
        }

        if(SteamVR_Input._default.inActions.TurnRight.GetLastStateDown(SteamVR_Input_Sources.Any))
        {
            print("turn right");
        }

    }
}
  
