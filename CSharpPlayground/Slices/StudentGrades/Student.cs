namespace CSharpPlayground.Slices.StudentGrades;

public sealed class Student
{
    private readonly List<decimal> grades = [];

    public Student(string id, string name)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Student id is required.", nameof(id));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Student name is required.", nameof(name));

        Id = id;
        Name = name;
    }

    public string Id { get; }
    public string Name { get; }
    public IReadOnlyList<decimal> Grades => grades;

    public void AddGrade(decimal grade)
    {
        if (grade < 0 || grade > 100)
            throw new ArgumentOutOfRangeException(
                nameof(grade),
                "Grade must be between 0 and 100."
            );

        grades.Add(grade);
    }

    public decimal GetTotalScore()
    {
        return grades.Sum();
    }

    public decimal GetAverageScore()
    {
        return grades.Count == 0 ? 0 : grades.Average();
    }
}
