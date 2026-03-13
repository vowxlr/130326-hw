using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _120326_hw
{
    internal static class FileHelper
    {
        public static void DirectoryExist(string path)
        {
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public static void FileExists(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }
        public static string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public static void WriteFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }
    }
}
