using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _120326_hw
{
    internal static class SaveSystem
    {
        private static string DirectoryName = "saveDirectory";
        private static string FileName = "player";

        public static void Save(string newInfo)
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), DirectoryName);
            FileHelper.DirectoryExist(directoryPath);
            string filePath = Path.Combine(directoryPath, FileName);

            FileHelper.FileExists(filePath);
            FileHelper.WriteFile(filePath, newInfo);
        }

        public static string Load()
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), DirectoryName);
            FileHelper.DirectoryExist(directoryPath);
            string filePath = Path.Combine(directoryPath, FileName);

            FileHelper.FileExists(filePath);
            return FileHelper.ReadFile(filePath);
        }
    }
}
