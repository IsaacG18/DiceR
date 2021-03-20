using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceR.common;

namespace DiceUT
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod2()
        {
            dice die = new dice(6);
            int expected = die.rollDice() + 3;
            int result = die.modify(3, true);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod1()
        {
            bool expected = true;
            bool result = false;

            dice die1 = new dice(6);
            dice die2 = new dice(6);
            dice die3 = new dice(6);
            dice die4 = new dice(6);
            
            DiceSet diceS = new DiceSet(4);
            bool d1 = diceS.addDice(die1);
            bool d2 = diceS.addDice(die2);
            bool d3 = diceS.addDice(die3);
            bool d4 = diceS.addDice(die4);
            if (d1 == d2 == d3 == d4 == true)
            {
                result = true;
            }
            Assert.AreEqual(expected, result);
        }
    }
}
