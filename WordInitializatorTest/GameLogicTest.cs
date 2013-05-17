using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman;

namespace WordInitializatorTest
{
    [TestClass]
    public class GameLogicTest
    {
        [TestMethod]
        public void RevealedCharsTest()
        {

            string word = "word";
            GuessCharacterHandler randerer = new GuessCharacterHandler();
            randerer.PlayRound(word);
            UserInputHandler wordGuesser = new UserInputHandler(); // used to be wg
            wordGuesser.Word = word;

            using (StringReader sr = new StringReader(string.Format("help{0}", Environment.NewLine)))
            {
                Console.SetIn(sr);
                wordGuesser.HandleUserInput(randerer);
                Assert.IsNotNull(randerer.RevealedChars);
            }

        }
    }
}
