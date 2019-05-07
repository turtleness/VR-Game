using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInit : MonoBehaviour {
    public GameObject Holster;
    public Material skyboxhell;
    public Animator ExplodingHouse;
    public GameObject Video;
    public Animation Boss;
    public GameObject Instructions;
	// Use this for initialization
	void Start () {
        Video.SetActive(false);

    }
    public void EnableSkybox()
    {
        Video.SetActive(true);
        RenderSettings.skybox = skyboxhell;
        ExplodingHouse.SetTrigger("exploding");
        Boss.Play();
        Instructions.SetActive(false);
        RenderSettings.fog = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            EnableSkybox();
        }
		
	}

    public void SomethingDetached(GameObject item)
    {
        Holster.GetComponent<Holster>().ItemDropped(item);

    }
    public void SomethingAttached(GameObject item)
    {
        Holster.GetComponent<Holster>().ItemPickedup(item);

    }
}
