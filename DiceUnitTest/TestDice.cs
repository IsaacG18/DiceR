using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceR.common;
namespace DiceUnitTest
{
    [TestClass]

    public class TestDice
    {
        [TestMethod]
        public void TestDiceOverloadedAndSize()
        {
            int result = 1;
            dice d = new dice(1, 5);
            int expected = d.getMaxSize();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestDiceOverloadedAndSize2()
        {
            int result = 1;
            dice d = new dice(1);
            int expected = d.getMaxSize();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestDiceRollAndNum()
        {
            int result = 6;
            dice d = new dice(1, 5);
            d.rollDice();
            int expected = d.getNumber();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestDiceRollAndNum2()
        {
            int result = 1;
            dice d = new dice(1);
            d.rollDice();
            int expected = d.getNumber();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestModify()
        {
            int result = 6;
            dice d = new dice(1);
            d.modify(5);
            d.rollDice();
            int expected = d.getNumber();
            Assert.AreEqual(expected, result);
        }
    }
}
