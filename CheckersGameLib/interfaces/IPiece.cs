namespace CheckersGameLib;

public interface IPiece
{
    /// <summary>
    /// Retrieve position of a piece
    /// </summary>
    /// <returns>Position of a piece that contains its row and column</returns>
    Position GetPosition();

    /// <summary>
    /// Set the position of a piece
    /// </summary>
    /// <param name="position"></param>
    /// <returns>True if set is success, otherwise false</returns>
    bool SetPosition(Position position);

    /// <summary>
    /// Retrieve color of a piece
    /// </summary>
    /// <returns>Whether black or red color of a piece</returns>
    PieceColor GetPieceColor();

    /// <summary>
    /// Set the color of a piece
    /// </summary>
    /// <param name="color"></param>
    /// <returns>True if set is success, otherwise false</returns>
    bool SetPieceColor(PieceColor color);
}