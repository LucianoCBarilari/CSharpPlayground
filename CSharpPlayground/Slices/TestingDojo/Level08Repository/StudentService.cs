namespace CSharpPlayground.Slices.TestingDojo.Level08Repository;

public sealed class StudentService(IStudentRepository repository)
{
    public async Task<Student> EnrollAsync(
        Guid id,
        string fullName,
        CancellationToken cancellationToken = default
    )
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Student id is required.", nameof(id));
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Student name is required.", nameof(fullName));

        var existing = await repository.GetByIdAsync(id, cancellationToken);
        if (existing is not null)
            throw new InvalidOperationException("Student already exists.");

        var student = new Student(id, fullName);
        await repository.AddAsync(student, cancellationToken);
        await repository.SaveChangesAsync(cancellationToken);
        return student;
    }

    public async Task AssignGradeAsync(
        Guid studentId,
        decimal score,
        CancellationToken cancellationToken = default
    )
    {
        var student = await repository.GetByIdAsync(studentId, cancellationToken);
        if (student is null)
            throw new InvalidOperationException("Student not found.");

        student.AddGrade(score);
        await repository.SaveChangesAsync(cancellationToken);
    }
}
