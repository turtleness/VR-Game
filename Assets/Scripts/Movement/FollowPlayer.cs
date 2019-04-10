using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public GameObject VRCAMERA;
    public bool DontRotate = false;

	void LateUpdate () {



           // float posy = transform.position.y;

            transform.position = new Vector3(VRCAMERA.transform.position.x, transform.position.y, VRCAMERA.transform.position.z);
        //    transform.eulerAngles = new Vector3(0, VRCAMERA.transform.rotation.y, 0);
        if (!DontRotate)
        {
            Quaternion rot = VRCAMERA.transform.rotation;
            rot.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.x, -10, 10), rot.eulerAngles.y, Mathf.Clamp(transform.eulerAngles.z, -10, 10));
            transform.rotation = rot;
        }


            //  transform.eulerAngles = new Vector3(VRCAMERA.transform.rotation.x, VRCAMERA.transform.rotation.y, transform.eulerAngles.z);
        

    }
}
