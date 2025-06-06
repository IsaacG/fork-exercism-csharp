using FsCheck;
using FsCheck.Fluent;

public class DiamondTests
{
    public static readonly char[] AllLetters = GetLetterRange('A', 'Z');
    private static string[] Rows(string x) => x.Split('\n').Select(line => line.TrimEnd('\r')).ToArray();

    private static string LeadingSpaces(string x) => x.Substring(0, x.IndexOfAny(AllLetters));
    private static string TrailingSpaces(string x) => x.Substring(x.LastIndexOfAny(AllLetters) + 1);

    private static char[] GetLetterRange(char min, char max) => Enumerable.Range(min, max - min + 1).Select(i => (char) i).ToArray();

    [Fact]
    public void Diamond_is_not_empty()
    {
        Prop.ForAll(Letters, letter =>
        {
            var actual = Diamond.Make(letter);
            Assert.NotEmpty(actual);
        }).QuickCheckThrowOnFailure();
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void First_row_contains_a()
    {
        Prop.ForAll(Letters, letter =>
        {
            var actual = Diamond.Make(letter);
            var rows = Rows(actual);
            var firstRowCharacters = rows.First().Trim();

            Assert.Equal("A", firstRowCharacters);
        }).QuickCheckThrowOnFailure();
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void All_rows_must_have_symmetric_contour()
    {
        Prop.ForAll(Letters, letter =>
        {
            var actual = Diamond.Make(letter);
            var rows = Rows(actual);

            Assert.All(rows, row => { Assert.Equal(LeadingSpaces(row), TrailingSpaces(row)); });
        }).QuickCheckThrowOnFailure();
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Top_of_figure_has_letters_in_correct_order()
    {
        Prop.ForAll(Letters, letter =>
        {
            var actual = Diamond.Make(letter);
            var rows = Rows(actual);

            var expected = GetLetterRange('A', letter);
            var firstNonSpaceLetters = rows.Take(expected.Length).Select(row => row.Trim()[0]);

            Assert.Equal(firstNonSpaceLetters, expected);
        }).QuickCheckThrowOnFailure();
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Figure_is_symmetric_around_the_horizontal_axis()
    {
        Prop.ForAll(Letters, letter =>
        {
            var actual = Diamond.Make(letter);

            var rows = Rows(actual);
            var top = rows.TakeWhile(row => !row.Contains(letter));
            var bottom = rows.Reverse().TakeWhile(row => !row.Contains(letter));

            Assert.Equal(bottom, top);
        }).QuickCheckThrowOnFailure();
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Diamond_has_square_shape()
    {
        Prop.ForAll(Letters, letter =>
        {
            var actual = Diamond.Make(letter);

            var rows = Rows(actual);
            var expected = rows.Length;

            Assert.All(rows, row => { Assert.Equal(expected, row.Length); });
        }).QuickCheckThrowOnFailure();
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void All_rows_except_top_and_bottom_have_two_identical_letters()
    {
        Prop.ForAll(Letters, letter =>
        {
            var actual = Diamond.Make(letter);

            var rows = Rows(actual).Where(row => !row.Contains('A'));

            Assert.All(rows, row =>
            {
                var twoCharacters = row.Replace(" ", "").Length == 2;
                var identicalCharacters = row.Replace(" ", "").Distinct().Count() == 1;
                Assert.True(twoCharacters && identicalCharacters, "Does not have two identical letters");
            });
        }).QuickCheckThrowOnFailure();
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Bottom_left_corner_spaces_are_triangle()
    {
        Prop.ForAll(Letters, letter =>
        {
            var actual = Diamond.Make(letter);

            var rows = Rows(actual);

            var cornerSpaces = rows.Reverse().SkipWhile(row => !row.Contains(letter)).Select(LeadingSpaces);
            var spaceCounts = cornerSpaces.Select(row => row.Length).ToList();
            var expected = Enumerable.Range(0, spaceCounts.Count).Select(i => i).ToList();

            Assert.Equal(expected, spaceCounts);
        }).QuickCheckThrowOnFailure();
    }

    private static readonly Arbitrary<char> Letters = Gen.Elements("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()).ToArbitrary();
}