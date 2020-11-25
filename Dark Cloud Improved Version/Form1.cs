using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dark_Cloud_Improved_Version
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Thread dayThread = new Thread(new ThreadStart(Dayuppy.Testing)); //Create a new thread to run Testing() from within Dayuppy.cs
        public static Thread chestThread = new Thread(new ThreadStart(CustomChests.ChestRandomizer));
        public static Thread townThread = new Thread(new ThreadStart(TownCharacter.InitializeChrOffsets));
        public static Thread weaponsThread = new Thread(new ThreadStart(Weapons.WeaponsBalanceChanges));
        public static Thread debugThread = new Thread(new ThreadStart(CheatCodes.DebugOptions));

        public static Thread customEffectsThread1 = new Thread(new ThreadStart(CustomEffects.Xiao));
        public static Thread customEffectsThread3 = new Thread(new ThreadStart(CustomEffects.Ruby));
        public static Thread customEffectsThread4 = new Thread(new ThreadStart(CustomEffects.Ungaga));
        public static Thread customEffectsThread5 = new Thread(new ThreadStart(CustomEffects.Osmond));


        private void button1_Click(object sender, EventArgs e)      //Dayuppy
        {
            if (!dayThread.IsAlive) //If we are not already running
                dayThread.Start(); //Start thread
        }

        private void button2_Click(object sender, EventArgs e)      //mike
        {
            //place here the function you want to use from your .cs file
            /*if (!weaponsThread.IsAlive) //If we are not already running
                weaponsThread.Start(); //Start thread*/

            if (!debugThread.IsAlive) //If we are not already running
                debugThread.Start(); //Start thread

            /*if (!customEffectsThread1.IsAlive) //If we are not already running
                customEffectsThread1.Start(); //Start thread*/

            if (!customEffectsThread3.IsAlive) //If we are not already running
                customEffectsThread3.Start(); //Start thread

            /*if (!customEffectsThread4.IsAlive) //If we are not already running
                customEffectsThread4.Start(); //Start thread*/

            /*if (!customEffectsThread5.IsAlive) //If we are not already running
                customEffectsThread5.Start(); //Start thread*/
        }

        private void button3_Click(object sender, EventArgs e)      //plgue
        {
            //place here the function you want to use from your .cs file
        }

        private void button4_Click(object sender, EventArgs e)      //wordofwind
        {
            //if (!chestThread.IsAlive) chestThread.Start();
            if (!townThread.IsAlive) townThread.Start();
        }
    }
}
