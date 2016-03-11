using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    // Author: Georgi Veselinov Kichev
    // Date: 29/02/2016
    // Version: 2

    public abstract class Shape : IShape
    {
        private IBoard board;
        protected Block[] blocks;
        protected Point[,] rotationOffset;
        protected int currentRotation;

        public event JoinPileHandler JoinPile;

        public abstract int Length { get; }

        public abstract Block this[int index] { get; }

        protected void OnJoinPile()
        {
            if (JoinPile != null)
            {
                JoinPile(this);
            }
        }

        public abstract void MoveLeft();
        public abstract void MoveRight();
        public abstract void MoveDown();
        public abstract void Drop();
        public abstract void Rotate();
        public abstract void Reset();
    }
}
