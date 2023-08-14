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
    public void SetRankTest(Rank rank)
    {
        bool actual = _piece.SetRank(rank);
        Assert.That(actual, Is.True);
    }

    [TestCase(false, false)]
    [TestCase(true, true)]
    public void SetIsEatenTest(bool input, bool expected)
    {
        bool actual = _piece.SetIsEaten(input);
        Assert.That(expected, Is.EqualTo(actual));
    }

    [TestCase(false, false)]
    [TestCase(true, true)]
    public void SetIsKingedTest(bool input, bool expected)
    {
        bool actual = _piece.SetIsKinged(input);
        Assert.That(expected, Is.EqualTo(actual));
    }

    [Test]
    public void SetPositionTest()
    {
        Position position = new Position(0, 1);
        bool expected = true;

        bool actual = _piece.SetPosition(position);
        Assert.That(expected, Is.EqualTo(actual));
    }
}
