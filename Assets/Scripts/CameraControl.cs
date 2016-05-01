using UnityEngine;
using System.Collections;
public class CameraControl : MonoBehaviour {
	public Transform playerTransform;
	Vector3 normal;
	// Use this for initialization
	void Start () {
		normal = Vector3.up; //initialize
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = playerTransform.position;
		playerPos.z = transform.position.z;//don't follow in Z
		transform.position = Vector3.Lerp(transform.position, playerPos, 0.1f);//soft follow

		//try to rotate so that normal is facing up.
		Quaternion newRotation = Quaternion.LookRotation(Vector3.forward, normal);
		transform.localRotation = Quaternion.Slerp (transform.localRotation, newRotation, 0.03f);
	}

	public void UpdateNormal(Vector3 newNormal){
		normal = newNormal;
	}
}
