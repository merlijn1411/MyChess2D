using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector3 WorldPosition { get; }
    public Vector2Int GridPosition { get; }
    public bool IsOccupied { get; set; }
    
    public Tile(Vector3 worldPosition, Vector2Int gridPosition)
    {
        WorldPosition = worldPosition;
        GridPosition = gridPosition;
        IsOccupied = false;
    }
}
