using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerMoveJitterSmooth : MonoBehaviour {

	public float thrust;
	public Rigidbody2D rb;
	public float airThrust;
	public float tiltAmount;
	public float maxVelocity;
	public AudioSource chime;
	public AudioSource winChime;

	float zeroAc;
	float sensV;
	float sensH;
	//public float speed;
	//public float force = 11.0f;
	bool win = false;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D>();
		//rb.AddForce(0,-10, thrust, ForceMode.Impulse);
	}

	void FixedUpdate() 
	{
		//are we using a computer as opposed to a mobile device with an accelerometer?
		if(SystemInfo.deviceType == DeviceType.Desktop)
		{
			//start of movement code from rollerball tutorial
			//used for desktop movement
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				
					rb.AddForce(new Vector3 (-3, 0, 0) * airThrust);
					Debug.Log ("left key");
			}
				
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				
					rb.AddForce(new Vector3 (3, 0, 0) * airThrust);
						Debug.Log ("right arrow");
			}
		}
//		or are we on mobile with an accelerometer?
		else
		{
			Vector3 movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);
			// Adding force to rigidbody
			rb.AddForce(movement * thrust * Time.deltaTime);

			Debug.Log ("phone");
		}
		
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
		//Debug.Log ("ResetTimer");
		Invoke ("WinReset", 9);
	}

	void WinReset (){
	
		if (win) {
			Debug.Log ("win");
			SceneManager.LoadScene (0);
		}
	}

//	//OLD CODE
//	float forceX = 0f;
//	float forceZ = 0f;
//	float accelX = Input.acceleration.x;
//	float accelZ = Input.acceleration.y;
//	//Debug.Log ("x==" + Input.acceleration.x);
//	//Debug.Log ("z==" + Input.acceleration.y);
//
//	//		if (accelX < tiltAmount) {
//	//			//Debug.Log ("-forceX");
//	//			forceX = -1f;
//	//		} else {
//	//			//Debug.Log ("forceX");
//	//			forceX = 1f;
//	//		}
//
//	//		if (accelZ < tiltAmount){
//	//			Debug.Log ("-forceY");
//	//			forceZ = -1f;
//	//		} else {
//	//			Debug.Log ("forceY");
//	//			forceZ = 1f;
//	//		}
//
//	if (Input.GetKeyDown (KeyCode.LeftArrow)) {
//
//		rb.AddForce(new Vector3 (forceX, 0, forceZ) * airThrust);
//		Debug.Log ("left key");
//
//
//	}
//
//	if (Input.GetKeyDown (KeyCode.RightArrow)) {
//
//		rb.AddForce(new Vector3 (forceZ, 0, forceX) * airThrust);
//		Debug.Log ("right arrow");
//
//	}
//
//	Vector3 dir = Vector3.zero;
//	dir.x = Input.acceleration.x;
//	//dir.y = Input.acceleration.y;
//	Physics.gravity = dir * thrust;
//
//	//		rb.AddForce(new Vector3 (forceX, 0, forceZ) * airThrust);
//	//
//	////		float velX = rb.velocity.x;
//	////		float velY = rb.velocity.z;
//	////
//	////		if (velX > maxVelocity) {
//	////			Debug.Log ("velX");
//	////			velX = maxVelocity;
//	////		} else if (velX < -maxVelocity) {
//	////			velX = -maxVelocity;
//	////		}
//	////
//	////		if (velY > maxVelocity) {
//	////			Debug.Log ("velY");
//	////			velY = maxVelocity;
//	////		} else if (velY < -maxVelocity) {
//	////			velY = -maxVelocity;
//	////		}
//	////
//	////		rb.velocity = new Vector3 (velX, -velY, 0);
}
