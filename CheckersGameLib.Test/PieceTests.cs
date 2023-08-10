namespace CheckersGameLib.Test;

public class PieceTests
{
    private Piece _piece;

    [SetUp]
    public void Setup()
    {
        _piece = new Piece();
    }

    [TestCase(Rank.King)]
    [TestCase(Rank.Basic)]
    public void GetRankTest(Rank expected)
    {
        _piece.SetRank(expected);
        Rank actual = _piece.GetRank();
        Assert.That(expected, Is.EqualTo(actual));
    }

    [TestCase(Rank.King)]
    [TestCase(Rank.Basic)]
    public void SetRankTest(Rank rank)
    {
        bool actual = _piece.SetRank(rank);
        Assert.That(actual, Is.True);
    }
}
