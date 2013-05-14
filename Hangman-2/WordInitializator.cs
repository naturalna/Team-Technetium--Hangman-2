using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    public class WordInitializator
    {
        private bool isPlayerUsedHelp = false;
        private char[] orderedLettersMask;
        private int guessedCharsCounter = 0;
        private int notGuessedCharsCounter = 0;

        public WordInitializator()
        {
        }

        public int GuessedCharsCounter 
        {
            get 
            { 
                return this.guessedCharsCounter;
            }
            set 
            { 
                this.guessedCharsCounter = value; 
            }
        }

        protected int NotGuessedCharsCounter
        {
            get
            {
                return this.notGuessedCharsCounter;
            }
            set
            {
                this.notGuessedCharsCounter = value;
            }
        }

        public bool IsPlayerUsedHelp 
        { 
            get
            {
                return this.isPlayerUsedHelp;
            }
            set
            {
                this.isPlayerUsedHelp = value;
            }
        }

        public char[] OrderedLettersMask 
        {
            get 
            {
                return this.orderedLettersMask;
            }
            set
            {
                this.orderedLettersMask = value;
            }
        }

        //public static bool IsPlayerUsedHelp = false;
        
        //public static char[] OrderedLettersMask;

        public void GameInisialization(string word)
        {
            Console.WriteLine("Welcome to “Hangman” game. Please try to guess my secret word.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game,'help' to cheat and 'exit' to quit the game.");

            this.OrderedLettersMask = new char[word.Length];
            StringBuilder hiddenWord = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                this.OrderedLettersMask[i] = '$';
                hiddenWord.Append("_ ");
            }

            Console.WriteLine();
            Console.WriteLine("The secret word is: ");
            Console.WriteLine(hiddenWord + "\n");
        }

        protected void GameEndInitialization(string word)
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
                || this.NotGuessedCharsCounter <= PlayersScore.Scoreboard[firstFreePosition].NumberOfMistakes) && IsPlayerUsedHelp == false)
            {
                Console.WriteLine("Please enter your name for the top scoreboard:");
                string playerName = Console.ReadLine();
                PlayerMistakes newResult = new PlayerMistakes(playerName, this.NotGuessedCharsCounter);
                PlayersScore.Scoreboard[firstFreePosition] = newResult;
                PlayersScore.SortScore(firstFreePosition);
            }

            this.GuessedCharsCounter = 0;
            this.NotGuessedCharsCounter = 0;
            this.IsPlayerUsedHelp = false;
        }

        protected void RevealGuessedLetters(string word)
        {
            StringBuilder partiallyHiddenWord = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                if (this.OrderedLettersMask[i].Equals('$'))
                {
                    partiallyHiddenWord.Append("_ ");
                }
                else
                {
                    partiallyHiddenWord.Append(this.OrderedLettersMask[i].ToString() + " ");
                }
            }

            Console.WriteLine(partiallyHiddenWord);
        }
    }
}