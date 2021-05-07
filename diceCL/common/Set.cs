using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceR.common
{
    public abstract class Set
    {
        private Player player { get; set; }//Getter and Setter for Player

        protected string name;
        protected int max;
        protected int retNum;
        protected int amount;
        //Get Players username
        public string getUsername()
        {
            return player.username;
        }
        //Get Players ID
        public int getID()
        {
            return player.ID;
        }
        //Set Player username and ID
        public string setPlayer(string newName, int ID)
        {
            player = new Player();
            player.username = newName;
            player.ID = ID;

            return player.username;
        }
        //Check if set is empty and return true is and false if it not empty
        public bool isEmpty()
        {
            if (amount == 0)
            {
                return true;
            }
            return false;
        }
        //Check if set is full, return true is and false if it not full
        public bool isFull()
        {
            if (amount == max)
            {
                return true;
            }
            return false;
        }
        //Reset the size of set rendering as empty
        public void reset()
        {
            amount = 0;
        }
        //Get the name of set
        public string getName()
        {
            return name;
        }
        //Set the name of set
        public string setName(string sName)
        {
            name = sName;
            return name;
        }
        //Returns the size of the set
        public int size()
        {
            return amount;
        }
        //Returns retNum
        public int getRetNum()
        {
            return retNum;
        }
    }
}
