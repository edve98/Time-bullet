using UnityEngine;
using System.Collections;

//turent should have colider and be a trigger!
public class TurretAI : MonoBehaviour
{
    public float smooth = 20.0F;
	GameObject player;
    public float speed = 1.0f;
    float cooldown = 0;

    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float Bullet_Forward_Force = 5000f;

	bool playerInSight;

    void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
        cooldown = speed;
    }

    // Update is called once per frame
    void Update () {
		RaycastHit hitInfo;
		bool colliderInTheWay = Physics.Linecast(transform.position, player.transform.position, out hitInfo);

		if(hitInfo.transform.gameObject.tag == "Player" || colliderInTheWay == false){
			playerInSight = true;
		}
		else playerInSight = false;


        cooldown -= Time.deltaTime;
        
		if (playerInSight){

			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), Time.deltaTime * smooth);

			//The Bullet instantiation happens here.
			if (cooldown <= 0){
				GameObject Temporary_Bullet_Handler;
				Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

				//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
				//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
				Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

				//Retrieve the Rigidbody component from the instantiated Bullet and control it.
				Rigidbody Temporary_RigidBody;
				Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

				//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
				Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

				cooldown = speed;

			}
		}

    }

}
