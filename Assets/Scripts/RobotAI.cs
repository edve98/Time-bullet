using UnityEngine;
using System.Collections;

public class RobotAI : MonoBehaviour {

	public Transform[] patrolPoints;
	public float moveSpeed;
	public float shootSpeed;
	private int currentPoint;
	private bool playerInSight;
	bool inRadius = false;
	GameObject player;

	public GameObject Bullet_Emitter;
	public GameObject Bullet;
	public float Bullet_Forward_Force = 50f;

	NavMeshAgent agent;

	float cooldown;

	void Start () {
		cooldown = shootSpeed;
		transform.position = patrolPoints[0].position;
		currentPoint = 0;
		agent = gameObject.GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
		
	void Update() {
		RaycastHit hitInfo;
		bool colliderInTheWay = Physics.Linecast(transform.position, player.transform.position, out hitInfo);
		
		if(hitInfo.transform.gameObject.tag == "Player" || colliderInTheWay == false){
			playerInSight = true;
		}
		else playerInSight = false;


		if (agent.remainingDistance < 0.5f && playerInSight == false) {
			currentPoint++;
			if (currentPoint >= patrolPoints.Length) currentPoint = 0;
		}

		if (playerInSight && inRadius){
			cooldown -= Time.deltaTime;
			agent.SetDestination(transform.position);
			shootingMode ();
		}
		else{
			agent.SetDestination(patrolPoints[currentPoint].position);
		}
	}

	void shootingMode(){
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (player.transform.position - transform.position), Time.deltaTime * 20f);


		//The Bullet instantiation happens here.
		if (cooldown <= 0) {
			GameObject Temporary_Bullet_Handler;
			Temporary_Bullet_Handler = Instantiate (Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

			//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
			//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
			//Temporary_Bullet_Handler.transform.Rotate (Vector3.left * 90);

			//Retrieve the Rigidbody component from the instantiated Bullet and control it.
			Rigidbody Temporary_RigidBody;
			Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody> ();

			//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
			Temporary_RigidBody.AddForce (transform.forward * Bullet_Forward_Force);

			//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
			Destroy (Temporary_Bullet_Handler, 3.0f);
			cooldown = shootSpeed;
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