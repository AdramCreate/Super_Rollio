using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {
    // Public Members
    public int hp;
    public GameObject playerTarget;

    // Private Members

	// Use this for initialization
	void Start () {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
	}
	
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hp -= 1;
            if (hp == 0)
            { 
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            hp -= 1;
            if (playerTarget != null)
            {
                PlayerController playerScript = playerTarget.GetComponent<PlayerController>();
                playerScript.score += 1;
                playerScript.SetScoreText();
            }
            if (hp == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
