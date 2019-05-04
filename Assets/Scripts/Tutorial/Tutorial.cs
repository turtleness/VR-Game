using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;


public class Tutorial : MonoBehaviour {
    public Text MainText;
    public int arraypointer = -1;
    private Transform playertrans;
    public GameObject bluezone;
    public GameObject tutorial;
   // public GameObject flashlight;
    public GameObject instructions;
    public GameObject altar;
    public GameObject options;
    public GameObject Camera;
    public GameObject lighter;
    public GameObject Blocker;

    private bool Tutorialfinished = false;
    private bool Lighterused = false;
    private bool CameraUsed = false;



    // movement end




    private bool Taskcomplete = false;



    // Use this for initialization
    void Start () {
        Blocker.SetActive(true);
        Invoke("EndTutorial",6);
        options.SetActive(false);
        lighter.SetActive(false);
        Camera.SetActive(false);
        // Invoke("EndTutorial", 5f);
        tutorial.SetActive(true);
        MainText.text = ("Welcome to the VR Horror Game");
        Invoke("NextText",5);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("BlueZone"))
        {
            Taskcomplete = true;
            other.gameObject.SetActive(false);
            TaskComplete();

        }
    }


    public void Uselighter()
    {
        if (Lighterused == false)
        {
            Lighterused = true;
            TaskComplete();

        }
    }
    public void UseCamera()
    {
        if (CameraUsed == false)
        {
            CameraUsed = true;
            TaskComplete();

        }
    }

    public void TaskComplete()
    {
        if (Tutorialfinished == false)
        {
            MainText.text = ("GoodJob");
            Invoke("NextText", 2f);
        }
        else
        {

        }


    }
    // Update is called once per frame

    private void EndTutorial()
    {
        tutorial.SetActive(false);
        altar.SetActive(true);
        options.SetActive(true);
        Tutorialfinished = true;
        lighter.SetActive(true);
        Camera.SetActive(true);
        Blocker.SetActive(false);
    }

    public void NextText()
    {
        Taskcomplete = false;
        arraypointer++;
        switch (arraypointer)
        {
            case 0:
                MainText.text = ("Please Walk Forward into the Blue zone by touching the top part of your trackpad and aiming with your right controller");
                break;
            case 1:
                MainText.text = ("Use the trackpad on the left controller to rotate, move to the next blue zone");
                bluezone.transform.position += new Vector3(0, 0, -4f);
                bluezone.SetActive(true);
                break;
            case 2:
                MainText.text = ("Please Walk to the next blue zone");
                bluezone.transform.position += new Vector3(-3, 0, 0f);
                bluezone.SetActive(true);
                break;
            case 3:
                MainText.text = ("Please Walk to the next blue zone");
                bluezone.transform.position += new Vector3(3, 0, 0f);
                bluezone.SetActive(true);
                break;
            case 4:
                lighter.SetActive(true);
                MainText.text = ("Now reach down to your left hip and grab the lighter with your index finger");
                break;
            case 5:
                Camera.SetActive(true);
                MainText.text = ("grab the camera on your right hip and click on your right trackpad to take a picture");
                break;
            case 6:
                MainText.text = ("You now know the basics, goodluck!, use the camera to scare off monsters");
                Invoke("EndTutorial", 6f);
                break;
        }

    }


}
