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
        GenerateQueens();
        GenerateKings();
    }

    private void GeneratePawns()
    {
        for (var i = 0; i < 8; i++)
        {
            GenerateForPiece(0, i, 1);
            pieces[0].Subscriber(gridManager);
        }
        
        for (var i = 0; i < 8; i++)
        {
            GenerateForPiece(0, i, 6);
            pieces[0].Subscriber(gridManager);
        }
    }

    private void GenerateRooks()
    {
        GenerateForPiece(1, 0, 7, 0);
        GenerateForPiece(1, 0, 7, 7);
        pieces[1].Subscriber(gridManager);
    }

    private void generateKnights()
    {
        GenerateForPiece(2, 1, 6, 0);
        GenerateForPiece(2, 1, 6, 7);
        pieces[2].Subscriber(gridManager);
    }
    
    private void generateBishops()
    {
        GenerateForPiece(3, 2, 5,0);
        GenerateForPiece(3, 2, 5,7);
        pieces[3].Subscriber(gridManager);
    }

    private void GenerateQueens()
    {
        GenerateRoyals(4, 3, 0);
        GenerateRoyals(4, 3, 7);
        pieces[4].Subscriber(gridManager);
    }
    
    private void GenerateKings()
    {
        GenerateRoyals(5, 4, 0);
        GenerateRoyals(5, 4, 7);
        pieces[5].Subscriber(gridManager);
    }
    
    private void GenerateForPiece(int pieceIndex, int firstColumn, int row)
    {
        var firstParent = gridManager.Grid[firstColumn, row].transform; 
        Instantiate(pieces[pieceIndex], firstParent.position, Quaternion.identity, firstParent);
    }

    private void GenerateForPiece(int pieceIndex, int firstColumn, int SecondColumn, int row)
    {
        var firstParent = gridManager.Grid[firstColumn, row].transform;
        var secondParent = gridManager.Grid[SecondColumn, row].transform;
        
        Instantiate(pieces[pieceIndex], firstParent.position, Quaternion.identity, firstParent); 
        Instantiate(pieces[pieceIndex], secondParent.position, Quaternion.identity, secondParent); 
    }

    private void GenerateRoyals(int pieceIndex, int column, int row)
    {
        var parent = gridManager.Grid[column, row].transform;
        Instantiate(pieces[pieceIndex], parent.position, Quaternion.identity, parent); 
    }
}
