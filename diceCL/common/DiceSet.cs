using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceR.common
{
    public class DiceSet: Set
    {
        private dice[] dSet;
        private dice retDice;
    
        //DiceSet CTOR inisializes name and size
        public DiceSet(int count, string sName)
        {
            max = count;
            amount = 0;
            dSet = new dice[count];
            setName(sName);
        }
        //Returns retDice
        public dice returnDice()
        {
            return retDice;
        }
        //Add a dice to dSet returns true if added else false
        public bool addDice(dice d)
        {
            if (isFull())//Checks if dSet is full
            {
                return false;
            }
            dSet[amount] = d;//Add to dSet
            amount++;
            return true;
        }
        //Add a set of Dice and returns how many are added
        public int addSetDice(dice[] d)
        {
            int added = 0;
            for (int i = 0; i < d.Length; i++)//Loops through each dice in d
            {
                if (!addDice(d[i]))
                {
                    break;//If adding fail end loop
                }
                added++;
            }
            return added;
        }
        //Adds into sDet till full and returns true if successful
        public bool addFull(int num)
        {
            while (!isFull())
            {
                dice d = new dice(num);
                addDice(d);
            }
            return true;
        }
        //This method try to get an item using posion, number or size then might delete it
        public bool getAndDeleteDice(int num, string type, bool delete)
        {
            if (isEmpty())//Check if dSet is empty
                return false;

            int element = -1;
            switch (type)//Checks way to find the dice
            {
                case "size":
                    if (sizeDice(num))//Checking by number
                    {
                        element = getRetNum();//Geting element postion
                    }
                    break;
                case "number":
                    if (numDice(num))//Checking by size
                    {
                        element = getRetNum();//Geting element postion
                    }
                    break;
                case "element":
                    if (elemDice(num))//Checking for element
                    {
                        element = getRetNum();//Geting element postion
                    }
                    break;
                default:
                    return false;
            }
            if (element != -1)//Checks a value is found 
            {
                retDice = dSet[element];
                retNum = dSet[element].getNumber();
                if (delete)//Check if delete is found
                {
                    dice[] temp = dSet;
                    amount--;
                    for (int j = element; j < amount; j++)//Loop though each value saving over the delete value
                    {
                        dSet[j] = temp[j + 1];
                    }
                }
                return true;
            }
            return false;
        }
        //Get an postion of dSet by size and returns true if found
        private bool sizeDice(int size)
        {
            for (int i = 0; i<amount; i++)//Loops through each dice
            {
                if (dSet[i].getMaxSize() == size )//Check if size match argument
                {
                    retNum = i;
                    return true;
                }
            }
            return false;
        }
        //Get an postion of dSet by number
        private bool numDice(int num)
        {
            for (int i = 0; i < amount; i++)//Loops through each dice
            {
                if (dSet[i].getNumber() == num)//Check if number match argument
                {
                    retNum = i;
                    return true;
                }
            }
            return false;
        }
        //Check for the postion of dSet
        private bool elemDice(int elem)
        {
            if(amount > elem && elem >= 0)//Checks if element exists
            {
                retNum = elem;
                return true;
            }
            return false;
        }
        //Roll each dice and add them together with a modifier and return the result
        public int[] rollAll(int mod)
        {
            int[] rolls = new int[amount];
            retNum = mod;
            for (int i = 0; i < amount; i++)//Loops through each dice
            {
                rolls[i] = dSet[i].rollDice();//Roll the dice
                retNum += rolls[i];//Adds each dice together
            }
            return rolls;
        }
    }
}
