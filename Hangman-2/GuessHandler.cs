//----------------------------------------------------------------------------------
// <copyright file="GuessHandler.cs" company="Teleric Academy Technetium Team">
// Teleric Academy
// </copyright>
//---------------------------------------------------------------------------------

namespace Hangman
{
    using System;
    using System.Linq;
    
    /// <summary>
    /// Manages the guesses of player
    /// </summary>
    public class GuessHandler : WordInitializator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuessHandler"/> class
        /// </summary>
        public GuessHandler() // used to be GuessRanderer
            : base()
        {
        }

        /// <summary>
        /// Initialize the word again after the player has guessed a letter
        /// </summary>
        /// <param name="word">Word to be guessed by player</param>
        /// <param name="charSupposed">Char entered by player</param>
        public void InitializationAfterTheGuess(string word, char charSupposed)
        {
            int supposedCharCounter = 0;

            if (RevealedChars.Contains<char>(charSupposed))
            {
                Console.WriteLine("You have already revelaed the letter {0}.", charSupposed);
                return;
            }

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].Equals(charSupposed))
                {
                    this.RevealedChars[i] = word[i];
                    supposedCharCounter++;
                }
            }

            if (supposedCharCounter == 0)
            {
                Console.WriteLine("Sorry! There are no unrevealed letters {0}", charSupposed);
                this.MistakesCounter++;
            }
            else
            {
                Console.WriteLine("Good job! You revealed {0} letters.\n", supposedCharCounter);
                this.GuessedCharsCounter += supposedCharCounter;
            }

            if (this.GuessedCharsCounter == word.Length)
            {
                this.ShowResults(word);
                CommandExecuter.Start();
            }

            Console.WriteLine("The secret word is:");
            this.RevealGuessedLetters(word);
        }

        /// <summary>
        /// Reveals a letter from the word when player asks for help
        /// </summary>
        /// <param name="word">Word to be guessed by player</param>
        public void RevealTheNextLetterByHelp(string word)
        {
            char firstUnrevealedLetter = this.GetFirstUnrevealedLetter(word);
            Console.WriteLine("OK, I reveal for you the next letter {0}.", firstUnrevealedLetter);
            this.InitializationAfterTheGuess(word, firstUnrevealedLetter);
            this.PlayerHasUsedHelp = true;
        }

        /// <summary>
        /// Gets first unrevealed letter in the word
        /// </summary>
        /// <param name="word">Word to be guessed by player</param>
        /// <returns>First not guessed letter in the word</returns>
        private char GetFirstUnrevealedLetter(string word)
        {
            char firstUnrevealedLetter = '$';

            for (int i = 0; i < word.Length; i++)
            {
                if (this.RevealedChars[i].Equals('$'))
                {
                    firstUnrevealedLetter = word[i];
                    break;
                }
            }

            return firstUnrevealedLetter;
        }
    }
}