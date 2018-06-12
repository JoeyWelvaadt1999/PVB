using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour {
    [SerializeField] private Vector2 _gridSize;
    [SerializeField] private int _nodeDiameter;

    private Node[,] _grid;

	// Use this for initialization
	private void Start () {
        _grid = new Node[(int)_gridSize.x, (int)_gridSize.y];
        CreateGrid();
	}
	
	// Update is called once per frame
	private void Update () {
		
	}

    private void CreateGrid() {
        for (int x = 0; x < _gridSize.x; x++)
        {
            for (int y = 0; y < _gridSize.y; y++)
            {
                Vector2 worldPos = GridToWorldPos(new Vector2(x,y));
                Node n = new Node(worldPos);
                _grid[x, y] = n;
            }
        }
    }

    public Vector2 GridToWorldPos(Vector2 gridPos) {
        float x = (gridPos.x * _nodeDiameter) - Mathf.CeilToInt((_gridSize.x * _nodeDiameter) / 2f);
        float y = (gridPos.y * _nodeDiameter) - Mathf.CeilToInt((_gridSize.y * _nodeDiameter) / 2f);

        return new Vector2(x, y);
    }

    private void OnDrawGizmos()
    {
        if (_grid != null)
        {
            for (int x = 0; x < _gridSize.x; x++)
            {
                for (int y = 0; y < _gridSize.y; y++)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireCube(new Vector3(_grid[x, y].WorldPosition.x, _grid[x, y].WorldPosition.y, 0), new Vector3(_nodeDiameter, _nodeDiameter, 1));
                }
            }
        }
    }
}
