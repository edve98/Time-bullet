using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Play : MonoBehaviour {
	
	public void play () {
		SceneManager.LoadScene ("test");
	}
}
