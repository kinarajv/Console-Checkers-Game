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

    /// <summary>
    /// Retrieve row value of a position
    /// </summary>
    /// <returns>Integer of row value</returns>
    public int GetRow()
    {
        return _row;
    }

    /// <summary>
    /// Set a value of a row
    /// </summary>
    /// <param name="row"></param>
    /// <returns>True if set row success, otherwise false</returns>
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

    /// <summary>
    /// Retrieve column value of a position
    /// </summary>
    /// <returns>Integer of column value</returns>
    public int GetColumn()
    {
        return _column;
    }

    /// <summary>
    /// Set a value of column
    /// </summary>
    /// <param name="column"></param>
    /// <returns>True if set column value success, otherwise false</returns>
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