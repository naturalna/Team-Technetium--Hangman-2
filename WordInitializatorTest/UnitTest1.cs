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
            GuessRanderer randerer = new GuessRanderer();
            randerer.GameInisialization(word);
            Assert.IsTrue(randerer.OrderedLettersMask.Length == word.Length);  
        }

        [TestMethod]
        public void InitializationAfterTheGuessTest()
        {
            string word = "SomeWord";
            GuessRanderer randerer = new GuessRanderer();
            randerer.GameInisialization(word);
            randerer.InitializationAfterTheGuess(word, 'a');
            Assert.IsTrue(randerer.NotGuessedCharsCounter == 1);    
        }

        [TestMethod]
        public void InitializationAfterTheGuessTest_TwoGestLettersAtTheSameTime()
        {
            string word = "SomeWord";
            GuessRanderer randerer = new GuessRanderer();
            randerer.GameInisialization(word);
            randerer.InitializationAfterTheGuess(word, 'o');
            Assert.IsTrue(randerer.GuessedCharsCounter == 2);
        }

        [TestMethod]
        public void RevealTheNextLetterByHelpTest_useHelpTwice()
        {
            string word = "test";
            GuessRanderer randerer = new GuessRanderer();
            randerer.GameInisialization(word);
            randerer.RevealTheNextLetterByHelp(word);
            randerer.RevealTheNextLetterByHelp(word);
            Assert.AreEqual(true, randerer.IsPlayerUsedHelp);
        }
    }
}
