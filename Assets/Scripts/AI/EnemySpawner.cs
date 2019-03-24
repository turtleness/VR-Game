
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] Enemys;

    public Transform[] Spawnpoints;

	// Use this for initialization
	void Start () {
		
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
        print(temp);
        TheEnemiesThatWereTakenAPictureOf.SetActive(false);
        TheEnemiesThatWereTakenAPictureOf.transform.position = Spawnpoints[temp].position;
        TheEnemiesThatWereTakenAPictureOf.GetComponent<Perspective>().ResetAI();
        TheEnemiesThatWereTakenAPictureOf.SetActive(true);

    }




	// Update is called once per frame
	void Update () {
		
	}
}
