using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowsSeoOptimizer.Core
{
    public class SeoReporter
    {
        private readonly List<SeoFile> _files = new();

        public void AddFile(SeoFile file)
        {
            _files.Add(file);
        }

        public void PrintReport()
        {
            Console.WriteLine("\n--- SEO Report ---");
            Console.WriteLine($"Total files analyzed: {_files.Count}");
            Console.WriteLine($"Total size: {_files.Sum(f => f.SizeBytes) / 1024.0:F2} KB");

            var byExtension = _files.GroupBy(f => f.Extension)
                                    .Select(g => new { Extension = g.Key, Count = g.Count() })
                                    .OrderByDescending(g => g.Count);

            Console.WriteLine("\nFile type distribution:");
            foreach (var group in byExtension)
            {
                Console.WriteLine($"  {group.Extension}: {group.Count} files");
            }

            Console.WriteLine("\nOptimization complete.");
        }
    }
}