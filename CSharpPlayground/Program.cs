using System.Diagnostics;
using CSharpPlayground.Algorithms;
using Microsoft.Extensions.Configuration;

namespace CSharpPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
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

            /* ======================
               BFS Test
            ====================== */
            var bfsWatch = Stopwatch.StartNew();

            traversal.RunBfsTraversal();

            bfsWatch.Stop();
            Console.WriteLine($"BFS Elapsed time: {bfsWatch.ElapsedMilliseconds} ms");


            /* ======================
               DFS Test
            ====================== */
            var dfsWatch = Stopwatch.StartNew();

            traversal.RunDfsTraversal();

            dfsWatch.Stop();
            Console.WriteLine($"DFS Elapsed time: {dfsWatch.ElapsedMilliseconds} ms");
        }
    }
}
