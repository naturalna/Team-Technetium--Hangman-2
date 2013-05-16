//----------------------------------------------------------------------------------
// <copyright file="PlayersScore.cs" company="Teleric Academy Technetium Team">
// Teleric Academy
// </copyright>
//---------------------------------------------------------------------------------

using System;

namespace Hangman
{
    /// <summary>
    /// Keeps Sores of the players
    /// </summary>
    public static class PlayersScore
    {
        /// <summary>
        /// Maximal number of scores to be kept
        /// </summary>
        private const int HighScoresNumber = 5; // used to be HIGH_SCORES_NUMBER

        /// <summary>
        /// Keeps best scores of the players
        /// </summary>
        private static readonly Player[] scoreboard = new Player[HighScoresNumber];

        /// <summary>
        /// Gets the scoreboard of top results
        /// </summary>
        public static Player[] Scoreboard
        {
            get
            {
                return scoreboard;
            }
        }

        /// <summary>
        /// Print top results
        /// </summary>
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

        /// <summary>
        /// Recalculate the current scoreboard according to current player's score
        /// </summary>
        /// <param name="firstFreePosition">First free position in scoreboard</param>
        internal static void PlaceScore(int firstFreePosition) // used to be SortScore
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