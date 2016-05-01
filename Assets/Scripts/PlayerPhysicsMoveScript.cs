using UnityEngine;
using System.Collections;

public class PlayerPhysicsMoveScript : MonoBehaviour {

	public float force;

	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;

	void Start () {
	
	}

	void FixedUpdate () {

		float timeAdjustedSpeed = force * Time.fixedDeltaTime;

		MoveByKey(up, new Vector3(0,timeAdjustedSpeed, 0));
		MoveByKey(left, new Vector3(-timeAdjustedSpeed, 0, 0));
		MoveByKey(down, new Vector3( 0, -timeAdjustedSpeed, 0));
		MoveByKey(right, new Vector3( timeAdjustedSpeed, 0, 0));
	}

	void MoveByKey(KeyCode key, Vector3 movement){
		if(Input.GetKey(key)){
			Rigidbody rigidbody = GetComponent<Rigidbody>();
			rigidbody.AddForce(movement, ForceMode.Impulse);

		}
	}
}
