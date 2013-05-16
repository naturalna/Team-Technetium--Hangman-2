using System;
using Hangman;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordInitializatorTest
{
    [TestClass]
    public class GuessRandererTests
    {
        [TestMethod]
        public void GuessRandererTest_OrderedLettersMaskMustBeCorrect()
        {
            string word = "SomeWord";
            GuessHandler randerer = new GuessHandler();
            randerer.PlayRound(word);
            Assert.IsTrue(randerer.RevealedChars.Length == word.Length);  
        }

        [TestMethod]
        public void InitializationAfterTheGuessTest()
        {
            string word = "SomeWord";
            GuessHandler randerer = new GuessHandler();
            randerer.PlayRound(word);
            randerer.InitializationAfterTheGuess(word, 'a');
            Assert.IsTrue(randerer.MistakesCounter == 1);    
        }

        [TestMethod]
        public void InitializationAfterTheGuessTest_TwoGestLettersAtTheSameTime()
        {
            string word = "SomeWord";
            GuessHandler randerer = new GuessHandler();
            randerer.PlayRound(word);
            randerer.InitializationAfterTheGuess(word, 'o');
            Assert.IsTrue(randerer.GuessedCharsCounter == 2);
        }


        [TestMethod]
        public void InitializationAfterTheGuessTest_AlreadyRevelaedLetter()
        {
            string word = "test";
            GuessHandler randerer = new GuessHandler();
            randerer.PlayRound(word);
            randerer.InitializationAfterTheGuess(word, 't');
            int openLetters = randerer.GuessedCharsCounter;
            randerer.InitializationAfterTheGuess(word, 't');
            Assert.IsTrue(openLetters == randerer.GuessedCharsCounter);
        }

        [TestMethod]
        public void RevealTheNextLetterByHelpTest_useHelpTwice()
        {
            string word = "test";
            GuessHandler randerer = new GuessHandler();
            randerer.PlayRound(word);
            randerer.RevealTheNextLetterByHelp(word);
            randerer.RevealTheNextLetterByHelp(word);
            Assert.AreEqual(true, randerer.PlayerHasUsedHelp);
        }

    }
}
