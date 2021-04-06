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
    
        public DiceSet(int count, string sName)
        {
            max = count;
            amount = 0;
            dSet = new dice[count];
            setName(sName);
        }
        
        public dice returnDice()
        {
            return retDice;
        }

        public bool addDice(dice d)
        {
            if (isFull())
            {
                return false;
            }
            dSet[amount] = d;
            amount++;
            return true;
        }
        public int addSetDice(dice[] d)
        {
            int added = 0;
            for (int i = 0; i < d.Length; i++)
            {
                if (!addDice(d[i]))
                {
                    break;
                }
                added++;
            }
            return added;
        }
        public bool addFull(int num)
        {
            while (!isFull())
            {
                dice d = new dice(num);
                addDice(d);
            }
            return true;
        }
        public bool getAndDeleteDice(int num, string type, bool delete)
        {
            if (isEmpty())
                return false;

            int element = -1;
            switch (type)
            {
                case "size":
                    if (sizeDice(num))
                    {
                        element = getRetNum();
                    }
                    break;
                case "number":
                    if (numDice(num))
                    {
                        element = getRetNum();
                    }
                    break;
                case "element":
                    if (elemDice(num))
                    {
                        element = getRetNum();
                    }
                    break;
                default:
                    return false;
            }
            if (element != -1)
            {
                retDice = dSet[element];
                retNum = dSet[element].getNumber();
                if (delete)
                {
                    dice[] temp = dSet;
                    amount--;
                    for (int j = element; j < amount; j++)
                    {
                        dSet[j] = temp[j + 1];
                    }
                }
                return true;
            }
            return false;
        }
        private bool sizeDice(int size)
        {
            for (int i = 0; i<amount; i++)
            {
                if (dSet[i].getSize() == size )
                {
                    retNum = i;
                    return true;
                }
            }
            return false;
        }
        private bool numDice(int num)
        {
            for (int i = 0; i < amount; i++)
            {
                if (dSet[i].getNumber() == num)
                {
                    retNum = i;
                    return true;
                }
            }
            return false;
        }
        private bool elemDice(int elem)
        {
            if(amount > elem && elem >= 0)
            {
                retNum = elem;
                return true;
            }
            return false;
        }
        public int[] rollAll(int mod)
        {
            int[] rolls = new int[amount];
            retNum = mod;
            for (int i = 0; i < amount; i++)
            {
                rolls[i] = dSet[i].rollDice();
                retNum += rolls[i];
            }
            return rolls;
        }
    }
}
