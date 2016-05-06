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
		//offset = Random.Range(0, 10);
		zen.Play();


		for (int i = 0; i < 500; i++) {
			Instantiate(platforms[Random.Range(0, 5)], new Vector3(Random.Range(-50f, 50f), 
											Random.Range(-5f, -500f), 
											Random.Range(50f, 500f)), Quaternion.identity);
			
//			Vector3 newPos = prefab.transform.localPosition;
//			newPos.x = (Mathf.PerlinNoise(Time.realtimeSinceStartup + offset, 0) * range) - (range/2);
//			newPos.y = (Mathf.PerlinNoise(0, Time.realtimeSinceStartup + offset) * range) - (range/2);
			//prefab.transform.localScale = new Vector3 (Random.Range(1f, 10f), Random.Range(1f, 10f), Random.Range (1f, 10f));
	}
		Instantiate(winCube, new Vector3(Random.Range(-50f, 50f), 
			Random.Range(-250f, -500f), 
			Random.Range(50f, 500f)), Quaternion.identity);
//		for (int i = 0; i < 1; i++) {
//			//images.Add ((GameObject)Instantiate (images [Random.Range (0, images.Count)]));
//			images.Add ((GameObject)Instantiate (images [Random.Range (0, images.Count)]));
//		}
	}
	// Update is called once per frame
	void Update ()
	{
		Reset ();

//		if (Input.GetKeyDown(KeyCode.Space)) {
//
//			for(int i=0; i<5; i++){
//				images.Add( (GameObject)Instantiate(images[Random.Range(0, images.Count)]));
//		}
//
//		for (int i = 0; i < 500; i++) {
//			
//			Debug.Log ("perlin");
//			Vector3 newPos = platforms[i].transform.position;
//						newPos.x = (Mathf.PerlinNoise(Time.realtimeSinceStartup + offset, 0) * range) - (range/2);
//						newPos.y = (Mathf.PerlinNoise(0, Time.realtimeSinceStartup + offset) * range) - (range/2);
//
//		}

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
					
