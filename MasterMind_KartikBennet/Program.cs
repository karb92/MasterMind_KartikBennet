using System;
using System.Linq;

namespace MasterMind_KartikBennet
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintWelcomeMessage();
            int num_attempts = 10;
            var masterMind = new Mastermind(num_attempts);

            int count = 1;
            bool isGameOver = false;

            while(count <= num_attempts && !isGameOver )
            {
                string input = Console.ReadLine();
                if (!ValidateInput(input))
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }

                var result = masterMind.Guess(input, count);
                Console.WriteLine(result.Response);
                count++;
                isGameOver = result.IsCompleted;
            }

        }

        static bool ValidateInput(string input)
        {
            return input.Length == 4 &&  input.All(char.IsDigit);
        }

        static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to MasterMin\n the game generates a 4 digit random number with numbers between 1 & 6\n" +
             "You have 10 attempts to guess\n"
              + "With each guess an output is displayed with + if digit is present in secret number and at correct position\n"
              +"- if digit is present,an empty space if digit is not present");
        }
    }
}
