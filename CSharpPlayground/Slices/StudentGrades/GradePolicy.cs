namespace CSharpPlayground.Slices.StudentGrades;

public class GradePolicy
{
    public GradePolicy(decimal passingScore = 60)
    {
        if (passingScore < 0 || passingScore > 100)
            throw new ArgumentOutOfRangeException(
                nameof(passingScore),
                "Passing score must be between 0 and 100."
            );

        PassingScore = passingScore;
    }

    public decimal PassingScore { get; }

    public bool IsPassing(decimal averageScore)
    {
        return averageScore >= PassingScore;
    }

    public string GetLetterGrade(decimal averageScore)
    {
        if (averageScore >= 90) return "A";
        if (averageScore >= 80) return "B";
        if (averageScore >= 70) return "C";
        if (averageScore >= 60) return "D";
        return "F";
    }
}
