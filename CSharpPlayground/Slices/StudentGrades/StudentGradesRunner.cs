namespace CSharpPlayground.Slices.StudentGrades;

public static class StudentGradesRunner
{
    public static void Run()
    {
        var policy = new GradePolicy();
        var student = new Student("S-1001", "Alice Johnson");

        student.AddGrade(95);
        student.AddGrade(78);
        student.AddGrade(88);

        var total = student.GetTotalScore();
        var average = student.GetAverageScore();
        var letter = policy.GetLetterGrade(average);
        var isPassing = policy.IsPassing(average);

        Console.WriteLine($"Student: {student.Name} ({student.Id})");
        Console.WriteLine($"Grades: {string.Join(", ", student.Grades)}");
        Console.WriteLine($"Total score: {total}");
        Console.WriteLine($"Average score: {average:F2}");
        Console.WriteLine($"Letter grade: {letter}");
        Console.WriteLine($"Passing: {isPassing}");
    }
}
