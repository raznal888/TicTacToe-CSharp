using System;

namespace TicTacToe
{
    internal class EasyAI : Player
    {
        protected string Level { get; init; }

        internal EasyAI()
        {
            Level = "easy";
        }
        
        internal override int[] GetMoveCoordinates(Match match) 
        {

            Console.WriteLine("Making move level \"{0}\"\n", Level);

            return GetRandomCoordinates(match);
        }

        internal int[] GetRandomCoordinates(Match match)
        {
            Random random = new Random();

            int[] coordinates = new int[2];
            
            bool moveNotValid = true;
            while (moveNotValid)
            {
                int selectedRow = random.Next(match.FieldHeight) + 1;
                int selectedColumn = random.Next(match.FieldLength) + 1;

                if (match.IsCellOccupied(selectedRow, selectedColumn))
                {
                    continue;
                }

                coordinates[0] = selectedRow - 1;
                coordinates[1] = selectedColumn - 1;

                moveNotValid = false;
            }

            return coordinates;
        }
    }
}