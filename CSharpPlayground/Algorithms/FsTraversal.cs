/**
 * BFS (Breadth-First Search - Búsqueda en Anchura)
 *
 * Este algoritmo recorre una estructura jerárquica (en este caso, el sistema
 * de archivos) explorando los nodos por niveles, no por profundidad.
 *
 * La idea central de BFS es:
 * - Descubrir primero todos los elementos del nivel actual
 * - Marcar cada elemento como procesado
 * - Recién después avanzar a los niveles siguientes
 *
 * En esta implementación:
 * - Cada directorio descubierto se registra con un estado (Pending / Processed)
 * - Los directorios nuevos se agregan como Pending
 * - En cada iteración se toma un único directorio Pending
 * - Ese directorio se explora, se registran sus subdirectorios
 * - Luego se marca como Processed
 *
 * El algoritmo finaliza cuando no existen más directorios en estado Pending.
 *
 * Este comportamiento corresponde a BFS porque:
 * - No se desciende inmediatamente en una rama profunda
 * - Los directorios se procesan en el orden en que fueron descubiertos
 * - El control del recorrido se basa en un conjunto de nodos pendientes,
 *   no en llamadas recursivas ni en una pila (Stack)
 *
 * BFS es adecuado para:
 * - Escaneo completo de estructuras jerárquicas
 * - Procesamiento por capas o niveles
 * - Evitar profundización excesiva (stack overflow)
 * - Tener control explícito del estado del recorrido
 */

 /**
 * DFS (Depth-First Search - Búsqueda en Profundidad)
 *
 * Este algoritmo recorre una estructura jerárquica (en este caso, el sistema
 * de archivos) explorando los nodos en profundidad antes de continuar con otras ramas.
 *
 * La idea central de DFS es:
 * - Explorar una rama completa antes de continuar con otras ramas
 * - Descender en subdirectorios hasta que no existan más
 * - Retroceder automáticamente para continuar el recorrido
 *
 * En esta implementación:
 * - Se utiliza una pila (Stack) para almacenar los directorios pendientes
 * - Cada iteración toma el último directorio agregado al Stack
 * - Se exploran sus subdirectorios y se agregan nuevamente al Stack
 *
 * El algoritmo finaliza cuando el Stack queda vacío.
 *
 * Este comportamiento corresponde a DFS porque:
 * - El recorrido prioriza profundidad sobre niveles
 * - Se realiza backtracking automático mediante la pila
 * - No depende de recursión, sino de una pila explícita
 *
 * DFS es adecuado para:
 * - Procesamiento completo de estructuras jerárquicas por rama
 * - Migraciones o ETL donde se desea procesar una carpeta completa antes de continuar
 * - Escenarios donde se busca minimizar estado global simultáneo
 */

namespace CSharpPlayground.Algorithms
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

                // Aquí normalmente se procesaría la carpeta actual
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

   

