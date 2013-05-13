namespace Hangman
{
    using System;

    public class CommandExecuter
    {
        

        public static PlayerMistakes[] Scoreboard = new PlayerMistakes[5];

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
            WordInitializator.InitializationAfterTheGuess(word, firstUnrevealedLetter);

            // flag - not in the chart
            WordInitializator.IsPlayerUsedHelp = true;
        }

        public static void Restart()
        {
            Console.WriteLine();
            string word = WordSelector.SelectRandomWord();

            // Console.WriteLine(word);
            WordInitializator.GameInisialization(word);
            WordGuesser wg = new WordGuesser();//{ Word = word };
            WordGuesser.Word=word;

            while (WordInitializator.GuessedCharsCounter < word.Length && WordGuesser.IsExited == false)
            {
                wg.GuessLetter();
            }
        }

        public static void TopResults()
        {
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                if (Scoreboard[i] != null)
                {
                    Console.WriteLine("{0}. {1} ---> {2}", i + 1, Scoreboard[i].PlayerName, Scoreboard[i].NumberOfMistakes);
                }
            }

            Console.WriteLine();
        }

        public static void Exit()
        {
            Console.WriteLine("Good bye!");
            WordGuesser.IsExited = true;
            return;
        }
    }
}