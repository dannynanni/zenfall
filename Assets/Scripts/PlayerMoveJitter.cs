using UnityEngine;
using System.Collections;

public class PlayerMoveJitter : MonoBehaviour {

	public float thrust;
	public Rigidbody rb;
	public float airThrust;
	//public float speed;
	//public float force = 11.0f;

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody>();
		//rb.AddForce(0,-10, thrust, ForceMode.Impulse);
	}

	void FixedUpdate() 
	{
		rb.AddForce(new Vector3 (Input.acceleration.x, 0, Input.acceleration.y) * airThrust);
	}
	void Update () {

		Debug.Log (Input.acceleration);
//		transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
		//transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);
//		Vector3 dir = Vector3.zero;
//		dir.x = -Input.acceleration.z;
//		dir.z = Input.acceleration.y;
//		if (dir.sqrMagnitude > 1)
//			dir.Normalize();
//
//		dir *= Time.deltaTime;
//		transform.Translate(dir * speed);

	
	}


	void OnCollisionStay(Collision collisionInfo){
		Vector3 normal = Vector3.up;
		Vector3 normalTotal = Vector3.zero;

		//only do this if we're touching something

			if (collisionInfo.contacts.Length > 0) {

			rb.AddForce(new Vector3 (Input.acceleration.x, 0, Input.acceleration.y) * thrust);
				
				}

			
		}
}


