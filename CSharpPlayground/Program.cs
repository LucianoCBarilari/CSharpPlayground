using CSharpPlayground.Slices.Algorithms;
using CSharpPlayground.Slices.Exercises;
using CSharpPlayground.Slices.LanguageFeatures;
using CSharpPlayground.Slices.Patterns;
using CSharpPlayground.Slices.StudentGrades;
using CSharpPlayground.Slices.TestingDojo;

namespace CSharpPlayground;

internal static class Program
{
    private static readonly Dictionary<string, Action> SliceRunners =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["language"] = LanguageFeaturesRunner.Run,
            ["patterns"] = PatternsRunner.Run,
            ["algorithms"] = AlgorithmsRunner.Run,
            ["exercises"] = ExercisesRunner.Run,
            ["grades"] = StudentGradesRunner.Run,
            ["testing"] = TestingDojoRunner.Run
        };

    private static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            RunSlice(args[0]);
        }

        while (true)
        {
            ShowMenu();
            Console.Write("Select an option (name/number, 0 to exit): ");

            var input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter a valid option.");
                ContinuePrompt();
                continue;
            }

            if (input == "0")
            {
                Console.WriteLine("Exiting...");
                break;
            }

            if (int.TryParse(input, out var optionIndex))
            {
                var sliceName = GetSliceNameByIndex(optionIndex);
                if (sliceName is null)
                {
                    Console.WriteLine("Invalid option number.");
                    ContinuePrompt();
                    continue;
                }

                RunSlice(sliceName);
                ContinuePrompt();
                continue;
            }

            RunSlice(input);
            ContinuePrompt();
        }
    }

    private static void RunSlice(string requestedSlice)
    {
        if (!SliceRunners.TryGetValue(requestedSlice, out var runSlice))
        {
            Console.WriteLine($"Unknown slice '{requestedSlice}'.");
            Console.WriteLine(
                $"Available slices: {string.Join(", ", SliceRunners.Keys)}"
            );
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"Running slice: {requestedSlice}");
        runSlice();
    }

    private static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("=== CSharp Playground ===");
        Console.WriteLine("Available slices:");

        var index = 1;
        foreach (var key in SliceRunners.Keys)
        {
            Console.WriteLine($"{index}. {key}");
            index++;
        }

        Console.WriteLine("0. exit");
        Console.WriteLine();
    }

    private static string? GetSliceNameByIndex(int optionIndex)
    {
        if (optionIndex < 1 || optionIndex > SliceRunners.Count)
            return null;

        return SliceRunners.Keys.ElementAt(optionIndex - 1);
    }

    private static void ContinuePrompt()
    {
        Console.WriteLine();
        Console.Write("Press Enter to continue...");
        Console.ReadLine();
    }
}
