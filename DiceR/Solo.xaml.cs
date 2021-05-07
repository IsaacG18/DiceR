
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DiceR.common;
//using Microsoft.Toolkit.Uwp.UI.Controls;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DiceR
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Solo : Page
    {
        const int memory = 5;
        DiceSet[] dSA = new DiceSet[memory];
        DiceSet cDS;
        int ID;
        string username;
        const string empty = "Empty Slot";
        int current = 0;
        public Solo()
        {
            this.InitializeComponent();
            SelectMemory(-1, current);
        }
        
        private void Roll(object sender, RoutedEventArgs e)
        {

          if(cDS == null)
            {
                cDS = new DiceSet(0, empty);//If current dice set does not exist then it sets to a basic set   
            }
            if (cDS.size() == 0)
            {
                errorMessage("The current set has no dice to roll");
                return;//Ends current method
            }
            cDS.rollAll(0);//Roll all the dice in current dice set
            display();
            errorMessage("");
        }
        private void display()
        {
            TextBlock[] diceRolls = { result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14, result15 };//Array of textblocks represting the resluts of the dice roll
            int size = cDS.size();
            int i = 0;
            foreach (TextBlock dR in diceRolls)//Loops through each diceRools
            {
                if (size > i)//Check if loop goes above size
                {
                    cDS.getAndDeleteDice(i, "element", false);//Get a dice based on its postion
                    dR.Text = cDS.getRetNum().ToString();//Get that dice value as a string and display it
                }
                else
                {
                    dR.Text = "";//Reset text block value
                }
                i++;
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (cDS == null)
            {
                errorMessage("Slot is empty");
                return;
            }
            if (cDS.getName() == empty)
            {
                errorMessage("Slot is empty");
                return;
            }

            int amount, mod, diceR;
            try
            {
                 amount = Int32.Parse(amountRoll.Text);// Try to convert string to int for amount
            }
            catch
            {
                errorMessage("Amount an is illegal input");
                return;
            }
            if (amount <= 0)
            {
                errorMessage("Amount is less than or equal to 0 which is an illegal input");
                return;
            }
            try
            {
                mod = Int32.Parse(modRoll.Text);//Try to convert string to int for mod
            }
            catch
            {
                if (modRoll.Text.Trim() == "") {
                    mod = 0;
                }
                else
                {
                    errorMessage("Modify is an illegal input");
                    return;
                }
            }
            if (mod < 0)
            {
                errorMessage("Mod is less than 0 which is an illegal input");
                return;
            }

            if (subtract.IsChecked== true)
            {
                mod = -mod;//If subtract is selected it convert mod to the negative of its self
            }
            try
            {
                diceR = Int32.Parse(dicRoll.Text);//Try to convert string to int for dice number
            }
            catch
            {
                errorMessage("Number is an illegal input");
                return;
            }
            if (diceR <= 0)
                return;


            if (cDS == null)
            {
                cDS = new DiceSet(0, empty);//If current dice set does not exist then it sets to a basic set
            }

            for (int i = 0; i < amount; i++)//Loop for each number in amout
            {
                dice die = new dice(diceR, mod);//Create new die based on users inputs
                cDS.addDice(die);//add die to current dice set
            }

            amountRoll.Text = "";
            modRoll.Text = "";
            dicRoll.Text = "";
            errorMessage("");
        }

        private void addSet(object sender, RoutedEventArgs e)
        {
            string name = setName.Text.Trim();
            if(name == "")
            {
                name = "Slot " + current.ToString();
            }
            int count;
          
            try
            {
                count = Int32.Parse(diceAmount.Text);//Try to convert string to int for dice count
            }
            catch
            {
                errorMessage("Dice Count is an illegal input");
                return;
            }
            if (count <= 0)
            {
                errorMessage("Dice Count is less than or equal to 0 which is an illegal input");
                return;
            }


            createPlayer();
            cDS = new DiceSet(count, name);//Creates a new dice set with user inputs
            errorMessage("");
            memoryName();
        }

        private void deleteSet(object sender, RoutedEventArgs e)
        {
            cDS = new DiceSet(0, empty);//Set current dice set to a basic dice set
            dSA[current] = cDS;//Set current save slot to current dice set
            memoryName();
            display();
            errorMessage("");
        }
        private void memoryName()
        {
            TextBlock[] memory = { memory1, memory2, memory3, memory4, memory5 };//Array of text blocks which represent memory
            memory[current].Text = cDS.getName();//Takes current memory and changes it text value to the current dice sets name
            setName.Text = "";
            diceAmount.Text = "";
        }

        private void Select1(object sender, RoutedEventArgs e)
        {
            dSA[current] = cDS;//Save the current dice set into current save slot
            cDS = dSA[0];//Set current dice set from save slot 0
            int temp = current;
            current = 0;
            SelectMemory(temp, current);
        }
        private void Select2(object sender, RoutedEventArgs e)
        {
            dSA[current] = cDS;//Save the current dice set into current save slot
            cDS = dSA[1];//Set current dice set from save slot 1
            int temp = current;
            current = 1;
            SelectMemory(temp, current);
        }
        private void Select3(object sender, RoutedEventArgs e)
        {
            dSA[current] = cDS;//Save the current dice set into current save slot
            cDS = dSA[2];//Set current dice set from save slot 2
            int temp = current;
            current = 2;
            SelectMemory(temp, current);
        }
        private void Select4(object sender, RoutedEventArgs e)
        {
            dSA[current] = cDS;//Save the current dice set into current save slot
            cDS = dSA[3];//Set current dice set from save slot 3
            int temp = current;
            current = 3;
            SelectMemory(temp, current);
        }
        private void Select5(object sender, RoutedEventArgs e)
        {
            dSA[current] = cDS;//Save the current dice set into current save slot
            cDS = dSA[4];//Set current dice set from save slot 4
            int temp = current;
            current = 4;
            SelectMemory(temp, current);
        }
        private void SelectMemory(int old, int currentNum)
        {
            Button[] saveSlot = { slot1, slot2, slot3, slot4, slot5 };
            if (currentNum != old)
            {
                for(int i =0; i < memory; i++)
                {
                    if (i == old)
                    {
                        saveSlot[i].Content = "Select";
                    }
                    if (i == currentNum)
                    {
                        saveSlot[i].Content = "Current";
                    }
                }
            }
            errorMessage("");
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            if (cDS == null)
            {
                errorMessage("Slot is empty");
                return;
            }
            if (cDS.getName() == empty)
            {
                errorMessage("Slot is empty");
                return;
            }
            int number = 0;
            try
            {
                number = Int32.Parse(delDice.Text);//Try to convert string to int for number 
            }
            catch
            {
                errorMessage("Number to delete an is illegal input");
                return;
            }

            cDS.getAndDeleteDice(number, "number", true);//This get a dice roll based on number and deletes it
            errorMessage("");
            display();
        }
        private void GetType(object sender, RoutedEventArgs e)
        {
            TextBlock[] diceRolls = { result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14, result15 };//Array of textblocks represting the resluts of the dice roll
            int i = 0;
           
            foreach (TextBlock tB in diceRolls)
            {
                if (tB == sender)
                {
                    if(cDS.getAndDeleteDice(i, "element", false))
                    resultDice.Text = "D" + cDS.returnDice().getMaxSize().ToString()
                                    + " " + cDS.returnDice().getModify().ToString();
                    return;
                }
                i++;
            }
        }
        private void clearDiceResult(object sender, RoutedEventArgs e)
        {
            resultDice.Text = "";
        }
        private void errorMessage(string errorMes)
        {
            error.Text = errorMes;
        }

        private void addPlayer(object sender, RoutedEventArgs e)
        {
            string temp = playerName.Text.Trim();
            if (temp == "")
                temp = "Guest";

            username = temp;
            createPlayer();
        }
        
        private void createPlayer()
        {
            Random rand = new Random();
            

            if (ID == 0)
                ID = rand.Next(1, 1000);//Get an ID if if ID does not already exist

            if (username == null)
                username = "Guest";//Set username to Guest if it does not already exist

            Player.Text = username;
            if (cDS == null)
                cDS = new DiceSet(0, empty);//Creates a defualt empty set if set does not exist
            cDS.setPlayer(username, ID);//Set Player Current Dice Set
            for (int i = 0; i < memory; i++)
            {
                if (dSA[i] == null)
                    dSA[i] = new DiceSet(0, empty);//Creates a defualt empty set if set does not exist
                dSA[i].setPlayer(username, ID);//Set Player Dice Set Array
            }
        }
    }
}
