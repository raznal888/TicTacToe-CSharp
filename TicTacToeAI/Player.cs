namespace TicTacToe
{
    internal abstract class Player
    {
        internal Mark Mark { get; set;}

        internal static Player Of(string type)
        {
            switch(type) 
            {
                case "user":
                    return new User();
                case "easy":
                    return new EasyAI();
                case "medium":
                    return new MediumAI();
                case "hard":
                    return new HardAI();
                default:
                    return null;
            }
        }
        
        internal abstract int[] GetMoveCoordinates(Match match);
    }
}