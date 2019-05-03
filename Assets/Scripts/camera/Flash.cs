using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {
    public float minTime = 2f;
    public float flashtime;
    int layerMask =~ 10;
    public Light myLight;
    private int iterations = 0;
    public GameObject Playerhead;
    public List<GameObject> Enemies = new List<GameObject>();
    public EnemySpawner enemyspawner;
    private bool Picturetaken = false;
    public float CameraBattery = 4;


    // Use this for initialization
    void Start () {
        // Enemies.Add
        Enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }
    private void FixedUpdate()
    {
    }

    public void PickupBattery(GameObject TheBattery)
    {
        if (CameraBattery == 4)
        {

        }
        else
        {
            CameraBattery += 1;
            Destroy(TheBattery);
        }

    }


    private void Resetpicturetaken()
    {
        Picturetaken = false;
    }

    public void Firstbitoflight()
    {

        if (Picturetaken == false)
        {
            if (CameraBattery != 0)
            {


                Invoke("Resetpicturetaken", 3);
                Picturetaken = true;
                CameraBattery -= 25;

                foreach (GameObject item in Enemies)
                {

                    Vector3 screenPoint = gameObject.GetComponent<Camera>().WorldToViewportPoint(item.transform.position);
                    bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
                    RaycastHit Hit;
                    if (onScreen == true)
                    {
                        if (Physics.Raycast(transform.position, item.transform.position - transform.position, out Hit, 100, layerMask))
                        {
                            if (Hit.collider.tag == "Enemy")
                            {
                                Hit.collider.gameObject.GetComponent<SentryAI>().ResetAI();
                                enemyspawner.RelocateEnemy(Hit.collider.gameObject);
                            }
                        }
                    }
                }

                iterations = 0;
                myLight.enabled = !myLight.enabled;
                Invoke("Secondbitoflight", minTime);

            }

        }
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

        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    Firstbitoflight();
        //}
    }
}
