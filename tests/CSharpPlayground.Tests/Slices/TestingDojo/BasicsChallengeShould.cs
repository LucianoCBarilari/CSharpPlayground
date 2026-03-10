using CSharpPlayground.Slices.TestingDojo.Level01Basics;
using Xunit;

namespace CSharpPlayground.Tests.Slices.TestingDojo;
public class BasicsChallengeShould
{
    [Theory]
    [InlineData(0, true, 0)]
    [InlineData(-10, true, 0)]  
    [InlineData(100, true, 20)]
    [InlineData(200, true, 40)]
    [InlineData(150, false, 15)]
    [InlineData(100, false, 0)]
    public void CalculateDiscount_VariousScenarios_ReturnsExpectedDiscount(decimal price, bool isVip, decimal expected)
    {
        var challenge = new BasicsChallenge();
        var result = challenge.CalculateDiscount(price, isVip);

        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(1900,false)]
    [InlineData(1988776545,false)]
    [InlineData(-100,false)]
    [InlineData(2020,true)]
    public void IsLeapYear_VariousScenarios_ReturnsExpected(int year, bool expected)
    {
        var challenge = new BasicsChallenge();
        var result = challenge.IsLeapYear(year);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(0, 32)]
    [InlineData(100, 212)]
    [InlineData(-40, -40)]
    [InlineData(37, 98.6)]
    public void CelsiusToFahrenheit_VariousInputs_ReturnsCorrectFahrenheit(double celsius, double expected)
    {
        var challenge = new BasicsChallenge();
        var result = challenge.CelsiusToFahrenheit(celsius);
        Assert.Equal(expected, result, 1);
    }
}
