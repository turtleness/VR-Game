using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;


public class BlackFadeWhenTriggered : MonoBehaviour {
    public GameObject FadeCamera;


    // Use this for initialization
    void Start () {
        FadeCamera.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        FadeCamera.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        FadeCamera.SetActive(false);
    }
    // Update is called once per frame  
    void Update () {
        
	}
}
