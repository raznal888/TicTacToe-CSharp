using System;

namespace TicTacToe
{
    internal class Match
    {
        internal readonly int FieldHeight = 3;
        internal readonly int FieldLength = 3;
        internal char[][] Field { get;}
        private Player[] Players { get;}
        internal Player CurrentPlayer { get; private set; }
        internal int[][] PlayerMoves { get; }
        internal int TurnCounter { get; private set;}
        internal Match(Player firstPlayer, Player secondPlayer) 
        {
            Field = new char[FieldHeight][];

            for (int i = 0; i < FieldHeight; i++)
            {
                Field[i] = new char[FieldLength];
                Array.Fill(Field[i], Mark.EMPTY.Char);
            }

            Players = new[] {firstPlayer, secondPlayer};
            CurrentPlayer = firstPlayer;
            TurnCounter = 0;
            PlayerMoves = new int[2][];
            PlayerMoves[0] = new int[2];
            PlayerMoves[1] = new int[2];

            Players[0].Mark = Mark.FIRST;
            Players[1].Mark = Mark.SECOND;
        }

        private void SetField(int[] move)
        {
            Field[move[0]][move[1]] = CurrentPlayer.Mark.Char;
        }
        
        private void SwitchCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == Players[0] ? Players[1] : Players[0];
        }

        internal bool IsCellOccupied(int selectedRow, int selectedColumn) 
        {
            return Field[selectedRow - 1][selectedColumn - 1] != Mark.EMPTY.Char;
        }

        internal void Play() 
        {

            PrintField();

            bool gameNotFinished = true;
            while (gameNotFinished) 
            {

                PlayerMoves[CurrentPlayer.Mark.GetOrdinal()] = CurrentPlayer.GetMoveCoordinates(this);
                
                int[] currentMove = PlayerMoves[CurrentPlayer.Mark.GetOrdinal()];

                SetField(currentMove);

                PrintField();

                if (IsWon(currentMove[0], currentMove[1]) != Mark.EMPTY.Char) 
                {
                    break;
                }

                TurnCounter++;

                if (TurnCounter == 9) 
                {
                    gameNotFinished = false;
                    break;
                }

                SwitchCurrentPlayer();
            }

            PrintResult(gameNotFinished);

        }

        private void PrintField() 
        {
            
            Console.WriteLine("---------");
            for (int row = 0; row < FieldHeight; row++) 
            {
                
                Console.Write("| ");
                for (int column = 0; column < FieldLength; column++) 
                {
                    Console.Write(Field[row][column] + " ");
                }
                Console.WriteLine("|");

            }
            Console.WriteLine("---------");
        }

        private void PrintResult(bool gameNotFinished) 
        {
            if (gameNotFinished) 
            {
                Console.WriteLine(CurrentPlayer.Mark.Char + " wins");
            } 
            else 
            {
                Console.WriteLine("Draw");
            }
        }

        internal char IsWon(int lastMoveRow, int lastMoveColumn) 
        {

            bool wins = CheckRow(lastMoveRow) || CheckColumn(lastMoveColumn)
                        || CheckMainDiagonal() || CheckSideDiagonal();
            if (wins) 
            {
                return Field[lastMoveRow][lastMoveColumn];
            }

            return Mark.EMPTY.Char;
        }

        private bool CheckRow(int lastMoveRow) 
        {
            return Field[lastMoveRow][2] == Field[lastMoveRow][1] && Field[lastMoveRow][1] == Field[lastMoveRow][0];
        }

        private bool CheckColumn(int lastMoveColumn) 
        {
            return Field[2][lastMoveColumn] == Field[1][lastMoveColumn] && Field[1][lastMoveColumn] == Field[0][lastMoveColumn];
        }

        private bool CheckMainDiagonal() 
        {
            return Field[0][0] == Field[1][1] && Field[1][1] == Field[2][2] && Field[0][0] != Mark.EMPTY.Char;
        }

        private bool CheckSideDiagonal() 
        {
            return Field[0][2] == Field[1][1] && Field[1][1] == Field[2][0] && Field[0][2] != Mark.EMPTY.Char;
        }
        
        
        
        
    }
}