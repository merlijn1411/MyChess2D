using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int height;
    public int width;
    public float cellSize;
    
    public GridRenderMask gridRenderMask;
    
    public Tile[,] Grid { get; private set;}

    [SerializeField] private Material lineMaterial;
    [SerializeField] private List<GameObject> cellPrefabs;
    
    private void Awake()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        Grid = new Tile[width, height];

        for (var y = 0; y < width; y++)
        {   
            for (var x = 0; x < height; x++)
            {
                var startPos = new Vector3(x + 0.5f, y + 0.5f);
                var worldPosition = new Vector3( startPos.x * cellSize, startPos.y * cellSize, 0f);
                var tile = RenderGrid(worldPosition);

                var tileObject = tile.GetComponent<Tile>();
                if (tileObject == null)
                {
                    Debug.Log("Tile prefab missed a Tile-script!");
                    continue;
                }
                Grid[x, y] = tileObject;
            }
        }
    }

    private GameObject RenderGrid(Vector3 worldPosition)
    {
        if (gridRenderMask == GridRenderMask.LineRenderer)
        {
            var lineRendererGrid = gameObject.GetOrAddComponent<LineRendererGrid>();
            lineRendererGrid?.CreateGrid(worldPosition,cellSize,lineMaterial);
        }
        
        if (gridRenderMask == GridRenderMask.SpriteRender)
        {
            var spriteRendererGrid = gameObject.GetOrAddComponent<SpriteRendererGrid>();
            return spriteRendererGrid.CreateGrid(worldPosition, cellSize ,cellPrefabs);
        }

        return null;
    }
    
    private void OnValidate()
    {
        if (width <= 1)
            width = 1;
        if (height <= 1)
            height = 1;
        if (cellSize <= 0.25f)
            cellSize = 0.25f;
    }
    
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x * cellSize, 0f, y * cellSize);
    }

    public Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        var x = Mathf.FloorToInt(worldPosition.x / cellSize);
        var y = Mathf.FloorToInt(worldPosition.z / cellSize);
        return new Vector2Int(x, y);
    }

}
