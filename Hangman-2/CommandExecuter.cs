//----------------------------------------------------------------------------------
// <copyright file="CommandExecuter.cs" company="Teleric Academy Technetium Team">
// Teleric Academy
// </copyright>
//----------------------------------------------------------------------------------

using System;

namespace Hangman
{

    /// <summary>
    /// Executes commands given by player.
    /// </summary>
    public static class CommandExecuter
    {
        /// <summary>
        /// Starts the game.
        /// </summary>
        public static void Start() // used to be Restart
        {
            Console.WriteLine();
            WordSelector wordSelector = new WordSelector();
            string word = wordSelector.SelectRandomWord();
            GuessHandler randerer = new GuessHandler();
            randerer.PlayRound(word);
            WordGuesser wordGuesser = new WordGuesser(); // used to be wg
            wordGuesser.Word = word;

            while (randerer.GuessedCharsCounter < word.Length && wordGuesser.HasExited == false)
            {
                wordGuesser.HandleUserInput(randerer);
            }
        }

        public static void Help(GuessHandler guessHandler, string word)
        {
            guessHandler.RevealTheNextLetterByHelp(word);
        }

        /// <summary>
        /// Shows top results.
        /// </summary>
        public static void Top()
        {
            PlayersScore.PrintTopResults();
        }

        /// <summary>
        /// Exits the game.
        /// </summary>
        public static void Exit(WordGuesser wordGuesser)
        {
            Console.WriteLine("Good bye!");
            wordGuesser.HasExited = true;
            return;
        }
    }
}