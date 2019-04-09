using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeForce : MonoBehaviour {

    public GameObject EnemyInstance;
    public float speed = 30;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position != EnemyInstance.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, EnemyInstance.transform.position, speed);
        }
        else
        {
            Destroy(gameObject);
        }

           

    }
}
