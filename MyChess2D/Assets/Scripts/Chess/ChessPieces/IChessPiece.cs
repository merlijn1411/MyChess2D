using UnityEngine;

namespace Chess
{
    public class IChessPiece : MonoBehaviour
    {
        protected Tile[,] _board;
        
        protected GridManager _gridManager;
        protected SpriteRenderer _spriteRenderer;
        [SerializeField] protected int steps;

        private bool _isSelected = false;
        
        private PlayerStateHandler  _playerStateHandler;
        
        public virtual void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _playerStateHandler = PlayerStateHandler.Instance;
        }

        private void OnMouseDown()
        {
            OnInteract();
        }

        public virtual void OnFirstMove()
        {
            
        }

        public virtual void OnInteract()
        {
            _isSelected = !_isSelected;
            var pieceTarget = _isSelected 
                ? this 
                : null;
            
            var stateChange = _isSelected
                ? PlayerState.PiecePicked
                : PlayerState.Idle;
            
            _playerStateHandler.PieceTarget = pieceTarget;
            _playerStateHandler.ChangeState(stateChange);
            
        }

        public void MovePiece(Transform target)
        {
            transform.position = target.position;
        }
        
        public void Subscriber(GridManager gridManager)
        {
            _gridManager = gridManager;
        }
    }
}

