namespace Hangman
{
    using System;

    public class CommandExecuter
    {
        public static void Restart()
        {
            Console.WriteLine();
            string word = WordSelector.SelectRandomWord();
            GuessRanderer randerer = new GuessRanderer();

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