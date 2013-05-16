using System;
using System.IO;
using System.Text;
using Hangman;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordInitializatorTest
{
    [TestClass]
    public class CommandExecuterTest
    {
        [TestMethod]
        public void Top_emptyScoreBoard()
        {           
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                CommandExecuter.Top();
                Assert.AreEqual<string>("\r\n\r\n", sw.ToString());
            }            
        }

        [TestMethod]
        public void Exit_emptyScoreBoard()
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
