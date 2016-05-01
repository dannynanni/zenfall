using UnityEngine;
using System.Collections;

public class OLDPlayerMoveScript : MonoBehaviour {

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
	}

	void MoveByKey(KeyCode key, Vector3 movement){
		if(Input.GetKey(key)){
			transform.position += movement;
		}
	}
}
