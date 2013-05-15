using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    public abstract class WordInitializator
    {
        private bool playerHasUsedHelp;//used to be isPlayerUsedHelp
        private char[] revealedChars; //used to be orderedLettersMask
        private int guessedCharsCounter;
        private int notGuessedCharsCounter;

        public WordInitializator()
               {
                playerHasUsedHelp = false;
                guessedCharsCounter = 0;
                notGuessedCharsCounter = 0;
            }
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

        public char[] RevealedChars //used to be OrderedLettersMask 
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

        //public static bool IsPlayerUsedHelp = false;
        public void PlayRound(string word)
        {
            Console.WriteLine("Welcome to �Hangman� game. Please try to guess my secret word.");
            StringBuilder stringBuilderInit = new StringBuilder();
            //Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game,'help' to cheat and 'exit' to quit the game.");
            stringBuilderInit.AppendLine("Use 'top' to view the top scoreboard, 'restart' to start a new game,'help' to cheat and 'exit' to quit the game.");
            StringBuilder hiddenWord = new StringBuilder();
            this.RevealedChars = new char[word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                this.RevealedChars[i] = '$';
                hiddenWord.Append("_ ");
            }

            stringBuilderInit.AppendLine("");
            stringBuilderInit.AppendLine("The secret word is: ");
            stringBuilderInit.AppendLine(hiddenWord.ToString());
            Console.WriteLine(stringBuilderInit.ToString());
        }

        protected void ShowResults(string word)//used to be GameEndInitialization
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
                && PlayerHasUsedHelp == false)
            {
                GetHighScoreEntry(firstFreePosition);
            }
        }
  
        private void GetHighScoreEntry(int firstFreePosition)
        {
            Console.WriteLine("Please enter your name for the top scoreboard:");
            string playerName = Console.ReadLine();
            Player player = new Player(playerName, this.NotGuessedCharsCounter);//used to be newResult
            PlayersScore.Scoreboard[firstFreePosition] = player;
            PlayersScore.PlaceScore(firstFreePosition);
        }

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
    }
}