using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {

	bool existence;
	// Use this for initialization
	void Start () {
	
		existence = true;
		//transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
		//transform.rotation = Random.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation = Random.rotation;
		//transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
//		if (existence) {
//
//			transform.Translate(Vector3.up * 2, Space.World);
//		}
	}
}
