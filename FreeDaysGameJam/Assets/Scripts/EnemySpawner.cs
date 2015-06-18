using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	// Use this for initialization
	float spawnTimer;
	public GameObject[] blocs;
	public GameObject spawnerSituations;
	
	private int rand;
	
	void Awake()
	{
		spawnTimer = 0;
	}
	
	void Update () 
	{
		spawnTimer += Time.deltaTime;
		
		if (spawnTimer > 2) 
		{
			SpawnBloc();
			spawnTimer = 0;
		}
	}
	
	void SpawnBloc()
	{
		Instantiate(blocs[Random.Range(0, blocs.Length)], spawnerSituations.transform.position, Quaternion.identity);
	}
}