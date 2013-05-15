using System;

namespace Hangman
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to “Hangman” game. ");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game,'help' to cheat and 'exit' to quit the game.");

            CommandExecuter.Start();
        }
    }
}
