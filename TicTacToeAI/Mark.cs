namespace TicTacToe
{
    internal class Mark
    {

        internal static Mark FIRST = new ('X');
        internal static Mark SECOND = new ('O');
        internal static Mark EMPTY = new ('_');

        internal char Char { get; }

        private Mark(char mark) => Char = mark;

        internal int GetOrdinal()
        {
            return Char == 'X' ? 0 : 1;
        }
        
        internal char GetOtherMark()
        {
            return this.Char == 'X' ? 'O' : 'X';
        }

    }
}