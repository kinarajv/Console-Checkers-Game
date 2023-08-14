namespace CheckersGameLib;

public interface IPlayer
{
    /// <summary>
    /// Retrieve name of player
    /// </summary>
    /// <returns>String of player name</returns>
    string GetName();

    /// <summary>
    /// Set name of player
    /// </summary>
    /// <param name="name"></param>
    /// <returns>True if set name of player success, otherwise false</returns>
    bool SetName(string name);

    /// <summary>
    /// Retrieve Id of player
    /// </summary>
    /// <returns>Integer of player Id</returns>
    int GetID();

    /// <summary>
    /// Set id of a player
    /// </summary>
    /// <param name="id"></param>
    /// <returns>True if set id of player success, otherwise false</returns>
    bool SetID(int id);
}