namespace CSharpPlayground.Slices.TestingDojo;

public static class TestingDojoCatalog
{
    public static IReadOnlyList<TestingExercise> Exercises { get; } =
    [
        new(1, "BasicsChallenge.CalculateDiscount", "Calculates discounts based on VIP status and price."),
        new(1, "BasicsChallenge.IsLeapYear", "Checks if a year is a leap year with classic rules."),
        new(1, "BasicsChallenge.CelsiusToFahrenheit", "Converts temperature with precision check."),
        new(2, "ValidationChallenge.IsValidUsername", "Validates length and character constraints."),
        new(2, "ValidationChallenge.ValidateOrder", "Validates order limits and throws exceptions."),
        new(2, "ValidationChallenge.IsSecurePassword", "Checks password strength (case, digits, length)."),
        new(3, "CollectionChallenge.GetEvenNumbers", "Filters with deterministic ordering."),
        new(3, "CollectionChallenge.TopScores", "Sorts and limits a score list."),
        new(3, "CollectionChallenge.GroupByPassStatus", "Partitions scores by threshold."),
        new(4, "TextDateChallenge.Slugify", "Transforms free text to URL-safe slug."),
        new(4, "TextDateChallenge.NextBusinessDay", "Skips weekends predictably."),
        new(4, "GreetingService.BuildGreeting", "Clock-driven deterministic greeting."),
        new(5, "CartService.AddItem", "State change with merge behavior."),
        new(5, "CartService.RemoveItem", "State change with validation."),
        new(5, "CartService.ApplyPercentDiscount", "Mutates state with boundaries."),
        new(6, "InvoiceNotifier.NotifyOverdueInvoices", "Isolates collaborators via interfaces."),
        new(7, "ReportAssembler.BuildCourseReport", "Rich object graph for FluentAssertions."),
        new(8, "StudentService.EnrollAsync", "Repository-backed service behavior."),
        new(8, "StudentService.AssignGradeAsync", "Mutation with repository checks."),
        new(9, "StudentQueries.GetHonorRoll", "IQueryable query for EF Core integration tests.")
    ];
}

public sealed record TestingExercise(int Level, string Method, string Goal);
