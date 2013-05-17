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
        public static void Start() 
        {
            Console.WriteLine();
            WordSelector wordSelector = new WordSelector();
            string word = wordSelector.SelectRandomWord();
            GuessCharacterHandler guessHandler = new GuessCharacterHandler();
            guessHandler.PlayRound(word);
            UserInputHandler wordGuesser = new UserInputHandler(); 
            wordGuesser.Word = word;

            while (guessHandler.GuessedCharsCounter < word.Length && wordGuesser.HasExited == false)
            {
                wordGuesser.HandleUserInput(guessHandler);
            }
        }

        public static void Help(GuessCharacterHandler guessHandler, string word)
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
        public static void Exit(UserInputHandler wordGuesser)
        {
            Console.WriteLine("Good bye!");
            wordGuesser.HasExited = true;
            return;
        }
    }
}