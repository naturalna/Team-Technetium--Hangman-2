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
        public void HandleUserInput_Help()
        {
            string word = "word";
            GuessHandler randerer = new GuessHandler();
            randerer.PlayRound(word);
            WordGuesser wordGuesser = new WordGuesser(); // used to be wg
            WordGuesser.Word = word;
            
            using (StringReader sr = new StringReader(string.Format("help{0}", Environment.NewLine)))
            {
                Console.SetIn(sr);
                wordGuesser.HandleUserInput(randerer);
                int guestCharsCounter = randerer.GuessedCharsCounter;
                Assert.IsTrue(guestCharsCounter == 1);
            }
        }

        [TestMethod]
        public void HandleUserInput_Exit()
        {
            string word = "word";
            GuessHandler randerer = new GuessHandler();
            randerer.PlayRound(word);
            WordGuesser wordGuesser = new WordGuesser(); // used to be wg
            WordGuesser.Word = word;

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
        public void HandleUserInput_Top()
        {
            string word = "word";
            GuessHandler randerer = new GuessHandler();
            randerer.PlayRound(word);
            WordGuesser wordGuesser = new WordGuesser(); // used to be wg
            WordGuesser.Word = word;

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
        public void HandleUserInput_Char()
        {
            string word = "word";
            GuessHandler randerer = new GuessHandler();
            randerer.PlayRound(word);
            WordGuesser wordGuesser = new WordGuesser(); // used to be wg
            WordGuesser.Word = word;

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
