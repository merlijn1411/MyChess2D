using System;
using System.Collections;
using System.Threading;
using Chess;
using UnityEngine;

public class PlayerStateHandler : MonoBehaviour
{
    public static PlayerStateHandler Instance { get; private set; }
    public PlayerState State { get; private set; }

    public IChessPiece PieceTarget  { get; set; }
    public Tile TileTarget { get; set; }

    public bool IsSelected = false;
    
    private void Awake()
    {
        Instance = this;
        State = PlayerState.Idle;
    }

    private void Start()
    {
        StartCoroutine(HandleRoutine());
    }

    private IEnumerator HandleRoutine()
    {
        if (State == PlayerState.PiecePicked) BoardGrabber.GrabberInstance.GetNotOccupiedTiles();
        
        
        yield return new WaitUntil( () => HasTarget(PieceTarget) && HasTarget(TileTarget) ); 
        PieceTarget.MovePiece(TileTarget.transform);
        RoutineReset();
    }

    private void RoutineReset()
    {
        PieceTarget = null;
        TileTarget = null;
        State = PlayerState.Idle;
        StartCoroutine(HandleRoutine());
    }

    public void ChangeState(PlayerState newState)
    {
        State = newState;
    }
    
    private static bool HasTarget(Tile target)
    {
        return target != null;
    }
    
    private static bool HasTarget(IChessPiece target)
    {
        return target != null;
    }
    
}

public enum PlayerState
{
    Idle, 
    PiecePicked,
}
