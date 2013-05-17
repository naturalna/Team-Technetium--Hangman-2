﻿using System;
using Hangman;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordInitializatorTest
{
    [TestClass]
    public class GuessRandererTests
    {
        [TestMethod]
        public void GuessHandlerTest_OrderedLettersMaskMustBeCorrectTest()
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
            randerer.HandleUserGuess(word, 'a');
            Assert.IsTrue(randerer.MistakesCounter == 1);    
        }

        [TestMethod]
        public void InitializationAfterTheGuessTest_TwoGestLettersAtTheSameTimeTest()
        {
            string word = "SomeWord";
            GuessHandler randerer = new GuessHandler();
            randerer.PlayRound(word);
            randerer.HandleUserGuess(word, 'o');
            Assert.IsTrue(randerer.GuessedCharsCounter == 2);
        }


        [TestMethod]
        public void InitializationAfterTheGuessTest_AlreadyRevelaedLetterTest()
        {
            string word = "test";
            GuessHandler randerer = new GuessHandler();
            randerer.PlayRound(word);
            randerer.HandleUserGuess(word, 't');
            int openLetters = randerer.GuessedCharsCounter;
            randerer.HandleUserGuess(word, 't');
            Assert.IsTrue(openLetters == randerer.GuessedCharsCounter);
        }

        [TestMethod]
        public void RevealTheNextLetterByHelpTestUseHelpTwiceTest()
        {
            string word = "test";
            GuessHandler randerer = new GuessHandler();
            randerer.PlayRound(word);
            randerer.RevealTheNextLetterByHelp(word);
            randerer.RevealTheNextLetterByHelp(word);
            Assert.AreEqual(2, randerer.MistakesCounter);
        }
    }
}
