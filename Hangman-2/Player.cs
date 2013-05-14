using System;

namespace Hangman
{
    public class Player //used to be PlayerMistake
    {
        private string playerName;
        private int numberOfMistakes;

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

        public Player(string playerName, int numberOfMistakes)
        {
            this.PlayerName = playerName;
            this.NumberOfMistakes = numberOfMistakes;
        }

        public int Compare(Player otherPlayer)
        {
            if (this.NumberOfMistakes <= otherPlayer.NumberOfMistakes) //what happens if number of mistakes is equal?
            {
                return -1;
            }
            else
            {
                return 1; // the newer one replaces the older
            }
        }
    }
}