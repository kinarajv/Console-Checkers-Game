namespace CheckersGameLib;

/// <summary>
/// Represent any moveset a piece can have
/// </summary>
public class Moveset
{
    /// <summary>
    /// Retrieve list of single move of a checkers game, whether it's for basic piece or king piece
    /// </summary>
    /// <param name="piece"></param>
    /// <returns>List of position that include any single move</returns>
    public List<Position> SingleMove(ICheckersPiece piece)
    {
        int row = piece.GetPosition().GetRow();
        int col = piece.GetPosition().GetColumn();
        List<Position> positions = new List<Position>();
        if (piece.GetRank().Equals(Rank.Basic))
        {
            if (piece.GetPieceColor().Equals(PieceColor.Black))
            {
                positions.Add(new Position(row + 1, col + 1));
                positions.Add(new Position(row + 1, col - 1));
            }
            else
            {
                positions.Add(new Position(row - 1, col + 1));
                positions.Add(new Position(row - 1, col - 1));
            }
        }
        else
        {
            positions.Add(new Position(row + 1, col + 1));
            positions.Add(new Position(row + 1, col - 1));
            positions.Add(new Position(row - 1, col + 1));
            positions.Add(new Position(row - 1, col - 1));
        }
        return positions;
    }

    /// <summary>
    /// Retrieve list of single jump move of a checkers game, whether it's for basic piece or king piece
    /// </summary>
    /// <param name="piece"></param>
    /// <returns>List of position that include any single jump move</returns>
    public List<Position> SingleJumpMove(ICheckersPiece piece)
    {
        int row = piece.GetPosition().GetRow();
        int col = piece.GetPosition().GetColumn();
        List<Position> positions = new List<Position>();
        if (piece.GetRank().Equals(Rank.Basic))
        {
            if (piece.GetPieceColor().Equals(PieceColor.Black))
            {
                positions.Add(new Position(row + 2, col + 2));
                positions.Add(new Position(row + 2, col - 2));
            }
            else
            {
                positions.Add(new Position(row - 2, col + 2));
                positions.Add(new Position(row - 2, col - 2));
            }
        }
        else
        {
            positions.Add(new Position(row + 2, col + 2));
            positions.Add(new Position(row + 2, col - 2));
            positions.Add(new Position(row - 2, col + 2));
            positions.Add(new Position(row - 2, col - 2));
        }
        return positions;
    }

    /// <summary>
    /// Retrieve list of double jump move of a checkers game, whether it's for basic piece or king piece
    /// </summary>
    /// <param name="piece"></param>
    /// <returns>List of position that include any double jump move</returns>
    public List<Position> DoubleJumpMove(ICheckersPiece piece)
    {
        int row = piece.GetPosition().GetRow();
        int col = piece.GetPosition().GetColumn();
        List<Position> positions = new List<Position>();
        if (piece.GetRank().Equals(Rank.Basic))
        {
            if (piece.GetPieceColor().Equals(PieceColor.Black))
            {
                positions.Add(new Position(row + 4, col + 4));
                positions.Add(new Position(row + 4, col - 4));
                positions.Add(new Position(row + 4, col - 0));
            }
            else
            {
                positions.Add(new Position(row - 4, col + 4));
                positions.Add(new Position(row - 4, col - 4));
                positions.Add(new Position(row - 4, col - 0));
            }
        }
        else
        {
            positions.Add(new Position(row + 4, col + 4));
            positions.Add(new Position(row + 4, col - 4));
            positions.Add(new Position(row - 4, col + 4));
            positions.Add(new Position(row - 4, col - 4));
            positions.Add(new Position(row + 4, col));
            positions.Add(new Position(row - 4, col));
            positions.Add(new Position(row, col - 4));
            positions.Add(new Position(row, col + 4));
        }
        return positions;
    }
}
