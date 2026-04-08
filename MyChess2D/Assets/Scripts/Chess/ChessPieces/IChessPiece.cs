using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Chess
{
    public class IChessPiece : MonoBehaviour
    {
        protected GridManager _gridManager;
        protected SpriteRenderer _spriteRenderer;
        [SerializeField] protected int steps;

        public virtual void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public virtual void OnFirstMove()
        {
            
        }

        public virtual void OnInteract()
        {
            
        }

        public virtual void OnMouseEnter()
        {
            Debug.Log(gameObject.name);
        }
        
        public void Subscriber(GridManager gridManager)
        {
            _gridManager = gridManager;
        }
    }
}

