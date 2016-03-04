using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadLevel : MonoBehaviour {

	public string sceneName;

	public void load () {
		SceneManager.LoadScene (sceneName);
	}
}