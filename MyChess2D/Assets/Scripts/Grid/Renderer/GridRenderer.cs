using System.Collections.Generic;
using UnityEngine;

public class GridRenderer : MonoBehaviour
{
    public GridManager gridManager;

    public virtual void CreateGrid(Vector3 worldPosition, float cellSize, GridManager _gridManager){}
    public virtual void CreateGrid(Vector3 worldPosition, float cellSize, Material lineMaterial){}

    public virtual GameObject CreateGrid(Vector3 worldPosition, float cellSize, List<GameObject> cellPrefabs) { return null;}
}
