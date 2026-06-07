using System;

namespace WindowsSeoOptimizer.Core
{
    public class SeoFile
    {
        public string FullPath { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public long SizeBytes { get; set; }
        public DateTime LastModified { get; set; }

        public string Extension => System.IO.Path.GetExtension(Name);
        public bool IsRenamed { get; set; }
    }
}