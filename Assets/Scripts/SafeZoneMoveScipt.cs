using UnityEngine;
using System.Collections;

public class SafeZoneMoveScipt : MonoBehaviour {

	public float range;

	float offset;

	// Use this for initialization
	void Start () {

		offset = Random.Range(0, 10);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = new Vector3();

		newPos.x = (Mathf.PerlinNoise(Time.realtimeSinceStartup + offset, 0) * range) - (range/2);
		newPos.y = (Mathf.PerlinNoise(0, Time.realtimeSinceStartup + offset) * range) - (range/2);

		transform.position = newPos;
	}
}
