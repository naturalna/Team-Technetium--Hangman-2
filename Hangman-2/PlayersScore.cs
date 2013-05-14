using System;

namespace Hangman
{
    static class PlayersScore
    {
        private const int HighScoresNumber = 5;// used to be HIGH_SCORES_NUMBER
        private static readonly Player[] scoreboard = new Player[HighScoresNumber];

        public static Player[] Scoreboard
        {
            get
            {
                return scoreboard;
            }
        }

        public static void PrintTopResults() // used to be TopResults
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

        internal static void PlaceScore(int firstFreePosition) //used to be SortScore
        {
            for (int i = firstFreePosition; i > 0; i--)
            {
                if (Scoreboard[i].Compare(Scoreboard[i - 1]) < 0)
                {
                    Player temp = Scoreboard[i];
                    Scoreboard[i] = Scoreboard[i - 1];
                    Scoreboard[i - 1] = temp;
                }
            }
        }
    }
}