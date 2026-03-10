namespace CSharpPlayground.Slices.TestingDojo.Level08Repository;

public sealed class Student
{
    private readonly List<decimal> grades = [];

    public Student(Guid id, string fullName)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Student id is required.", nameof(id));
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Student name is required.", nameof(fullName));

        Id = id;
        FullName = fullName.Trim();
    }

    public Guid Id { get; }
    public string FullName { get; }
    public IReadOnlyList<decimal> Grades => grades;

    public void AddGrade(decimal score)
    {
        if (score < 0m || score > 100m)
            throw new ArgumentOutOfRangeException(nameof(score), "Score must be between 0 and 100.");

        grades.Add(score);
    }
}

public interface IStudentRepository
{
    Task<Student?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Student student, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Student>> ListAsync(CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
