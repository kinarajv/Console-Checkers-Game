namespace CheckersGameLib;

public interface IPiece
{
    Position GetPosition();
    bool SetPosition(Position position);

    PieceColor GetPieceColor();
    bool SetPieceColor(PieceColor color);
}