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

        public static Thread customEffectsThread1 = new Thread(new ThreadStart(CustomEffects.BabelSpearEffect));
        public static Thread customEffectsThread2 = new Thread(new ThreadStart(CustomEffects.DragonsYEffect));


        private void button1_Click(object sender, EventArgs e)      //Dayuppy
        {
            if (!dayThread.IsAlive) //If we are not already running
                dayThread.Start(); //Start thread
        }

        private void button2_Click(object sender, EventArgs e)      //mike
        {
            //place here the function you want to use from your .cs file
            if (!weaponsThread.IsAlive) //If we are not already running
                weaponsThread.Start(); //Start thread

            if (!customEffectsThread1.IsAlive) //If we are not already running
                customEffectsThread1.Start(); //Start thread

            if (!customEffectsThread2.IsAlive) //If we are not already running
                customEffectsThread2.Start(); //Start thread
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
