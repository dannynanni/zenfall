using UnityEngine;
using System.Collections;

public class Vec3 : Vec2 {

	public float z;

	public Vec3(){
		
	}

	public Vec3(float x, float y, float z){
		this.x = x;
		this.y = y;
		this.z = z;
	}
}
