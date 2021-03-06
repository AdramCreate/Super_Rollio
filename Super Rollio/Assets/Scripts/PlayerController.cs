﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	// Public Members
	public int speed;
    public int hp;
    public int score;
    public Text healthText;
    public Text scoreText;
    public AudioClip deathSound;
    public AudioClip damageSound;

	// Private Members
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
        SetHealthText();
        SetScoreText();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

	// For physics calculations
	void FixedUpdate(){
        float moveWS = Input.GetAxis("Horizontal");
        float moveAD = Input.GetAxis("Vertical");
        Vector3 newMovement = new Vector3(moveWS, moveAD);
        rb.AddForce(newMovement * speed);
	}

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            hp -= 1;
            SetHealthText();
            if(hp == 0)
            {
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
                Destroy(gameObject);
            }
            else
            {
                AudioSource.PlayClipAtPoint(damageSound, transform.position);
            }
        }
    }

    public void SetHealthText()
    {
        healthText.text = "HP: ";
        for(int i = 0; i < hp; i++)
        {
            healthText.text += "@ ";
        }
    }

    public void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString("D4");
    }
}
