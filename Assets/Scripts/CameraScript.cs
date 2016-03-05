using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject laser;
	public BoxCollider laserTrigger;
	public int laserLenght = 10;
	public GameObject fakinAtsavra;
	public float spinTime;
	public int speed;

	float cooldown;

	void Start () {
		laser.transform.position.Set (0, 0, laserLenght / 2);
		laserTrigger.size.Set(0.5f, 0.5f, laserLenght);
		fakinAtsavra.transform.position.Set (0, 0, -laserLenght);

		cooldown = spinTime;
	}

	public bool decreasing = true;
	void Update () {
		if (cooldown <= 0){
			decreasing = !decreasing;
			cooldown = spinTime;
		}
		cooldown -= Time.deltaTime;

		if(decreasing) gameObject.transform.Rotate (new Vector3(0, speed * Time.deltaTime * -1, 0));
		else gameObject.transform.Rotate (new Vector3(0, speed * Time.deltaTime, 0));
	}
}
