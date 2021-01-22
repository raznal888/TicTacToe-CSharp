using System;

namespace TicTacToe
{
    internal class MediumAI : EasyAI
    {
        internal MediumAI()
        {
            Level = "medium";
        }
        
        internal override int[] GetMoveCoordinates(Match match) 
        {

            Console.WriteLine("Making move level \"{0}\"\n", Level);

            return CheckForMove(match);
        }

        private int[] CheckForMove(Match match) {

            //A közepes nehézségi fokozat esetén a gép ellenőrzi, hogy saját maga vagy az ellenfél egy lépésre van-e
            //a győzelemtől. Ha igen, akkor úgy lép, hogy győzzön vagy megakadályozza az ellenfél győzelmét.
            //Más esetben véletlenszerűen lépked.

            if (match.TurnCounter >= 3) 
            {
                int[][] moves = new int[2][];
                moves[0] = CanWinInOneMove(match, match.PlayerMoves[match.CurrentPlayer.Mark.GetOrdinal()]);
                moves[1] = CanWinInOneMove(match, match.PlayerMoves[1 - match.CurrentPlayer.Mark.GetOrdinal()]);

                if (moves[0] != null) 
                {
                    return moves[0];
                } 
                
                if (moves[1] != null) 
                {
                    return moves[1];
                }
            }

            return GetRandomCoordinates(match);
        }

        private int[] CanWinInOneMove(Match match, int[] move) {

            int[] coordinates = {-1, -1};

            char currentMove = match.Field[move[0]][move[1]];
            for (int i = 0; i < match.FieldHeight; i++) {
                for (int j = 0; j < match.FieldLength; j++) {

                    //Sorok ellenőrzése

                    if (currentMove == match.Field[move[0]][i] && i != move[1]) {
                        coordinates[0] = move[0];
                        coordinates[1] = (2 - move[1]) + (2 - i) - 1;

                        if (!match.IsCellOccupied(coordinates[0] + 1, coordinates[1] + 1)) {
                            return coordinates;
                        }
                    }

                    //Oszlopok ellenőrzése

                    if (currentMove == match.Field[i][move[1]] && i != move[0]) {
                        coordinates[0] = (2 - move[0]) + (2 - i) - 1;
                        coordinates[1] = move[1];

                        if (!match.IsCellOccupied(coordinates[0] + 1, coordinates[1] + 1)) {
                            return coordinates;
                        }
                    }

                    if (i != move[0] && j != move[1] && currentMove == match.Field[i][j]) {

                        //Főátló ellenőrzése

                        if (move[0] == move[1] && i == j) {
                            coordinates[0] = (2 - move[0]) + (2 - i) - 1;
                            coordinates[1] = coordinates[0];

                            if (!match.IsCellOccupied(coordinates[0] + 1, coordinates[1] + 1)) {
                                return coordinates;
                            }
                        }

                        //Mellékátló ellenőrzése

                        if (move[0] + move[1] == 2 && i + j == 2 && currentMove == match.Field[i][j]) {
                            coordinates[0] = (2 - move[0]) + (2 - i) - 1;
                            coordinates[1] = 2 - coordinates[0];

                            if (!match.IsCellOccupied(coordinates[0] + 1, coordinates[1] + 1)) {
                                return coordinates;
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}