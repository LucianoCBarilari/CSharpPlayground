using CSharpPlayground.Slices.TestingDojo.Level04TextDate;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace CSharpPlayground.Tests;

public class GreetingServiceShould
{
    public class TestClock : IClock
    {
        public DateTime UtcNow { get; set; }
    }
    [Fact]
    public void BuildGreeting_CurrentDateTime_ReturnExpected()
    {
        var testClock = new TestClock();
        testClock.UtcNow = new DateTime(2026, 3, 16, 9, 0, 0);

        GreetingService greetingService = new(testClock);

        string userName = "UserExpected";
        var result = greetingService.BuildGreeting(userName);

        Assert.Contains(userName, result);
        Assert.Equal("Good morning, UserExpected", result);
    }
    [Theory]
    [MemberData(nameof(GetGreetingData))]
    public void BuildGreeting_ThreeDateTime_Expected(DateTime testDate, string currentUser, string expected)
    {
        var testClock = new TestClock { UtcNow = testDate };

        GreetingService greetingService = new(testClock);

        var result = greetingService.BuildGreeting(currentUser);

        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> GetGreetingData()
    {        
         yield return new object[] 
         {
             new DateTime(2026, 3, 16, 9, 0, 0), "Pepe", "Good morning, Pepe" 
         };
         yield return new object[] 
         { 
             new DateTime(2026, 3, 16, 15, 0, 0), "Pepe", "Good afternoon, Pepe" 
         };
         yield return new object[] 
         { 
             new DateTime(2026, 3, 16, 20, 0, 0), "Pepe", "Good evening, Pepe" 
         };
    }
} 

