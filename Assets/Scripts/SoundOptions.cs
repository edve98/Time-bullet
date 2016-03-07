using UnityEngine;
using System.Collections;

using UnityEngine.UI;
public class SoundOptions : MonoBehaviour {

	public static float musicVolume = 1f;
	public static float sfxVolume = 1f;

	public static bool muteMusic = false;
	public static bool muteSfx = false;


	public Slider musicSlider;
	public Slider sfxSlider;

	public Toggle musicToggle;
	public Toggle sfxToggle;

    void Start() {
        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;

        musicToggle.isOn = muteMusic;
        sfxToggle.isOn = muteSfx;
    }

	void Update () {
		musicVolume = musicSlider.value;
		sfxVolume = sfxSlider.value;

		muteMusic = musicToggle.isOn;
		muteSfx = sfxToggle.isOn;

		Debug.Log (musicVolume + " " + muteMusic);
	}
}
