using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holster : MonoBehaviour {
    public GameObject LeftHolster;
    public GameObject RightHolster;
    public float DistanceToHandCheck = 0.1f;
    public GameObject Camera;
    public float YOffsetOfBelt = 10f;
    private Vector3 leftoldscale;
    private Vector3 rightoldscale;
    private bool equiped;
    private GameObject leftsocketeditem;
    private GameObject rightsocketeditem;

    // Use this for initialization
    void Start () {

		
	}


    public void AttackObjectToHolster(GameObject item, GameObject Holster)
    {
        if (Holster = LeftHolster)
        {
            leftsocketeditem = item;
        }
        else if (Holster = RightHolster)
        {
            rightsocketeditem = item;
        }

        item.transform.parent = Holster.transform;
        item.transform.position = Holster.transform.position;
        item.transform.rotation = Holster.transform.rotation;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.GetComponent<Rigidbody>().useGravity = false;
    }

    public void RemoveObjectFromHolster(GameObject item)
    {
        item.transform.parent = null;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.GetComponent<Rigidbody>().useGravity = true;
        print("i am called");
    }



    public void ItemPickedup(GameObject item)
    {

        if (item == leftsocketeditem)
        {
            RemoveObjectFromHolster(item);
            leftsocketeditem = null;
            item.transform.localScale = leftoldscale;
        }
        else if (item == rightsocketeditem)
        {
            RemoveObjectFromHolster(item);
            rightsocketeditem = null;
            item.transform.localScale = rightoldscale;
        }
    }

        public void ItemDropped(GameObject item)
    {

        if (Vector3.Distance(item.transform.position, LeftHolster.transform.position) <= DistanceToHandCheck)
        {
            leftoldscale = item.transform.localScale;
            AttackObjectToHolster(item, LeftHolster);
         

        }
        else if (Vector3.Distance(item.transform.position, RightHolster.transform.position) <= DistanceToHandCheck)
        {
            rightoldscale = item.transform.localScale;
            AttackObjectToHolster(item, RightHolster);
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
