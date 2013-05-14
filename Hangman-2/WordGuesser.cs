using System;
using System.Linq;
using System.Text;
namespace Hangman
{
    public class WordGuesser
    {
        
        private static string word;
        private static bool isExited;

        public static bool IsExited
        {
            get
            {
                return isExited;
            }
            set
            {
                isExited = value;
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
        
        //2 methods from WordInitializator must be moved here!
        public void GuessLetter(GuessRanderer randerer)
        {
            string supposedCharOrCommand = ReadUserInput();

            if (supposedCharOrCommand.Length == 1) // the input is a character
            {
                char supposedChar = supposedCharOrCommand[0];
                randerer.InitializationAfterTheGuess(Word, supposedChar);
            }
            else if (supposedCharOrCommand.Equals("help"))
                CommandExecuter.RevealTheNextLetter(Word);
            else if (supposedCharOrCommand.Equals("restart"))
                CommandExecuter.Restart();
            else if (supposedCharOrCommand.Equals("exit"))
            {
                CommandExecuter.Exit();
                return;
            }
            else if (supposedCharOrCommand.Equals("top"))
                PlayersScore.TopResults();

        }
    }
}
