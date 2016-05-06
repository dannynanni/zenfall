using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerMoveJitterSmooth : MonoBehaviour {

	public float thrust;
	public Rigidbody rb;
	public float airThrust;
	public float tiltAmount;
	public float maxVelocity;
	public AudioSource chime;
	public AudioSource winChime;
	//public float speed;
	//public float force = 11.0f;
	bool win = false;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody>();
		//rb.AddForce(0,-10, thrust, ForceMode.Impulse);
	}

	void FixedUpdate() 
	{
		float forceX = 0f;
		float forceZ = 0f;
		float accelX = Input.acceleration.x;
		float accelZ = Input.acceleration.y;
		Debug.Log ("x==" + Input.acceleration.x);
		Debug.Log ("z==" + Input.acceleration.y);

		if (accelX < tiltAmount) {
			Debug.Log ("-forceX");
			forceX = -1f;
		} else {
			Debug.Log ("forceX");
			forceX = 1f;
		}

		if (accelZ < tiltAmount){
			Debug.Log ("-forceY");
			forceZ = -1f;
		} else {
			Debug.Log ("forceY");
			forceZ = 1f;
		}

		rb.AddForce(new Vector3 (forceX, 0, forceZ) * airThrust);

//		float velX = rb.velocity.x;
//		float velY = rb.velocity.z;
//
//		if (velX > maxVelocity) {
//			Debug.Log ("velX");
//			velX = maxVelocity;
//		} else if (velX < -maxVelocity) {
//			velX = -maxVelocity;
//		}
//
//		if (velY > maxVelocity) {
//			Debug.Log ("velY");
//			velY = maxVelocity;
//		} else if (velY < -maxVelocity) {
//			velY = -maxVelocity;
//		}
//
//		rb.velocity = new Vector3 (velX, -velY, 0);
	}
	void Update () {

		//Debug.Log (Input.acceleration);
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

		ResetTimer ();
	}


//	void OnCollisionStay(Collision collisionInfo){
//		Vector3 normal = Vector3.up;
//		Vector3 normalTotal = Vector3.zero;
//
//		//only do this if we're touching something
//
//		if (collisionInfo.contacts.Length > 0) {
//
//			rb.AddForce(new Vector3 (Input.acceleration.x, 0, Input.acceleration.y) * thrust);
//
//		}
//
//
//	}

	void OnCollisionEnter (Collision collision){

		if (collision.gameObject.tag == "cube") {
		
			chime.Play ();
		}

		if (collision.gameObject.tag == "wincube") {

			winChime.Play ();
			win = true;
		}


	}

	void ResetTimer(){
		Debug.Log ("ResetTimer");
		Invoke ("WinReset", 9);
	}

	void WinReset (){
	
		if (win) {
			Debug.Log ("win");
			SceneManager.LoadScene (0);
		}
	}
}
