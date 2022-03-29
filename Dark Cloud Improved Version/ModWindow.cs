using System;
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
    public partial class ModWindow : Form
    {
        private static ModWindow instance;
        private delegate void EnableDelegate(bool enable);
        public ModWindow()
        {
            InitializeComponent();
            instance = this;

        } 

        public static Thread dayThread = new Thread(new ThreadStart(Dayuppy.Testing)); //Create a new thread to run Testing() from within Dayuppy.cs
        //public static Thread chestThread = new Thread(new ThreadStart(CustomChests.ChestRandomizer));
        public static Thread townThread = new Thread(new ThreadStart(TownCharacter.InitializeChrOffsets));
        public static Thread TASSThread = new Thread(new ThreadStart(TASThread.RunTAS));
        public static Thread TASSThread2 = new Thread(new ThreadStart(TASThread.RecordTAS));
        public static Thread dungeonthread = new Thread(new ThreadStart(DungeonThread.InsideDungeonThread));
        public static Thread debugThread = new Thread(new ThreadStart(CheatCodes.DebugOptions));
        public static Thread launchThread = new Thread(new ThreadStart(MainMenuThread.CheckEmulatorAndGame));

        #region Basic stuff
        private void ModWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion

        #region Validations
        private void ValidateNumber(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit(Convert.ToChar(e.KeyValue)))
            {
                e.SuppressKeyPress = true;
            }
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
            Label_UserMode_PlaceholderText.Text = "Cannot detect PCSX2-Emulator!\n\nPlease launch your emulator to continue.";
        }

        void TooManyEmulatorsActive(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(TooManyEmulatorsActive), new object[] { enable });
                return;
            }
            Label_UserMode_PlaceholderText.Text = "Too many PCSX2-emulators open!\n\nPlease make sure only one is running at time.";
        }

        void GameNotActive(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(GameNotActive), new object[] { enable });
                return;
            }
            Label_UserMode_PlaceholderText.Text = "Please boot Dark Cloud (USA) to continue.";
        }

        void InvalidFirstLaunchGameMode(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(InvalidFirstLaunchGameMode), new object[] { enable });
                return;
            }
            Label_UserMode_PlaceholderText.Text = "Detected a save file already running!\n\nPlease re-boot Dark Cloud to start the Mod.";
            MainMenuThread.saveFileMessageBox = true;
            string message = "Detected a save file already running! Enhanced Mod currently not active.\n\nThe mod needs to be launched while in the Main Menu.\n\nDo you want the mod to return your game to Main Menu?";
            string title = "Save file running!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Exclamation);
            this.TopMost = false;

            while (true)
            {
                Label_UserMode_PlaceholderText.Text = "Detected a save file already running!\n\nPlease re-boot Dark Cloud to start the Mod.";
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
            Label_UserMode_PlaceholderText.Text = "Dark Cloud has been booted!";
        }

        void FormPnachNotActive(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(FormPnachNotActive), new object[] { enable });
                return;
            }
            Label_UserMode_PlaceholderText.Text = "PNACH File not active!\n\nPlease put the Enhanced Mod's PNACH file into the Emulator's Cheats folder and active cheats in Emulator with System->Enable Cheats";
        }

        void FormCurrentlyInMainMenu(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(FormCurrentlyInMainMenu), new object[] { enable });
                return;
            }
            Label_UserMode_PlaceholderText.Text = "Enhanced Mod is active! Currently in Main menu.\n\nYou can start a new game or load a save.";
        }

        void FormCurrentlyInGame(bool enable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EnableDelegate(FormCurrentlyInGame), new object[] { enable });
                return;
            }
            Label_UserMode_PlaceholderText.Text = "Enhanced Mod is active and running!\n\nRemember to NEVER use save states with the mod! Always save the game normally through the game's save menu.";
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
                Label_UserMode_PlaceholderText.Text = "A possible save state used! Mod has been terminated.";
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

            Label_UserMode_PlaceholderText.Text = "Another instance of Enhanced Mod is already active!\n\nYou can close this window.";
        }

        protected override void OnFormClosed(FormClosedEventArgs e) //when mod is quit
        {
            launchThread.Abort();
            Memory.WriteByte(0x21F10024, 0);
            base.OnFormClosed(e);
        }
        #endregion

        #region Main Screen
        private void buttonLaunchModAsUser(object sender, EventArgs e) //Launch Mod as normal User
        {
            TabControl_USER.Visible = true;
            Container_MainModes.Visible = false;
            if (!launchThread.IsAlive) launchThread.Start();
        }

        private void buttonLaunchModAsDev(object sender, EventArgs e) //Launch Mod with dev buttons
        {
            TabControl_DEV.Visible = true;
            Container_MainModes.Visible = false;

            //Initialize fields
            DEV_Page2_TextBox_Gilda.Text = Player.Gilda.ToString();

            //Initialize enemy hp fields
            DEV_Page2_TextBox_Enemy1.Text = Memory.ReadUInt(Enemies.Enemy0.hp).ToString();
            DEV_Page2_TextBox_Enemy2.Text = Memory.ReadUInt(Enemies.Enemy1.hp).ToString();
            DEV_Page2_TextBox_Enemy3.Text = Memory.ReadUInt(Enemies.Enemy2.hp).ToString();
            DEV_Page2_TextBox_Enemy4.Text = Memory.ReadUInt(Enemies.Enemy3.hp).ToString();
            DEV_Page2_TextBox_Enemy5.Text = Memory.ReadUInt(Enemies.Enemy4.hp).ToString();
            DEV_Page2_TextBox_Enemy6.Text = Memory.ReadUInt(Enemies.Enemy5.hp).ToString();
            DEV_Page2_TextBox_Enemy7.Text = Memory.ReadUInt(Enemies.Enemy6.hp).ToString();
            DEV_Page2_TextBox_Enemy8.Text = Memory.ReadUInt(Enemies.Enemy7.hp).ToString();
            DEV_Page2_TextBox_Enemy9.Text = Memory.ReadUInt(Enemies.Enemy8.hp).ToString();
            DEV_Page2_TextBox_Enemy10.Text = Memory.ReadUInt(Enemies.Enemy9.hp).ToString();
            DEV_Page2_TextBox_Enemy11.Text = Memory.ReadUInt(Enemies.Enemy10.hp).ToString();
            DEV_Page2_TextBox_Enemy12.Text = Memory.ReadUInt(Enemies.Enemy11.hp).ToString();
            DEV_Page2_TextBox_Enemy13.Text = Memory.ReadUInt(Enemies.Enemy12.hp).ToString();
            DEV_Page2_TextBox_Enemy14.Text = Memory.ReadUInt(Enemies.Enemy13.hp).ToString();
            DEV_Page2_TextBox_Enemy15.Text = Memory.ReadUInt(Enemies.Enemy14.hp).ToString();
            DEV_Page2_TextBox_Enemy16.Text = Memory.ReadUInt(Enemies.Enemy15.hp).ToString();
        }
        #endregion

        #region User Page 1
        private void Btn_UserMode_Quit_Clicked(object sender, EventArgs e)
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
        #endregion

        #region USER Page 2
        private void CBox_UserMode_WeaponBeepsChanged(object sender, EventArgs e) //Option 1 Checkbox
        {
            if (CBox_UserMode_WeaponBeeps.Checked == true)
            {
                Memory.WriteByte(0x21F10028, 1); //Flag to disable weapon beeping sounds
            }
            else if (CBox_UserMode_WeaponBeeps.Checked == false)
            {
                Memory.WriteByte(0x21F10028, 0);
            }
        }

        private void CBox_UserMode_GraphicsChanged(object sender, EventArgs e)
        {
            if (CBox_UserMode_BattleMusic.Checked == true)
            {
                Memory.WriteByte(0x21F1002C, 1); //Flag to disable weapon beeping sounds
            }
            else if (CBox_UserMode_BattleMusic.Checked == false)
            {
                Memory.WriteByte(0x21F1002C, 0);
            }
        }

        private void CBox_UserMode_Widescreen_Changed(object sender, EventArgs e)
        {
            if (CBox_UserMode_Widescreen.Checked == true)
            {
                Memory.WriteByte(0x21F10030, 1); //Flag to enable widescreen
            }
            else if (CBox_UserMode_Widescreen.Checked == false)
            {
                Memory.WriteByte(0x21F10030, 0);
            }
        }

        private void CBox_UserMode_Graphics_Changed(object sender, EventArgs e)
        {
            if (CBox_UserMode_Graphics.Checked == true)
            {
                Memory.WriteByte(0x21F10034, 1); //Flag to enable graphical improvements
            }
            else if (CBox_UserMode_Graphics.Checked == false)
            {
                Memory.WriteByte(0x21F10034, 0);
            }
        }

        #endregion

        #region DEV Page 1
        private void DEV_Page1_Btn_Dayuppy(object sender, EventArgs e)  //Dayuppy
        {
            if (dayThread.ThreadState == ThreadState.Unstarted)
            {
                dayThread.Start();
            }
        }

        private void DEV_Page1_Btn_Mike(object sender, EventArgs e) //Mike
        {
            //Start the changes Thread
            if (MainMenuThread.changesThread.ThreadState == ThreadState.Unstarted)
            {
                MainMenuThread.changesThread.Start();
            }
            else return;

            //The Synthsphere Listener thread
            if (Weapons.weaponsMenuListener.ThreadState == ThreadState.Unstarted)
            {
                Weapons.weaponsMenuListener.Start();//Start thread
            }
            else return;
        }

        private void DEV_Page1_Btn_Plgue(object sender, EventArgs e)      //plgue
        {
            //place here the function you want to use from your .cs file            
        }

        private void DEV_Page1_Btn_WordOfWind(object sender, EventArgs e)      //wordofwind
        {
            //if (!chestThread.IsAlive) chestThread.Start();

            if (townThread.ThreadState == ThreadState.Unstarted)
            {
                townThread.Start();//Start thread
            }
            else return;

            //if (!TASSThread.IsAlive) TASSThread.Start();
            //if (!TASSThread2.IsAlive) TASSThread2.Start();


        }

        private void DEV_Page1_Btn_DungeonThread(object sender, EventArgs e)  //DungeonThread
        {
            if (dungeonthread.ThreadState == ThreadState.Unstarted)
            {
                dungeonthread.Start();//Start thread
            }
            else return;
        }

        private void DEV_Page1_Btn_TownThread(object sender, EventArgs e)  //townThread
        {
            if (townThread.ThreadState == ThreadState.Unstarted)
            {
                townThread.Start();//Start thread
            }
            else return;
        }

        private void DEV_Page1_CBox_DebugThread(object sender, EventArgs e)
        {
            if (CBox_DebugThread.Checked)
            {
                if (debugThread.ThreadState == ThreadState.Unstarted)
                {
                    debugThread.Start();//Start thread
                }
                else return;

                CBox_DebugThread.Enabled = false;
            }
        }
        #endregion

        #region DEV Page 2



        private void DEV_Page2_TextBox_Gilda_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Gilda.Text == "")
            {
                DEV_Page2_TextBox_Gilda.Text = "0";
                return;
            }
            
            Player.Gilda = Convert.ToUInt16(DEV_Page2_TextBox_Gilda.Text);

        }

        private void DEV_Page2_Btn_SetEnemiesMaxHP_Click(object sender, EventArgs e)
        {
            int MaxEnemyHp = int.MaxValue;

            DEV_Page2_TextBox_Enemy1.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy0.hp, MaxEnemyHp);
            DEV_Page2_TextBox_Enemy2.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy1.hp, MaxEnemyHp);
            DEV_Page2_TextBox_Enemy3.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy2.hp, MaxEnemyHp);
            DEV_Page2_TextBox_Enemy4.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy3.hp, MaxEnemyHp);
            DEV_Page2_TextBox_Enemy5.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy4.hp, MaxEnemyHp);
            DEV_Page2_TextBox_Enemy6.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy5.hp, MaxEnemyHp);
            DEV_Page2_TextBox_Enemy7.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy6.hp, MaxEnemyHp);
            DEV_Page2_TextBox_Enemy8.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy7.hp, MaxEnemyHp);
            DEV_Page2_TextBox_Enemy9.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy8.hp, MaxEnemyHp);
            DEV_Page2_TextBox_Enemy10.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy9.hp, MaxEnemyHp);
            DEV_Page2_TextBox_Enemy11.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy10.hp, MaxEnemyHp);
            DEV_Page2_TextBox_Enemy12.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy11.hp, MaxEnemyHp);
            DEV_Page2_TextBox_Enemy13.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy12.hp, MaxEnemyHp);
            DEV_Page2_TextBox_Enemy14.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy13.hp, MaxEnemyHp);
            DEV_Page2_TextBox_Enemy15.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy14.hp, MaxEnemyHp);
            DEV_Page2_TextBox_Enemy16.Text = MaxEnemyHp.ToString(); Memory.WriteInt(Enemies.Enemy15.hp, MaxEnemyHp);
        }


        private void DEV_Page2_TextBox_Enemy1_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy1.Text == "") DEV_Page2_TextBox_Enemy1.Text = "0";

            Memory.WriteInt(Enemies.Enemy0.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy1.Text));
        }

        private void DEV_Page2_TextBox_Enemy2_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy2.Text == "") DEV_Page2_TextBox_Enemy2.Text = "0";

            Memory.WriteInt(Enemies.Enemy1.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy2.Text));

        }

        private void DEV_Page2_TextBox_Enemy3_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy3.Text == "") DEV_Page2_TextBox_Enemy3.Text = "0";

            Memory.WriteInt(Enemies.Enemy2.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy3.Text));

        }

        private void DEV_Page2_TextBox_Enemy4_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy4.Text == "") DEV_Page2_TextBox_Enemy4.Text = "0";

            Memory.WriteInt(Enemies.Enemy3.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy4.Text));

        }

        private void DEV_Page2_TextBox_Enemy5_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy5.Text == "") DEV_Page2_TextBox_Enemy5.Text = "0";

            Memory.WriteInt(Enemies.Enemy4.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy5.Text));

        }

        private void DEV_Page2_TextBox_Enemy6_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy6.Text == "") DEV_Page2_TextBox_Enemy6.Text = "0";

            Memory.WriteInt(Enemies.Enemy5.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy6.Text));

        }

        private void DEV_Page2_TextBox_Enemy7_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy7.Text == "") DEV_Page2_TextBox_Enemy7.Text = "0";

            Memory.WriteInt(Enemies.Enemy6.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy7.Text));

        }

        private void DEV_Page2_TextBox_Enemy8_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy8.Text == "") DEV_Page2_TextBox_Enemy8.Text = "0";

            Memory.WriteInt(Enemies.Enemy7.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy8.Text));

        }

        private void DEV_Page2_TextBox_Enemy9_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy9.Text == "") DEV_Page2_TextBox_Enemy9.Text = "0";

            Memory.WriteInt(Enemies.Enemy8.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy9.Text));

        }

        private void DEV_Page2_TextBox_Enemy10_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy10.Text == "") DEV_Page2_TextBox_Enemy10.Text = "0";

            Memory.WriteInt(Enemies.Enemy9.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy10.Text));

        }

        private void DEV_Page2_TextBox_Enemy11_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy11.Text == "") DEV_Page2_TextBox_Enemy11.Text = "0";

            Memory.WriteInt(Enemies.Enemy10.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy11.Text));

        }

        private void DEV_Page2_TextBox_Enemy12_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy12.Text == "") DEV_Page2_TextBox_Enemy12.Text = "0";

            Memory.WriteInt(Enemies.Enemy11.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy12.Text));

        }

        private void DEV_Page2_TextBox_Enemy13_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy13.Text == "") DEV_Page2_TextBox_Enemy13.Text = "0";

            Memory.WriteInt(Enemies.Enemy12.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy13.Text));

        }

        private void DEV_Page2_TextBox_Enemy14_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy14.Text == "") DEV_Page2_TextBox_Enemy14.Text = "0";

            Memory.WriteInt(Enemies.Enemy13.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy14.Text));

        }

        private void DEV_Page2_TextBox_Enemy15_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy15.Text == "") DEV_Page2_TextBox_Enemy15.Text = "0";

            Memory.WriteInt(Enemies.Enemy14.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy15.Text));

        }

        private void DEV_Page2_TextBox_Enemy16_TextChanged(object sender, EventArgs e)
        {
            if (DEV_Page2_TextBox_Enemy16.Text == "") DEV_Page2_TextBox_Enemy16.Text = "0";

            Memory.WriteInt(Enemies.Enemy15.hp, Convert.ToInt32(DEV_Page2_TextBox_Enemy16.Text));

        }


        #endregion


    }
}
