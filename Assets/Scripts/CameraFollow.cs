using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	public float plusY;
	public float plusZ;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
		Camera.main.transform.position = new Vector3 (player.transform.position.x,
			player.transform.position.y + plusY,
			player.transform.position.z + plusZ);
	}
}

