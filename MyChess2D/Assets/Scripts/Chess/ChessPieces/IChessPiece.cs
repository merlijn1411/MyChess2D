using UnityEngine;

namespace Chess
{
    public class IChessPiece : MonoBehaviour
    {
        protected Tile[,] _board;
        
        protected GridManager _gridManager;
        protected SpriteRenderer _spriteRenderer;
        [SerializeField] protected int steps;
        
        private PlayerStateHandler  _playerStateHandler;
        
        public virtual void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _playerStateHandler = PlayerStateHandler.Instance;
        }

        private void OnMouseDown()
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if (hit.collider == null) return;
            OnInteract();
        }

        public virtual void OnFirstMove()
        {
            
        }

        protected virtual void OnInteract()
        {
            var isSelected = _playerStateHandler.IsSelected;
            isSelected = !isSelected;

            var pieceTarget = isSelected 
                ? this 
                : null;
            
            var stateChange = isSelected
                ? PlayerState.PiecePicked
                : PlayerState.Idle;
            
            _playerStateHandler.PieceTarget = pieceTarget;
            _playerStateHandler.ChangeState(stateChange);
            
        }

        public void MovePiece(Transform target)
        {
            transform.position = target.position;
            _playerStateHandler.IsSelected = false;
        }
        
        public void Subscriber(GridManager gridManager)
        {
            _gridManager = gridManager;
        }
    }
}

