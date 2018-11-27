using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltFollow : MonoBehaviour {

    public Transform Player;

	// Use this for initialization
	void Start () {
        transform.position = Player.position;
	}
	    
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3 (Player.position.x,Player.position.y - 0.30f, Player.position.z);

    }
}
