namespace CheckersGameLib;
using System.Runtime.Serialization;

[DataContract]
public class Position
{
    [DataMember]
    private int _row;
    [DataMember]
    private int _column;

    public Position()
    {
        // _row = 0;
        // _column = 0;
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
        if (row != _row)
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
        if (column != _column)
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