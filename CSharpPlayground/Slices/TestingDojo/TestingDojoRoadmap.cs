namespace CSharpPlayground.Slices.TestingDojo;

public static class TestingDojoRoadmap
{
    public static IReadOnlyList<TestingPhase> Phases { get; } =
    [
        new(
            1,
            "Tiny Pure Functions",
            "Assert basics, naming, Arrange-Act-Assert"
        ),
        new(
            2,
            "Input Validation",
            "Boundary values, invalid inputs, exception assertions"
        ),
        new(
            3,
            "Collections and Filtering",
            "Data-driven tests with [Theory] and [InlineData]"
        ),
        new(
            4,
            "String and Date Rules",
            "Culture-safe checks, deterministic behavior"
        ),
        new(
            5,
            "Stateful Services",
            "Setup/teardown, fixtures, avoiding test coupling"
        ),
        new(
            6,
            "Dependency Isolation",
            "Mocks/stubs/fakes for collaborators"
        ),
        new(
            7,
            "FluentAssertions",
            "Readable assertions, object and collection equivalence"
        ),
        new(
            8,
            "Repository Pattern",
            "Service tests against repository abstractions"
        ),
        new(
            9,
            "EF Core Integration Slice",
            "InMemory/SQLite test DB, mapping checks, realistic flows"
        ),
        new(
            10,
            "Hardening",
            "Regression suites, bug reproduction tests, refactor safety"
        )
    ];
}

public sealed record TestingPhase(int Level, string Title, string Focus);
