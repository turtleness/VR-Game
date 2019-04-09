using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkSlime : MonoBehaviour {
    public float speed = 1;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 4);
		
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position -= new Vector3(0, 0.001f * speed, 0);
        gameObject.transform.localScale -= new Vector3(-0.010f * speed, 0.008f * speed, -0.010f * speed);

    }
}
