namespace CSharpPlayground.Slices.TestingDojo.Level07FluentAssertions;

public sealed class ReportAssembler
{
    public CourseReport BuildCourseReport(string courseName, IEnumerable<StudentScore> scores)
    {
        if (string.IsNullOrWhiteSpace(courseName))
            throw new ArgumentException("Course name is required.", nameof(courseName));
        ArgumentNullException.ThrowIfNull(scores);

        var list = scores.ToList();
        var average = list.Count == 0 ? 0m : list.Average(s => s.Score);

        return new CourseReport(
            courseName.Trim(),
            average,
            list
                .OrderByDescending(s => s.Score)
                .ThenBy(s => s.StudentName, StringComparer.OrdinalIgnoreCase)
                .Select(s => new StudentResult(
                    s.StudentName,
                    s.Score,
                    s.Score >= 60m ? "Passed" : "Failed"
                ))
                .ToList()
        );
    }
}

public sealed record StudentScore(string StudentName, decimal Score);

public sealed record StudentResult(string StudentName, decimal Score, string Status);

public sealed record CourseReport(
    string CourseName,
    decimal AverageScore,
    IReadOnlyList<StudentResult> Results
);
