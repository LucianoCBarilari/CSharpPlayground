namespace CSharpPlayground.Slices.TestingDojo.Level04TextDate;

public interface IClock
{
    DateTime UtcNow { get; }
}

public class SystemClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}

public class GreetingService(IClock clock)
{
    public string BuildGreeting(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("User name is required.", nameof(userName));

        var hour = clock.UtcNow.Hour;
        var greeting = hour switch
        {
            < 12 => "Good morning",
            < 18 => "Good afternoon",
            _ => "Good evening"
        };

        return $"{greeting}, {userName.Trim()}";
    }
}
