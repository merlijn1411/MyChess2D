using UnityEngine;

namespace Chess
{
    public class Pawn : IChessPiece
    {

        public override void Start()
        {
            base.Start();
            steps = 2;
        }

        public override void OnFirstMove()
        {
            steps = 1;
        }

        public override void OnMouseEnter()
        {
            base.OnMouseEnter();
        }
        
    }
}

