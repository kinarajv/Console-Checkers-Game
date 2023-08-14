namespace CheckersGameLib
{
    public class Moveset
    {
        private List<Position> GetPositions(ICheckersPiece piece, int rowOffset, int colOffset)
        {
            int row = piece.GetPosition().GetRow();
            int col = piece.GetPosition().GetColumn();
            List<Position> positions = new List<Position>();

            if (piece.GetRank().Equals(Rank.Basic))
            {
                if (piece.GetPieceColor().Equals(PieceColor.Black))
                {
                    positions.Add(new Position(row + rowOffset, col + colOffset));
                    positions.Add(new Position(row + rowOffset, col - colOffset));
                }
                else
                {
                    positions.Add(new Position(row - rowOffset, col + colOffset));
                    positions.Add(new Position(row - rowOffset, col - colOffset));
                }
            }
            else
            {
                positions.Add(new Position(row + rowOffset, col + colOffset));
                positions.Add(new Position(row + rowOffset, col - colOffset));
                positions.Add(new Position(row - rowOffset, col + colOffset));
                positions.Add(new Position(row - rowOffset, col - colOffset));
            }

            return positions;
        }

        public List<Position> SingleMove(ICheckersPiece piece)
        {
            return GetPositions(piece, 1, 1);
        }

        public List<Position> SingleJumpMove(ICheckersPiece piece)
        {
            return GetPositions(piece, 2, 2);
        }

        public List<Position> DoubleJumpMove(ICheckersPiece piece)
        {
            List<Position> positions = GetPositions(piece, 4, 4);
            if (piece.GetRank().Equals(Rank.King))
            {
                positions.Add(new Position(piece.GetPosition().GetRow() + 4, piece.GetPosition().GetColumn()));
                positions.Add(new Position(piece.GetPosition().GetRow() - 4, piece.GetPosition().GetColumn()));
                positions.Add(new Position(piece.GetPosition().GetRow(), piece.GetPosition().GetColumn() - 4));
                positions.Add(new Position(piece.GetPosition().GetRow(), piece.GetPosition().GetColumn() + 4));
            }
            return positions;
        }
    }
}
