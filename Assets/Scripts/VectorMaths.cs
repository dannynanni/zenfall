using UnityEngine;
using System.Collections;

public class VectorMaths : MonoBehaviour {

	public Vector3 startPoint;
	public Vector3 vec1;
	public Vector3 vec2;

	public Vector3 inVec;

	// Use this for initialization
	void Start () {
	
		Debug.Log("Vec1 Mag: " + vec1.magnitude);
		Debug.Log("Vec1 Normalized: " + vec1.normalized);
		Debug.Log("Vec1 my normal: " + vec1/vec1.magnitude);
		Debug.Log("Vec1 mag 10: " + vec1.normalized * 10);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay(startPoint, vec1, Color.white);
		Debug.DrawRay(startPoint, vec2, Color.white);
		Debug.DrawRay(startPoint, -vec1, Color.white);
		Debug.DrawRay(startPoint, -vec2, Color.white);

		Vector3 cross = Vector3.Cross(vec1, vec2);

		Debug.DrawRay(startPoint, cross, Color.red);

		Debug.DrawRay(startPoint, inVec, Color.green);

		float dot = Vector3.Dot(inVec, cross);

		Debug.Log("Dot Product: " + dot);

		Vector3 normal = cross.normalized;
		Vector3 normalizedInVec = inVec.normalized;

		float normDot = Vector3.Dot(normal, normalizedInVec);

		Debug.Log("normDot: " + normDot);

		Vector3 reflection = Vector3.Reflect(inVec, normal);

		Debug.DrawRay(startPoint, -reflection, Color.yellow);
	}
}
