using Chess;
using UnityEngine;

public class ChessPiecesGenerator : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;
    
    [SerializeField] private IChessPiece pawn;
    private void Start()
    {
        for (var i = 0; i < 8; i++)
        {
            Instantiate(pawn,gridManager.Grid[i,1].transform.localPosition,Quaternion.identity); 
            pawn.Subscriber(gridManager);
        }
    }

    
}
