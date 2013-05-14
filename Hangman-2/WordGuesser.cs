using System;
using System.Linq;

namespace Hangman
{
    public class WordGuesser
    {
        private static string word;
        private static bool hasExited;

        public static bool HasExited //used to be IsExited
        {
            get
            {
                return hasExited;
            }
            set
            {
                hasExited = value;
            }
        }

        public static string Word
        {
            get
            {
                return word;
            }
            set
            {
                word = value;
            }
        }

        private string ReadUserInput()
        {
            Console.WriteLine("Enter your guess: ");
            string input = Console.ReadLine();
            return input;
        }

        public void HandleUserInput(GuessHandler guessHandler) //used to be GuessLetter
        {
            string supposedCharOrCommand = ReadUserInput();

            if (supposedCharOrCommand.Length == 1)
            {
                char supposedChar = supposedCharOrCommand[0];
                guessHandler.InitializationAfterTheGuess(Word, supposedChar);
            }
            else if (supposedCharOrCommand.Equals("help"))
            {
                guessHandler.RevealTheNextLetterByHelp(Word);
            }
            else if (supposedCharOrCommand.Equals("restart"))
            {
                CommandExecuter.Start();
            }
            else if (supposedCharOrCommand.Equals("exit"))
            {
                CommandExecuter.Exit();
            }
            else if (supposedCharOrCommand.Equals("top"))
            {
                CommandExecuter.Top();
            }

        }
    }
}
