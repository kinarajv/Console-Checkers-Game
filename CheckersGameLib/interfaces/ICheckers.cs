namespace CheckersGameLib;

public interface ICheckers
{
    /// <summary>
    /// Retrieve rank of the checkers piece
    /// </summary>
    /// <returns>whether basic rank or king rank of the checkers piece</returns>
    Rank GetRank();

    /// <summary>
    /// Set the rank of a checkers piece
    /// </summary>
    /// <param name="rank"></param>
    /// <returns>true if set success, otherwise false</returns>
    bool SetRank(Rank rank);

    /// <summary>
    /// Retrieve isEaten value of the checkers piece
    /// </summary>
    /// <returns>whether true or false based on isEaten value</returns>    
    bool GetIsEaten();

    /// <summary>
    /// Set the isEaten field of a checkers piece
    /// </summary>
    /// <param name="isEaten"></param>
    /// <returns>return the value of the isEaten field</returns>
    bool SetIsEaten(bool isEaten);

    /// <summary>
    /// Retrieve isKinged value of the checkers piece
    /// </summary>
    /// <returns>whether true or false based on isKinged value</returns>    
    bool GetIsKinged();

    /// <summary>
    /// Set the isEaten field of a checkers piece
    /// </summary>
    /// <param name="isKinged"></param>
    /// <returns>return the value of the isKinged field</returns>
    bool SetIsKinged(bool isKinged);
}
