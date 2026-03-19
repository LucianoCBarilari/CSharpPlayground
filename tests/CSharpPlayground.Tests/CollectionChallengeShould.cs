using CSharpPlayground.Slices.TestingDojo.Level03Collections;
using Xunit;

namespace CSharpPlayground.Tests;

public class CollectionChallengeShould
{
    [Theory]
    [InlineData(new int[]{ 80, 90, 100 },90)]
    [InlineData(new int[] { 0, 100 }, 50.0)]                                                                
    [InlineData(new int[] { }, 0.0)]                                                                        
    [InlineData(null, 0.0)]
    public void CalculateAverageScore_VariousScenarios_ReturnsExpected(int[]? scoreArray,double expected)
    {
        CollectionChallenge challenge = new();

        var result = challenge.CalculateAverageScore(scoreArray?.ToList());

        Assert.Equal(expected, result,1);
    }
    
    [Theory]
    [MemberData(nameof(GetActiveUsernames_TestData))]
    public void GetActiveUsernames_VariousScenarios_ReturnsExpected(List<UserAccount> userAccount,List<string> expected) 
    {
        CollectionChallenge challenge = new();

        var result = challenge.GetActiveUsernames(userAccount);

        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(HasDuplicateIds_TestData))]
    public void HasDuplicateIds_TestData_VariousScenarios_ReturnsExpected(List<int>? identifier,bool hasOrNot) 
    {
        CollectionChallenge challenge = new();

        var result = challenge.HasDuplicateIds(identifier);

        Assert.Equal(hasOrNot, result);
    }

    public static IEnumerable<object[]> GetActiveUsernames_TestData()
    {
        yield return new object[] 
        { 
            new List<UserAccount>
                {
                    new UserAccount { Username = "user1", IsActive = true },
                    new UserAccount { Username = "user2", IsActive = false },
                    new UserAccount { Username = "user3", IsActive = true },
                }, 
            new List<string> { "user1", "user3" } 
        };
        yield return new object[] 
        { 
            new List<UserAccount>
                {
                    new UserAccount { Username = "user1", IsActive = false },
                    new UserAccount { Username = "user2", IsActive = false },
                    new UserAccount { Username = "user3", IsActive = false },
                }, new List<string>() 
        };
        yield return new object[] { null, new List<string>() };
    }

    public static IEnumerable<object[]> HasDuplicateIds_TestData()
    {
        yield return new object[]
        {
                new List<int>{ 1,2,3,4,5,6, },
                false
        };
        yield return new object[]
        {
            null,
            false
        };
        yield return new object[]
       {
                new List<int>{ 1,2,1,4,1,6, },
                true
       };
    }

}