using UnityEngine;
using System.Collections;

public class MusicBeh : MonoBehaviour {

    AudioSource source;
    PlayerControls player;

	// Use this for initialization
	void Start () {
        source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        source.loop = true;
        source.Play();
        player = gameObject.GetComponent<PlayerControls>();
	}

    public float timeToDecrease = 0.05f;
    bool musicOn = false;

    // Update is called once per frame
    void LateUpdate()
    {
        musicOn = player.TimeMoving;
        Debug.Log("Music is:" + musicOn + "And time is:" + player.TimeMoving);
        if (source.pitch > 0 && Time.timeScale < 0.05f)
        {
            source.pitch -= timeToDecrease;
            if (source.pitch < 0f)
            {
                source.pitch = 0;
            }
        }

        else if (source.pitch < 1 && Time.timeScale > 0.95f)
        {
            source.pitch += timeToDecrease;
            if (source.pitch > 1f)
            {
                source.pitch = 1;
            }
        }
        musicOn = player.TimeMoving;
    }
    void Update()
    {
        musicOn = player.TimeMoving;
        if(SoundOptions.muteMusic) source.volume = 0f;
        source.volume = SoundOptions.musicVolume;
    }
}
