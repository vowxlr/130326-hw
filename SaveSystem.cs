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
        private static string FileName = "players.txt";
        private static string FileLeaderBoardName = "leaderboard.txt";
        private static string Separator = "---";
        private static string GetFilePath()
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), DirectoryName);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            return Path.Combine(directoryPath, FileName);
        }
        public static List<PlayerProfile> LoadAllPlayers()
        {
            string filePath = GetFilePath();
            if (!File.Exists(filePath))
                return new List<PlayerProfile>();

            string content = File.ReadAllText(filePath);
            string[] blocks = content.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
            List<PlayerProfile> players = new List<PlayerProfile>();

            foreach (string block in blocks)
            {
                string[] lines = block.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Length < 3) continue;

                string name = lines[0].Split(':')[1].Trim();
                int maxLevel = int.Parse(lines[1].Split(':')[1].Trim());
                int score = int.Parse(lines[2].Split(':')[1].Trim());

                players.Add(new PlayerProfile(name, maxLevel, score));
            }

            return players;
        }
        public static void SaveAllPlayers(List<PlayerProfile> players)
        {
            if (players == null) return;

            List<string> fileLines = new List<string>();
            for (int i = 0; i < players.Count; i++)
            {
                var p = players[i];
                fileLines.Add($"PlayerName: {p.Playername}");
                fileLines.Add($"MaxLevel: {p.Maxlevel}");
                fileLines.Add($"Score: {p.SCore}");
                if (i != players.Count - 1)
                    fileLines.Add(Separator);
            }

            string allText = string.Join(Environment.NewLine, fileLines);

            string filePath = GetFilePath();
            File.WriteAllText(filePath, allText);
        }
    }
}
