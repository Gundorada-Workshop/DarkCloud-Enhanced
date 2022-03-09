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
        private static Form1 instance;
        private delegate void EnableDelegate(bool enable);
        public Form1()
        {
            InitializeComponent();
            instance = this;

        }

        public static Thread dayThread = new Thread(new ThreadStart(Dayuppy.Testing)); //Create a new thread to run Testing() from within Dayuppy.cs
        //public static Thread chestThread = new Thread(new ThreadStart(CustomChests.ChestRandomizer));
        public static Thread townThread = new Thread(new ThreadStart(TownCharacter.InitializeChrOffsets));
        public static Thread weaponsThread = new Thread(new ThreadStart(Weapons.WeaponsBalanceChanges));
        public static Thread TASSThread = new Thread(new ThreadStart(TASThread.RunTAS));
        public static Thread TASSThread2 = new Thread(new ThreadStart(TASThread.RecordTAS));
        public static Thread dungeonthread = new Thread(new ThreadStart(DungeonThread.InsideDungeonThread));
        public static Thread debugThread = new Thread(new ThreadStart(CheatCodes.DebugOptions));
        public static Thread launchThread = new Thread(new ThreadStart(MainMenuThread.CheckEmulatorAndGame));

        private void button1_Click(object sender, EventArgs e)      //Dayuppy
        {
            if (!dayThread.IsAlive) //If we are not already running
                dayThread.Start(); //Start thread
        }

        private void button2_Click(object sender, EventArgs e)      //mike
        {
            //place here the function you want to use from your .cs file
            //if (!weaponsThread.IsAlive) //If we are not already running
            weaponsThread.Start(); //Start thread
            
            //The Synthsphere Listener thread
            Weapons.weaponsMenuListener.Start();
            
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

        private void buttonLaunchMod(object sender, EventArgs e) //Launch Mod as normal User
        {
            tabControl2.Visible = true;
            button7.Visible = false;
            button8.Visible = false;
            if (!launchThread.IsAlive) launchThread.Start();
        }

        private void buttonLaunchModAsDev(object sender, EventArgs e) //Launch Mod with dev buttons
        {
            tabControl1.Visible = true;
            button7.Visible = false;
            button8.Visible = false;          
        }

        public static void EmulatorCount(int newValue)
        {
            if (newValue == 0)
            {
                instance.NoEmulatorsActive(true);
            }
            else if (newValue > 1)
            {
                instance.TooManyEmulatorsActive(true);
            }
            else if (newValue == 1)
            {
                instance.GameNotActive(true);
            }
        }

        public static void PnachNotActive()
        {
            instance.FormPnachNotActive(true);
        }

        public static void FirstLaunchGameMode(bool validGameMode)
        {
            if (validGameMode == false)
            {
                instance.InvalidFirstLaunchGameMode(true);
            }
            else
            {
                instance.ValidFirstLaunchGameMode(true);
            }
        }
        void NoEmulatorsActive(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(NoEmulatorsActive), new object[] { enable });
                return;
            }
            label2.Text = "Cannot detect PCSX2-Emulator!\n\nPlease launch your emulator to continue.";
        }

        void TooManyEmulatorsActive(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(TooManyEmulatorsActive), new object[] { enable });
                return;
            }
            label2.Text = "Too many PCSX2-emulators open!\n\nPlease make sure only one is running at time.";
        }

        void GameNotActive(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(GameNotActive), new object[] { enable });
                return;
            }
            label2.Text = "Please boot Dark Cloud (USA) to continue.";
        }

        void InvalidFirstLaunchGameMode(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(InvalidFirstLaunchGameMode), new object[] { enable });
                return;
            }
            label2.Text = "Detected a save file already running!\n\nPlease re-boot Dark Cloud to start the Mod.";
        }

        void ValidFirstLaunchGameMode(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(ValidFirstLaunchGameMode), new object[] { enable });
                return;
            }
            label2.Text = "Currently in Main Menu.";
        }

        void FormPnachNotActive(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(FormPnachNotActive), new object[] { enable });
                return;
            }
            label2.Text = "PNACH File not active!\n\nPlease put the Enhanced Mod's PNACH file into the Emulator's Cheats folder and active cheats in Emulator with System->Enable Cheats";
        }
    }
}
