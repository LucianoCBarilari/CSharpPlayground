using CSharpPlayground.Slices.StudentGrades;
using Xunit;

namespace CSharpPlayground.Tests;

public class GradePolicyShould
{
    [Fact]
    public void GetLetterGrade_ReturnsCorrectLetter()
    {
        GradePolicy policy = new GradePolicy();
        Assert.Equal("A", policy.GetLetterGrade(95));
        Assert.Equal("B", policy.GetLetterGrade(85));
        Assert.Equal("C", policy.GetLetterGrade(75));
        Assert.Equal("D", policy.GetLetterGrade(65));
        Assert.Equal("F", policy.GetLetterGrade(55));
    }
}
