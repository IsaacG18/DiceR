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
    public sealed partial class Solo : Page
    {
        static int memory = 5;
        DiceSet[] dSA = new DiceSet[memory];
        DiceSet cDS;
        int current = 0;
        public Solo()
        {
            this.InitializeComponent();
        }
        
        private void Roll(object sender, RoutedEventArgs e)
        {

            TextBlock[] diceRolls = { result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14, result15 };


          if(cDS == null)
            {
                cDS = new DiceSet(0, "Empty Slot");
                return;
            }
            cDS.rollAll(0);
            display();
        }
        private void display()
        {
            TextBlock[] diceRolls = { result1, result2, result3, result4, result5, result6, result7, result8, result9, result10, result11, result12, result13, result14, result15 };
            int size = cDS.size();
            int i = 0;
            foreach (TextBlock dR in diceRolls)
            {
                if (size > i)
                {
                    cDS.getAndDeleteDice(i, "element", false);
                    dR.Text = cDS.getRetNum().ToString();
                }
                else
                {
                    dR.Text = "";
                }
                i++;
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            int amount, mod, diceR;
            try
            {
                 amount = Int32.Parse(amountRoll.Text);
            }
            catch
            {
                 amount = 0;
            }
            try
            {
                mod = Int32.Parse(modRoll.Text);
            }
            catch
            {
                mod = 0;
            }
            
            if(subtract.IsChecked== true)
            {
                mod = -mod;
            }
            try
            {
                diceR = Int32.Parse(dicRoll.Text);
            }
            catch
            {
                diceR = 0;
            }
            if (cDS == null)
            {
                cDS = new DiceSet(0, "Empty Slot");
            }

            for (int i = 0; i < amount; i++)
            {
                dice die = new dice(diceR, mod);
                cDS.addDice(die);
            }

            amountRoll.Text = "";
            modRoll.Text = "";
            dicRoll.Text = "";
        }

        private void addSet(object sender, RoutedEventArgs e)
        {
            string name = setName.Text;
            int count;
          
            try
            {
                count = Int32.Parse(diceAmount.Text);
            }
            catch
            {
                count = 0;
            }


             
            cDS = new DiceSet(count, name);
            memoryName();
        }

        private void deleteSet(object sender, RoutedEventArgs e)
        {
            cDS = new DiceSet(0,"Empty Slot");
            dSA[current] = cDS;
            memoryName();
        }
        private void memoryName()
        {
            TextBlock[] memory = { memory1, memory2, memory3, memory4, memory5 };
            memory[current].Text = cDS.getName();
            setName.Text = "";
            diceAmount.Text = "";
        }

        private void Select1(object sender, RoutedEventArgs e)
        {
            dSA[current] = cDS;
            cDS = dSA[0];
            current = 0;
        }
        private void Select2(object sender, RoutedEventArgs e)
        {
            dSA[current] = cDS;
            cDS = dSA[1];
            current = 1;
        }
        private void Select3(object sender, RoutedEventArgs e)
        {
            dSA[current] = cDS;
            cDS = dSA[2];
            current = 2;
        }
        private void Select4(object sender, RoutedEventArgs e)
        {
            dSA[current] = cDS;
            cDS = dSA[3];
            current = 3;
        }
        private void Select5(object sender, RoutedEventArgs e)
        {
            dSA[current] = cDS;
            cDS = dSA[4];
            current = 4;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            int number = 0;
            try
            {
                number = Int32.Parse(delDice.Text);
            }
            catch
            {
                return;
            }

            cDS.getAndDeleteDice(number, "number", true);
            display();
        }
    }
}
