using System;

namespace Hangman
{
    class PlayersScore
    {
        private const int HIGH_SCORES_NUMBER = 5;
        private static PlayerMistakes[] scoreboard = new PlayerMistakes[HIGH_SCORES_NUMBER];

        public static PlayerMistakes[] Scoreboard
        {
            get
            {
                return scoreboard;
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

        internal static void SortScore(int firstFreePosition)
        {
            for (int i = firstFreePosition; i > 0; i--)
            {
                if (Scoreboard[i].Compare(Scoreboard[i - 1]) < 0)
                {
                    PlayerMistakes temp = Scoreboard[i];
                    Scoreboard[i] = Scoreboard[i - 1];
                    Scoreboard[i - 1] = temp;
                }
            }
        }
    }
}