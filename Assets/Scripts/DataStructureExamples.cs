using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataStructureExamples : MonoBehaviour {

	public List<GameObject> platforms = new List<GameObject>();
	public GameObject prefab;


	// Use this for initialization
	void Start () {


		for (int i = 0; i < 500; i++) {
			Instantiate(platforms[Random.Range(0, 5)], new Vector3(Random.Range(-50f, 50f), 
											Random.Range(-5f, -500f), 
											Random.Range(50f, 500f)), Quaternion.identity);
			//prefab.transform.localScale = new Vector3 (Random.Range(1f, 10f), Random.Range(1f, 10f), Random.Range (1f, 10f));
	}
//		for (int i = 0; i < 1; i++) {
//			//images.Add ((GameObject)Instantiate (images [Random.Range (0, images.Count)]));
//			images.Add ((GameObject)Instantiate (images [Random.Range (0, images.Count)]));
//		}
	}
	// Update is called once per frame
	void Update ()
	{

//		if (Input.GetKeyDown(KeyCode.Space)) {
//
//			for(int i=0; i<5; i++){
//				images.Add( (GameObject)Instantiate(images[Random.Range(0, images.Count)]));
//		}



	}
}
					
