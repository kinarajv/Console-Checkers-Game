namespace CheckersGameLib;

public class Board : IBoard
{
    private int size;

    /// <summary>
    /// Retrieve board of game's size
    /// </summary>
    /// <returns>Integer of board size</returns>
    public int GetSize()
    {
        return size;
    }

    /// <summary>
    /// Set the size of board of game
    /// </summary>
    /// <param name="size"></param>
    /// <returns>True if set is success, otherwise false</returns>
    public bool SetSize(int size)
    {
        if (size >= 8)
        {
            this.size = size;
            return true;
        }
        else
        {
            return false;
        }
    }
}