using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class InputTester : MonoBehaviour
{

    public SteamVR_Action_Boolean grabPinch; //Grab Pinch is the trigger, select from inspecter
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller
                                                                         // Use this for initialization

    void OnEnable()
    {
        if (grabPinch != null)
        {
            grabPinch.AddOnChangeListener(OnTriggerPressedOrReleased, inputSource);
        }
    }


    private void OnDisable()
    {
        if (grabPinch != null)
        {
            grabPinch.RemoveOnChangeListener(OnTriggerPressedOrReleased, inputSource);
        }
    }


    private void OnTriggerPressedOrReleased(SteamVR_Action_In action_In)
    {

        transform.Rotate(0, 20, 0);
        Debug.Log("Trigger was pressed or released");
    }
}