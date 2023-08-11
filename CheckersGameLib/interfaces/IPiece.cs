namespace CheckersGameLib;

public interface IPiece
{
    /// <summary>
    /// Retrieve position of a checkers piece
    /// </summary>
    /// <returns>position of a checkers piece that contains its row and column</returns>
    Position GetPosition();

    /// <summary>
    /// Set the position of a checkers piece
    /// </summary>
    /// <param name="position"></param>
    /// <returns>true if set is success, otherwise false</returns>
    bool SetPosition(Position position);

    /// <summary>
    /// Retrieve color of a checkers piece
    /// </summary>
    /// <returns>whether black or red color of a piece</returns>
    PieceColor GetPieceColor();

    /// <summary>
    /// Set the color of a checkers piece
    /// </summary>
    /// <param name="color"></param>
    /// <returns>true if set is success, otherwise false</returns>
    bool SetPieceColor(PieceColor color);
}