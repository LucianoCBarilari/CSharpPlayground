using CSharpPlayground.Slices.TestingDojo.Level02Validation;
using Xunit;

namespace CSharpPlayground.Tests;

public class ValidationChallengeShould
{
    [Theory]
    [InlineData(" ",false )]
    [InlineData(null,false)]
    [InlineData("User/*pepe",false)]
    [InlineData("UserpepeUserpepeUserpepeUserpepe",false)]
    [InlineData("UserOk",true)]
    [InlineData("User",false)]
    public void IsValidUsername_VariousScenarios_ReturnsExpected(string? user,bool expected)
    {
         ValidationChallenge challenge = new();

         var result = challenge.IsValidUsername(user);

         Assert.Equal(expected,result);

    }
    [Theory]
    [InlineData(-10,5,typeof(ArgumentOutOfRangeException))]
    [InlineData(10,-5,typeof(ArgumentException))]
    [InlineData(10,11,typeof(ValidationException))]
    public void ValidateOrder_VariousScenarios_ReturnsExpected(decimal total, int item,Type expectedException)
    {
        ValidationChallenge challenge = new();

         Assert.Throws(expectedException,()=>challenge.ValidateOrder(total,item));
    }
    [Fact]
    public void ValidateOrder_ValidData_DoesNotThrow()
    {
        ValidationChallenge challenge = new();
        challenge.ValidateOrder(100, 5);
    }

    [Theory]
    [InlineData(" ",false)]
    [InlineData("abcde",false)]
    [InlineData("abcdefgh",false)]
    [InlineData("ABCDEFGH",false)]
    [InlineData("12345678",false)]
    [InlineData("Abcd5678",true)]
    public void IsSecurePassword_VariousScenarios_ReturnsExpected(string password,bool expected)
    {
        ValidationChallenge challenge = new();
        var result = challenge.IsSecurePassword(password);

        Assert.Equal(expected,result);
    }
}
