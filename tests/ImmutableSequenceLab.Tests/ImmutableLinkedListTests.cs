using ImmutableSequenceLab.DataStructures;

namespace ImmutableSequenceLab.Tests;

public class ImmutableLinkedListTests
{
    [Fact]
    public void Push_ShouldAddValueAtFront()
    {
        // Arrange
        var original = ImmutableLinkedList<int>.Empty;

        // Act
        var result = original.Push(5);

        // Assert
        Assert.Equal(5, result.Value);
        Assert.Same(original, result.Tail);
    }

    [Fact]
    public void Push_ShouldNotModifyOriginalList()
    {
        // Arrange
        var original = ImmutableLinkedList<int>.Empty;
        original = original.Push(10);

        // Act
        var result = original.Push(5);

        // Assert
        Assert.Equal(10, original.Value);
        Assert.Equal(5, result.Value);
        Assert.Same(original, result.Tail);
    }

    [Fact]
    public void Count_ShouldReturnNumberOfElements()
    {
        // Arrange
        var list = ImmutableLinkedList<int>.Empty;
        list = list.Push(10);
        list = list.Push(20);
        list = list.Push(30);

        // Act
        var count = list.Count();

        // Assert
        Assert.Equal(3, count);
    }
    [Fact]
public void Contains_ShouldReturnTrueWhenValueExists()
{
    // Arrange
    var list = ImmutableLinkedList<int>.Empty;
    list = list.Push(10);
    list = list.Push(20);
    list = list.Push(30);

    // Act
    var result = list.Contains(20);

    // Assert
    Assert.True(result);
}
[Fact]
public void Contains_ShouldReturnFalseWhenValueDoesNotExist()
{
    // Arrange
    var list = ImmutableLinkedList<int>.Empty;
    list = list.Push(10);
    list = list.Push(20);
    list = list.Push(30);

    // Act
    var result = list.Contains(99);

    // Assert
    Assert.False(result);
}[Fact]
public void Reverse_ShouldReverseTheList()
{
    // Arrange
    var list = ImmutableLinkedList<int>.Empty;
    list = list.Push(10);
    list = list.Push(20);
    list = list.Push(30);

    // Act
    var reversed = list.Reverse();

    // Assert
    Assert.Equal(10, reversed.Value);
    Assert.Equal(20, reversed.Tail!.Value);
    Assert.Equal(30, reversed.Tail!.Tail!.Value);
}
[Fact]
public void StringMethods_ShouldProduceSameResult()
{
    // Arrange
    var list = ImmutableLinkedList<int>.Empty;
    list = list.Push(10);
    list = list.Push(20);
    list = list.Push(30);

    // Act
    var naive = list.ToNaiveString();
    var builder = list.ToBuilderString();

    // Assert
    Assert.Equal(naive, builder);
}
}