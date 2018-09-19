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
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Stage"))
        {
            hp -= 1;
            if (hp == 0)
            {
                if (collision.gameObject.CompareTag("bullet"))
                {
                    PlayerController playerScript = playerTarget.GetComponent<PlayerController>();
                    playerScript.score += 1;
                    playerScript.SetScoreText();
                }
                Destroy(gameObject);
            }
        }
    }
}
