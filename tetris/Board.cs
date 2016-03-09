using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    // Author: Erika Bourque
    // Date: 09/03/2016
    // Version: 2.0
    // commit

    public class Board : IBoard
    {
        // Instance Variables
        private Color[,] board = new Color[20, 10];
        private IShape shape;
        private IShapeFactory shapeFactory;

        // Constructor
        // ADD MOAR?!?
        // Why do i need shape? to place the colors?
        public Board()
        {
            // Creating proxy
            shapeFactory = new ShapeProxy(this);
            //shape = shapeFactory;
            

            // Last thing
            shapeFactory.DeployNewShape();
            shape.JoinPile += addToPile;
        }

        // Properties
        public IShape Shape
        {
            get
            {
                return shape;
            }
        }

        // Indexer
        public Color this[int i, int j]
        {
            get
            {
                if ((i > -1) && (i < 20) && (j > -1) && (j < 10))
                {
                    return board[i, j];
                }
                else
                {
                    throw new ArgumentException("Board error. Invalid coordinates for indexer: " + i + ", " + j);
                }
            }
        }

        // Events
        public event LinesClearedHandler LinesCleared;
        public event GameOverHandler GameOver;

        // Event Firing Methods
        protected void OnLinesCleared(int lines)
        {
            if (LinesCleared != null)
            {
                LinesCleared(lines);
            }
        }

        protected void OnGameOver()
        {
            if (GameOver != null)
            {
                GameOver();
            }
        }

        // Event Handler
        private void addToPile(IShape shape)
        {
            Point coords;

            for (int i = 0; i < shape.Length; i++)
            {
                coords = shape[i].Position;
                board[coords.Y, coords.X] = shape[i].Color;
            }

            shapeFactory.DeployNewShape();
        }

        // Methods
        // Assuming rank == dimension, 0(rows) or 1(cols) dimension
        public int GetLength(int rank)
        {
            return board.GetLength(rank);
        }
    }
}
