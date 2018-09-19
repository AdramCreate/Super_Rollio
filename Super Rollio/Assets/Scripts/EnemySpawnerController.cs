using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour {
    // Public Variables
    public GameObject enemyPrefab;
    public GameObject targetPlayer;
    public float offset;
    public float spawnTime;

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
        Vector3 newEnemyPos = new Vector3(Random.Range(-70f + offset, 70f-offset), Random.Range(5f+offset, 81.5f-offset), transform.position.z);

        // To handle enemy spawning too close to player
        Vector3 currPlayerPos = targetPlayer.transform.position;
        if (newEnemyPos.x >= currPlayerPos.x + offset)
        {
            newEnemyPos.x += offset;
        }
        else
        {
            newEnemyPos.x -= offset;
        }
        if(newEnemyPos.y >= currPlayerPos.y + offset)
        {
            newEnemyPos.y += offset;
        }
        else
        {
            newEnemyPos.y -= offset;
        }

        Instantiate(enemyPrefab, newEnemyPos, transform.rotation);
    }
}
