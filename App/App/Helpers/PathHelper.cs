using System.IO;

namespace PersonalLibraryApp.Helpers
{
    public static class PathHelper
    {
        private static string? _solutionRoot;

        public static string GetSolutionRelativePath(string relativeSubPath)
        {
            if (_solutionRoot == null)
            {
                var baseDir = AppContext.BaseDirectory;
                var dir = new DirectoryInfo(baseDir);

                // Traverse up until .sln is found
                while (dir != null && !File.Exists(Path.Combine(dir.FullName, "App.sln")))
                {
                    dir = dir.Parent;
                }

                if (dir == null)
                    throw new DirectoryNotFoundException("Could not locate solution root (.sln file)");

                _solutionRoot = dir.FullName;
            }

            return Path.Combine(_solutionRoot, relativeSubPath);
        }
    }
}
