using UnityEngine;
using System.Collections;

public class TurretAI : MonoBehaviour {
    public float smooth = 2.0F;
    public float tiltAngle = 30.0F;
    public Transform target;
    



    void Awake()
    {

    }

        void Start () {
        target = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), Time.deltaTime * smooth);

    }
}
