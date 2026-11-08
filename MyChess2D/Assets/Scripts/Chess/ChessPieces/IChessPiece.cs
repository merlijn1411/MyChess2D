using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Chess
{
    public class IChessPiece : MonoBehaviour
    {
        public Transform targetTransform;
        protected Tile[,] _board;
        
        protected GridManager _gridManager;
        protected SpriteRenderer _spriteRenderer;
        [SerializeField] protected int steps;

        private bool _isSelected = false;
        
        public virtual void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
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
            
        }

        private void MovePiece()
        {
            transform.position = targetTransform.position;
        }

        // public virtual void OnMouseEnter()
        // {
        //     Debug.Log(gameObject.name);
        // }
        
        public void Subscriber(GridManager gridManager)
        {
            _gridManager = gridManager;
        }
    }
}

