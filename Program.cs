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
            int playerExpMult = 10;

            Console.Write("Введите имя игрока:");
            string name = Console.ReadLine().Trim();

            List<PlayerProfile> allPlayers = SaveSystem.LoadAllPlayers();
            PlayerProfile currentPlayer = allPlayers.FirstOrDefault(p => p.Playername == name);


            if (currentPlayer == null)
            {
                currentPlayer = new PlayerProfile(name, 1, 0);
                allPlayers.Add(currentPlayer);
                SaveSystem.SaveAllPlayers(allPlayers);
                Console.WriteLine($"Создан новый игрок: {currentPlayer.Playername}, Макс. уровень {currentPlayer.Maxlevel}, Счёт {currentPlayer.SCore}.");
            }
            else
            {
                Console.WriteLine($"Игрок {currentPlayer.Playername}, Макс. уровень {currentPlayer.Maxlevel}, Счёт {currentPlayer.SCore}.");
            }

            GameLevel Lvl1 = new GameLevel(1, 1, 10);
            GameLevel Lvl2 = new GameLevel(2, 1, 50);
            GameLevel Lvl3 = new GameLevel(3, 1, 100);
            GameLevel Lvl4 = new GameLevel(4, 1, 250);
            GameLevel Lvl5 = new GameLevel(5, 1, 1000);

            bool flag = true;
            while (flag)
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
                    int lvl = IsIntForLvl(currentPlayer.Maxlevel);
                    switch (lvl)
                    {
                        case 1:
                            {
                                Lvl1.Game();
                                currentPlayer.AddScore(lvl * lvl * playerExpMult);
                                currentPlayer.ChangeMaxLevel(lvl);
                                SaveSystem.SaveAllPlayers(allPlayers);
                                Console.WriteLine($"Текущие данные: Игрок {currentPlayer.Playername}, Макс. уровень {currentPlayer.Maxlevel}, Счёт {currentPlayer.SCore}.");
                                break;
                            }
                        case 2:
                            {
                                Lvl2.Game();
                                currentPlayer.AddScore(lvl * lvl * playerExpMult);
                                currentPlayer.ChangeMaxLevel(lvl);
                                SaveSystem.SaveAllPlayers(allPlayers);
                                Console.WriteLine($"Текущие данные: Игрок {currentPlayer.Playername}, Макс. уровень {currentPlayer.Maxlevel}, Счёт {currentPlayer.SCore}.");
                                break;
                            }
                        case 3:
                            {
                                Lvl3.Game();
                                currentPlayer.AddScore(lvl * lvl * playerExpMult);
                                currentPlayer.ChangeMaxLevel(lvl);
                                SaveSystem.SaveAllPlayers(allPlayers);
                                Console.WriteLine($"Текущие данные: Игрок {currentPlayer.Playername}, Макс. уровень {currentPlayer.Maxlevel}, Счёт {currentPlayer.SCore}.");
                                break;
                            }
                        case 4:
                            {
                                Lvl4.Game();
                                currentPlayer.AddScore(lvl * lvl * playerExpMult);
                                currentPlayer.ChangeMaxLevel(lvl);
                                SaveSystem.SaveAllPlayers(allPlayers);
                                Console.WriteLine($"Текущие данные: Игрок {currentPlayer.Playername}, Макс. уровень {currentPlayer.Maxlevel}, Счёт {currentPlayer.SCore}.");
                                break;
                            }
                        case 5:
                            {
                                Lvl5.Game();
                                currentPlayer.AddScore(lvl * lvl * playerExpMult);
                                currentPlayer.ChangeMaxLevel(lvl);
                                SaveSystem.SaveAllPlayers(allPlayers);
                                Console.WriteLine($"Текущие данные: Игрок {currentPlayer.Playername}, Макс. уровень {currentPlayer.Maxlevel}, Счёт {currentPlayer.SCore}.");
                                break;
                            }

                    }
                }
                else if ((userChoice == 2))
                {
                    flag = false;
                    List<PlayerProfile> leaderBoard = LeaderBoard.SortLeaderBoard(allPlayers);
                    LeaderBoard.ShowLeaderBoard(leaderBoard);
                    SaveSystem.SaveAllPlayers(allPlayers);
                }
                else
                {
                    Console.WriteLine("Такого варианта нет");
                }
            }
        }
        public static int IsInt()
        {
            while (true)
            {
                string n = Console.ReadLine().Trim();
                if (int.TryParse(n, out int newn))
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
                else if (int.Parse(n) > maxLvl)
                {
                    Console.WriteLine("Этот уровень еще не открыт");
                }
            }
        }

    }
}
