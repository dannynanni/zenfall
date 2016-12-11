﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TapToPlay : MonoBehaviour {

	public Collider2D collider;

	void Update () {

		if (Input.touchCount == 1)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (collider == Physics2D.OverlapPoint(touchPos))
			{
				SceneManager.LoadScene ("balanceTut", LoadSceneMode.Single);

			}
		}

	}

	void OnMouseDown(){
	
		SceneManager.LoadScene ("balanceTut", LoadSceneMode.Single);
	}
}
