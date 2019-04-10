
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    private GameObject[] Enemys;

    public Transform[] Spawnpoints;
    public GameObject slime;

	// Use this for initialization
	void Start () {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        SpawnEnemies();
	}



    private void SpawnEnemies()
    {
        foreach (var Enemy in Enemys)
        {
            int temp = Random.Range(0, 4);

            Enemy.transform.position = Spawnpoints[temp].position;

        }
    }

    public void RelocateEnemy(GameObject TheEnemiesThatWereTakenAPictureOf)
    {

            int temp = Random.Range(0, 4);
        
        Instantiate(slime, TheEnemiesThatWereTakenAPictureOf.GetComponentInChildren<FeetObject>().gameObject.transform.position, new Quaternion());
        TheEnemiesThatWereTakenAPictureOf.SetActive(false);
        TheEnemiesThatWereTakenAPictureOf.transform.position = Spawnpoints[temp].position;
        TheEnemiesThatWereTakenAPictureOf.GetComponent<Perspective>().ResetAI();
        TheEnemiesThatWereTakenAPictureOf.SetActive(true);

    }




	// Update is called once per frame
	void Update () {
		
	}
}
