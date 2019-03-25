using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnObject : MonoBehaviour {
    private Vector3 originalPos;
    private Quaternion originalRot;
    public float T = 1;

    // Use this for initialization
    void Start () {
        originalPos = transform.localPosition;
        originalRot = transform.localRotation;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void AttachEasein ()
    {
        if (transform.localPosition != originalPos || transform.localRotation != originalRot)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPos, Time.deltaTime * T);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, originalRot, Time.deltaTime * T);
            Invoke("AttachEasein", 0.02f);
        }

    }




}
