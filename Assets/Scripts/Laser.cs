using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			GameObject[] Enemies = GameObject.FindGameObjectsWithTag ("EnemyTagThingy");
			for(int i=0; i < Enemies.Length; i++){
				//Enemies [i].GetComponent<RobotAI> ().alerted = true;
			}
		}
	}
}