using System;
using System.IO;
using WindowsSeoOptimizer.Core;
using Xunit;

namespace WindowsSeoOptimizer.Tests
{
    public class SeoOptimizerTests
    {
        [Fact]
        public void SanitizeFileName_ReplacesSpacesWithHyphens()
        {
            var optimizer = new MetadataOptimizer();
            var file = new SeoFile
            {
                FullPath = Path.Combine(Path.GetTempPath(), "hello world.txt"),
                Name = "hello world.txt"
            };

            optimizer.OptimizeMetadata(file);

            Assert.Contains("hello-world.txt", file.Name);
        }

        [Fact]
        public void FileScanner_ReturnsEmptyForMissingDirectory()
        {
            var scanner = new FileScanner();
            var files = scanner.ScanDirectory(@"C:\nonexistent_path_xyz_123");

            Assert.Empty(files);
        }
    }
}