namespace Assignment1.Tests;
using FluentAssertions;
using Xunit;

public class RegExprTests
{
    [Fact]
    public void SplitLine_given_lines_of_garbage_returns_words_in_garbage() {

        // Arrange
        var lines = new string[]{"hello", "my friend im", "cool092 and92 9292 cool"};

        // Act
        var n = RegExpr.SplitLine(lines);

        // Assert 
        n.Should().BeEquivalentTo(new List<string>() {"hello", "my", "friend", "im", "cool092", "and92", "9292", "cool"});
    }

    [Fact]
    public void Resolution_given_1920x1080_andmore_returns_tuple_1920_1080_andmore() {

        // Arrange
        var line = "1920x1080, 720x800, 12020x12020 00x00";

        // Act
        var r = RegExpr.Resolution(line);

        // Assert 
        r.Should().BeEquivalentTo(new List<(int width, int height)> {(1920, 1080), (720, 800), (12020, 12020), (00, 00)});
    }

    [Fact]
    public void InnerText_given_example_with_a_from_assignment_returns_correct() {

        // Arrange
        var line =
        @"<div>
            <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=""https://en.wikipedia.org/wiki/Theoretical_computer_science"" title=""Theoretical computer science"">theoretical computer science</a> and <a href=""https://en.wikipedia.org/wiki/Formal_language"" title=""Formal language"">formal language</a> theory, a sequence of <a href=""https://en.wikipedia.org/wiki/Character_(computing)"" title=""Character (computing)"">characters</a> that define a <i>search <a href=""https://en.wikipedia.org/wiki/Pattern_matching"" title=""Pattern matching"">pattern</a></i>. Usually this pattern is then used by <a href=""https://en.wikipedia.org/wiki/String_searching_algorithm"" title=""String searching algorithm"">string searching algorithms</a> for ""find"" or ""find and replace"" operations on <a href=""https://en.wikipedia.org/wiki/String_(computer_science)"" title=""String (computer science)"">strings</a>.</p>
        </div>";

        var tag = "a";

        // Act
        var r = RegExpr.InnerText(line, tag);

        // Assert 
        r.Should().BeEquivalentTo(new List<string>
                                        {
                                            "theoretical computer science",
                                            "formal language",
                                            "characters", 
                                            "pattern",
                                            "string searching algorithms",
                                            "strings"
                                        });
    }

    [Fact]
    public void InnerText_given_example_with_p_from_assignment_returns_correct() {

        // Arrange
        var line =
        @"<div>
            <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p>
        </div>";

        var tag = "p";

        // Act
        var r = RegExpr.InnerText(line, tag);

        // Assert 
        r.Should().BeEquivalentTo(new List<string>
                                        {
                                            "The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to.",
                                        });
    }
}