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

                    string expected = "Welcome to “Hangman” game.\n";
                    string ex = "Use 'top' to view the top scoreboard, 'restart' to start a new game,'help' to cheat and 'exit' to quit the game.";
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    MainClass.Main();
                    Assert.AreEqual<string>(expected, sw.ToString());
                }
            }
        }
    }
}
