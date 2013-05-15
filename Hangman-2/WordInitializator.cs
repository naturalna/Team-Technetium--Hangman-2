//----------------------------------------------------------------------------------
// <copyright file="WordInitializator.cs" company="Teleric Academy Technetium Team">
// Teleric Academy
// </copyright>
//----------------------------------------------------------------------------------

namespace Hangman
{
    using System;
    using System.Text;

    /// <summary>
    /// Manages the initialization of the words
    /// </summary>
    public abstract class WordInitializator
    {
        /// <summary>
        /// Keep track of whether player has used help
        /// </summary>
        private bool playerHasUsedHelp; // used to be isPlayerUsedHelp

        /// <summary>
        /// Keeps revealed chars
        /// </summary>
        private char[] revealedChars; // used to be orderedLettersMask

        /// <summary>
        /// Counts guessed chars
        /// </summary>
        private int guessedCharsCounter;

        /// <summary>
        /// Counts not guessed chars
        /// </summary>
        private int notGuessedCharsCounter;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordInitializator"/> class
        /// </summary>
        public WordInitializator()
        {
            this.playerHasUsedHelp = false;
            this.guessedCharsCounter = 0;
            this.notGuessedCharsCounter = 0;
        }

        /// <summary>
        /// Gets or sets number of guessed chars
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
        /// Gets or sets number of not guessed chars
        /// </summary>
        public int NotGuessedCharsCounter
        {
            get
            {
                return this.notGuessedCharsCounter;
            }

            protected set
            {
                this.notGuessedCharsCounter = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the player has used help
        /// </summary>
        public bool PlayerHasUsedHelp
        {
            get
            {
                return this.playerHasUsedHelp;
            }

            protected set
            {
                this.playerHasUsedHelp = value;
            }
        }

        /// <summary>
        /// Gets or sets revealed by player chars
        /// </summary>
        public char[] RevealedChars // used to be OrderedLettersMask 
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
        /// Gets the name of the player
        /// </summary>
        /// <returns>Name of the player</returns>
        public static string GetPlayerName()
        {
            Console.WriteLine("Please enter your name for the top scoreboard:");
            string playerName = Console.ReadLine();
            return playerName;
        }

        // public static bool IsPlayerUsedHelp = false;

        /// <summary>
        /// Starts the new game with new word
        /// </summary>
        /// <param name="word"> Word to be guessed by player</param>
        public void PlayRound(string word)
        {
            Console.WriteLine("Please try to guess my secret word.");
            StringBuilder stringBuilderInit = new StringBuilder();

            StringBuilder hiddenWord = new StringBuilder();
            this.RevealedChars = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                this.RevealedChars[i] = '$';
                hiddenWord.Append("_ ");
            }

            stringBuilderInit.AppendLine();
            stringBuilderInit.AppendLine("The secret word is: ");
            stringBuilderInit.AppendLine(hiddenWord.ToString());
            Console.WriteLine(stringBuilderInit.ToString());
        }

        /// <summary>
        /// Show current result of the player 
        /// </summary>
        /// <param name="word">Word already guessed by player</param>
        protected void ShowResults(string word) // used to be GameEndInitialization
        {
            Console.WriteLine("You won with {0} mistakes.", this.NotGuessedCharsCounter);
            this.RevealGuessedLetters(word);
            Console.WriteLine();

            int firstFreePosition = 4;

            for (int i = 0; i < 4; i++)
            {
                if (PlayersScore.Scoreboard[i] == null)
                {
                    firstFreePosition = i;
                    break;
                }
            }

            if ((PlayersScore.Scoreboard[firstFreePosition] == null
                || this.NotGuessedCharsCounter <= PlayersScore.Scoreboard[firstFreePosition].NumberOfMistakes)
                && this.PlayerHasUsedHelp == false)
            {
                this.GetHighScoreEntry(firstFreePosition);
            }
        }
        
        /// <summary>
        /// Reveals the guessed letter by player
        /// </summary>
        /// <param name="word">Word to be guessed by player</param>
        protected void RevealGuessedLetters(string word)
        {
            StringBuilder partiallyHiddenWord = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                if (this.RevealedChars[i].Equals('$'))
                {
                    partiallyHiddenWord.Append("_ ");
                }
                else
                {
                    partiallyHiddenWord.Append(this.RevealedChars[i].ToString() + " ");
                }
            }

            Console.WriteLine(partiallyHiddenWord);
        }

        /// <summary>
        /// Save the result of the player in a scoreboard
        /// </summary>
        /// <param name="firstFreePosition"> First free position in Scoreboard</param>
        private void GetHighScoreEntry(int firstFreePosition)
        {
            string playerName = GetPlayerName();
            Player player = new Player(playerName, this.NotGuessedCharsCounter); // used to be newResult
            PlayersScore.Scoreboard[firstFreePosition] = player;
            PlayersScore.PlaceScore(firstFreePosition);
        }
    }
}