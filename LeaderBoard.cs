using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _120326_hw
{
    internal static class LeaderBoard
    {
        private static string DirectoryName = "saveDirectory";
        private static string FileLeaderBoardName = "leaderboard.txt";
        private static string Separator = "---";
        private static string GetFilePath()
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), DirectoryName);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            return Path.Combine(directoryPath, FileLeaderBoardName);
        }
        public static List<PlayerProfile> SortLeaderBoard(List<PlayerProfile> allPlayers)
        {
            if (allPlayers == null || allPlayers.Count == 0)
                return new List<PlayerProfile>();

            List<PlayerProfile> sorted = new List<PlayerProfile>(allPlayers);

            for (int i = 1; i < sorted.Count; i++)
            {
                PlayerProfile current = sorted[i];
                int j = i - 1;
                while (j >= 0 && sorted[j].SCore < current.SCore)
                {
                    sorted[j + 1] = sorted[j];
                    j--;
                }
                sorted[j + 1] = current;
            }
            return sorted;
        }
        public static List<PlayerProfile> SaveNewLeaderBoard(List<PlayerProfile> players)
        {
            List<PlayerProfile> leaderBoard = SortLeaderBoard(players);

            List<string> fileLines = new List<string>();
            for (int i = 0; i < leaderBoard.Count; i++)
            {
                var p = leaderBoard[i];
                fileLines.Add($"PlayerName: {p.Playername}");
                fileLines.Add($"MaxLevel: {p.Maxlevel}");
                fileLines.Add($"Score: {p.SCore}");
                if (i != leaderBoard.Count - 1)
                    fileLines.Add(Separator);
            }

            string allText = string.Join(Environment.NewLine, fileLines);

            string filePath = GetFilePath();
            File.WriteAllText(filePath, allText);
            return leaderBoard;
        }
        public static void ShowLeaderBoard(List<PlayerProfile> leaderBoard)
        {
            Console.WriteLine("Уровень сложности задания: 3");
            Console.WriteLine("Игрок | Уровень | Счёт");
            for(int i = 0; i < leaderBoard.Count;i++)
            {
                Console.WriteLine($"{leaderBoard[i].Playername} | {leaderBoard[i].Maxlevel} | {leaderBoard[i].SCore}");
            }

        }
    }
}
