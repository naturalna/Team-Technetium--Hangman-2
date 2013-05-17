using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman;

namespace WordInitializatorTest
{
    [TestClass]
    public class PlayersScoreTest
    {
        [TestMethod]
        public void TestNotNullScoreboard()
        {
            Assert.IsNotNull(PlayersScore.Scoreboard);
        }
    }
}
