using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesLeft : MonoBehaviour {

	public Text livesText;
	PlayerControls playerCtrl;

	void Start () {
		playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
	}

	void Update () {
		livesText.text = "Lives left: " + playerCtrl.livesLeft;
	}
}
