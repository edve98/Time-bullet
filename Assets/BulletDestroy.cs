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
        bullitrb.velocity = transform.forward * bulletSpeed * Time.deltaTime * 10;

    }

    void OnTriggerEnter(Collider obj)
    {
        if (!obj.isTrigger && !obj.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
