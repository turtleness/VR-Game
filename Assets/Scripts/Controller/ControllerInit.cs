using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInit : MonoBehaviour {
    public GameObject Holster;
    public Material skyboxhell;
    public Animator ExplodingHouse;

	// Use this for initialization
	void Start () {
        RenderSettings.skybox = null;
    }
    public void EnableSkybox()
    {
        RenderSettings.skybox = skyboxhell;
        ExplodingHouse.SetTrigger("exploding");
    }
	
	// Update is called once per frame
	void Update () {
		
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
