using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z);
	}
}
