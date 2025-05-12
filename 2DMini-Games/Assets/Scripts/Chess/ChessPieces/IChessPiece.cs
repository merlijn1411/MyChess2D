using UnityEngine;
using UnityEngine.EventSystems;

namespace Chess
{
    public class IChessPiece : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] protected GridManager gridManager;
        [SerializeField] protected int steps;
    
    

        public void OnPointerClick(PointerEventData eventData)
        {
        
        }
    }
}

