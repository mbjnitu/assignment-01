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
}