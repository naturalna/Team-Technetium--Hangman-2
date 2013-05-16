//----------------------------------------------------------------------------------
// <copyright file="WordSelector.cs" company="Teleric Academy Technetium Team">
// Teleric Academy
// </copyright>
//---------------------------------------------------------------------------------

using System;
using System.Linq;

namespace Hangman
{
    /// <summary>
    /// Selects random word to be guessed by player
    /// </summary>
    public class WordSelector
    {
        /// <summary>
        /// Keeps array of strings with the possible words to be guessed by the player.
        /// </summary>
        private static readonly string[] words =
        {
            "computer", "programmer", "software", "debugger", "compiler",
            "developer", "algorithm", "array", "method", "variable"
        };

        /// <summary>
        /// Select random word from a predefined array of string values.
        /// </summary>
        /// <returns>A random word.</returns>
        public string SelectRandomWord()
        {
            // including 0, exluding word.Length
            int randomPosition = RandomNumber(0, words.Length); // used to be randomPositionOfTheWordToBeSelected
            string randomlySelectedWord = words.ElementAt(randomPosition);
            return randomlySelectedWord;
        }

        /// <summary>
        /// Generate random number between min and max values.
        /// </summary>
        /// <param name="min">Lower border of interval from which the number will be selected.</param>
        /// <param name="max">Upper border of interval from which the number will be selected.</param>
        /// <returns>Random integer number.</returns>
        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}