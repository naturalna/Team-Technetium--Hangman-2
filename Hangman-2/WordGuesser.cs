//----------------------------------------------------------------------------------
// <copyright file="WordGuesser.cs" company="Teleric Academy Technetium Team">
// Teleric Academy
// </copyright>
//---------------------------------------------------------------------------------

namespace Hangman
{
    using System;
    using System.Linq;

    /// <summary>
    /// Manages the user input
    /// </summary>
    public class WordGuesser
    {
        /// <summary>
        /// Word to be guessed by player
        /// </summary>
        private static string word;

        /// <summary>
        /// Keeps track whether the user wants to exit the game
        /// </summary>
        private static bool hasExited;

        /// <summary>
        /// Gets or sets a value indicating whether the player wants to exit
        /// </summary>
        public static bool HasExited // used to be IsExited
        {
            get
            {
                return hasExited;
            }

            set
            {
                hasExited = value;
            }
        }

        /// <summary>
        /// Gets or sets a word to be guessed by player
        /// </summary>
        public static string Word
        {
            get
            {
                return word;
            }

            set
            {
                word = value;
            }
        }
        
        /// <summary>
        /// Handle player input
        /// </summary>
        /// <param name="guessHandler">Data input by player</param>
        public void HandleUserInput(GuessHandler guessHandler) // used to be GuessLetter
        {
            string supposedCharOrCommand = this.ReadUserInput();

            if (supposedCharOrCommand.Length == 1)
            {
                char supposedChar = supposedCharOrCommand[0];
                guessHandler.InitializationAfterTheGuess(Word, supposedChar);
            }
            else if (supposedCharOrCommand.Equals("help"))
            {
                guessHandler.RevealTheNextLetterByHelp(Word);
            }
            else if (supposedCharOrCommand.Equals("restart"))
            {
                CommandExecuter.Start();
            }
            else if (supposedCharOrCommand.Equals("exit"))
            {
                CommandExecuter.Exit();
            }
            else if (supposedCharOrCommand.Equals("top"))
            {
                CommandExecuter.Top();
            }
        }

        /// <summary>
        /// Read user input
        /// </summary>
        /// <returns>String value - Player input</returns>
        private string ReadUserInput()
        {
            Console.WriteLine("Enter your guess: ");
            string input = Console.ReadLine();
            return input;
        }
    }
}
