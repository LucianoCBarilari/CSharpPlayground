using System.Diagnostics;
using CSharpPlayground.Algorithms;
using CSharpPlayground.Patterns.Composite;
using Microsoft.Extensions.Configuration;

namespace CSharpPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .Build();

            var rootPath = config["Traversal:RootPath"] ?? string.Empty;

            if (string.IsNullOrWhiteSpace(rootPath))
            {
                Console.WriteLine("Traversal:RootPath is empty. Set it in appsettings.json to run traversals.");
                return;
            }

            var traversal = new FsTraversal(rootPath);

            // BFS Test
            var bfsWatch = Stopwatch.StartNew();
            traversal.RunBfsTraversal();
            bfsWatch.Stop();
            Console.WriteLine($"BFS Elapsed time: {bfsWatch.ElapsedMilliseconds} ms");

            // DFS Test
            var dfsWatch = Stopwatch.StartNew();
            traversal.RunDfsTraversal();
            dfsWatch.Stop();
            Console.WriteLine($"DFS Elapsed time: {dfsWatch.ElapsedMilliseconds} ms");
            */

            var tree = CompositeFactory.BuildTree();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Composite Demo");
                Console.WriteLine("1. List tree");
                Console.WriteLine("2. Toggle Group");
                Console.WriteLine("3. Toggle Item");
                Console.WriteLine("4. Show selected Item IDs");
                Console.WriteLine("0. Exit");
                Console.Write("Option: ");

                var input = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                if (input == "0")
                {
                    break;
                }

                if (input == "1")
                {
                    PrintTree(tree);
                    continue;
                }

                if (input == "2")
                {
                    Console.Write("Group Id: ");
                    if (!int.TryParse(Console.ReadLine(), out var orgId))
                    {
                        Console.WriteLine("Invalid Group Id.");
                        continue;
                    }

                    var group = tree.FirstOrDefault(o => o.Id == orgId);
                    if (group == null)
                    {
                        Console.WriteLine("Group not found.");
                        continue;
                    }

                    if (group.IsSelected)
                    {
                        group.Deselect();
                    }
                    else
                    {
                        group.Select();
                    }

                    continue;
                }

                if (input == "3")
                {
                    Console.Write("Group Id: ");
                    if (!int.TryParse(Console.ReadLine(), out var orgId))
                    {
                        Console.WriteLine("Invalid Group Id.");
                        continue;
                    }

                    Console.Write("Item Id: ");
                    if (!int.TryParse(Console.ReadLine(), out var escId))
                    {
                        Console.WriteLine("Invalid Item Id.");
                        continue;
                    }

                    var group = tree.FirstOrDefault(o => o.Id == orgId);
                    if (group == null)
                    {
                        Console.WriteLine("Group not found.");
                        continue;
                    }

                    var item = group.ChildNode
                        .OfType<ItemNode>()
                        .FirstOrDefault(e => e.Id == escId);

                    if (item == null)
                    {
                        Console.WriteLine("Item not found.");
                        continue;
                    }

                    if (item.IsSelected)
                    {
                        item.Deselect();
                    }
                    else
                    {
                        item.Select();
                    }

                    continue;
                }

                if (input == "4")
                {
                    var selectedIds = tree
                        .SelectMany(o => o.GetSelectedIds())
                        .Distinct()
                        .OrderBy(id => id)
                        .ToList();

                    Console.WriteLine(selectedIds.Count == 0
                        ? "No Items selected."
                        : $"Selected Item IDs: {string.Join(", ", selectedIds)}");
                    continue;
                }

                Console.WriteLine("Unknown option.");
            }
        }

        private static void PrintTree(List<GroupNode> tree)
        {
            foreach (var org in tree.OrderBy(o => o.Id))
            {
                Console.WriteLine($"[{(org.IsSelected ? "X" : " ")}] Group {org.Id} - {org.Name}");
                foreach (var child in org.ChildNode.OfType<ItemNode>().OrderBy(c => c.Id))
                {
                    Console.WriteLine($"  [{(child.IsSelected ? "X" : " ")}] Item {child.Id} - {child.Name}");
                }
            }
        }
    }
}
