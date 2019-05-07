using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class ActivateUI : MonoBehaviour {

    public GameObject UIMenu;
    public Transform UIMenuPos;

    public GameObject Pointer;

    public SteamVR_Action_Boolean Pause;
    public SteamVR_Input_Sources PauseSource = SteamVR_Input_Sources.Any;
    public SteamVR_ActionSet actionSetdefault;

    public static bool GameIsPaused = false;

    // Use this for initialization
    void Start () {
        UIMenu.SetActive(false);
        Pointer.SetActive(false);
	}



	// Update is called once per frame
	void Update () {
		
        if(SteamVR_Input._default.inActions.Pause.GetStateDown(SteamVR_Input_Sources.Any))
        {
           if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        UIMenuPos.LookAt(Camera.main.transform);

	}

    void ResumeGame()
    {
        UIMenu.SetActive(false);
        Pointer.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioListener.pause = false;
    }

    void PauseGame()
    {
        UIMenu.SetActive(true);
        Pointer.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioListener.pause = true;
    }

}
