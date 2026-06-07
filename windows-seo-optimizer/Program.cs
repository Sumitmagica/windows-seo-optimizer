using System;
using System.IO;
using WindowsSeoOptimizer.Core;

namespace WindowsSeoOptimizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Windows SEO Optimizer v1.0");
            Console.WriteLine("===========================\n");

            var scanner = new FileScanner();
            var optimizer = new MetadataOptimizer();
            var reporter = new SeoReporter();

            string targetPath = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();

            var files = scanner.ScanDirectory(targetPath);
            Console.WriteLine($"Found {files.Count} files to analyze.\n");

            foreach (var file in files)
            {
                optimizer.OptimizeMetadata(file);
                reporter.AddFile(file);
            }

            reporter.PrintReport();
        }
    }
}