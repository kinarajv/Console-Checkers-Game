namespace CheckersGameLib;

public class Board : IBoard
{
    private int size;

    public int GetSize()
    {
        return size;
    }

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