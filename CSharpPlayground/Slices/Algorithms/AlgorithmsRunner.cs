namespace CSharpPlayground.Slices.Algorithms;

public static class AlgorithmsRunner
{
    public static void Run()
    {
        var rootPath = Directory.GetCurrentDirectory();
        var traversal = new FsTraversal(rootPath);

        traversal.RunBfsTraversal();
        traversal.RunDfsTraversal();

        Console.WriteLine($"Traversal executed on: {rootPath}");
    }
}
