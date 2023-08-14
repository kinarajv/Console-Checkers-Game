namespace CheckersGameLib;

public interface IPlayer
{
    /// <summary>
    /// Retrieve name of player
    /// </summary>
    /// <returns>string of player name</returns>
    string GetName();

    /// <summary>
    /// Set name of player
    /// </summary>
    /// <param name="name"></param>
    /// <returns>true if set name of player success, otherwise false</returns>
    bool SetName(string name);

    /// <summary>
    /// Retrieve Id of player
    /// </summary>
    /// <returns>integer of player Id</returns>
    int GetID();

    /// <summary>
    /// Set id of a player
    /// </summary>
    /// <param name="id"></param>
    /// <returns>true if set id of player success, otherwise false</returns>
    bool SetID(int id);
}