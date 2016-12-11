using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnScript : MonoBehaviour {

	public float Timer = 2;

	public List<GameObject> weights = new List<GameObject>();

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Timer -= Time.deltaTime;
		if (Timer <= 0f)
		{
			Spawn ();
			Timer = 2;
		}
	}

	void Spawn(){
	
		Instantiate(weights[Random.Range(0, 9)], new Vector3(Random.Range(-3f, 3f), 4.9f, 1), Quaternion.identity);
	}
}
