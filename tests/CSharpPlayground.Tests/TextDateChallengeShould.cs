using System.ComponentModel;
using CSharpPlayground.Slices.TestingDojo.Level04TextDate;
using Xunit;

namespace CSharpPlayground.Tests;

public class TextDateChallengeShould
{
    [Theory]
    [InlineData(" ","")]
    [InlineData("pepe campeon", "pepe-campeon")]
    [InlineData(" ¡Hola Mundo 2026! ", "hola-mundo-2026")]
    [InlineData("pepe campeon numero 1", "pepe-campeon-numero-1")]
    [InlineData("C# es lo mejor", "c-es-lo-mejor")]
    [InlineData("Hola!!!! Mundo", "hola-mundo")]
    public void Slugify_Some_ReturnExpected(string input,string? expected) 
    {
        TextDateChallenge textDateChallenge = new();

        var result = textDateChallenge.Slugify(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(WeekendData))]
    public void NextBusinessDay_WhenInputIsWeekend_ShouldReturnFollowingMonday(
        DateOnly input,
        DateOnly expected)
    {
        TextDateChallenge textDateChallenge = new();

        var result = textDateChallenge.NextBusinessDay(input);

        Assert.Equal(expected, result);
    }

    public static TheoryData<DateOnly, DateOnly> WeekendData => new()
    {
        { new DateOnly(2026, 3, 28), new DateOnly(2026, 3, 30) }, 
        { new DateOnly(2026, 3, 29), new DateOnly(2026, 3, 30) }, 
    };
			
}
