using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    float bulletSpeed = 75;

	void Update () {
        Rigidbody bullitrb = gameObject.GetComponent<Rigidbody>();
        bullitrb.velocity = transform.up * bulletSpeed * Time.deltaTime * 10;

    }

    void OnCollisionEnter (Collision obj) {
		if (obj.gameObject.tag == "Enemy") {
			Destroy(obj.gameObject);
        }
		if (obj.gameObject.tag == "Player"){
			obj.gameObject.GetComponent<PlayerControls>().livesLeft--;
		}
		Destroy(gameObject);
    }
}
