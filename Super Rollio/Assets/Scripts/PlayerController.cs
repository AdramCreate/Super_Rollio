﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	// Public Members
	public int speed;
    public int hp;
    public int score;
    public Text healthText;
    public Text scoreText;

	// Private Members
	private Rigidbody rb;
    private string currSceneName;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
        SetHealthText();
        SetScoreText();
        currSceneName = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(currSceneName);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
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
                Destroy(gameObject);
            }
        }
    }

    public void SetHealthText()
    {
        healthText.text = "HP: " + hp;
    }

    public void SetScoreText()
    {
        if(score < 100)
            scoreText.text = "Score: " + score.ToString("D2");
    }
}
