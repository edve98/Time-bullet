using UnityEngine;
using System.Collections;

//turent should have colider and be a trigger!
public class TurretAI : MonoBehaviour
{
    public float smooth = 2.0F;
    public Transform target;
    public Transform bullet;
    public Transform bulletSpawn;
    public float bulletSpeed = 1000.0F; 

    // Update is called once per frame
    void Update()
    {
        

    }

    
    void OnTriggerStay(Collider obj) {
        if (obj.gameObject.CompareTag("Player")) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), Time.deltaTime * smooth);
            Rigidbody bulletInstance;
            bulletInstance = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation) as Rigidbody;
            bulletInstance.AddForce(bulletSpawn.forward * bulletSpeed);


        }
    }
}
