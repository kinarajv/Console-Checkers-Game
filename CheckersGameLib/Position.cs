namespace CheckersGameLib;

public class Position
{
    private int _row;
    private int _column;

    public Position()
    {
    }

    public Position(int row, int column)
    {
        _row = row;
        _column = column;
    }

    public int GetRow()
    {
        return _row;
    }

    public bool SetRow(int row)
    {
        if (row != 0)
        {
            _row = row;
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetColumn()
    {
        return _column;
    }

    public bool SetColumn(int column)
    {
        if (column != 0)
        {
            _column = column;
            return true;
        }
        else
        {
            return false;
        }
    }
}