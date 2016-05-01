using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;

public class PathFinding : MonoBehaviour
{
    public bool OnlyDisplayPathGizmos;

    private PathRequestManager _requestManager;
    private Grid _grid;

    void Start()
    {
        _grid = GetComponent<Grid>();
        _requestManager = GetComponent<PathRequestManager>();
    }

    //Method runs the FindPath Coroutine
    public void StartFindPath(Vector3 startPos, Vector3 targetPos)
    {
        StartCoroutine(FindPath(startPos, targetPos));
    }

    //Astar magic in here
    //Woooo Magic
    IEnumerator FindPath(Vector3 startPosition, Vector3 targetPosition)
    {

        Vector3[] waypoints = new Vector3[0];
        bool pathSucess = false;

        //Find the start and target nodes in the grid
        Node startNode = _grid.NodeFromWorldPoint(startPosition);
        Node targetNode = _grid.NodeFromWorldPoint(targetPosition);

        //Only run if both start position and target position is in a passable area
        if (startNode.passable && targetNode.passable)
        {

            //Create the open and closed sets
            Heap<Node> openSet = new Heap<Node>(_grid.MaxSize);
            HashSet<Node> closedSet = new HashSet<Node>();

            //Add the starting location to the open set
            openSet.Add(startNode);

            //Run through loop adding the neighbours of each node until the target node is reached
            while (openSet.Count > 0)
            {
                //Take the lowest Gcost node from the open set and assign to currentNode
                Node currentNode = openSet.RemoveFirst();

                //Then add it to the closed set
                closedSet.Add(currentNode);

                //If the currentNode is the target node, exit the loop
                if (currentNode == targetNode)
                {
                    pathSucess = true;
                    break;
                }

                //Go through each neighbour of the currentNode
                //Then calaculate the cost and add it to the open set
                foreach (var neighbour in _grid.GetNeighbours(currentNode))
                {
                    //If the neighbour node is not passable or is already in the closed set, skip the loop
                    if (!neighbour.passable || closedSet.Contains(neighbour))
                    {
                        continue;
                    }

                    //Find the cost to get to each neighbour
                    int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                    
                    //Set the costs of the neighbour if is not already in the open set.
                    //If it is, check to see if the new Gcost is lower if so replace them
                    if (newMovementCostToNeighbour < currentNode.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = newMovementCostToNeighbour;
                        neighbour.hCost = GetDistance(neighbour, targetNode);
                        neighbour.parent = currentNode;

                        //Adds the neighbour to the open set
                        if (!openSet.Contains(neighbour))
                        {
                            openSet.Add(neighbour);
                        }
                        else //Or updates it if it already existed in the open set
                        {
                            openSet.UpdateItem(neighbour);
                        }
                    }
                }
            }
        }

        yield return null;

        //After a path is found, retrace the path to optimize the path
        if (pathSucess)
        {
            waypoints = RetracePath(startNode, targetNode);
            
        }
        //Gives the completed path to the pathRequestManager and runs call back action there
        _requestManager.FinishedProcessingPath(waypoints, pathSucess);
    }

    //Traces a path from the target node to the start node
    //Follows to the parent of each node
    //Then flips the path array and sends it to the SimplfyPath method
    Vector3[] RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;
        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        Vector3[] waypoints = SimplifyPath(path);
        Array.Reverse(waypoints);
        return waypoints;
    }

    //Cleans the path to use only nodes that change the direction of the path
    Vector3[] SimplifyPath(List<Node> path)
    {
        List<Vector3> waypoints = new List<Vector3>();
        Vector2 directionOld = Vector2.zero;

        for (int i = 1; i < path.Count; i++)
        {
            Vector2 directionNew = new Vector2(path[i-1].gridX - path[i].gridX, path[i-1].gridY - path[i].gridY);
            if (directionNew != directionOld)
            {
                waypoints.Add(path[i].worldPosition);
            }
            directionOld = directionNew;
        }

        return waypoints.ToArray();
    }

    //Gets the distance betwen 2 nodes
    int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);


        //Returns shortest side as diagonal (cost 14) and longest side as straight (cost 10)
        if (dstX > dstY)
        {
            return 14*dstY + 10 * (dstX - dstY);
        }
        return 14*dstX + 10 * (dstY - dstX);
    }
}
