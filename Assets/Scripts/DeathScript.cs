using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour {

    public GameObject death;
    PlayerControls player;

	// Use this for initialization
	void Start () {
        player = GetComponent<PlayerControls>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (player.timeLeft == 0)
        {
            death.SetActive(true);
            Time.timeScale = 0.000001f;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        if (player.livesLeft == 0)
        {
            death.SetActive(true);
            Time.timeScale = 0.000001f;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
	}
}
