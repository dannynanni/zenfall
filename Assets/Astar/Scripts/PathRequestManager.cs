using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PathRequestManager : MonoBehaviour {
   
    static PathRequestManager _instance;

    Queue<PathRequest> _pathRequestsQueue = new Queue<PathRequest>();
    PathRequest _currentPathRequest;

    private PathFinding _pathFinding;

    private bool _isProcessingPath;

    void Awake()
    {
        _instance = this;
        _pathFinding = GetComponent<PathFinding>();
    }
    
    //Requests a path. Static method to be called when aStar path needs to be found
    //PathRequest struct instance created and then queued
    //When successful run callback function
    public static void RequestPath(Vector3 pathStart, Vector3 pathEnd, Action<Vector3[], bool> callback)
    {
        PathRequest newRequest = new PathRequest(pathStart, pathEnd, callback);
        _instance._pathRequestsQueue.Enqueue(newRequest);
        _instance.TryProcessNext();
    }

    //Proccess the next path in the queue
    //Removes the pathRequest from queue
    void TryProcessNext()
    {
        if (!_isProcessingPath && _pathRequestsQueue.Count > 0)
        {
            _currentPathRequest = _pathRequestsQueue.Dequeue();
            _isProcessingPath = true;
            _pathFinding.StartFindPath(_currentPathRequest.PathStart, _currentPathRequest.PathEnd);
        }
    }

    //When the path is finished:
    //Fire callback and then process the next in queue
    public void FinishedProcessingPath(Vector3[] path, bool success)
    {
        _currentPathRequest.Callback(path, success);
        _isProcessingPath = false;
        TryProcessNext();
    }

    //Holds information about the path
    struct PathRequest
    {
        public Vector3 PathStart;
        public Vector3 PathEnd;
        public Action<Vector3[], bool> Callback;

        public PathRequest (Vector3 start, Vector3 end, Action<Vector3[],bool> _callback)
        {
            PathStart = start;
            PathEnd = end;
            Callback = _callback;
        }
    }
}
