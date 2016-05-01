using UnityEngine;
using System.Collections;

public class Vec2 {

	//fields - a variable in a class
	public float x = 0;
	public float y = 0;

	//default constructor
	public Vec2(){
		Debug.Log("Called Vec2 default constructor");
	}

	public Vec2(float x, float y){
		this.x = x;
		this.y = y;
	}

	public Vec2(bool isRand){
		if(isRand){
			x = Random.Range(0, 1000);
			y = Random.Range(0, 1000);
		}
	}
}
