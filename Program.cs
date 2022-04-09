using System;

namespace GuessTheNum
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxTries = 5;
            int maxNum = 100;

            InitGame(maxTries, maxNum);
        }

        static private void InitGame(int maxTries, int maxNum)
        {
            Console.WriteLine("Hello! Type \"w\" to guess the num. Type \"e\" to let the bot guess your num.");
            ConsoleKey key = Console.ReadKey().Key;
            Console.WriteLine();
            Console.Write($"Type maxTries or press Enter for {maxTries} maxTries: ");
            string mtr = Console.ReadLine();
            if(mtr != "")
                maxTries = int.Parse(mtr);
            Console.Write($"Type maxNum or press Enter for {maxNum} maxNum: ");
            string mnum = Console.ReadLine();
            if(mnum != "")
                maxNum = int.Parse(mnum);


            if (key == ConsoleKey.W)
                GuessTheNum(maxTries, maxNum);
            else if (key == ConsoleKey.E)
                BotGuess(maxTries, maxNum);
            else
            {
                Console.Clear();
                InitGame(maxTries, maxNum);
            }
        }

        static private void GuessTheNum(int tries, int maxNum)
        {
            Random rand = new Random();
            int goalNum = rand.Next(maxNum + 1);
            Console.WriteLine($"Bot has thought of a num in a range from 0 to {maxNum}.");
            while (tries > 0)
            {
                Console.WriteLine($"Type your guess! You have {tries} tries.");
                int tryNum = int.Parse(Console.ReadLine());
                if (tryNum > goalNum)
                    Console.WriteLine("Bot: Goal num is less than this.");
                else if (tryNum < goalNum)
                    Console.WriteLine("Bot: Goal num is greater than this.");
                else
                {
                    Console.WriteLine("Game: You Won!");
                    Console.ReadKey();
                    break;
                }
                tries--;
            }
            if(tries == 0)
            {
                Console.WriteLine($"Game: Game Over! Num is {goalNum}.");
                Console.ReadKey();
            }

        }

        static private void BotGuess(int tries, int maxNum)
        {
            Console.WriteLine($"Type desired num in a range from 0 to {maxNum}.");
            int goalNum = int.Parse(Console.ReadLine());
            if (goalNum > maxNum || goalNum < 0)
            {
                Console.Clear();
                InitGame(tries, maxNum);
            }
            int leftBorder = 0;
            int rightBorder = maxNum;
            int currentNum;
            while (tries > 0)
            {
                currentNum = (rightBorder - leftBorder) / 2 + leftBorder;

                Console.WriteLine($"Bot: I think the num is {currentNum}.");

                if (currentNum > goalNum)
                {
                    rightBorder = currentNum;
                    Console.WriteLine("You: No, the goal is less than that.");
                }
                else if (currentNum < goalNum)
                {
                    leftBorder = currentNum;
                    Console.WriteLine("You: No, the goal is greater than that.");
                }
                else
                {
                    Console.WriteLine("Game: Game Over! Bot has guessed your num.");
                    Console.ReadKey();
                    break;
                }
                tries--;
            }
            if (tries == 0)
            {
                Console.WriteLine("Game: You Won!");
                Console.ReadKey();
            }
        }
    }
}
