﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
		Camera.main.transform.position = new Vector3 (player.transform.position.x,
			player.transform.position.y + 10,
			player.transform.position.z);
	}
}

