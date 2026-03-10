using CSharpPlayground.Slices.TestingDojo.Level02Validation;
using Xunit;

namespace CSharpPlayground.Tests.Slices.TestingDojo;

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
}
