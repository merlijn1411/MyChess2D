using UnityEngine;

public class BoardGrabber : MonoBehaviour
{
    public static BoardGrabber GrabberInstance { get; private set; }
    [SerializeField] private Tile[,] board;
    private void Awake()
    {
        GrabberInstance = this;
    }

    private void Start()
    {
        board = GridManager.GridInstance.Grid;
    }

    public void GetNotOccupiedTiles()
    {
        var boardSize = board.GetLength(0);
        for (var r = 0; r < boardSize; r++)
        {
            for (var c = 0; c < boardSize; c++)
            {
                var tile = board[c, r].GetComponent<Tile>();
            }
        }
    }
}
