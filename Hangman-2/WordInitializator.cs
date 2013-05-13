using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    public class WordInitializator
    {
        private static int notGuessedCharsCounter = 0;
        public static bool IsPlayerUsedHelp = false;
        public static int GuessedCharsCounter = 0;
        public static char[] OrderedLettersMask;

        public static void GameInisialization(string word)
        {
            Console.WriteLine("Welcome to “Hangman” game. Please try to guess my secret word.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game,'help' to cheat and 'exit' to quit the game.");

            OrderedLettersMask = new char[word.Length];
            StringBuilder hiddenWord = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                OrderedLettersMask[i] = '$';
                hiddenWord.Append("_ ");
            }

            Console.WriteLine();
            Console.WriteLine("The secret word is: ");
            Console.WriteLine(hiddenWord + "\n");
        }

        public static void InitializationAfterTheGuess(string word, char charSupposed)
        {
            int supposedCharCounter = 0;
            if (OrderedLettersMask.Contains<char>(charSupposed))
            {
                Console.WriteLine("You have already revelaed the letter {0}", charSupposed);
                return;
            }

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].Equals(charSupposed))
                {
                    OrderedLettersMask[i] = word[i];
                    supposedCharCounter++;
                }
            }

            if (supposedCharCounter == 0)
            {
                Console.WriteLine("Sorry! There are no unrevealed letters {0}", charSupposed);
                notGuessedCharsCounter++;
            }
            else
            {
                Console.WriteLine("Good job! You revealed {0} letters.\n", supposedCharCounter);
                GuessedCharsCounter += supposedCharCounter;
            }

            if (GuessedCharsCounter == word.Length)
            {
                GameEndInitialization(word);
                CommandExecuter.Restart();
            }

            Console.WriteLine("The secret word is:");
            RevealGuessedLetters(word);
        }

        public static void RevealGuessedLetters(string word)
        {
            StringBuilder partiallyHiddenWord = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                if (OrderedLettersMask[i].Equals('$'))
                {
                    partiallyHiddenWord.Append("_ ");
                }
                else
                {
                    partiallyHiddenWord.Append(OrderedLettersMask[i].ToString() + " ");
                }
            }

            Console.WriteLine(partiallyHiddenWord);
        }

        public static void GameEndInitialization(string word)
        {
            Console.WriteLine("You won with {0} mistakes.", notGuessedCharsCounter);
            RevealGuessedLetters(word);
            Console.WriteLine();

            int firstFreePosition = 4;
        
            for (int i = 0; i < 4; i++)
            {
                if (CommandExecuter.Scoreboard[i] == null)
                {
                    firstFreePosition = i;
                    break;
                }
            }
            
            if ((CommandExecuter.Scoreboard[firstFreePosition] == null 
                || notGuessedCharsCounter <= CommandExecuter.Scoreboard[firstFreePosition].NumberOfMistakes) && IsPlayerUsedHelp == false)
            {
                Console.WriteLine("Please enter your name for the top scoreboard:");
                string playerName = Console.ReadLine();
                PlayerMistakes newResult = new PlayerMistakes(playerName, notGuessedCharsCounter);
                CommandExecuter.Scoreboard[firstFreePosition] = newResult;
                SortScore(firstFreePosition);
            }

            GuessedCharsCounter = 0;
            notGuessedCharsCounter = 0;
            IsPlayerUsedHelp = false;
        }

        private static void SortScore(int firstFreePosition)
        {
            for (int i = firstFreePosition; i > 0; i--)
            {
                if (CommandExecuter.Scoreboard[i].Compare(CommandExecuter.Scoreboard[i - 1]) < 0)
                {
                    PlayerMistakes temp = CommandExecuter.Scoreboard[i];
                    CommandExecuter.Scoreboard[i] = CommandExecuter.Scoreboard[i - 1];
                    CommandExecuter.Scoreboard[i - 1] = temp;
                }
            }
        }
    }
}