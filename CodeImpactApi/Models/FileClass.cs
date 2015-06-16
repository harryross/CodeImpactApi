using System.Collections.Generic;

namespace CodeImpactApi.Models
{
    public class FileClass
    {
        public string File { get; set; }
        public FileType Type { get; set; }
        public List<string> Methods { get; set; }
        public string FullClassName { get; set; }
        public string ClassName { get; set; }
        public string Kind { get; set; }
        public bool IsWebsiteClas { get; set; }
    }

    public enum FileType
    {
        CSharp
    }
}