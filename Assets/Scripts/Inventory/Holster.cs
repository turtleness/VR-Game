using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holster : MonoBehaviour {
    public GameObject LeftHolster;
    public GameObject RightHolster;
    public float DistanceToHandCheck = 0.5f;

    // Use this for initialization
    void Start () {

		
	}


    public void attachObjectToHand(GameObject item, GameObject Holster)
    {
        item.transform.parent = Holster.transform;
        item.transform.position = Holster.transform.position;
        item.transform.rotation = Holster.transform.rotation;


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
		
	}
}
