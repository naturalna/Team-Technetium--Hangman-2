//----------------------------------------------------------------------------------
// <copyright file="WordInitializator.cs" company="Teleric Academy Technetium Team">
// Teleric Academy
// </copyright>
//----------------------------------------------------------------------------------

using System;
using System.Text;

namespace Hangman
{
    /// <summary>
    /// Manages the initialization of the words.
    /// </summary>
    public abstract class GameLogic //used to be WordInitializator
    {
        /// <summary>
        /// Special character that cannot be a part of the word.
        /// </summary>
        protected const char SpecialCharacter = '$';

        /// <summary>
        /// Keeps revealed characters.
        /// </summary>
        private char[] revealedChars; // used to be orderedLettersMask

        /// <summary>
        /// Counts guessed characters.
        /// </summary>
        private int guessedCharsCounter;

        /// <summary>
        /// Counts not guessed characters.
        /// </summary>
        private int mistakesCounter; //used to be notGuessedCharsCounter

        /// <summary>
        /// Initializes a new instance of the <see cref="WordInitializator"/> class.
        /// </summary>
        public GameLogic()
        {
            this.guessedCharsCounter = 0;
            this.mistakesCounter = 0;
        }

        /// <summary>
        /// Gets or sets number of correctly guessed characters.
        /// </summary>
        public int GuessedCharsCounter
        {
            get
            {
                return this.guessedCharsCounter;
            }

            protected set
            {
                this.guessedCharsCounter = value;
            }
        }

        /// <summary>
        /// Gets or sets number of mistaken characters.
        /// </summary>
        public int MistakesCounter
        {
            get
            {
                return this.mistakesCounter;
            }

            protected set
            {
                this.mistakesCounter = value;
            }
        }

        /// <summary>
        /// Gets or sets revealed by player characters.
        /// </summary>
        public char[] RevealedChars
        {
            get
            {
                return this.revealedChars;
            }

            protected set
            {
                this.revealedChars = value;
            }
        }

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        /// <returns>The name of the player.</returns>
        public static string InputUserName()
        {
            Console.WriteLine("Please enter your name for the top scoreboard:");
            string playerName = Console.ReadLine();
            return playerName;
        }

        /// <summary>
        /// Show current result of the player.
        /// </summary>
        /// <param name="word">Word already guessed by player.</param>
        protected void EndOfGame(string word)
        {
            Console.WriteLine("You won with {0} mistakes.", this.MistakesCounter);
            this.RevealGuessedLetters(word);
            Console.WriteLine();

            int firstFreePosition = PlayersScore.Scoreboard.Length - 1; //the first 4 players are in the scoreboard

            for (int i = 0; i < PlayersScore.Scoreboard.Length; i++)
            {
                if (PlayersScore.Scoreboard[i] == null)
                {
                    firstFreePosition = i;
                    break;
                }
            }

            if ((PlayersScore.Scoreboard[firstFreePosition] == null || 
                this.MistakesCounter <= PlayersScore.Scoreboard[firstFreePosition].NumberOfMistakes))
            {
                this.GetHighScoreEntry(firstFreePosition);
            }
        }

        /// <summary>
        /// Reveals the guessed letter by player.
        /// </summary>
        /// <param name="word">Word to be guessed by player.</param>
        protected void RevealGuessedLetters(string word)
        {
            StringBuilder partiallyHiddenWord = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                if (this.RevealedChars[i].Equals(SpecialCharacter))
                {
                    partiallyHiddenWord.Append("_ ");
                }
                else
                {
                    partiallyHiddenWord.Append(this.RevealedChars[i].ToString());
                }
            }

            Console.WriteLine(partiallyHiddenWord);
        }

        /// <summary>
        /// Save the result of the player in a scoreboard.
        /// </summary>
        /// <param name="firstFreePosition">First free position in Scoreboard.</param>
        private void GetHighScoreEntry(int firstFreePosition)
        {
            string playerName = InputUserName();
            Player player = new Player(playerName, this.MistakesCounter); // used to be newResult
            PlayersScore.Scoreboard[firstFreePosition] = player;
            PlayersScore.PlaceScore(firstFreePosition);
        }
    }
}