using CSharpPlayground.Slices.Patterns.Composite;

namespace CSharpPlayground.Slices.Patterns;

public static class PatternsRunner
{
    public static void Run()
    {
        var groups = CompositeFactory.BuildTree();
        Console.WriteLine($"Composite groups: {groups.Count}");

        var firstGroupWithChildren = groups.FirstOrDefault(g => g.ChildNode.Count > 0);
        if (firstGroupWithChildren is null)
        {
            Console.WriteLine("No selectable nodes found.");
            return;
        }

        firstGroupWithChildren.ChildNode[0].Select();
        var selectedIds = groups.SelectMany(g => g.GetSelectedIds()).ToList();
        Console.WriteLine($"Selected IDs: {string.Join(", ", selectedIds)}");
    }
}
