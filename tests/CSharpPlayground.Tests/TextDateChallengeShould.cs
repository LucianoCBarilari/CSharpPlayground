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
}
