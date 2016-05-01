using UnityEngine;
using System.Collections;

public class Node : IHeapItem<Node>
{

    public bool passable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;

    public int gCost;
    public int hCost;

    public Node parent;
    private int _heapIndex;

    public Node(bool _passable, Vector3 _worldPos, int _gridX, int _gridY)
    {
        passable = _passable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    //The index of the node in the Heap
    public int HeapIndex
    {
        get { return _heapIndex; }
        set { _heapIndex = value; }
    }

    //Interface needed for the heap to compare two nodes using Fcost and Hcost as a tie breaker
    public int CompareTo(Node nodeToCompare)
    {
        int compare = fCost.CompareTo(nodeToCompare.fCost);
        if (compare == 0)
        {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }

        return -compare;
    }
}
