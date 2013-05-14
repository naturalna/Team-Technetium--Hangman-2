namespace Hangman
{
    using System;

    public class CommandExecuter
    {
        //private static WordInitializator wordInitializator = new WordInitializator();
        private static GuessRanderer randerer = new GuessRanderer();

        public static void RevealTheNextLetter(string word)
        {
            char firstUnrevealedLetter = '$';

            for (int i = 0; i < word.Length; i++)
            {
                if (randerer.OrderedLettersMask[i].Equals('$'))
                {
                    firstUnrevealedLetter = word[i];
                    break;
                }
            }

            Console.WriteLine("OK, I reveal for you the next letter {0}.", firstUnrevealedLetter);
            randerer.InitializationAfterTheGuess(word, firstUnrevealedLetter);

            // flag - not in the chart
            randerer.IsPlayerUsedHelp = true;
        }

        public static void Restart()
        {
            Console.WriteLine();
            string word = WordSelector.SelectRandomWord();

            // Console.WriteLine(word);
            randerer.GameInisialization(word);
            WordGuesser wg = new WordGuesser();
            WordGuesser.Word = word;

            while (randerer.GuessedCharsCounter < word.Length && WordGuesser.IsExited == false)
            {
                wg.GuessLetter(randerer);
            }
        }

        public static void Exit()
        {
            Console.WriteLine("Good bye!");
            WordGuesser.IsExited = true;
            return;
        }
    }
}