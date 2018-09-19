using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {
    // Public Variables
    public GameObject target;
    public GameObject bulletPrefab;
    public Camera myCamera;
    public int bulletSpeed;

	// Use this for initialization
	void Start () {
        transform.position = target.transform.position;
    }

    void LateUpdate()
    {
        if (target.gameObject != null)
        {
            transform.position = target.transform.position;
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }
        else
            Destroy(gameObject);
    }

    void Fire()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -myCamera.transform.position.z);
        Vector3 mouseToWorldPos = myCamera.ScreenToWorldPoint(mousePos);
        float angle = Mathf.Atan2(mouseToWorldPos.y - transform.position.y, mouseToWorldPos.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * bulletSpeed;
    }
}
