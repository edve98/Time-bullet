using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletsLeft : MonoBehaviour {

	public Text bulletText;
	PlayerControls playerCtrl;

	void Start () {
		playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
	}

	void Update () {
		bulletText.text = "Bullets left: " + playerCtrl.bulletsLeft;
	}
}
