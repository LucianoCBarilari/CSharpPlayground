namespace CSharpPlayground.Slices.TestingDojo.Level09EfCoreReady;

public sealed record StudentReadModel(
    Guid Id,
    string FullName,
    decimal AverageScore,
    bool IsActive
);

public static class StudentQueries
{
    public static IQueryable<StudentReadModel> GetHonorRoll(
        IQueryable<StudentReadModel> source,
        decimal minAverageScore = 85m
    )
    {
        ArgumentNullException.ThrowIfNull(source);

        return source
            .Where(s => s.IsActive && s.AverageScore >= minAverageScore)
            .OrderByDescending(s => s.AverageScore)
            .ThenBy(s => s.FullName);
    }
}
