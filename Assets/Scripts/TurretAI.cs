﻿using UnityEngine;
using System.Collections;

//turent should have colider and be a trigger!
public class TurretAI : MonoBehaviour
{
    public float turningSpeed = 20.0F;
	GameObject player;
    public float shootSpeed = 1.0f;
    float cooldown = 0;

    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float Bullet_Forward_Force = 5000f;

	bool playerInSight;
	bool inRadius = false;

    void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
        cooldown = shootSpeed;
    }

    // Update is called once per frame
    void Update () {
		if (transform.rotation.x  > 0) {
			gameObject.transform.rotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.y);
		}

		RaycastHit hitInfo;
		bool colliderInTheWay = Physics.Linecast(transform.position, player.transform.position, out hitInfo);

		if(hitInfo.transform.gameObject.tag == "Player" || colliderInTheWay == false){
			playerInSight = true;
		}
		else playerInSight = false;


        cooldown -= Time.deltaTime;
        
		if (playerInSight && inRadius){
			var targetRotation = Quaternion.LookRotation (player.transform.position - transform.position);
			transform.rotation = targetRotation;
			gameObject.transform.rotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.y);
			Debug.Log (targetRotation);

			//The Bullet instantiation happens here.
			if (cooldown <= 0){
				GameObject Temporary_Bullet_Handler;
				Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

				//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
				//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
				//Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

				//Retrieve the Rigidbody component from the instantiated Bullet and control it.
				Rigidbody Temporary_RigidBody;
				Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

				//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
				Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

				cooldown = shootSpeed;

			}
		}

    }

	void OnTriggerExit(Collider col){
		if(col.tag == "Player"){
			inRadius = false;
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			inRadius = true;
		}
	}
}
