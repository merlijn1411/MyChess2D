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

    public Tile GetTile(int x, int y)
    {
        return board[x, y].GetComponent<Tile>();
    }

    public Tile[,] GetBoard()
    {
        var boardSize = board.GetLength(0);
        for (var c = 0; c < boardSize; c++)
        {
            for (var r = 0; r < boardSize; r++)
            {
                var tile = board[r, c].GetComponent<Tile>();
                
            }
        }

        return board;
    }
}
