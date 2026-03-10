namespace CSharpPlayground.Slices.LanguageFeatures;

public static class LanguageFeaturesRunner
{
    public static void Run()
    {
        int[] ints = [1, 2, 3, 4, 5, 6];
        Console.WriteLine(ints.Csv);
        ints.GetEven().ToList().ForEach(i => Console.WriteLine(i));
        ints.GetOdd().ToList().ForEach(i => Console.WriteLine(i));

        var p = new Person();
        p.Name = "null";

        var x = nameof(IEnumerable<>);
        Console.WriteLine(x);

        var e = new DelegateExample();
        var ints2 = new[] { 7, 8, 9, 10 };
        e.ConvertToCsv(ints2, out var result);
        Console.WriteLine(result);

        var person = new PersonOperator(30, "John");
        Console.WriteLine(person);

        person += 5;
        Console.WriteLine(person);
    }
}
