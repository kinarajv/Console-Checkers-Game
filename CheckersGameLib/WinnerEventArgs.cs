namespace CheckersGameLib;

/// <summary>
/// Include a IPlayer class to give an information about the winner of the game
/// </summary>
public class WinnerEventArgs : EventArgs
{
    public IPlayer Player { get; }

    /// <summary>
    /// Initialize player who win the game
    /// </summary>
    /// <param name="player"></param>
    public WinnerEventArgs(IPlayer player)
    {
        Player = player;
    }
}