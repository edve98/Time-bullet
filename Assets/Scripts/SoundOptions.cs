using UnityEngine;
using System.Collections;

using UnityEngine.UI;
public class SoundOptions : MonoBehaviour {

	public static float musicVolume;
	public static float sfxVolume;

	public static bool muteMusic;
	public static bool muteSfx;


	public Slider musicSlider;
	public Slider sfxSlider;

	public Toggle musicToggle;
	public Toggle sfxToggle;


	void Update () {
		musicVolume = musicSlider.value;
		sfxVolume = sfxSlider.value;

		muteMusic = musicToggle.isOn;
		muteSfx = sfxToggle.isOn;
	}
}
