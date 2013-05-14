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
        public static int GuessedCharsCounter = 0;
        public static int notGuessedCharsCounter = 0;

        private string ReadUserInput()
        {
            Console.WriteLine("Enter your guess: ");
            string input = Console.ReadLine();
            return input;
        }

        public static void InitializationAfterTheGuess(string word, char charSupposed)
        {
            int supposedCharCounter = 0;
            if (WordInitializator.OrderedLettersMask.Contains<char>(charSupposed))
            {
                Console.WriteLine("You have already revelaed the letter {0}", charSupposed);
                return;
            }

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].Equals(charSupposed))
                {
                    WordInitializator.OrderedLettersMask[i] = word[i];
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
                WordInitializator.GameEndInitialization(word);
                CommandExecuter.Restart();
            }

            Console.WriteLine("The secret word is:");
            RevealGuessedLetters(word);
        }
        //2 methods from WordInitializator must be moved here!
        public void GuessLetter()
        {
            string supposedCharOrCommand = ReadUserInput();

            if (supposedCharOrCommand.Length == 1) // the input is a character
            {
                char supposedChar = supposedCharOrCommand[0];
                WordGuesser.InitializationAfterTheGuess(Word, supposedChar);
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

        public static void RevealGuessedLetters(string word)
        {
            StringBuilder partiallyHiddenWord = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                if (WordInitializator.OrderedLettersMask[i].Equals('$'))
                {
                    partiallyHiddenWord.Append("_ ");
                }
                else
                {
                    partiallyHiddenWord.Append(WordInitializator.OrderedLettersMask[i].ToString() + " ");
                }
            }

            Console.WriteLine(partiallyHiddenWord);
        }
    }
}
