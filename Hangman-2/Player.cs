//----------------------------------------------------------------------------------
// <copyright file="Player.cs" company="Teleric Academy Technetium Team">
// Teleric Academy
// </copyright>
//---------------------------------------------------------------------------------

using System;

namespace Hangman
{
    /// <summary>
    /// Contains information about player.
    /// </summary>
    public class Player 
    {
        /// <summary>
        /// Player name.
        /// </summary>
        private string playerName;

        /// <summary>
        /// Mistakes made by player.
        /// </summary>
        private int numberOfMistakes;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="playerName"> Player name.</param>
        /// <param name="numberOfMistakes">Player mistakes.</param>
        public Player(string playerName, int numberOfMistakes)
        {
            this.PlayerName = playerName;
            this.NumberOfMistakes = numberOfMistakes;
        }

        /// <summary>
        /// Gets or sets player name.
        /// </summary>
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

        /// <summary>
        /// Gets number of player's mistakes.
        /// </summary>
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

        /// <summary>
        /// Compare mistakes of two players.
        /// </summary>
        /// <param name="otherPlayer">Other player.</param>
        /// <returns> -1 if mistakes of current player are less or equal to mistakes of the other player;
        /// 1 if mistakes of current player are more than mistakes of the other person.
        /// </returns>
        public int Compare(Player otherPlayer)
        {
            if (this.NumberOfMistakes <= otherPlayer.NumberOfMistakes)
            {
                return -1; // what happens if number of mistakes is equal?
            }
            else
            {
                return 1; // the newer one replaces the older
            }
        }
    }
}