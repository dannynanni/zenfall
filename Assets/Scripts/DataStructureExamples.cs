using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DataStructureExamples : MonoBehaviour {

	public List<GameObject> platforms = new List<GameObject>();
	public GameObject prefab;
	float offset;
	public float range;
	public GameObject player;
	public GameObject winCube;
	public AudioSource zen;


	// Use this for initialization
	void Start () {
		
		zen.Play();


//		for (int i = 0; i < 500; i++) {
//			Instantiate(platforms[Random.Range(0, 5)], new Vector3(Random.Range(-50f, 50f), 
//											Random.Range(-5f, -500f), 
//											Random.Range(50f, 500f)), Quaternion.identity);
//			
//
//	}
//		Instantiate(winCube, new Vector3(Random.Range(-50f, 50f), 
//			Random.Range(-250f, -500f), 
//			Random.Range(50f, 500f)), Quaternion.identity);
//
//	}
	}
	// Update is called once per frame
	void Update ()
	{
		Reset ();

	}

	void Reset (){

		if (player.transform.position.y < -525) {
		
			Debug.Log ("reset");
			SceneManager.LoadScene (0);
		}

		if (player.transform.position.x < -60) {

			SceneManager.LoadScene (0);
		}

		if (player.transform.position.x > 60) {

			SceneManager.LoadScene (0);
		}
	}

}
					
