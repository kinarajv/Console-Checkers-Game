namespace CheckersGameLib;

public interface IBoard
{
    /// <summary>
    /// Retrieve board of game's size
    /// </summary>
    /// <returns>Integer of board size</returns>
    int GetSize();

    /// <summary>
    /// Set the size of board of game
    /// </summary>
    /// <param name="size"></param>
    /// <returns>True if set is success, otherwise false</returns>
    bool SetSize(int size);
}
