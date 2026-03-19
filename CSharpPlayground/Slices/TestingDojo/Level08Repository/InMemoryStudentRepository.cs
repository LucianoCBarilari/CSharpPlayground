namespace CSharpPlayground.Slices.TestingDojo.Level08Repository;

public sealed class InMemoryStudentRepository : IStudentRepository
{
    private readonly Dictionary<Guid, Student> students = new();

    public Task<Student?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        students.TryGetValue(id, out var student);
        return Task.FromResult(student);
    }

    public Task AddAsync(Student student, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(student);
        students[student.Id] = student;
        return Task.CompletedTask;
    }

    public Task<IReadOnlyList<Student>> ListAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IReadOnlyList<Student>>(students.Values.ToList());
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}
