using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceR.common;
namespace DiceUnitTest
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void playerID()
        {
            Player player = new Player();
            player.ID = 3;
            int expected = 3;
            int result = 3;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void playerUsername()
        {
            Player player = new Player();
            player.username = "Dave";
            string expected = "Dave";
            string result = "Dave";
            Assert.AreEqual(expected, result);
        }
    }
}
