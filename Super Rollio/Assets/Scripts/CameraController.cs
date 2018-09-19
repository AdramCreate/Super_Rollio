using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	// Public Members
	public GameObject target;

	// Private Members
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = target.transform.position - transform.position;
	}

	// Best update to call after all physics calculations are done
	void LateUpdate(){
		transform.position = target.transform.position - offset;
		transform.LookAt(target.transform);
	}
}
