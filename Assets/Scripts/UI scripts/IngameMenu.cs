using UnityEngine;
using System.Collections;

public class IngameMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame

    public bool menuActive = false;
    public GameObject menu;

	void LateUpdate () {
        if (Input.GetKeyDown(KeyCode.Escape)) Debug.Log("Escape");
        if (Input.GetKeyDown(KeyCode.Escape) && menuActive == false)
        {
            Debug.Log("Works");
            menuActive = true;
            menu.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && menuActive == true)
        {
            menuActive = false;
            menu.SetActive(false);
            Time.timeScale = 1f;
        }
        if (menuActive) Time.timeScale = 0.0000001f;
    }
}
