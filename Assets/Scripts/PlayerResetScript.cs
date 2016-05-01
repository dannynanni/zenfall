using UnityEngine;
using System.Collections;

public class PlayerResetScript : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(gameObject.transform.position.x >= 30 |
		   gameObject.transform.position.x <= -30 | 
		   gameObject.transform.position.y <= -40 | 
		   gameObject.transform.position.y >= 20) 
		{ Application.LoadLevel("level1"); }
	}
}
