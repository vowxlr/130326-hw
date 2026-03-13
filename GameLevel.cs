using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _120326_hw
{
    internal class GameLevel
    {
        private int level;
        private int firstNumber;
        private int secondNumber;
        public int Level { get { return level; } }
        public int FirstNumber { get { return firstNumber; } }
        public int SecondNumber { get { return secondNumber; } }
        public GameLevel(int level, int firstNumber, int secondNumber)
        {
            this.level = level;
            this.firstNumber = firstNumber;
            this.secondNumber = secondNumber;
        }
        public bool Game()
        {
            Console.WriteLine($"+| Уровень №{level}");
            Random random = new Random();
            int secretNumber = random.Next(firstNumber, secondNumber);
            while(true)
            {
                int playerNumb = PlayerNumber(firstNumber, secondNumber);
                if(playerNumb == secretNumber)
                {
                    Console.WriteLine("Уровень пройден !");
                    return true;
                }
                else if(playerNumb > secretNumber)
                {
                    Console.WriteLine("Загаданное число меньше");
                }
                else if (playerNumb < secretNumber)
                {
                    Console.WriteLine("Загаданное число больше");
                }
            }
        }
        public int PlayerNumber(int firstNumber, int secondNumber)
        {
            while(true)
            {
                Console.WriteLine("Введите предполагаемое число:");
                int n = Program.IsInt();
                if((firstNumber <= n) && (n <= secondNumber))
                {
                    return n;
                }
            }
        }
    }
}
