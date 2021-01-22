using System;

namespace TicTacToe
{
    internal class HardAI : EasyAI
    {
        private int[] Move { get; }

        internal HardAI()
        {
            Level = "hard";
            Move = new int[2];
        }

        internal override int[] GetMoveCoordinates(Match match)
        {
            //A minimax algoritmus implementációjának forrása:
            // https://github.com/CodingTrain/website/blob/main/CodingChallenges/CC_154_Tic_Tac_Toe_Minimax/P5/minimax.js

            int bestScore = -1000;
            int[] step = new int[2];

            for (int i = 0; i < match.FieldHeight; i++) 
            {
                for (int j = 0; j < match.FieldLength; j++) 
                {
                    if (match.Field[i][j] == Mark.EMPTY.Char)
                    {

                        match.Field[i][j] = Mark.Char;
                        Move[0] = i;
                        Move[1] = j;

                        int score = Minimax(match, 1, false);

                        match.Field[i][j] = Mark.EMPTY.Char;

                        if (score > bestScore) 
                        {
                            bestScore = score;
                            step[0] = i;
                            step[1] = j;
                        }
                    }
                }
            }

            Console.WriteLine("Making move level \"{0}\"\n", Level);

            return step;
        }

        private int Minimax(Match match, int depth, bool isMaximizing) 
        {

            if (match.IsWon(Move[0], Move[1]) == Mark.Char) 
            {
                return 1;
            }
            if (match.IsWon(Move[0], Move[1]) == Mark.GetOtherMark()) 
            {
                return -1;
            }
            if (match.TurnCounter + depth == 9) 
            {
                return 0;
            }

            int score;
            int bestScore = isMaximizing ? -1000 : 1000;

            for (int i = 0; i < match.FieldHeight; i++) 
            {
                for (int j = 0; j < match.FieldLength; j++) 
                {
                    if (match.Field[i][j] == Mark.EMPTY.Char) 
                    {
                        Move[0] = i;
                        Move[1] = j;

                        match.Field[i][j] = isMaximizing ? Mark.Char : Mark.GetOtherMark();

                        score = Minimax(match, depth + 1, !isMaximizing);

                        match.Field[i][j] = Mark.EMPTY.Char;

                        if (isMaximizing && score > bestScore || !isMaximizing && score < bestScore) 
                        {
                            bestScore = score;
                        }
                    }
                }
            }

            return bestScore;
        }
    }
}