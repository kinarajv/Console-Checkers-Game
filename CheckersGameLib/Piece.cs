namespace CheckersGameLib;

public class Piece
{
    private bool _isEaten = false;
    private Rank _rank;
    private Position _position;
    private PieceColor _pieceColor;

    public bool GetIsEaten()
    {
        return _isEaten;
    }

    public bool SetIsEaten(bool isEaten)
    {
        if (_isEaten != isEaten)
        {
            _isEaten = isEaten;
            return true;
        }
        return false;
    }

    public Rank GetRank()
    {
        return _rank;
    }

    public bool SetRank(Rank rank)
    {
        foreach (string ranks in Enum.GetNames(typeof(Rank)))
        {
            if (Enum.GetName(rank).Equals(ranks))
            {
                _rank = rank;
                return true;
            }
        }
        return false;
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
        foreach (string color in Enum.GetNames(typeof(PieceColor)))
        {
            if (Enum.GetName(pieceColor).Equals(color))
            {
                _pieceColor = pieceColor;
                return true;
            }
        }
        return false;
    }
}