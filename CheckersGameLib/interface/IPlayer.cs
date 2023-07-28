namespace CheckersGameLib;

public interface IPlayer
{
    string GetName();
    bool SetName(string name);
    int GetID();
    bool SetID(int id);
}