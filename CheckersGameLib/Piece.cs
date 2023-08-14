using System.Runtime.Serialization;

namespace CheckersGameLib;

/// <summary>
/// Represent a piece detail
/// </summary>
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

    /// <summary>
    /// Initial piece detail with isEaten and isKinged value are false
    /// </summary>
    public Piece()
    {
        _isEaten = false;
        _isKinged = false;
    }

    /// <summary>
    /// Initial piece detail with desired position, rank, and pieceColor
    /// </summary>
    /// <param name="position"></param>
    /// <param name="rank"></param>
    /// <param name="pieceColor"></param>
    public Piece(Position position, Rank rank, PieceColor pieceColor)
    {
        _position = position;
        _rank = rank;
        _pieceColor = pieceColor;
        _isEaten = false;
        _isKinged = false;
    }

    /// <summary>
    /// Retrieve rank of the checkers piece
    /// </summary>
    /// <returns>Whether basic rank or king rank of the checkers piece</returns>
    public Rank GetRank()
    {
        return _rank;
    }


    /// <summary>
    /// Set the rank of a checkers piece
    /// </summary>
    /// <param name="rank"></param>
    /// <returns>True if set success, otherwise false</returns>
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

    /// <summary>
    /// Retrieve position of a piece
    /// </summary>
    /// <returns>Position of a piece that contains its row and column</returns>
    public Position GetPosition()
    {
        return _position;
    }

    /// <summary>
    /// Set the position of a piece
    /// </summary>
    /// <param name="position"></param>
    /// <returns>True if set is success, otherwise false</returns>
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

    /// <summary>
    /// Retrieve color of a piece
    /// </summary>
    /// <returns>Whether black or red color of a piece</returns>
    public PieceColor GetPieceColor()
    {
        return _pieceColor;
    }

    /// <summary>
    /// Set the color of a piece
    /// </summary>
    /// <param name="color"></param>
    /// <returns>True if set is success, otherwise false</returns>
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

    /// <summary>
    /// Retrieve isEaten value of the checkers piece
    /// </summary>
    /// <returns>Whether true or false based on isEaten value</returns>    
    public bool GetIsEaten()
    {
        return _isEaten;
    }

    /// <summary>
    /// Set the isEaten field of a checkers piece
    /// </summary>
    /// <param name="isEaten"></param>
    /// <returns>Value of isEaten field</returns>
    public bool SetIsEaten(bool isEaten)
    {
        _isEaten = isEaten;
        return _isEaten;
    }


    /// <summary>
    /// Retrieve isKinged value of the checkers piece
    /// </summary>
    /// <returns>Whether true or false based on isKinged value</returns>    
    public bool GetIsKinged()
    {
        return _isKinged;
    }

    /// <summary>
    /// Set the isEaten field of a checkers piece
    /// </summary>
    /// <param name="isKinged"></param>
    /// <returns>Value of isKinged field</returns>
    public bool SetIsKinged(bool isKinged)
    {
        _isKinged = isKinged;
        return _isKinged;
    }
}