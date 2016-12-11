using UnityEngine;
using System.Collections;

public class RendererScript : MonoBehaviour {

	public TrailRenderer trail;
	// Use this for initialization
	void Start () {
		trail.sortingLayerName = "renderer";
		trail.sortingOrder = 2;
	}
}
