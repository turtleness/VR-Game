
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour {

    private GameObject[] Enemys;

    public Transform[] Spawnpoints;
    public GameObject[] Upstairpoints;
    public GameObject[] Downstairpoints;
    public GameObject slime;
    private int halfmark;
    // Use this for initialization
    void Start () {
     //   Upstairpoints = GameObject.FindGameObjectsWithTag("Upstairspoints");
     //  Downstairpoints = GameObject.FindGameObjectsWithTag("Downstairspoints");
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        halfmark = Mathf.FloorToInt((Enemys.Length / 2));
        print(halfmark);
      //  SpawnEnemies();

	}



    private void SpawnEnemies()
    {
        for (int i = 0; i < halfmark; i++)
        {
            Enemys[i].SetActive(false);
            int temp = Random.Range(0, Downstairpoints.Length -1);
            Enemys[i].GetComponent<NavMeshAgent>().areaMask = 5;
            Enemys[i].transform.position = Downstairpoints[temp].transform.position;
            Enemys[i].SetActive(true);



        }
        for (int x = halfmark; x < Enemys.Length; x++)
        {
            Enemys[x].SetActive(false);
            int temp = Random.Range(0, Upstairpoints.Length -1);
            Enemys[x].GetComponent<NavMeshAgent>().areaMask = 4;
            Enemys[x].transform.position = Upstairpoints[temp].transform.position;
            Enemys[x].SetActive(true);

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
