using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    public class WordInitializator
    {
        
        public static bool IsPlayerUsedHelp = false;
        
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

        public static void GameEndInitialization(string word)
        {
            Console.WriteLine("You won with {0} mistakes.", WordGuesser.notGuessedCharsCounter);
            WordGuesser.RevealGuessedLetters(word);
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
                || WordGuesser.notGuessedCharsCounter <= PlayersScore.Scoreboard[firstFreePosition].NumberOfMistakes) && IsPlayerUsedHelp == false)
            {
                Console.WriteLine("Please enter your name for the top scoreboard:");
                string playerName = Console.ReadLine();
                PlayerMistakes newResult = new PlayerMistakes(playerName, WordGuesser.notGuessedCharsCounter);
                PlayersScore.Scoreboard[firstFreePosition] = newResult;
                PlayersScore.SortScore(firstFreePosition);
            }

            WordGuesser.GuessedCharsCounter = 0;
            WordGuesser.notGuessedCharsCounter = 0;
            IsPlayerUsedHelp = false;
        }
    }
}