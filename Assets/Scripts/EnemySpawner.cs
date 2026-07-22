using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public float minTimeBetweenSpawns = 0f; // Smallest time range that an enemy can spawn
	public float maxTimeBetweenSpawns = 10f; // Largest time range that an emey can spawn
	public float spawnDelay = 3f;       // The amount of time before spawning starts.
	public float dropRangeLeft = 0;         // Smallest value of x in world coordinates the delivery can happen at.
	public float dropRangeRight = 220;        // Largest value of x in world coordinates the delivery can happen at.
	public GameObject[] enemies;        // Array of enemy prefabs.


	void Start()
	{
		float spawnTime = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}


	void Spawn()
	{
		// Instantiate a random enemy.
		float dropPosX = Random.Range(dropRangeLeft, dropRangeRight);

		// Create a position with the random x coordinate.
		Vector2 dropPos = new Vector2(dropPosX, 7);
		Instantiate(enemies[0], dropPos, Quaternion.identity);
	}
}
