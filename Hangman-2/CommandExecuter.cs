namespace Hangman
{
    using System;

    public class CommandExecuter
    {
        public static void RevealTheNextLetter(string word)
        {
            char firstUnrevealedLetter = '$';

            for (int i = 0; i < word.Length; i++)
            {
                if (WordInitializator.OrderedLettersMask[i].Equals('$'))
                {
                    firstUnrevealedLetter = word[i];
                    break;
                }
            }

            Console.WriteLine("OK, I reveal for you the next letter {0}.", firstUnrevealedLetter);
            WordGuesser.InitializationAfterTheGuess(word, firstUnrevealedLetter);

            // flag - not in the chart
            WordInitializator.IsPlayerUsedHelp = true;
        }

        public static void Restart()
        {
            Console.WriteLine();
            string word = WordSelector.SelectRandomWord();

            // Console.WriteLine(word);
            WordInitializator.GameInisialization(word);
            WordGuesser wg = new WordGuesser();
            WordGuesser.Word = word;

            while (WordGuesser.GuessedCharsCounter < word.Length && WordGuesser.IsExited == false)
            {
                wg.GuessLetter();
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