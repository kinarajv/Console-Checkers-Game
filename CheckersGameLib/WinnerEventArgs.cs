namespace CheckersGameLib;

public class WinnerEventArgs : EventArgs
{
    public IPlayer Player { get; }

    public WinnerEventArgs(IPlayer player)
    {
        Player = player;
    }
}