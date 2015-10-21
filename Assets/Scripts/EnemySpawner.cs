using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public Vector3 spawnRange;
	public float spawnRate = 1.0f;
	private float spawnTimer;
	private float spawnCount = 1.0f;
	public GameObject[] enemies;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		spawnTimer += Time.deltaTime;

		if (spawnCount < 10)
		{

			if (spawnTimer > spawnRate) 
			{
				spawnTimer = 0;
				for (int i = 0; i < spawnCount; i++)
				{
					SpawnEnemy ();
					spawnCount += 0.025f;
				}

			}

		}

	}

	void SpawnEnemy ()
	{
		Vector3 spawnPosition = new Vector3 (Random.Range(-spawnRange.x, spawnRange.x), spawnRange.y, spawnRange.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate(enemies[Random.Range(0,enemies.Length)], spawnPosition, spawnRotation);
	}

}
