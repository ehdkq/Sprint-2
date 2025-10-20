using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_2
{
    public enum Cell { Empty, S, O }
    public enum Player { Blue, Red }
    public enum GameMode { Simple, General}

    public class SOSGame
    {
        //doesn't need win conditions for this sprint, so it's just placing and changing turns
        public int BoardSize {  get; private set; }
        public Cell[,] GameBoard { get; private set; }
        public Player CurrentTurn { get; private set; }

        //starts the game
        public void NewGame(int boardSize)
        {
            BoardSize = boardSize;
            GameBoard = new Cell[BoardSize, BoardSize]; //initializes board size
            CurrentTurn = Player.Blue; //the default player is blue
        }

        //determines if an S or an O is on the board
        public bool MakeMove(int row, int col, Cell move)
        {
            //checks if the cell is empty
            if (GameBoard[row, col] != Cell.Empty)
            {
                return false; //return false if it's an invalid move, aka the cell is not empty
            }
            GameBoard[row, col] = move;
            CurrentTurn = (CurrentTurn == Player.Blue) ? Player.Red : Player.Blue; //switches turns if there's a valid move
            return true; //returns true if it's a valid move
        }
    }
}
