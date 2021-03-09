using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.IO.Path;
using static System.IO.Directory;

namespace AntiqueEye.Models
{
    public struct PathInfo
    {
        public static PathInfo Create(string path)
        {
            return new PathInfo
            {
                DirectoryName = GetDirectoryName(path),
                Extension = GetExtension(path),
                FileName = GetFileName(path),
                FileNameWithoutExtension = GetFileNameWithoutExtension(path),
                PathRoot = GetPathRoot(path),
                FullPath = GetFullPath(path),
                HasExtension = HasExtension(path),
                IsPathRoot = IsPathRooted(path),
                DirectoryRoot = GetDirectoryRoot(path),
                ParentDirectory = GetParent(path)
            };
        }

        public string DirectoryName { get; set; }

        public string Extension { get; set; }

        public string FileName { get; set; }

        public string FileNameWithoutExtension { get; set; }

        public string PathRoot { get; set; }

        public string FullPath { get; set; }

        public bool HasExtension { get; set; }

        public bool IsPathRoot { get; set; }

        public string DirectoryRoot { get; set; }

        public DirectoryInfo ParentDirectory { get; set; }
    }
}
