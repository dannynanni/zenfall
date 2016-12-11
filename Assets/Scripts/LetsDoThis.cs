﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LetsDoThis : MonoBehaviour {

	public Collider2D collider;

	void Start () {
	
		Invoke("LoadNext", 5);
	}

//	void Update () {
//
//		if (Input.touchCount == 1)
//		{
//			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
//			Vector2 touchPos = new Vector2(wp.x, wp.y);
//			if (collider == Physics2D.OverlapPoint(touchPos))
//			{
//				SceneManager.LoadScene ("balance", LoadSceneMode.Single);
//			}
//		}
//
//	}

	void OnMouseDown(){

		SceneManager.LoadScene ("balance", LoadSceneMode.Single);
	}

	void LoadNext(){

		SceneManager.LoadScene ("balance", LoadSceneMode.Single);

	}
}

