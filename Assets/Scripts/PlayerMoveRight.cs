using UnityEngine;
using System.Collections;

public class PlayerMoveRight : MonoBehaviour {

	public float thrust;
	public Rigidbody2D rb;
	public Collider2D collider;

	void Start () {

		rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
	}

	void Update () {

		if (Input.touchCount == 1)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (collider == Physics2D.OverlapPoint(touchPos))
			{
				rb.AddForce(new Vector3 (3, 0, 0) * thrust);

			}
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {

			rb.AddForce(new Vector3 (3, 0, 0) * thrust);
			Debug.Log ("left key");
		}

	}

}