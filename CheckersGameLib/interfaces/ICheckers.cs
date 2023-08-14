namespace CheckersGameLib;

public interface ICheckers
{
    /// <summary>
    /// Retrieve rank of the checkers piece
    /// </summary>
    /// <returns>Whether basic rank or king rank of the checkers piece</returns>
    Rank GetRank();

    /// <summary>
    /// Set the rank of a checkers piece
    /// </summary>
    /// <param name="rank"></param>
    /// <returns>True if set success, otherwise false</returns>
    bool SetRank(Rank rank);

    /// <summary>
    /// Retrieve isEaten value of the checkers piece
    /// </summary>
    /// <returns>Whether true or false based on isEaten value</returns>    
    bool GetIsEaten();

    /// <summary>
    /// Set the isEaten field of a checkers piece
    /// </summary>
    /// <param name="isEaten"></param>
    /// <returns>Value of isEaten field</returns>
    bool SetIsEaten(bool isEaten);

    /// <summary>
    /// Retrieve isKinged value of the checkers piece
    /// </summary>
    /// <returns>Whether true or false based on isKinged value</returns>    
    bool GetIsKinged();

    /// <summary>
    /// Set the isEaten field of a checkers piece
    /// </summary>
    /// <param name="isKinged"></param>
    /// <returns>Value of isKinged field</returns>
    bool SetIsKinged(bool isKinged);
}
