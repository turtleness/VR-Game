using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInit : MonoBehaviour {
    public GameObject Holster;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SomethingDetached(GameObject item)
    {
        Holster.GetComponent<Holster>().ItemDropped(item);

    }
}
