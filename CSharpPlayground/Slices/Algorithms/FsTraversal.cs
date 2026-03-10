/**
 * BFS (Breadth-First Search)
 *
 * This algorithm traverses a hierarchical structure (in this case, the file
 * system) by exploring nodes level by level, not by depth.
 *
 * The core idea of BFS is:
 * - Discover all elements of the current level first
 * - Mark each element as processed
 * - Only then advance to the next levels
 *
 * In this implementation:
 * - Each discovered directory is registered with a state (Pending / Processed)
 * - New directories are added as Pending
 * - Each iteration takes a single Pending directory
 * - That directory is explored and its subdirectories are registered
 * - Then it is marked as Processed
 *
 * The algorithm ends when there are no more Pending directories.
 *
 * This behavior matches BFS because:
 * - It does not immediately descend into a deep branch
 * - Directories are processed in the order they were discovered
 * - Traversal control is based on a set of pending nodes,
 *   not on recursion or a stack (Stack)
 *
 * BFS is suitable for:
 * - Full scans of hierarchical structures
 * - Processing by layers or levels
 * - Avoiding excessive depth (stack overflow)
 * - Explicit control of traversal state
 */

/**
 * DFS (Depth-First Search)
 *
 * This algorithm traverses a hierarchical structure (in this case, the file
 * system) by exploring nodes in depth before continuing with other branches.
 *
 * The core idea of DFS is:
 * - Explore a full branch before moving to other branches
 * - Descend into subdirectories until none remain
 * - Backtrack automatically to continue the traversal
 *
 * In this implementation:
 * - A stack is used to store pending directories
 * - Each iteration takes the last directory added to the stack
 * - Its subdirectories are explored and pushed back onto the stack
 *
 * The algorithm ends when the stack is empty.
 *
 * This behavior matches DFS because:
 * - The traversal prioritizes depth over levels
 * - Backtracking is performed automatically via the stack
 * - It does not rely on recursion, but on an explicit stack
 *
 * DFS is suitable for:
 * - Full processing of hierarchical structures per branch
 * - Migrations or ETL where you want to process a whole folder before continuing
 * - Scenarios where you want to minimize simultaneous global state
 */

namespace CSharpPlayground.Slices.Algorithms
{
    public class FsTraversal
    {
        private readonly string rootPath;

        private readonly Dictionary<string, Status> directoryStateMap = new();

        public FsTraversal(string rootPath)
        {
            this.rootPath = rootPath ?? string.Empty;
        }

        /* ===========================
           BFS Traversal
        =========================== */
        public void RunBfsTraversal()
        {
            foreach (var entry in GetSubDirectories(rootPath))
            {
                directoryStateMap.TryAdd(entry.Key, entry.Value);
            }

            bool hasPendingDirectories = true;

            while (hasPendingDirectories)
            {
                var pendingDirectoryPath = directoryStateMap
                    .FirstOrDefault(entry => entry.Value == Status.Pending)
                    .Key;

                if (!string.IsNullOrWhiteSpace(pendingDirectoryPath))
                {
                    var discoveredDirectories =
                        GetSubDirectories(pendingDirectoryPath);

                    foreach (var discoveredEntry in discoveredDirectories)
                    {
                        directoryStateMap.TryAdd(
                            discoveredEntry.Key,
                            discoveredEntry.Value
                        );
                    }

                    directoryStateMap[pendingDirectoryPath] = Status.Processed;
                }
                else
                {
                    hasPendingDirectories = false;
                }
            }
        }

        /* ===========================
           DFS Traversal
        =========================== */
        public void RunDfsTraversal()
        {
            Stack<string> menuStack = new();
            menuStack.Push(rootPath);

            while (menuStack.Count > 0)
            {
                string currentPath = menuStack.Pop();

                // Normally you would process the current folder here
                // Ej: Console.WriteLine(currentPath);

                var subDirectories = Explorer(currentPath);

                foreach (var submenu in subDirectories)
                {
                    menuStack.Push(submenu);
                }
            }
        }

        private List<string> Explorer(string currentPath)
        {
            if (string.IsNullOrWhiteSpace(currentPath))
                return new();

            if (!Directory.Exists(currentPath))
                return new();

            return Directory.GetDirectories(currentPath).ToList();
        }

        private Dictionary<string, Status> GetSubDirectories(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
                return new();

            if (!Directory.Exists(directoryPath))
                return new();

            return Directory.GetDirectories(directoryPath)
                .ToDictionary(
                    subDirectoryPath => subDirectoryPath,
                    _ => Status.Pending
                );
        }
    }
}

   


