//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//public class SafeZoneMoveScipt : MonoBehaviour {
//
//	public float range;
//	public GameObject gm;
//	public DataStructureExamples ds;
//	float offset;
//
//	// Use this for initialization
//	void Start () {
//
//		gm = GameObject.Find ("GameManager");
//		ds = gm.GetComponent<DataStructureExamples>	();
//		List<GameObject> platforms = ds.platforms; 
//		offset = Random.Range(0, 10);
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		//Vector3 newPos = new Vector3();
//		//Vector3 newPos = platforms.transform.localposition;
//
//		newPos.x = (Mathf.PerlinNoise(Time.realtimeSinceStartup + offset, 0) * range) - (range/2);
//		newPos.y = (Mathf.PerlinNoise(0, Time.realtimeSinceStartup + offset) * range) - (range/2);
//
//		transform.position = newPos;
//	}
//}
