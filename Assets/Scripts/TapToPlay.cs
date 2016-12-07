using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TapToPlay : MonoBehaviour {

	void Update () {
	
		if (Input.touchCount == 1) {

			SceneManager.LoadScene ("balance", LoadSceneMode.Additive);
		}

	}

	void OnMouseDown(){
	
		SceneManager.LoadScene ("balance", LoadSceneMode.Additive);
	}
}
