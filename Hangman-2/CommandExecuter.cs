//----------------------------------------------------------------------------------
// <copyright file="CommandExecuter.cs" company="Teleric Academy Technetium Team">
// Teleric Academy
// </copyright>
//----------------------------------------------------------------------------------

namespace Hangman
{
    using System;

    /// <summary>
    /// Executes commands given by player
    /// </summary>
    public static class CommandExecuter
    {
        /// <summary>
        /// Starts the game
        /// </summary>
        public static void Start() // used to be Restart
        {
            Console.WriteLine();
            WordSelector wordSelector = new WordSelector();
            string word = wordSelector.SelectRandomWord();
            GuessHandler randerer = new GuessHandler();
            randerer.PlayRound(word);
            WordGuesser wordGuesser = new WordGuesser(); // used to be wg
            WordGuesser.Word = word;

            while (randerer.GuessedCharsCounter < word.Length && WordGuesser.HasExited == false)
            {
                wordGuesser.HandleUserInput(randerer);
            }
        }

        /// <summary>
        /// Print top results
        /// </summary>
        public static void Top()
        {
            PlayersScore.PrintTopResults();
        }

        /// <summary>
        /// Exit the game
        /// </summary>
        public static void Exit()
        {
            Console.WriteLine("Good bye!");
            WordGuesser.HasExited = true;
            return;
        }
    }
}