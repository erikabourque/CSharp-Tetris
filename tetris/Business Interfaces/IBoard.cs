using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Tetris.tmep;

namespace Tetris
{
    // Author: Erika Bourque
    // Date: 29/02/2016
    // Version: 2.5

    // Delegates
    public delegate void LinesClearedHandler(int numOfLines);
    public delegate void GameOverHandler();

    public interface IBoard
    {
        // Property
        IShape Shape { get; }

        // Indexer
        Color this[int i, int j] { get; }        
        
        // Events
        event LinesClearedHandler LinesCleared;
        event GameOverHandler GameOver;

        // Methods
        int GetLength(int rank);
    }
}
