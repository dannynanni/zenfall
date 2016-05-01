using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{
    public bool ShowWaypointPath;
    public Transform Target;
    public float Speed = 20;

    private Vector3[] _path;
    private int _targetIndex;

	private Vector3 mousePos;

	public float delayTime;
	private float timer;

    void Update()
    {
        //**********
        //
        // Change this area to make the astar find a go to the path as you please
        // You just have to call PathRequestManager.RequestPath
        // While passing it your position, the target position, and OnPathFound
        //


//        if (Input.GetButtonDown("Jump"))
//        {
//            //Finds the aStar path then starts to move towards the target
//            PathRequestManager.RequestPath(transform.position, Target.position, OnPathFound);
//        }
//		mousePos = Input.mousePosition;
//		Target.position = Camera.main.ScreenToWorldPoint (mousePos);
//
//		timer += Time.deltaTime;
//		if (timer >= delayTime) {
//
//			if (Input.GetMouseButtonDown (0)) {
//				timer = 0;
//				PathRequestManager.RequestPath (transform.position, Target.position, OnPathFound);
//			}
//		}

		if (Input.GetMouseButtonDown (0)) {

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			Physics.Raycast (ray, out hit);
			PathRequestManager.RequestPath (transform.position, hit.point, OnPathFound);
		}

        //**************
    }

    // Call back function that starts the unit down the path to the target
    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful && newPath.Length>0)
        {
            _path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    //Guides the unit between the waypoints of the path toward the target
    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = _path[0];
        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                _targetIndex ++;
                if (_targetIndex >= _path.Length)
                {
                    _targetIndex = 0;
                    _path = new Vector3[0];
                    yield break;
                }

                currentWaypoint = _path[_targetIndex];
            }

            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, Speed*Time.deltaTime);
            yield return null;
        }
    }


    //Draw the waypoints and lines between in sceneview
    public void OnDrawGizmos()
    {
        if (_path != null && ShowWaypointPath)
        {
            for (int i = _targetIndex; i < _path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(_path[i], Vector3.one);

                if (i == _targetIndex)
                {
                    Gizmos.DrawLine(transform.position, _path[i]);
                }
                else
                {
                    Gizmos.DrawLine(_path[i-1], _path[i]);
                }
            }
        }
    }
}
