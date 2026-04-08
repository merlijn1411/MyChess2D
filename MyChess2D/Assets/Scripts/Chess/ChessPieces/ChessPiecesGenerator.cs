using System.Collections.Generic;
using Chess;
using UnityEngine;

//Default list index order:
// 0: Pawn
// 1: Rook
// 2: Knight
// 3: Bishop
// 4: Queen
// 5: King

public class ChessPiecesGenerator : MonoBehaviour
{
    [SerializeField] private GridManager gridManager;
    
    [SerializeField] private IChessPiece pawn;

    [SerializeField] private List<IChessPiece> pieces;
    
    private void Start()
    {
        if (GridManager.GridInstance.gridRenderMask != GridRenderMask.SpriteRender) return;
        GeneratePawns();
        GenerateRooks();
        generateKnights();
        generateBishops();
        GenerateQueen();
        GenerateKing();
    }

    private void GeneratePawns()
    {
        for (var i = 0; i < 8; i++)
        {
            Instantiate(pieces[0], gridManager.Grid[i,1].transform.position, Quaternion.identity, gridManager.Grid[i,1].transform); 
            pieces[0].Subscriber(gridManager);
        }
    }

    private void GenerateRooks()
    {
        GenerateForPiece(1, 0, 7);
        pieces[1].Subscriber(gridManager);
    }

    private void generateKnights()
    {
        GenerateForPiece(2, 1, 6);
        pieces[2].Subscriber(gridManager);
    }
    
    private void generateBishops()
    {
        GenerateForPiece(3, 2, 5);
        pieces[3].Subscriber(gridManager);
    }

    private void GenerateQueen()
    {
        Instantiate(pieces[4], gridManager.Grid[3,0].transform.position, Quaternion.identity, gridManager.Grid[3,0].transform); 
        pieces[4].Subscriber(gridManager);
    }
    
    private void GenerateKing()
    {
        Instantiate(pieces[5], gridManager.Grid[4,0].transform.position, Quaternion.identity, gridManager.Grid[4,0].transform); 
        pieces[5].Subscriber(gridManager);
    }

    private void GenerateForPiece(int PieceIndex, int FirstPlace, int SecondPlace)
    {
        Instantiate(pieces[PieceIndex], gridManager.Grid[FirstPlace,0].transform.position, Quaternion.identity, gridManager.Grid[FirstPlace,0].transform); 
        Instantiate(pieces[PieceIndex], gridManager.Grid[SecondPlace,0].transform.position, Quaternion.identity, gridManager.Grid[SecondPlace,0].transform); 
    }
}
