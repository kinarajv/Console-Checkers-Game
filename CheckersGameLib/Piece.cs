namespace CheckersGameLib;

public class Piece
{
    private Rank _rank;
    private Position _position;
    private PieceColor _pieceColor;

    public Rank GetRank()
    {
        return _rank;
    }

    public bool SetRank(Rank rank)
    {
        if (rank.Equals(_rank))
        {
            _rank = rank;
            return true;
        }
        else
        {
            return false;
        }
    }
    public Position GetPosition()
    {
        return _position;
    }

    public bool SetPosition(Position position)
    {
        if (position != null)
        {
            _position = position;
            return true;
        }
        else
        {
            return false;
        }
    }

    public PieceColor GetPieceColor()
    {
        return _pieceColor;
    }

    public bool SetPieceColor(PieceColor pieceColor)
    {
        if (pieceColor.Equals(this._pieceColor))
        {
            this._pieceColor = pieceColor;
            return true;
        }
        else
        {
            return false;
        }
    }
}