using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {
    // Public Members
    public int hp;
    public GameObject playerTarget;
    public int moveSpeed;
    public AudioClip deathSound;

    // Private Members

	// Use this for initialization
	void Start () {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        Physics.IgnoreLayerCollision(9, 9);
	}
	
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if(playerTarget != null)
        {
            transform.LookAt(playerTarget.transform.position);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
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
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
                Destroy(gameObject);
            }
        }
    }
}
