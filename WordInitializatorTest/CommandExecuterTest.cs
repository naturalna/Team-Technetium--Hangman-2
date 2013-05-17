using System;
using System.IO;
using Hangman;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordInitializatorTest
{
    [TestClass]
    public class CommandExecuterTest
    {
        [TestMethod]
        public void TopEmptyScoreBoardTest()
        {           
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                CommandExecuter.Top();
                Assert.AreEqual<string>("\r\n\r\n", sw.ToString());
            }            
        }

        [TestMethod]
        public void ExitEmptyScoreBoardTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                WordGuesser wordGuesser = new WordGuesser();
                Console.SetOut(sw);
                CommandExecuter.Exit(wordGuesser);
                Assert.AreEqual<string>("Good bye!\r\n", sw.ToString());
            }
        }
    }
}
