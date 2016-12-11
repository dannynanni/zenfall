using UnityEngine;
using System.Collections;

public class IgnoreCollision : MonoBehaviour {


	void Start () {
	
		Physics.IgnoreLayerCollision(8,9, true);
	}
}

