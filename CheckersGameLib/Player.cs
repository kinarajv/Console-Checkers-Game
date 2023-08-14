namespace CheckersGameLib;

/// <summary>
/// Represent of player information such as name and id
/// </summary>
public class Player : IPlayer
{
    private string _name;
    private int _id;

    /// <summary>
    /// Initialize default player information
    /// </summary>
    public Player()
    {
        _name = null;
        _id = 0;
    }

    /// <summary>
    /// Initialize player information with input name
    /// </summary>
    /// <param name="name"></param>
    public Player(string name)
    {
        _name = name;
    }

    /// <summary>
    /// Retrieve name of player
    /// </summary>
    /// <returns>String of player name</returns>
    public string GetName()
    {
        return _name;
    }

    /// <summary>
    /// Set name of player
    /// </summary>
    /// <param name="name"></param>
    /// <returns>True if set name of player success, otherwise false</returns>
    public bool SetName(string name)
    {
        if (name != null)
        {
            _name = name;
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Retrieve Id of player
    /// </summary>
    /// <returns>Integer of player Id</returns>
    public int GetID()
    {
        return _id;
    }

    /// <summary>
    /// Set id of a player
    /// </summary>
    /// <param name="id"></param>
    /// <returns>True if set id of player success, otherwise false</returns>
    public bool SetID(int id)
    {
        if (id != 20000)
        {
            _id = id;
            return true;
        }
        else
        {
            return false;
        }
    }
}