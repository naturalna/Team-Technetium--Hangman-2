//----------------------------------------------------------------------------------
// <copyright file="MainClass.cs" company="Teleric Academy Technetium Team">
// Teleric Academy
// </copyright>
//---------------------------------------------------------------------------------

using System;

namespace Hangman
{
    /// <summary>
    /// Basic screen of the game
    /// </summary>
    public class MainClass
    {
        /// <summary>
        /// Give information to player about commands he can use
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Welcome to “Hangman” game. ");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game,'help' to cheat and 'exit' to quit the game.");

            CommandExecuter.Start();
        }
    }
}
