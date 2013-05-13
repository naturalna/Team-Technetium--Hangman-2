namespace Hangman
{
    using System;

    public class CommandExecuter
    {
        public class PlayerMistakes
        {
            public string PlayerName
            {
                get
                {
                    return this.playerName;
                }

                set
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("The player name can not be null");
                    }

                    this.playerName = value;
                }
            }

            public int NumberOfMistakes
            {
                get
                {
                    return this.numberOfMistakes;
                }

                private set
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException("The number of mistakes can not be negative!");
                    }

                    this.numberOfMistakes = value;
                }
            }

            public PlayerMistakes(string playerName, int numberOfMistakes)
            {
                this.PlayerName = playerName;
                this.NumberOfMistakes = numberOfMistakes;
            }

            public int Compare(PlayerMistakes otherPlayer)
            {
                if (this.NumberOfMistakes <= otherPlayer.NumberOfMistakes)
                {
                    return -1;
                }
                else
                {
                    return 1; // the newer one replaces the older
                }
            }

            private string playerName;

            private int numberOfMistakes;
        }

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
            WordGuesser wg = new WordGuesser() { Word = word };

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