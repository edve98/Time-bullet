using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {

	public GameObject optionsPanel;
	bool active = false;

	public void toggle () {
		optionsPanel.SetActive (!active);
		active = !active;
	}
}
