using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnObject : MonoBehaviour {
    private Vector3 originalPos;
    private Quaternion originalRot;
    public float T = 1;
    private Light l;
    // Use this for initialization
    void Start () {
        if (gameObject.GetComponentInChildren<Light>())
        {
            l = gameObject.GetComponentInChildren<Light>();
            l.enabled = false;
        }
        originalPos = transform.localPosition;
        originalRot = transform.localRotation;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void AttacheasiinDelay()
    {
        Invoke("AttachEasein", 1);
    }

    public void enablecomponent()
    {
        if (l.enabled == true)
        {
            l.enabled = false;
        }
        else
        {
            l.enabled = true;
        }
            
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
