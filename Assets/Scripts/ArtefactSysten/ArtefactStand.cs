using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArtefactStand : MonoBehaviour {

    public Transform socket1;
    public Transform socket2;
    public Transform socket3;
    public Transform socket4;
    public bool Socket1socketed = false;
    public bool Socket2socketed = false;
    public bool Socket3socketed = false;
    public bool Socket4socketed = false;

    public UnityEvent EnableSkyBox;

    public Transform centersocket;
    public GameObject socketitem1;
    public GameObject socketitem2;
    public GameObject socketitem3;
    public GameObject socketitem4;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {





    }

    public void OffTheSocket(GameObject Socketname)
    {
        if (Socketname.gameObject == socketitem1)
        {
            Socket1socketed = false;
        }
        else if (Socketname.gameObject == socketitem2)
        {
            Socket2socketed = false;
        }
        else if (Socketname.gameObject == socketitem3)
        {
            Socket3socketed = false;
        }
        else if (Socketname.gameObject == socketitem3)
        {
            Socket3socketed = false;
        }
    }

    public void AttachToSocket()
    {

        print("fucntion is being called");
        Collider[] hitColliders = Physics.OverlapSphere(centersocket.position, 1);
        int i = 0;

        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.tag == "Artefact")
            {
                if (hitColliders[i].gameObject == socketitem1 & Socket1socketed == false)
                {
                    hitColliders[i].gameObject.transform.position = socket1.transform.position;
                    Vector3 rotationVector = new Vector3(-90, 0, 0);
                    Quaternion rotation = Quaternion.Euler(rotationVector);
                    hitColliders[i].gameObject.transform.rotation = rotation;
                    Socket1socketed = true;
                }
                else if (hitColliders[i].gameObject == socketitem2 & Socket2socketed == false)
                {
                    hitColliders[i].gameObject.transform.position = socket2.transform.position;
                    Vector3 rotationVector = new Vector3(-90, 0, 0);
                    Quaternion rotation = Quaternion.Euler(rotationVector);
                    hitColliders[i].gameObject.transform.rotation = rotation;
                    Socket2socketed = true;
                }
                else if (hitColliders[i].gameObject == socketitem3 & Socket3socketed == false)
                {
                    hitColliders[i].gameObject.transform.position = socket3.transform.position;
                    Vector3 rotationVector = new Vector3(-90, 0, 0);
                    Quaternion rotation = Quaternion.Euler(rotationVector);
                    hitColliders[i].gameObject.transform.rotation = rotation;
                    Socket3socketed = true;
                }
                else if (hitColliders[i].gameObject == socketitem4 & Socket4socketed == false)
                {
                    hitColliders[i].gameObject.transform.position = socket4.transform.position;
                    Vector3 rotationVector = new Vector3(-90, 0, 0);
                    Quaternion rotation = Quaternion.Euler(rotationVector);
                    hitColliders[i].gameObject.transform.rotation = rotation;
                    Socket4socketed = true;
                }
            }
            i++;

        }
        if (Socket1socketed == true && Socket2socketed == true && Socket3socketed == true && Socket4socketed == true)
        {
            EnableSkyBox.Invoke();
        }
    }


}
