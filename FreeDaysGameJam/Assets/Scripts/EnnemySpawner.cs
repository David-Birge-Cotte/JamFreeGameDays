using UnityEngine;
using System.Collections;

public class EnnemySpawner : MonoBehaviour {

	// Use this for initialization
	float spawnTimer;

	void Awake(){
		spawnTimer = 0;
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		spawnTimer += Time.deltaTime;
		if (spawnTimer > 2) {
			SpawnEnnemy();
			spawnTimer = 0;
		}


	}
	void SpawnEnnemy(){
		//Instantiate(//ennemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}

}
