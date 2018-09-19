using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CameraController : MonoBehaviour {
	// Public Members
	public GameObject target;

	// Private Members
	private Vector3 offset;
    private string currSceneName;

    // Use this for initialization
    void Start () {
		offset = target.transform.position - transform.position;
        currSceneName = SceneManager.GetActiveScene().name;
    }

	// Best update to call after all physics calculations are done
	void LateUpdate(){
        if (target != null)
        {
            transform.position = target.transform.position - offset;
            transform.LookAt(target.transform);
        }
	}

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(currSceneName);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
