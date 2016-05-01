using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
    public bool DisplayGridGizmos;
    public LayerMask UnpassableMask;
    public Vector2 GridWorldSize;
    public float NodeRadius;
    
    private Node[,] _grid;

    private float _nodeDiameter;
    private int _gridSizeX;
    private int _gridSizeY;

    void Awake()
    {
        _nodeDiameter = NodeRadius*2;
        _gridSizeX = Mathf.RoundToInt(GridWorldSize.x/_nodeDiameter);
        _gridSizeY = Mathf.RoundToInt(GridWorldSize.y/ _nodeDiameter);
        CreateGrid();
    }

    //Creates a grid of nodes
    void CreateGrid()
    {
        _grid = new Node[_gridSizeX, _gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * GridWorldSize.x/2 - Vector3.forward*GridWorldSize.y/2;
        for (int x = 0; x < _gridSizeX; x++)
        {
            for (int y = 0; y < _gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right*(x*_nodeDiameter + NodeRadius) + Vector3.forward* (y * _nodeDiameter + NodeRadius);
                
                //Check to see if the node contains a unpassable object then adds it to grid array
                bool passable = !(Physics.CheckSphere(worldPoint, NodeRadius, UnpassableMask));
                _grid[x,y] = new Node(passable, worldPoint, x, y);
            }
        }
    }

    public int MaxSize
    {
        get { return _gridSizeX*_gridSizeY; }
    }


    //Return a list of the nodes that surround a node
    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                //Skips the middle node
                if(x==0 && y == 0)
                    continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < _gridSizeX && checkY >= 0 && checkY < _gridSizeY)
                {
                    neighbours.Add(_grid[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }


    //Returns a node in the grid that is at the location of pass world point
    public Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + GridWorldSize.x/2)/GridWorldSize.x;
        float percentY = (worldPosition.z + GridWorldSize.y / 2) / GridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((_gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((_gridSizeY - 1) * percentY);

        return _grid[x, y];
    }


    public List<Node> Path;
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(GridWorldSize.x, 1, GridWorldSize.y));

        //Draws the nodes
        if (_grid != null && DisplayGridGizmos)
        {
            foreach (var n in _grid)
            {
                Gizmos.color = (n.passable) ? Color.white : Color.red;
                Gizmos.DrawCube(n.worldPosition, Vector3.one * (_nodeDiameter - .1f));
            }
        }

    }
}
