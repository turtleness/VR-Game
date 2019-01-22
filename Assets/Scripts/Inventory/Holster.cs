using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holster : MonoBehaviour {
    public GameObject LeftHolster;
    public GameObject RightHolster;
    public float DistanceToHandCheck = 0.1f;
    public GameObject Camera;
    public float YOffsetOfBelt = 10f;

    // Use this for initialization
    void Start () {

		
	}


    public void attachObjectToHand(GameObject item, GameObject Holster)
    {
        item.transform.parent = Holster.transform;
        item.transform.position = Holster.transform.position;
        item.transform.rotation = Holster.transform.rotation;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.GetComponent<Rigidbody>().useGravity = false;


    }

    public void ItemDropped(GameObject item)
    {
        if (Vector3.Distance(item.transform.position, LeftHolster.transform.position) <= DistanceToHandCheck)
        {
            attachObjectToHand(item, LeftHolster);

        }
        else if (Vector3.Distance(item.transform.position, RightHolster.transform.position) <= DistanceToHandCheck)
        {
            attachObjectToHand(item, RightHolster);
        }
    }


	// Update is called once per frame
	void Update () {
       

        Quaternion forward = Camera.transform.rotation;
        forward.eulerAngles = new Vector3(0, forward.eulerAngles.y, forward.eulerAngles.z); 
        transform.rotation = forward;
        transform.position = Camera.transform.position - new Vector3(0,YOffsetOfBelt,0);
	}
}
