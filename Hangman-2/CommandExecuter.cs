using System;

namespace Hangman
{
    public static class CommandExecuter
    {
        public static void Start() //used to be Restart
        {
            Console.WriteLine();
            WordSelector wordSelector = new WordSelector();
            string word = wordSelector.SelectRandomWord();
            GuessHandler randerer = new GuessHandler();

            randerer.PlayRound(word);
            WordGuesser wordGuesser = new WordGuesser(); //used to be wg
            WordGuesser.Word = word;

            while (randerer.GuessedCharsCounter < word.Length && WordGuesser.HasExited == false)
            {
                wordGuesser.HandleUserInput(randerer);
            }
        }

        public static void Top()
        {
            PlayersScore.PrintTopResults();
        }

        public static void Exit()
        {
            Console.WriteLine("Good bye!");
            WordGuesser.HasExited = true;
            return;
        }
    }
}