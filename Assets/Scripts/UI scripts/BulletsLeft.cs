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
        if (playerCtrl.coolDownTimer <= 0) {
            bulletText.text = "Gun is ready";
        }
		else bulletText.text = "Reloading in: " + playerCtrl.coolDownTimer.ToString("F2");
	}
}
