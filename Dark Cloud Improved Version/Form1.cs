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
        //public static Thread chestThread = new Thread(new ThreadStart(CustomChests.ChestRandomizer));
        public static Thread townThread = new Thread(new ThreadStart(TownCharacter.InitializeChrOffsets));
        public static Thread weaponsThread = new Thread(new ThreadStart(Weapons.WeaponsBalanceChanges));
        public static Thread TASSThread = new Thread(new ThreadStart(TASThread.RunTAS));
        public static Thread TASSThread2 = new Thread(new ThreadStart(TASThread.RecordTAS));
        public static Thread dungeonthread = new Thread(new ThreadStart(DungeonThread.InsideDungeonThread));
        public static Thread debugThread = new Thread(new ThreadStart(CheatCodes.DebugOptions));

        private void button1_Click(object sender, EventArgs e)      //Dayuppy
        {
            if (!dayThread.IsAlive) //If we are not already running
                dayThread.Start(); //Start thread
        }

        private void button2_Click(object sender, EventArgs e)      //mike
        {
            //place here the function you want to use from your .cs file
            if (!dungeonthread.IsAlive) //If we are not already running
                dungeonthread.Start(); //Start thread

            if (!debugThread.IsAlive) //If we are not already running
                debugThread.Start(); //Start thread
        }

        private void button3_Click(object sender, EventArgs e)      //plgue
        {
            //place here the function you want to use from your .cs file            
        }

        private void button4_Click(object sender, EventArgs e)      //wordofwind
        {
            //if (!chestThread.IsAlive) chestThread.Start();
            if (!townThread.IsAlive) townThread.Start();
            //if (!TASSThread.IsAlive) TASSThread.Start();
            //if (!TASSThread2.IsAlive) TASSThread2.Start();
        }

        private void button5_Click(object sender, EventArgs e)  //DungeonThread
        {
            if (!dungeonthread.IsAlive) //If we are not already running
                dungeonthread.Start(); //Start thread
        }

        private void button6_Click(object sender, EventArgs e)  //townThread
        {
            if (!townThread.IsAlive) townThread.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (!debugThread.IsAlive) //If we are not already running
                    debugThread.Start();

                checkBox1.Enabled = false;
            }

        }
    }
}
