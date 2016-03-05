using UnityEngine;
using System.Collections;

//turent should have colider and be a trigger!
public class TurretAI : MonoBehaviour
{
    public float smooth = 20.0F;
    public Transform target;
    public float speed = 1.0f;
    float cooldown = 0;

    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float Bullet_Forward_Force = 5000f;

    void Start() {
        cooldown = speed;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        Debug.Log(cooldown);

        if (exit == true) {
            cooldown = speed;
        }

    }

    
    void OnTriggerStay(Collider obj) {
            if (obj.gameObject.CompareTag("Player"))
            {
            exit = false;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), Time.deltaTime * smooth);
                //The Bullet instantiation happens here.
                if (cooldown <= 0)
                {
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

                //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
                Destroy(Temporary_Bullet_Handler, 10.0f);
                cooldown = speed;

            }
        }
    }

    bool exit = false;

    void OnTriggerExit(Collider obj) {
        if (obj.gameObject.CompareTag("Player")) {
            exit = true;
        }
    }
}
