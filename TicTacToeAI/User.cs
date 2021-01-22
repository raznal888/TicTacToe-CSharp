using System;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    internal class User : Player
    {
        internal override int[] GetMoveCoordinates(Match match)
        {
            return EnterCoordinates(match);
        }
        
        private int[] EnterCoordinates(Match match) {
            int[] coordinates = new int[2];

            bool moveNotValid = true;
            while (moveNotValid) {
                Console.Write("Enter the coordinates: ");
                string input = Console.ReadLine();

                Regex isNumeric = new Regex("\\d\\s\\d");

                if(!isNumeric.IsMatch(input)) {
                    Console.WriteLine("You should enter numbers!");
                    continue;
                }

                String[] inputParts = input.Split(" ");
                int selectedRow = Int32.Parse(inputParts[0]);
                int selectedColumn = Int32.Parse(inputParts[1]);

                if (!(selectedRow >= 1 && selectedRow <= 3) || !(selectedColumn >= 1 && selectedColumn <= 3)) {
                    Console.WriteLine("Coordinates should be from 1 to 3!");
                    continue;
                }

                if (match.IsCellOccupied(selectedRow, selectedColumn)) {
                    Console.WriteLine("This cell is occupied! Choose another one!");
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