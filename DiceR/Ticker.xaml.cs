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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DiceR
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Ticker : Page
    {
        const int memory = 5;
        TickerSet[] tSA = new TickerSet[memory];
        TickerSet cTS;
        int current = 0;
        const int size = 4;
        int ID;
        string username;
        const string empty = "Empty Slot";
        public Ticker()
        {
            this.InitializeComponent();
            SelectMemory(-1, current);
        }
        private void addSet(object sender, RoutedEventArgs e)
        {
            string name = setName.Text.Trim();//Get the name
            if (name == "")
            {
                name = "Slot " + current.ToString();
            }
            cTS = new TickerSet(size, name);
            memoryName();
            createPlayer();
            errorMessage("");
        }
        private void deleteSet(object sender, RoutedEventArgs e)
        {
            cTS = new TickerSet(size, empty);//Reset the current ticker set
            tSA[current] = cTS;//Save over the old Ticker set
            memoryName();
            for (int i = 0; i < size; i++)//Loop through each 
            {
                changeNum(i, "");
            }
            errorMessage("");
        }
        private void Reset(object sender, RoutedEventArgs e)
        {
            if (cTS != null)
            {
                for (int i = 0; i < size; i++)//Loop through each 
                {
                    changeNum(i, "");//Reset each number
                }

                cTS.reset();//Reset cTS
                tSA[current] = cTS;//Save over the old Ticker set
            }
            errorMessage("");
        }
        private void memoryName()
        {
            TextBlock[] memory = { memory1, memory2, memory3, memory4, memory5 };//Array of textboxs
            memory[current].Text = cTS.getName();//Sets the name to display as one of the memory slot
            setName.Text = "";
        }
        private void Select1(object sender, RoutedEventArgs e)
        {
            tSA[current] = cTS;//Save the current ticker set into current save slot
            cTS = tSA[0];//Set current ticker set from save slot 0
            int temp = current;
            current = 0;
            SelectMemory(temp, current);
            display();
        }
        private void Select2(object sender, RoutedEventArgs e)
        {
            tSA[current] = cTS;//Save the current ticker set into current save slot
            cTS = tSA[1];//Set current ticker set from save slot 1
            int temp = current;
            current = 1;
            SelectMemory(temp, current);
            display();
        }
        private void Select3(object sender, RoutedEventArgs e)
        {
            tSA[current] = cTS;//Save the current ticker set into current save slot
            cTS = tSA[2];//Set current ticker set from save slot 2
            int temp = current;
            current = 2;
            SelectMemory(temp, current);
            display();
        }
        private void Select4(object sender, RoutedEventArgs e)
        {
            tSA[current] = cTS;//Save the current ticker set into current save slot
            cTS = tSA[3];//Set current ticker set from save slot 3
            int temp = current;
            current = 3;
            SelectMemory(temp, current);
            display();
        }
        private void Select5(object sender, RoutedEventArgs e)
        {
            tSA[current] = cTS;//Save the current ticker set into current save slot
            cTS = tSA[4];//Set current ticker set from save slot 4
            int temp = current;
            current = 4;
            SelectMemory(temp, current);
            display();
        }
        private void SelectMemory(int old, int currentNum)
        {
            Button[] saveSlot = { slot1, slot2, slot3, slot4, slot5 };
            if (currentNum != old)
            {
                for (int i = 0; i < memory; i++)
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
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            if (cTS == null)
            {
                errorMessage("Slot is empty");
                return;
            }
            if (cTS.getName() == empty)
            {
                errorMessage("Slot is empty");
                return;
            }
            int amount, max, start;
            try
            {
                amount = Int32.Parse(amountRoll.Text);//Try to covert string to int for amount
            }
            catch
            {
                errorMessage("Amount is an illegal input");
                return;
            }
            if (amount <= 0)
            {
                errorMessage("Amount is less than or equal to 0 which is an illegal input");
                return;
            }

            try
            {
                max = Int32.Parse(maxNum.Text);//Try to covert string to int for max
            }
            catch
            {
                errorMessage("Max number is an illegal input");
                return;
            }
            if (max <= 0)
            {
                errorMessage("Max number is less than or equal to 0 which is an illegal input");
                return;
            }

            try
            {
                start = Int32.Parse(startNum.Text);//Try to covert string to int for start
            }
            catch
            {
                errorMessage("Starting number is an illegal input");
                return;
            }

            for (int i = 0; i < amount; i++)//Loop for each number in amout
            {
                if (cTS.size() >= size)//End loop if size of the current ticker set is greater the max size
                {
                    break;
                }

                common.Ticker tick = new common.Ticker(max, start);//Create ticker
                cTS.addTicker(tick);//Add ticker
                cTS.getTicker(i);//Get ticker
            }
            display();
            amountRoll.Text = "";
            maxNum.Text = "";
            startNum.Text = "";
            errorMessage("");
            memoryName();
            
        }
        public void changeNum(int valNum, string change)
        {
            TextBlock[] value = { value1, value2, value3, value4 };//Array of textblocks represting the number to be displayed
            value[valNum].Text = change;//Change set textblock
        }
        private void display()
        {
            if (cTS != null)//Check if cTS exists
            {
                for (int i = 0; i < size; i++)//Loops through each Ticker slot
                {
                    if (cTS.getTicker(i))//Check that ticker exists
                        changeNum(i, cTS.getRetNum().ToString());
                }
            }
            else
            {
                for (int i = 0; i < size; i++)//Loops through each Ticker slot
                {
                    changeNum(i, "");
                }
            }
        }

        private void modBut(object sender, RoutedEventArgs e)
        {
            int i = 0;
            Button[] butAdd = { addNum1, addNum2, addNum3, addNum4 };//Array of buttons represting commands to add from ticker
            Button[] butSub = { subNum1, subNum2, subNum3, subNum4 };//Array of textblocks represting commands to subtrack from ticker
            if (cTS != null)
            {//Check if cTS exists
                foreach (Button b in butAdd)
                {//Loops through each butAdd
                    if (sender == b)//If sender equal the button
                    {
                        if (cTS.getTicker(i))
                        {
                            modNum(i, true);
                        }
                    }
                    i++;
                }
                i = 0;
                foreach (Button b in butSub)//Loops through each butSub
                {
                    if (sender == b)//If sender equal the button
                    {
                        if (cTS.getTicker(i))
                        {
                            modNum(i, false);
                        }
                    }
                    i++;
                }
            }

        }
        private void modNum(int num, bool boolAdd)
        {
            TextBox[] textB = { Num1, Num2, Num3, Num4 };//Array of textboxs represting user input
            int mod = 0;
            try
            {
                mod = Int32.Parse(textB[num].Text);//Try to convert user input to an int for mod
            }
            catch
            {
                errorMessage("Modify is an illegal input");
                return;
            }
            if (mod <= 0)
            {
                errorMessage("Modify is less than or equal to 0 which is an illegal input");
                return;
            }

            if (!boolAdd) mod = -mod;//If the user wnat to subtract it turns mod into its negative
            cTS.getTicker(num);//get choosen ticker
            cTS.tick().modify(mod);//users mod number to modify ticker

            errorMessage("");
            changeNum(num, cTS.tick().getNumber().ToString());//update displayed value to the current value
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
                username = "Guest";//Creates a defualt empty set if set does not exist
            if (cTS == null)
                cTS = new TickerSet(size, empty);//Creates a defualt empty set if set does not exist
            cTS.setPlayer(username, ID);//Set Player Current Ticker Set
            Player.Text = username;
            for (int i = 0; i < memory; i++)
            {
                if (tSA[i] == null)
                    tSA[i] = new TickerSet(size, empty);//Creates a defualt empty set if set does not exist
                tSA[i].setPlayer(username, ID);//Set Player Dice Set Array

            }
        }
    }
}
