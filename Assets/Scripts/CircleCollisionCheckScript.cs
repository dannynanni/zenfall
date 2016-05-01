using UnityEngine;
using System.Collections;

public class CircleCollisionCheckScript : MonoBehaviour {

	public GameObject safeZone;
	public float maxSafeDist;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position, safeZone.transform.position) > maxSafeDist){
			Destroy(gameObject);
		}	
	}
}
