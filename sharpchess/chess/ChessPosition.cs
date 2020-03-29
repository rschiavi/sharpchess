using board;

namespace chess
{
    class ChessPosition
    {
        public int Row { get; set; }
        public char Col { get; set; }

        public ChessPosition(char col, int row)
        {
            Row = row;
            Col = col;
        }

        public Position ToPosition()
        {
            return new Position(8 - Row, Col - 'a');
        }

        public override string ToString()
        {
            return $"{Col}{Row}";
        }
    }
}
