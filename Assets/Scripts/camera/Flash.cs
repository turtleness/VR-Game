using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {
    public float minTime = 2f;
    public float flashtime;
    public Light myLight;
    private int iterations = 0;

    // Use this for initialization
    void Start () {
        Firstbitoflight();
        
}

    public void Firstbitoflight()
    {
        iterations = 0;
        myLight.enabled = !myLight.enabled;
        Invoke("Secondbitoflight", minTime);
        
    }

    public void Secondbitoflight()
    {

        iterations++;
        myLight.enabled = !myLight.enabled;
        Invoke("Secondbitoflight", flashtime);
        if (iterations >= 3)
        {
            CancelInvoke("Secondbitoflight");
        }
    }

	
	// Update is called once per frame
	void Update () {
 

    }
}
