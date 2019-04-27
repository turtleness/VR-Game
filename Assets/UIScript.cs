using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Valve.VR;

public class UIScript : MonoBehaviour {

    //[SteamVR_DefaultActionSet("InteractUI")]

    public SteamVR_Action_Boolean InteractUI;
    public SteamVR_Input_Sources RightHandSource = SteamVR_Input_Sources.RightHand;
    public SteamVR_Input_Sources LeftHandSource = SteamVR_Input_Sources.LeftHand;
    public SteamVR_ActionSet actionSetdefault;

    bool paused = false;
    GameObject uiScreen;

    void Update()
    {
        if (SteamVR_Input._default.inActions.TurnLeft.GetStateDown(RightHandSource))
        {
            paused = togglePause();
        }

        if (SteamVR_Input._default.inActions.TurnLeft.GetStateDown(LeftHandSource))
        {
            paused = togglePause();
        }
    }

    void OnGUI()
    {
        if (paused == true)
        {
            uiScreen.SetActive(true);
        }
        
        if(paused == false)
        {
            uiScreen.SetActive(false);
        }
            
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
        //Just to make sure its working
    }

    bool isMute;

    public void Mute()
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
