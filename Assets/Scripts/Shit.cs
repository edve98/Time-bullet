using UnityEngine;
using System.Collections;

public class Shit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f, 10f, 0f);
	}
}
