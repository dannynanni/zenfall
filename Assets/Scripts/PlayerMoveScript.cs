using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMoveScript : MonoBehaviour {

	public float speed;

	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;





	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
		// Replaced with super cool MoveByKey function
//		if(Input.GetKey(KeyCode.W)){
//			Debug.Log("Pressed W");
//			transform.position += new Vector3(0, 1 * speed, 0);
//		}

		float timeAdjustedSpeed = speed * Time.deltaTime;

		MoveByKey(up, new Vector3(0,timeAdjustedSpeed, 0));
		MoveByKey(left, new Vector3(-timeAdjustedSpeed, 0, 0));
		MoveByKey(down, new Vector3( 0, -timeAdjustedSpeed, 0));
		MoveByKey(right, new Vector3( timeAdjustedSpeed, 0, 0));

//		if(Input.GetKeyDown(KeyCode.UpArrow)){
//			transform.position += Vector3.up * Time.deltaTime;
//		}
//		if(Input.GetKeyDown(KeyCode.DownArrow)){
//			transform.position += Vector3.down * Time.deltaTime;
//		}
//		if(Input.GetKeyDown(KeyCode.LeftArrow)){
//			transform.position += Vector3.left * Time.deltaTime;
//		}
//		if(Input.GetKeyDown(KeyCode.RightArrow)){
//			transform.position += Vector3.right * Time.deltaTime;
//		}

	}

	void MoveByKey(KeyCode key, Vector3 movement){
		if(Input.GetKey(key)){
			transform.position += movement;
		}
	}

	//every frame we're touching a surface, send the collision normal (perpendicular) vector to the camera
	void OnCollisionStay(Collision collisionInfo){
		Vector3 normal = Vector3.up;
		Vector3 normalTotal = Vector3.zero;

		//only do this if we're touching something
		if (collisionInfo.contacts.Length > 0) {
			foreach (ContactPoint point in collisionInfo.contacts) {
				normalTotal += point.normal;//add all the collision normals together
				//Physics.gravity = Physics.gravity * Camera.main.transform.up * -1;
				Physics.gravity = Camera.main.transform.up * -1;
			}
			normalTotal /= collisionInfo.contacts.Length;
			normal = normalTotal;
		}

		Camera.main.SendMessage ("UpdateNormal", normal); //send the normal to the camera
	}
}
