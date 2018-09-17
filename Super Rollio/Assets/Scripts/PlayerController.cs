using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	// Public Members
	public int speed;
	
	// Private Members
	private RigidBody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
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
}
