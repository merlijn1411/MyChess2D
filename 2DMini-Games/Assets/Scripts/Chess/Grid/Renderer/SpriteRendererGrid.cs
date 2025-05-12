using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererGrid : GridRenderer
{
    public override GameObject CreateGrid(Vector3 worldPosition, float cellSize,List<GameObject> cellPrefabs)
    {
        var x = Mathf.FloorToInt(worldPosition.x / cellSize);
        var y = Mathf.FloorToInt(worldPosition.y / cellSize);
        
        var prefabIndex = Mathf.Abs((x + y) % cellPrefabs.Count);

        var selectedPrefab = cellPrefabs[prefabIndex];
        selectedPrefab.transform.localScale = new Vector3(cellSize, cellSize, 0f);
        var tileObject =Instantiate(selectedPrefab, worldPosition, Quaternion.identity, transform);
        return tileObject;
    }
    
}
