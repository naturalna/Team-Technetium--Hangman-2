using System;
using System.IO;
using Hangman;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordInitializatorTest
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void MainTest_ExitTest()
        {
            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader(string.Format("exit{0}", Environment.NewLine)))
                {     
                    
                    string expected = "Welcome to “Hangman” game. \r\nUse 'top' to view the top scoreboard, 'restart' "+
                        "to start a new game,'help' to cheat and 'exit' to quit the game.\r\n\r\nPlease try to guess my "+
                        "secret word.\r\nEnter your guess: \r\nGood bye!\r\n" ;
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    MainClass.Main();                  
                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
        }
    }
}
