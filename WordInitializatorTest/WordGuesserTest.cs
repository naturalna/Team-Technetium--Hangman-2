using System;
using System.IO;
using Hangman;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordInitializatorTest
{
    [TestClass]
    public class WordGuesserTest
    {
        [TestMethod]
        public void HandleUserInput_HelpTest()
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
                int guestCharsCounter = randerer.GuessedCharsCounter;
                Assert.IsTrue(guestCharsCounter == 1);
            }
        }

        [TestMethod]
        public void HandleUserInput_ExitTest()
        {
            string word = "word";
            GuessCharacterHandler randerer = new GuessCharacterHandler();
            randerer.PlayRound(word);
            UserInputHandler wordGuesser = new UserInputHandler(); // used to be wg
            wordGuesser.Word = word;

            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader(string.Format("exit{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    Console.SetOut(sw);
                    wordGuesser.HandleUserInput(randerer);
                    Assert.AreEqual<string>("Enter your guess: \r\nGood bye!\r\n", sw.ToString());
                }
            }
        }

        [TestMethod]
        public void HandleUserInput_TopTest()
        {
            string word = "word";
            GuessCharacterHandler randerer = new GuessCharacterHandler();
            randerer.PlayRound(word);
            UserInputHandler wordGuesser = new UserInputHandler(); // used to be wg
            wordGuesser.Word = word;

            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader(string.Format("top{0}", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    Console.SetOut(sw);
                    wordGuesser.HandleUserInput(randerer);
                    Assert.AreEqual<string>("Enter your guess: \r\n\r\n\r\n", sw.ToString());
                }
            }
        }

        [TestMethod]
        public void HandleUserInput_CharTest()
        {
            string word = "word";
            GuessCharacterHandler randerer = new GuessCharacterHandler();
            randerer.PlayRound(word);
            UserInputHandler wordGuesser = new UserInputHandler(); // used to be wg
            wordGuesser.Word = word;

            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader(string.Format("z{0}exit", Environment.NewLine)))
                {
                    Console.SetIn(sr);
                    Console.SetOut(sw);
                    wordGuesser.HandleUserInput(randerer);
                    string testText = "Enter your guess: \r\nSorry! There are no unrevealed letters z\r\nThe secret word is:\r\n_ _ _ _ \r\n";
                    Assert.AreEqual<string>(testText, sw.ToString());
                }
            }
        }
    }
}
