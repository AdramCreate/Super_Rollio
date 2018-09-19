using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour {
    // Public Variables
    public GameObject enemyPrefab;
    public GameObject targetPlayer;

    // Private Variables
    private float spawnTime = 0.5f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);
	}
	
    void SpawnEnemy()
    {
        if(targetPlayer == null)
        {
            return;
        }
        Vector3 newEnemyPos = new Vector3(Random.Range(-70f, 70f), Random.Range(8.0f, 87.5f), transform.position.z);
        Instantiate(enemyPrefab, newEnemyPos, transform.rotation);
    }
}
