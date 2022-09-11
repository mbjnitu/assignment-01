namespace Assignment1.Tests;
using FluentAssertions;
using Xunit;

public class IteratorsTests
{
    [Fact]
    public void flatten_given_list_of_lists_w_0to9_returns_list_0to8() {

        // Arrange
        var m = new List<List<int>>() {
            new List<int> {0, 1, 2},
            new List<int> {3, 4, 5},
            new List<int> {6, 7, 8}
        };

        // Act
        var n = Iterators.Flatten(m);

        // Assert 
        n.Should().BeEquivalentTo(new List<int>() {0, 1, 2, 3, 4, 5, 6, 7, 8});
    }

    [Fact]
    public void mmm() {

        // Arrange
        var m = new List<int>() {
            0, 1, 2, 3, 4, 5, 6, 7, 8
        };

        Predicate<int> even = Even;
        bool Even(int i) => i % 2 == 0;

        // Act
        var n = Iterators.Filter(m, even);

        // Assert 
        n.Should().BeEquivalentTo(new List<int>() {0, 2, 4, 6, 8});
    }
}