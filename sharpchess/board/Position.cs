namespace board
{
    class Position
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public override string ToString()
        {
            return Row + ", " + Col;
        }
    }
}
