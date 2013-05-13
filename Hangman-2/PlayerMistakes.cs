using System;

namespace Hangman
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
}