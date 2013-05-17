//----------------------------------------------------------------------------------
// <copyright file="GuessCharacterHandler.cs" company="Teleric Academy Technetium Team">
// Teleric Academy
// </copyright>
//---------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Text;

namespace Hangman
{
    /// <summary>
    /// Manages the guesses of player.
    /// </summary>
    public class GuessCharacterHandler : GameLogic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuessCharacterHandler"/> class.
        /// </summary>
        public GuessCharacterHandler() // used to be GuessRanderer
            : base()
        {
        }

        /// <summary>
        /// Shows the word after the player's guess. 
        /// If the player guessed correctly then the correct letter in the word is revealed. 
        /// Else the number of player's mistakes is increased by 1.
        /// </summary>
        /// <param name="word">Word to be guessed by player.</param>
        /// <param name="charSupposed">Char entered by player.</param>
        public void HandleUserGuess(string word, char charSupposed) 
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
                base.EndOfGame(word);
                CommandExecuter.Start();
            }

            Console.WriteLine("The secret word is:");
            this.RevealGuessedLetters(word);
        }

        /// <summary>
        /// Reveals a letter from the word when player asks for help.
        /// </summary>
        /// <param name="word">Word to be guessed by player.</param>
        public void RevealTheNextLetterByHelp(string word)
        {
            char firstUnrevealedLetter = this.GetFirstUnrevealedLetter(word);
            Console.WriteLine("OK, I reveal for you the next letter {0}.", firstUnrevealedLetter);
            this.HandleUserGuess(word, firstUnrevealedLetter);
            //this.PlayerHasUsedHelp = true;
            this.MistakesCounter = this.MistakesCounter + 1;
        }

        /// <summary>
        /// Gets first unrevealed letter in the word.
        /// </summary>
        /// <param name="word">Word to be guessed by player.</param>
        /// <returns>First not guessed letter in the word.</returns>
        private char GetFirstUnrevealedLetter(string word)
        {
            char firstUnrevealedLetter = SpecialCharacter;

            for (int i = 0; i < word.Length; i++)
            {
                if (this.RevealedChars[i].Equals(SpecialCharacter))
                {
                    firstUnrevealedLetter = word[i];
                    break;
                }
            }

            return firstUnrevealedLetter;
        }

        /// <summary>
        /// Starts the new game with new word.
        /// </summary>
        /// <param name="word">Word to be guessed by player.</param>
        public void PlayRound(string word)
        {
            Console.WriteLine("Please try to guess my secret word.");
            StringBuilder stringBuilderInit = new StringBuilder();

            StringBuilder hiddenWord = new StringBuilder();
            this.RevealedChars = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                this.RevealedChars[i] = SpecialCharacter;
                hiddenWord.Append("_ ");
            }

            stringBuilderInit.AppendLine();
            stringBuilderInit.AppendLine("The secret word is: ");
            stringBuilderInit.AppendLine(hiddenWord.ToString());
            //Console.WriteLine(stringBuilderInit.ToString());
        }
    }
}