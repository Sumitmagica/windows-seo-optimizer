using System;
using System.Collections.Generic;
using System.IO;

namespace WindowsSeoOptimizer.Core
{
    public class FileScanner
    {
        public List<SeoFile> ScanDirectory(string path)
        {
            var files = new List<SeoFile>();

            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Warning: Directory '{path}' not found.");
                return files;
            }

            foreach (var filePath in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories))
            {
                var info = new FileInfo(filePath);
                files.Add(new SeoFile
                {
                    FullPath = filePath,
                    Name = info.Name,
                    SizeBytes = info.Length,
                    LastModified = info.LastWriteTime
                });
            }

            return files;
        }
    }
}