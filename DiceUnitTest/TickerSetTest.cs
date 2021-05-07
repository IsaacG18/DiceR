using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceR.common;

namespace DiceUnitTest
{
    [TestClass]
    public class TickerSetTest
    {
        [TestMethod]
        public void TSTestAddTicker()
        {
            bool expected = true;
            bool result = true;
            int num = 5;
            Ticker tick = new Ticker(4, 10);

            TickerSet tS = new TickerSet(num, "Set Name");

            for (int i = 0; i < num; i++)
            {
                if (!tS.addTicker(tick))
                {
                    result = false;
                };
            }

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TSPlayer()
        {
            TickerSet tS = new TickerSet(0, "Set Name");
            tS.setPlayer("Guest", 100);
            bool expected = true;
            bool result = false;
            if (tS.getUsername() == "Guest" && tS.getID() == 100)
            {
                result = true;
            }
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TSTestGetName()
        {
            string expected = "Name1";
            int num = 5;
            TickerSet tS = new TickerSet(num, "Name1");
            string result = tS.getName();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TSTestSetName()
        {
            string expected = "Name1";
            int num = 5;
            TickerSet tS = new TickerSet(num, "Set Name");
            tS.setName("Name1");
            string result = tS.getName();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TSTestIsEmpty()
        {
            bool expected = true;
            int num = 4;
            TickerSet tS = new TickerSet(num, "Set Name");
            bool result = tS.isEmpty();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TSTestAddFullTicker()
        {
            bool expected = true;
            bool result = false;
            int num = 3;
            Ticker tick = new Ticker(4, 10);

            TickerSet tS = new TickerSet(num, "Set Name");
            tS.addFull(tick);
            if (tS.isFull())
            {
                result = true;
            }
            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void TSTestReset()
        {
            bool expected = true;
            bool result = false;
            int num = 3;


            Ticker tick = new Ticker(4, 10);
            TickerSet tS = new TickerSet(num, "Set Name");

            tS.addFull(tick);

            tS.reset();

            if (tS.isEmpty())
            {
                result = true;
            }

            Assert.AreEqual(expected, result);

            }

        public void TSTestNum()
        {
            int expected = 4;
            int num = 4;
            Ticker tick = new Ticker(4, 4);
            TickerSet tS = new TickerSet(num, "Set Name");

            tS.addFull(tick);



            tS.getTicker(1);
            int result = tS.getRetNum();

            Assert.AreEqual(expected, result);

        }
        

        [TestMethod]
        public void TSTestGetTicker()
        {
            bool expected = true;
            int num = 4;
            Ticker tick = new Ticker(4, 4);
            TickerSet tS = new TickerSet(num, "Set Name");

            tS.addFull(tick);
            bool result = tS.getTicker(1);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TSTestSize()
        {
            int expected = 4;
            int num = 4;
            Ticker tick = new Ticker(4, 4);
            TickerSet tS = new TickerSet(num, "Set Name");
            tS.addFull(tick);
            int result = tS.size();
            Assert.AreEqual(expected, result);
        }
        
    }
}



