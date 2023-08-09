using System.Runtime.Serialization;

namespace CheckersGameLib;

[DataContract]
public class Piece : ICheckersPiece
{
    [DataMember]
    private Rank _rank;
    [DataMember]
    private Position _position;
    [DataMember]
    private PieceColor _pieceColor;
    private bool _isEaten;
    private bool _isKinged;
    // private readonly Moveset _moveset;

    public Piece()
    {
        _isEaten = false;
        _isKinged = false;
    }

    public Piece(Position position, Rank rank, PieceColor pieceColor)
    {
        _position = position;
        _rank = rank;
        _pieceColor = pieceColor;
        _isEaten = false;
        _isKinged = false;
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

    public bool GetIsEaten()
    {
        return _isEaten;
    }

    public bool SetIsEaten(bool isEaten)
    {
        _isEaten = isEaten;
        return _isEaten;
    }

    public bool GetIsKinged()
    {
        return _isKinged;
    }

    public bool SetIsKinged(bool isKinged)
    {
        _isKinged = isKinged;
        return _isKinged;
    }

    // public bool IsOccupied()
    // {
    //     int row = _position.GetRow();
    //     int col = _position.GetColumn();

    //     Position P1M1 = GetPosition();

    //     if (true)
    //     {

    //     }
    // }
}