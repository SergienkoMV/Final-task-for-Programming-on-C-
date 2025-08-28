using FinalTask.Utils;
using System;

namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new Casino().StartGame();
            }
            catch (WrongDiceNumberException ex)
            {
                Console .WriteLine($"Error: {ex.Message} {ex.Value}");
                Console.ReadLine();
            }
        }
    }
}
