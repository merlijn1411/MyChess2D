using System.Collections;
using Chess;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector3 WorldPosition { get; }
    public Vector2Int GridPosition { get; }
    public bool IsOccupied { get; set; }
    
    public Tile tileNumber { get; private set; }
    
    public Tile(Vector3 worldPosition, Vector2Int gridPosition)
    {
        WorldPosition = worldPosition;
        GridPosition = gridPosition;
        IsOccupied = false;
    }

    public void SetTileNumber(Tile board)
    {
        tileNumber = board;
    }

    private void OnEnable()
    {
        StartCoroutine(AfterStart());
    }

    private IEnumerator AfterStart()
    {
        yield return new WaitForEndOfFrame();
        CheckOccupation();
    }

    private void CheckOccupation()
    {
        var childObject = GetComponentInChildren(typeof(IChessPiece)) as IChessPiece;
        IsOccupied = childObject;
    }
}


