namespace CSharpPlayground.Slices.TestingDojo;

public static class TestingDojoRunner
{
    public static void Run()
    {
        Console.WriteLine("Testing Dojo slice loaded.");
        Console.WriteLine("Goal: train QA thinking with xUnit in progressive levels.");
        Console.WriteLine();

        foreach (var phase in TestingDojoRoadmap.Phases)
        {
            Console.WriteLine(
                $"[{phase.Level}] {phase.Title} -> {phase.Focus}"
            );
        }

        Console.WriteLine();
        Console.WriteLine("Exercise catalog:");
        foreach (var exercise in TestingDojoCatalog.Exercises.OrderBy(x => x.Level))
        {
            Console.WriteLine(
                $"- L{exercise.Level}: {exercise.Method} | {exercise.Goal}"
            );
        }

        Console.WriteLine();
        Console.WriteLine("Tests folder: tests/CSharpPlayground.Tests/Slices/TestingDojo/");
    }
}
