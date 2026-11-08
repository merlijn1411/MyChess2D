using System.Collections;
using Chess;
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

    public virtual void OnMouseDown()
    {
        var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
        if (hit.collider == null) return;
        
        var stateHandler = PlayerStateHandler.Instance;
        var tileTarget = stateHandler.State == PlayerState.PiecePicked ? this : null;
        PlayerStateHandler.Instance.TileTarget = tileTarget;
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


