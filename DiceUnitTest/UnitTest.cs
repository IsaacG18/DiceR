
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiceR.common;
namespace DiceUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DSPlayer()
        {
            DiceSet dS = new DiceSet(0, "Set Name");
            dS.setPlayer("Guest", 100);
            bool expected = true;
            bool result = false;
            if (dS.getUsername() == "Guest" && dS.getID() == 100)
            {
                result = true;
            }
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DSTestAddDice()
        {
            bool expected = true;
            bool result = true;
            int num = 5;
            dice die1 = new dice(4);

            DiceSet dS = new DiceSet(num, "Set Name");

            for (int i = 0; i < num; i++)
            {
                if (!dS.addDice(die1))
                {
                    result = false;
                };
            }

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DSTestGetName()
        {
            string expected = "Name1";
            int num = 5;
            DiceSet dS = new DiceSet(num, "Name1");
            string result = dS.getName();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DSTestSetName()
        {
            string expected = "Name1";
            int num = 5;
            DiceSet dS = new DiceSet(num, "Set Name");
            dS.setName("Name1");
            string result = dS.getName();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DSTestIsEmpty()
        {
            bool expected = true;
            int num = 4;
            DiceSet dS = new DiceSet(num, "Set Name");
            bool result = dS.isEmpty();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DSTestIsFull()
        {
            bool expected = true;

            int num = 3;
            dice die1 = new dice(4);

            DiceSet dS = new DiceSet(num, "Set Name");

            for (int i = 0; i < num; i++)
            {
                dS.addDice(die1);
            }
            bool result = dS.isFull();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void DSTestAddSetDice(){
            int num = 3;
            int expected = num;

            
            dice die1 = new dice(4);

            dice[] dsAdd = {die1, die1, die1, die1, die1};

            DiceSet dS = new DiceSet(num, "Set Name");


            int result = dS.addSetDice(dsAdd);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DSTestAddFull()
        {
            bool expected = true;
            bool result = false;
            int num = 3;


            DiceSet dS = new DiceSet(num, "Set Name");

            dS.addFull(4);
            if (dS.isFull())
            {
                result = true;
            }
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DSTestgetAndDeleteDiceDeleteSize()
        {
            bool expected = true;
            int num = 3;

            DiceSet dS = new DiceSet(num, "Set Name");
            dS.addFull(4);

            bool result = dS.getAndDeleteDice(4, "size", true);

            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void DSTestgetAndDeleteDiceGetSize()
        {
            bool expected = true;
            int num = 4;

            DiceSet dS = new DiceSet(num, "Set Name");

            dS.addFull(4);

            bool result = dS.getAndDeleteDice(4, "size", false);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DSTestgetAndDeleteDiceDeleteSize2()
        {
            bool expected = true;
            bool result = false;
            int num = 3;


            DiceSet dS = new DiceSet(num, "Set Name");

            dS.addFull(4);

            dS.getAndDeleteDice(4, "size", true);

            if (!dS.isEmpty() && !dS.isFull())
            {
                result = true;
            }

            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void DSTestgetAndDeleteDiceDeleteNum()
        {
            bool expected = true;
            int num = 3;

            DiceSet dS = new DiceSet(num, "Set Name");
            dS.addFull(1);
            dS.rollAll(0);
            bool result = dS.getAndDeleteDice(1, "number", true);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DSTestgetAndDeleteDiceDeleteNum2()
        {
            bool expected = true;
            bool result = false;
            int num = 4;


            DiceSet dS = new DiceSet(num, "Set Name");

            dS.addFull(1);
            dS.rollAll(0);
            dS.getAndDeleteDice(1, "number", true);
            if (!dS.isEmpty() && !dS.isFull())
            {
                result = true;
            }

            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void DSTestgetAndDeleteDiceGetNum()
        {
            bool expected = true;
            int num = 3;

            DiceSet dS = new DiceSet(num, "Set Name");
            dS.addFull(1);
            dS.rollAll(0);
            bool result = dS.getAndDeleteDice(1, "number", false);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DSTestgetAndDeleteDiceDeleteElement()
        {
            bool expected = true;
            int num = 4;

            DiceSet dS = new DiceSet(num, "Set Name");
            dS.addFull(4);
            bool result = dS.getAndDeleteDice(0, "element", true);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DSTestgetAndDeleteDiceDeleteElement2()
        {
            bool expected = true;
            bool result = false;
            int num = 4;


            DiceSet dS = new DiceSet(num, "Set Name");

            dS.addFull(4);

            dS.getAndDeleteDice(0, "element", true);
            if (!dS.isEmpty() && !dS.isFull())
            {
                result = true;
            }

            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void DSTestgetAndDeleteDiceGetElement()
        {
            bool expected = true;
            int num = 4;

            DiceSet dS = new DiceSet(num, "Set Name");
            dS.addFull(4);
            bool result = dS.getAndDeleteDice(3, "element", false);

            Assert.AreEqual(expected, result);
        }
        
        [TestMethod]
        public void DSTestReset()
        {
            bool expected = true;
            bool result = false;
            int num = 3;
            

            DiceSet dS = new DiceSet(num, "Set Name");
            dS.addFull(4);

            dS.reset();

            if (dS.isEmpty())
            {
                result = true;
            }

            Assert.AreEqual(expected, result);

        }
      

        [TestMethod]
        public void DSTestNum()
        {
            bool expected = true;
            bool result = false;
            int num = 4;
            DiceSet dS = new DiceSet(num, "Set Name");

            dS.addFull(4);

            int[] r = dS.rollAll(0);


            int total = dS.getRetNum();

            if (total > 0)
            {
                result = true;
            }

            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void DSTestReturnDiceGetSizeDice()
        {
            int num = 5;
            DiceSet dS = new DiceSet(num, "Set Name");

            dS.addFull(4);
            int expected = 4;



            dS.getAndDeleteDice(4, "size", false);

            int result = dS.returnDice().getMaxSize(); ;
            

           

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DSTestSize()
        {
            int num = 5;
            int expected = 2;
            dice die1 = new dice(4);
            dice[] dsAdd = { die1, die1};
            DiceSet dS = new DiceSet(num, "Set Name");
            dS.addSetDice(dsAdd);
            int result = dS.size();

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void DSTestGetDice()
        {
            int num = 5;
            int expected = 2;
            dice die1 = new dice(4);
            dice[] dsAdd = { die1, die1 };
            DiceSet dS = new DiceSet(num, "Set Name");
            dS.addSetDice(dsAdd);
            int result = dS.size();

            Assert.AreEqual(expected, result);
        }

    }
}
