using System;
using System.IO;

namespace WindowsSeoOptimizer.Core
{
    public class MetadataOptimizer
    {
        public void OptimizeMetadata(SeoFile file)
        {
            string name = Path.GetFileNameWithoutExtension(file.Name);
            string ext = Path.GetExtension(file.Name);

            string sanitized = SanitizeFileName(name);

            if (sanitized != name)
            {
                string newName = sanitized + ext;
                string newPath = Path.Combine(Path.GetDirectoryName(file.FullPath) ?? ".", newName);

                try
                {
                    File.Move(file.FullPath, newPath);
                    file.FullPath = newPath;
                    file.Name = newName;
                    Console.WriteLine($"  Renamed: {name}{ext} -> {sanitized}{ext}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  Error renaming {file.Name}: {ex.Message}");
                }
            }
        }

        private string SanitizeFileName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "untitled";

            name = name.Replace(" ", "-");
            name = name.Replace("_", "-");
            name = name.ToLowerInvariant();

            foreach (char c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '-');

            return name.Trim('-');
        }
    }
}