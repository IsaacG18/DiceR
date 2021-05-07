using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceR.common;
namespace DiceUnitTest
{
    [TestClass]

    public class TickerTest
    {
        [TestMethod]
        public void TestTickerGetSize()
        {
            int result = 10;
            Ticker t = new Ticker(10,2);
            int expected = t.getMaxSize();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestTickerGetSize2()
        {
            int result = 2;
            Ticker t = new Ticker(2, 10);
            int expected = t.getMaxSize();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestTickerGetNum()
        {
            int result = 2;
            Ticker t = new Ticker(10, 2);
            int expected = t.getNumber();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestTickerModifyAdd()
        {
            int result = 7;
            Ticker t = new Ticker(10, 2);
            t.modify(5);
            int expected = t.getNumber();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestTickerModifySub()
        {
            int result = -3;
            Ticker t = new Ticker(10, 2);
            t.modify(-5);
            int expected = t.getNumber();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestTickerModifyAddOver()
        {
            int result = 10;
            Ticker t = new Ticker(10, 2);
            t.modify(10);
            int expected = t.getNumber();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestTickerModifySubOver()
        {
            int result = -10;
            Ticker t = new Ticker(10, 2);
            t.modify(-20);
            int expected = t.getNumber();
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestTickerModifyAddNothing()
        {
            int result = 2;
            Ticker t = new Ticker(10, 2);
            t.modify(0);
            int expected = t.getNumber();
            Assert.AreEqual(expected, result);
        }
    }
}
