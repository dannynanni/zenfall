using UnityEngine;
using System.Collections;

public class winPlatMoveScript : MonoBehaviour {

	Vector3 startPos;
	Vector3 endPos;
	public GameObject platform;
	public float speed;

	// Use this for initialization
	void Start () {


		startPos = new Vector3 (0f, -510f, 250f);
		platform.transform.position = startPos;
		endPos = new Vector3 (0f, -510, 510f);
	}
	
	// Update is called once per frame
	void Update () {
	
		MoveForward ();
		MoveBack ();
}

	IEnumerator ForwardLerp(){

		if (platform.transform.position.z == 250f){
			Debug.Log ("lerp1");
			float percentage = 0.0f;
				while (percentage < 1.0f) {
					percentage = Mathf.Min (percentage + speed * Time.deltaTime, 1.0f);
				platform.transform.position = Vector3.Lerp (startPos, endPos, percentage);
					yield return 0;
					}
		}
	}

	public void MoveForward (){
	
		StartCoroutine ("ForwardLerp");
	}

	IEnumerator BackwardLerp(){

		if (platform.transform.position.z == 510f){
			float percentage = 0.0f;
			while (percentage < 1.0f) {
				percentage = Mathf.Min (percentage + speed * Time.deltaTime, 1.0f);
				platform.transform.position = Vector3.Lerp (endPos, startPos, percentage);
				yield return 0;
			}
		}
	}

	public void MoveBack (){

		StartCoroutine ("BackwardLerp");
	}
}
