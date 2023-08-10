namespace CheckersGameLib;

public interface ICheckers
{
    Rank GetRank();
    bool SetRank(Rank rank);

    bool GetIsEaten();
    bool SetIsEaten(bool isEaten);

    bool GetIsKinged();
    bool SetIsKinged(bool isKinged);
}
