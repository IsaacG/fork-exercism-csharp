public class ScrabbleScoreTests
{
    [Fact]
    public void Lowercase_letter()
    {
        Assert.Equal(1, ScrabbleScore.Score("a"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Uppercase_letter()
    {
        Assert.Equal(1, ScrabbleScore.Score("A"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Valuable_letter()
    {
        Assert.Equal(4, ScrabbleScore.Score("f"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Short_word()
    {
        Assert.Equal(2, ScrabbleScore.Score("at"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Short_valuable_word()
    {
        Assert.Equal(12, ScrabbleScore.Score("zoo"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Medium_word()
    {
        Assert.Equal(6, ScrabbleScore.Score("street"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Medium_valuable_word()
    {
        Assert.Equal(22, ScrabbleScore.Score("quirky"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Long_mixed_case_word()
    {
        Assert.Equal(41, ScrabbleScore.Score("OxyphenButazone"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void English_like_word()
    {
        Assert.Equal(8, ScrabbleScore.Score("pinata"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Empty_input()
    {
        Assert.Equal(0, ScrabbleScore.Score(""));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Entire_alphabet_available()
    {
        Assert.Equal(87, ScrabbleScore.Score("abcdefghijklmnopqrstuvwxyz"));
    }
}
