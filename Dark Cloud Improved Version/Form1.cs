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

        public static void CurrentlyInMainMenu()
        {
            instance.FormCurrentlyInMainMenu(true);
        }

        public static void CurrentlyInGame()
        {
            instance.FormCurrentlyInGame(true);
        }

        public static void SaveStateDetected()
        {
            instance.FormSaveStateDetected(true);
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

        public static void NotEnhancedModSaveFile()
        {
            instance.FormNotEnhancedModSaveFile(true);
        }

        public static void EnhancedModAlreadyOpen()
        {
            instance.FormEnhancedModAlreadyOpen(true);
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
            MainMenuThread.saveFileMessageBox = true;
            string message = "Detected a save file already running! Enhanced Mod currently not active.\n\nThe mod needs to be launched while in the Main Menu.\n\nDo you want the mod to return your game to Main Menu?";
            string title = "Save file running!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Exclamation);
            this.TopMost = false;
            
            while (true)
            {
                label2.Text = "Detected a save file already running!\n\nPlease re-boot Dark Cloud to start the Mod.";
                if (result == DialogResult.Yes)
                {
                    if (Player.InDungeonFloor() == true)
                        Memory.WriteInt(Addresses.dungeonDebugMenu, 151); //If we are in a dungeon, this will take us to the main menu
                    else
                        Memory.WriteByte(Addresses.townSoftReset, 1);
                    //MainMenuThread.saveFileMessageBox = false;
                    break;
                }
                else if (result == DialogResult.No)
                {
                    break;
                }
            }

            
        }

        void ValidFirstLaunchGameMode(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(ValidFirstLaunchGameMode), new object[] { enable });
                return;
            }
            label2.Text = "Dark Cloud has been booted!";
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

        void FormCurrentlyInMainMenu(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(FormCurrentlyInMainMenu), new object[] { enable });
                return;
            }
            label2.Text = "Enhanced Mod is active! Currently in Main menu.\n\nYou can start a new game or load a save.";
        }

        void FormCurrentlyInGame(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(FormCurrentlyInGame), new object[] { enable });
                return;
            }
            label2.Text = "Enhanced Mod is active and running!\n\nRemember to NEVER use save states with the mod! Always save the game normally through the game's save menu.";
        }

        void FormSaveStateDetected(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(FormSaveStateDetected), new object[] { enable });
                return;
            }
            this.TopMost = true;
            MainMenuThread.saveStateUsed = true;
            string message = "The mod has detected a possible save state load!\n\nUsing save states is NOT ALLOWED while using the Enhanced Mod, since it can cause major issues.\n\nThe game has been reset, and this mod will be closed.";
            string title = "Save state detected!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Exclamation);
            this.TopMost = false;
            while (true)
            {
                label2.Text = "A possible save state used! Mod has been terminated.";
                launchThread.Abort();
                Memory.WriteByte(0x21F10024, 0);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }

        void FormNotEnhancedModSaveFile(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(FormNotEnhancedModSaveFile), new object[] { enable });
                return;
            }

            this.TopMost = true;
            string message = "Loaded a Dark Cloud save file which was not started with Enhanced Mod!\n\nPlease load a save file which you have started with Enhanced Mod, or start a New Game with the mod.";
            string title = "Invalid save file!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Exclamation);
            this.TopMost = false;
            while (true)
            {
                if (result == DialogResult.OK)
                {
                    break;
                }
                else
                {
                    break;
                }
            }
        }

        void FormEnhancedModAlreadyOpen(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(FormEnhancedModAlreadyOpen), new object[] { enable });
                return;
            }

            label2.Text = "Another instance of Enhanced Mod is already active!\n\nYou can close this window.";
        }

        protected override void OnFormClosed(FormClosedEventArgs e) //when mod is quit
        {
            launchThread.Abort();
            Memory.WriteByte(0x21F10024, 0);
            base.OnFormClosed(e);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) //Option 1 Checkbox
        {
            if (checkBox2.Checked == true)
            {
                Memory.WriteByte(0x21F10028, 1); //Flag to disable weapon beeping sounds
            }
            else if (checkBox2.Checked == false)
            {
                Memory.WriteByte(0x21F10028, 0);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                Memory.WriteByte(0x21F1002C, 1); //Flag to disable weapon beeping sounds
            }
            else if (checkBox3.Checked == false)
            {
                Memory.WriteByte(0x21F1002C, 0);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                Memory.WriteByte(0x21F10030, 1); //Flag to enable widescreen
            }
            else if (checkBox4.Checked == false)
            {
                Memory.WriteByte(0x21F10030, 0);
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                Memory.WriteByte(0x21F10034, 1); //Flag to enable graphical improvements
            }
            else if (checkBox5.Checked == false)
            {
                Memory.WriteByte(0x21F10034, 0);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (Memory.ReadByte(Addresses.mode) == 2 || Memory.ReadByte(Addresses.mode) == 3)
            {
                this.TopMost = true;
                string message = "Closing the mod will return your game to the Main Menu, remember to save your game!\n\nAre you sure you want to quit?\n\nTip: You can soft-reset your game back to the Main Menu by holding Start+Select+L1+L2+R1+R2, and then quit the mod without any warnings.";
                string title = "Are you sure you want to quit?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Exclamation);
                

                while (true)
                {
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else if (result == DialogResult.No)
                    {
                        break;
                    }
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
