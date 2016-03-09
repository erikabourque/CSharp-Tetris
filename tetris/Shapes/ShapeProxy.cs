using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class ShapeProxy : IShapeFactory, IShape
    {
        // Instance Variables
        private Random random;
        private IShape current;
        private IBoard board;

        // Constructor
        // INSERT CODE HERE
        public ShapeProxy(IBoard board)
        {
            random = new Random();
            this.board = board;

            DeployNewShape();
        }

        // Properties
        public int Length
        {
            get
            {
                return current.Length;
            }
        }

        // Indexer
        // Assuming Validation in current
        public Block this[int i]
        {
            get
            {
                return current[i];
            }
        }

        // Events
        public event JoinPileHandler JoinPile;

        // Event Handler, also fires event
        protected void OnJoinPile(IShape shape)
        {
            if (JoinPile != null)
            {
                JoinPile(shape);
            }
        }

        // Methods
        // PROBS ADD MORE
        public void DeployNewShape()
        {
            int index = random.Next(1, 8);

            switch (index)
            {
                case 1:
                    current = new ShapeO(board);
                    break;
                case 2:
                    current = new ShapeI(board);
                    break;
                case 3:
                    current = new ShapeS(board);
                    break;
                case 4:
                    current = new ShapeZ(board);
                    break;
                case 5:
                    current = new ShapeL(board);
                    break;
                case 6:
                    current = new ShapeJ(board);
                    break;
                case 7:
                    current = new ShapeT(board);
                    break;
            }

            current.JoinPile += OnJoinPile;
        }

        // Following methods assume validation in current
        public void MoveLeft()
        {
            current.MoveLeft();
        }

        public void MoveRight()
        {
            current.MoveRight();
        }

        public void MoveDown()
        {
            current.MoveDown();
        }

        public void Drop()
        {
            current.Drop();
        }

        public void Rotate()
        {
            current.Rotate();
        }

        public void Reset()
        {
            current.Reset();
        }
    }
}
