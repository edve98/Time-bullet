using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    public float bulletSpeed = 35;

	void Update () {
        Rigidbody bullitrb = gameObject.GetComponent<Rigidbody>();
        bullitrb.velocity = transform.up * bulletSpeed * Time.deltaTime * 10;

    }

    void OnCollisionEnter (Collision obj) {
		Debug.Log ("Hello from the other side to: " + obj.gameObject.name);
		if (obj.gameObject.tag == "Enemy") {
            if(!obj.gameObject.name.StartsWith("S"))
                obj.gameObject.GetComponent<RobotAI>().livesLeft--;
        }
		if (obj.gameObject.tag == "Player"){
			obj.gameObject.GetComponent<PlayerControls>().livesLeft--;
		}

		Destroy(gameObject);
    }
}
