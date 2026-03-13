using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _120326_hw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerExp = 0;
            int playerLvl = 1;
            int playerExpMult = 0;

            string path = (@"D:\Ьеь\c#\120326 hw\120326 hw\players.txt");

            Console.Write("Введите имя игрока:");
            string name = Console.ReadLine().Trim();

            PlayerProfile Player = new PlayerProfile(name, 1, 0);

            LvlSystem playerLvlSystem = new LvlSystem(playerExp, playerLvl, playerExpMult);
            string loadContent = SaveSystem.Load().Trim();

            string text = File.ReadAllText(path);
            string[] blocks = text.Split(new[] { "---" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> lines = new List<string>();
            foreach (string block in blocks)
            {
                string[] l = block.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(string line in l)
                {
                    lines.Add(line);
                }
            }

            for (int i = 0; i< lines.Count; i+=3)
            {
                if(lines[i] == $"PlayerName: {name}")
                {
                    playerLvlSystem.LoadData(int.Parse(lines[i + 1].Split()[1]), int.Parse(lines[i + 2].Split()[1]));
                    break;
                }
                else
                {
                    SaveNewInfo(Player);
                }
            }

            Console.WriteLine(loadContent);

            GameLevel Lvl1 = new GameLevel(1, 1, 10);
            GameLevel Lvl2 = new GameLevel(2, 1, 50);
            GameLevel Lvl3 = new GameLevel(3, 1, 100);
            GameLevel Lvl4 = new GameLevel(4, 1, 250);
            GameLevel Lvl5 = new GameLevel(5, 1, 1000);


            bool flag = true;
            while(flag)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("#Выберите действие:");
                Console.WriteLine("1) Выбрать уровень для прохождения");
                Console.WriteLine("2) Выйти из игры");
                Console.WriteLine("---------------------");
                int userChoice = IsInt();

                if (userChoice == 1)
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("#Выберите уровень для прохождения:");
                    Console.WriteLine("[1]    [2]    [3]    [4]    [5]");
                    Console.WriteLine("---------------------");
                    int lvl = IsIntForLvl(Player.Maxlevel);
                    switch (lvl)
                    {
                        case 1:
                            {
                                Lvl1.Game();
                                playerLvlSystem.AddExp(lvl * lvl * 10);
                                Player.AddScore(lvl * lvl * 10);
                                Player.ChangeMaxLevel(lvl);
                                SaveNewInfo(Player);
                                Console.WriteLine($"Текущие данные: Игрок {Player.Playername}, Макс. уровень {Player.Maxlevel}, Счёт {Player.SCore}.");
                                break;
                            }
                        case 2:
                            {
                                Lvl2.Game();
                                playerLvlSystem.AddExp(lvl * lvl * 10);
                                Player.AddScore(lvl * lvl * 10);
                                Player.ChangeMaxLevel(lvl);
                                SaveNewInfo(Player);
                                Console.WriteLine($"Текущие данные: Игрок {Player.Playername}, Макс. уровень {Player.Maxlevel}, Счёт {Player.SCore}.");
                                break;
                            }
                        case 3:
                            {
                                Lvl3.Game();
                                playerLvlSystem.AddExp(lvl * lvl * 10);
                                Player.AddScore(lvl * lvl * 10);
                                Player.ChangeMaxLevel(lvl);
                                SaveNewInfo(Player);
                                Console.WriteLine($"Текущие данные: Игрок {Player.Playername}, Макс. уровень {Player.Maxlevel}, Счёт {Player.SCore}.");
                                break;
                            }
                        case 4:
                            {
                                Lvl4.Game();
                                playerLvlSystem.AddExp(lvl * lvl * 10);
                                Player.AddScore(lvl * lvl * 10);
                                Player.ChangeMaxLevel(lvl);
                                SaveNewInfo(Player);
                                Console.WriteLine($"Текущие данные: Игрок {Player.Playername}, Макс. уровень {Player.Maxlevel}, Счёт {Player.SCore}.");
                                break;
                            }
                        case 5:
                            {
                                Lvl5.Game();
                                playerLvlSystem.AddExp(lvl * lvl * 10);
                                Player.AddScore(lvl * lvl * 10);
                                Player.ChangeMaxLevel(lvl);
                                SaveNewInfo(Player);
                                Console.WriteLine($"Текущие данные: Игрок {Player.Playername}, Макс. уровень {Player.Maxlevel}, Счёт {Player.SCore}.");
                                break;
                            }

                    }
                }
                else if((userChoice == 2))
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Такого варианта нет");
                }
            }
        }
        public static void SaveNewInfo(PlayerProfile Player)
        {
            SaveSystem.Save($"PlayerName: {Player.Playername}");
            SaveSystem.Save($"MaxLevel: {Player.Maxlevel}");
            SaveSystem.Save($"Score: {Player.SCore}");
            SaveSystem.Save("---");
        }
        public static int IsInt()
        {
            while(true)
            {
                string n = Console.ReadLine().Trim();
                if(int.TryParse(n, out int newn))
                {
                    return newn;
                }
            }
        }
        public static int IsIntForLvl(int maxLvl)
        {
            while (true)
            {
                string n = Console.ReadLine().Trim();
                if (int.TryParse(n, out int newn) && (int.Parse(n) <= maxLvl) && (1 <= int.Parse(n)))
                {
                    return newn;
                }
                else if(int.Parse(n) > maxLvl)
                {
                    Console.WriteLine("Этот уровень еще не открыт");
                }
            }
        }

    }
}
