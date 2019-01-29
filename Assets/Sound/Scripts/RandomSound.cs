
using UnityEngine;
using System.Collections;

public class RandomSound : MonoBehaviour
{

    public AudioClip[] FootStepSounds;
    public float waitTime = 0.75f;
    public float waitTimeR = 0.25f;

    // Use this for initialization
    void Start()
    {
        Invoke("FootStep", waitTime);
    }

    // Update is called once per frame
    void Update()
    {


    }

    void FootStep()
    {
            GetComponent<AudioSource>().clip = FootStepSounds[Random.Range(0, FootStepSounds.Length)];
            GetComponent<AudioSource>().Play();
            Invoke("FootStep", waitTime);
        

    }

}
