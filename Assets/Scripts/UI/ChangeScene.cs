using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine.EventSystems;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    public void MenuScreen()
    {
        SteamVR_LoadLevel.Begin("Menu");
    }

    public void PGame()
    {
        SteamVR_LoadLevel.Begin("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
