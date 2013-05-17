//----------------------------------------------------------------------------------
// <copyright file="WordGuesser.cs" company="Teleric Academy Technetium Team">
// Teleric Academy
// </copyright>
//---------------------------------------------------------------------------------

using System;
using System.Linq;

namespace Hangman
{
    /// <summary>
    /// Manages the user input.
    /// </summary>
    public class WordGuesser
    {
        /// <summary>
        /// Word to be guessed by player.
        /// </summary>
        private string word;

        /// <summary>
        /// Keeps track whether the user wants to exit the game.
        /// </summary>
        private bool hasExited;

        /// <summary>
        /// Gets or sets a value indicating whether the player wants to exit.
        /// </summary>
        public bool HasExited;

        /// <summary>
        /// Gets or sets a word to be guessed by player.
        /// </summary>
        public string Word
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
        /// Handles player input.
        /// </summary>
        /// <param name="guessHandler">Data input by player.</param>
        public void HandleUserInput(GuessHandler guessHandler) // used to be GuessLetter
        {
            string supposedCharOrCommand = this.ReadPlayerInput();

            if (supposedCharOrCommand.Length == 1)
            {
                char supposedChar = supposedCharOrCommand[0];
                guessHandler.HandleUserGuess(Word, supposedChar);
            }
            else if (supposedCharOrCommand.Equals("help"))
            {
                CommandExecuter.Help(guessHandler, Word);
            }
            else if (supposedCharOrCommand.Equals("restart"))
            {
                CommandExecuter.Start();
            }
            else if (supposedCharOrCommand.Equals("exit"))
            {
                CommandExecuter.Exit(this);
            }
            else if (supposedCharOrCommand.Equals("top"))
            {
                CommandExecuter.Top();
            }
        }

        /// <summary>
        /// Reads player input.
        /// </summary>
        /// <returns>Player's input.</returns>
        private string ReadPlayerInput()
        {
            Console.WriteLine("Enter your guess: ");
            string input = Console.ReadLine();
            return input;
        }
    }
}
