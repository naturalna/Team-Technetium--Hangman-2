using System;
using Hangman;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordInitializatorTest
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void Player_CompareTwoPlayerFirstBiggerThanSecondTest()
        {
            Player playerIvan = new Player("Ivan", 2);
            Player playerAsen = new Player("Asen", 3);
            var result  = playerAsen.Compare(playerIvan);
            Assert.IsTrue(result == 1);
        }

        [TestMethod]
        public void Player_CompareTwoPlayerSecondBiggerThanFirstTest()
        {
            Player playerIvan = new Player("Ivan", 2);
            Player playerAsen = new Player("Asen", 3);
            var result = playerIvan.Compare(playerAsen);
            Assert.IsTrue(result == -1);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void Player_CompareTwoPlayerWithNegativeMistakesTest()
        {
            Player playerIvan = new Player("Ivan", 2);
            Player playerAsen = new Player("Asen", -4);
            var result = playerAsen.Compare(playerIvan);
            Assert.IsTrue(result == 1);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Player_CompareTwoPlayersWithNullNameTest()
        {
            Player playerIvan = new Player(null, 2);
            Player playerAsen = new Player("Asen", -4);
            var result = playerAsen.Compare(playerIvan);
            Assert.IsTrue(result == 1);
        }      
    }
}
