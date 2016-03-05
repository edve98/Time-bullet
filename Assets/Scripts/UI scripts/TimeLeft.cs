using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour {

	public Text timeText;
	PlayerControls playerCtrl;

	void Start () {
		playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
	}

	void Update () {
		timeText.text = "Time left: " + playerCtrl.timeLeft + "s";
	}
}
