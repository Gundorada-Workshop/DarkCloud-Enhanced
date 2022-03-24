namespace Dark_Cloud_Improved_Version
{
    partial class ModWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModWindow));
            this.Btn_ModeUser = new System.Windows.Forms.Button();
            this.Btn_ModeDev = new System.Windows.Forms.Button();
            this.Tab_Dev2 = new System.Windows.Forms.TabPage();
            this.Tab_Dev1 = new System.Windows.Forms.TabPage();
            this.TabDev_Border1 = new System.Windows.Forms.Panel();
            this.TabDev_Border2 = new System.Windows.Forms.Panel();
            this.TabDev_SplitContainer = new System.Windows.Forms.SplitContainer();
            this.TabDev_BtnQuit = new System.Windows.Forms.Button();
            this.Table_MainlThreads = new System.Windows.Forms.TableLayoutPanel();
            this.Label_MainThreads = new System.Windows.Forms.Label();
            this.Btn_TownThread = new System.Windows.Forms.Button();
            this.Btn_DungeonThread = new System.Windows.Forms.Button();
            this.CBox_DebugThread = new System.Windows.Forms.CheckBox();
            this.Table_PersonalThreads = new System.Windows.Forms.TableLayoutPanel();
            this.Label_PersonalThreads = new System.Windows.Forms.Label();
            this.Btn_Wordofwind = new System.Windows.Forms.Button();
            this.Btn_Mikezord = new System.Windows.Forms.Button();
            this.Btn_Plgue = new System.Windows.Forms.Button();
            this.Btn_Dayuppy = new System.Windows.Forms.Button();
            this.TabControl_DEV = new System.Windows.Forms.TabControl();
            this.Tab_User2 = new System.Windows.Forms.TabPage();
            this.CBox_UserMode_Graphics = new System.Windows.Forms.CheckBox();
            this.CBox_UserMode_Widescreen = new System.Windows.Forms.CheckBox();
            this.CBox_UserMode_WeaponBeeps = new System.Windows.Forms.CheckBox();
            this.CBox_UserMode_BattleMusic = new System.Windows.Forms.CheckBox();
            this.Tab_User1 = new System.Windows.Forms.TabPage();
            this.Label_UserMode_PlaceholderText = new System.Windows.Forms.Label();
            this.Label_UserMode_WelcomeTitle = new System.Windows.Forms.Label();
            this.Btn_UserMode_Quit = new System.Windows.Forms.Button();
            this.TabControl_USER = new System.Windows.Forms.TabControl();
            this.Container_MainModes = new System.Windows.Forms.Panel();
            this.Tab_Dev1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TabDev_SplitContainer)).BeginInit();
            this.TabDev_SplitContainer.Panel2.SuspendLayout();
            this.TabDev_SplitContainer.SuspendLayout();
            this.Table_MainlThreads.SuspendLayout();
            this.Table_PersonalThreads.SuspendLayout();
            this.TabControl_DEV.SuspendLayout();
            this.Tab_User2.SuspendLayout();
            this.Tab_User1.SuspendLayout();
            this.TabControl_USER.SuspendLayout();
            this.Container_MainModes.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_ModeUser
            // 
            this.Btn_ModeUser.Font = new System.Drawing.Font("DarkCloud", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ModeUser.Location = new System.Drawing.Point(75, 127);
            this.Btn_ModeUser.Name = "Btn_ModeUser";
            this.Btn_ModeUser.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Btn_ModeUser.Size = new System.Drawing.Size(147, 98);
            this.Btn_ModeUser.TabIndex = 8;
            this.Btn_ModeUser.Text = "Launch Mod as User";
            this.Btn_ModeUser.UseVisualStyleBackColor = true;
            this.Btn_ModeUser.Click += new System.EventHandler(this.buttonLaunchModAsUser);
            // 
            // Btn_ModeDev
            // 
            this.Btn_ModeDev.Font = new System.Drawing.Font("DarkCloud", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ModeDev.Location = new System.Drawing.Point(292, 127);
            this.Btn_ModeDev.Name = "Btn_ModeDev";
            this.Btn_ModeDev.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Btn_ModeDev.Size = new System.Drawing.Size(147, 98);
            this.Btn_ModeDev.TabIndex = 9;
            this.Btn_ModeDev.Text = "Launch Mod as Developer";
            this.Btn_ModeDev.UseVisualStyleBackColor = true;
            this.Btn_ModeDev.Click += new System.EventHandler(this.buttonLaunchModAsDev);
            // 
            // Tab_Dev2
            // 
            this.Tab_Dev2.Location = new System.Drawing.Point(4, 27);
            this.Tab_Dev2.Name = "Tab_Dev2";
            this.Tab_Dev2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Tab_Dev2.Size = new System.Drawing.Size(506, 314);
            this.Tab_Dev2.TabIndex = 1;
            this.Tab_Dev2.Text = "Page2";
            this.Tab_Dev2.UseVisualStyleBackColor = true;
            // 
            // Tab_Dev1
            // 
            this.Tab_Dev1.Controls.Add(this.TabDev_Border1);
            this.Tab_Dev1.Controls.Add(this.TabDev_Border2);
            this.Tab_Dev1.Controls.Add(this.TabDev_SplitContainer);
            this.Tab_Dev1.Controls.Add(this.Table_MainlThreads);
            this.Tab_Dev1.Controls.Add(this.Table_PersonalThreads);
            this.Tab_Dev1.Location = new System.Drawing.Point(4, 21);
            this.Tab_Dev1.Name = "Tab_Dev1";
            this.Tab_Dev1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Tab_Dev1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tab_Dev1.Size = new System.Drawing.Size(506, 320);
            this.Tab_Dev1.TabIndex = 0;
            this.Tab_Dev1.Text = "Page1";
            this.Tab_Dev1.UseVisualStyleBackColor = true;
            // 
            // TabDev_Border1
            // 
            this.TabDev_Border1.BackColor = System.Drawing.Color.DarkGray;
            this.TabDev_Border1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabDev_Border1.Location = new System.Drawing.Point(2, 113);
            this.TabDev_Border1.Name = "TabDev_Border1";
            this.TabDev_Border1.Size = new System.Drawing.Size(494, 3);
            this.TabDev_Border1.TabIndex = 0;
            // 
            // TabDev_Border2
            // 
            this.TabDev_Border2.BackColor = System.Drawing.Color.DarkGray;
            this.TabDev_Border2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabDev_Border2.Location = new System.Drawing.Point(5, 221);
            this.TabDev_Border2.Name = "TabDev_Border2";
            this.TabDev_Border2.Size = new System.Drawing.Size(494, 3);
            this.TabDev_Border2.TabIndex = 10;
            // 
            // TabDev_SplitContainer
            // 
            this.TabDev_SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabDev_SplitContainer.Location = new System.Drawing.Point(3, 221);
            this.TabDev_SplitContainer.Name = "TabDev_SplitContainer";
            // 
            // TabDev_SplitContainer.Panel2
            // 
            this.TabDev_SplitContainer.Panel2.Controls.Add(this.TabDev_BtnQuit);
            this.TabDev_SplitContainer.Size = new System.Drawing.Size(500, 96);
            this.TabDev_SplitContainer.SplitterDistance = 166;
            this.TabDev_SplitContainer.SplitterWidth = 5;
            this.TabDev_SplitContainer.TabIndex = 9;
            // 
            // TabDev_BtnQuit
            // 
            this.TabDev_BtnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TabDev_BtnQuit.Location = new System.Drawing.Point(229, 64);
            this.TabDev_BtnQuit.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.TabDev_BtnQuit.Name = "TabDev_BtnQuit";
            this.TabDev_BtnQuit.Size = new System.Drawing.Size(87, 25);
            this.TabDev_BtnQuit.TabIndex = 0;
            this.TabDev_BtnQuit.Text = "Quit";
            this.TabDev_BtnQuit.UseVisualStyleBackColor = true;
            this.TabDev_BtnQuit.Click += new System.EventHandler(this.Btn_UserMode_Quit_Clicked);
            // 
            // Table_MainlThreads
            // 
            this.Table_MainlThreads.ColumnCount = 3;
            this.Table_MainlThreads.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Table_MainlThreads.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Table_MainlThreads.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Table_MainlThreads.Controls.Add(this.Label_MainThreads, 0, 0);
            this.Table_MainlThreads.Controls.Add(this.Btn_TownThread, 1, 0);
            this.Table_MainlThreads.Controls.Add(this.Btn_DungeonThread, 2, 0);
            this.Table_MainlThreads.Controls.Add(this.CBox_DebugThread, 1, 1);
            this.Table_MainlThreads.Dock = System.Windows.Forms.DockStyle.Top;
            this.Table_MainlThreads.Location = new System.Drawing.Point(3, 112);
            this.Table_MainlThreads.Name = "Table_MainlThreads";
            this.Table_MainlThreads.RowCount = 2;
            this.Table_MainlThreads.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Table_MainlThreads.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Table_MainlThreads.Size = new System.Drawing.Size(500, 109);
            this.Table_MainlThreads.TabIndex = 7;
            // 
            // Label_MainThreads
            // 
            this.Label_MainThreads.AutoSize = true;
            this.Label_MainThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_MainThreads.Location = new System.Drawing.Point(3, 0);
            this.Label_MainThreads.Name = "Label_MainThreads";
            this.Label_MainThreads.Size = new System.Drawing.Size(160, 54);
            this.Label_MainThreads.TabIndex = 8;
            this.Label_MainThreads.Text = "Main Threads:";
            this.Label_MainThreads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_TownThread
            // 
            this.Btn_TownThread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_TownThread.Location = new System.Drawing.Point(178, 11);
            this.Btn_TownThread.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.Btn_TownThread.Name = "Btn_TownThread";
            this.Btn_TownThread.Size = new System.Drawing.Size(142, 32);
            this.Btn_TownThread.TabIndex = 5;
            this.Btn_TownThread.Text = "Town Thread";
            this.Btn_TownThread.UseVisualStyleBackColor = true;
            this.Btn_TownThread.Click += new System.EventHandler(this.button6_Click);
            // 
            // Btn_DungeonThread
            // 
            this.Btn_DungeonThread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_DungeonThread.Location = new System.Drawing.Point(344, 11);
            this.Btn_DungeonThread.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.Btn_DungeonThread.Name = "Btn_DungeonThread";
            this.Btn_DungeonThread.Size = new System.Drawing.Size(144, 32);
            this.Btn_DungeonThread.TabIndex = 4;
            this.Btn_DungeonThread.Text = "Dungeon Thread";
            this.Btn_DungeonThread.UseVisualStyleBackColor = true;
            this.Btn_DungeonThread.Click += new System.EventHandler(this.button5_Click);
            // 
            // CBox_DebugThread
            // 
            this.CBox_DebugThread.AutoSize = true;
            this.CBox_DebugThread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBox_DebugThread.Location = new System.Drawing.Point(174, 62);
            this.CBox_DebugThread.Margin = new System.Windows.Forms.Padding(8);
            this.CBox_DebugThread.Name = "CBox_DebugThread";
            this.CBox_DebugThread.Padding = new System.Windows.Forms.Padding(5, 1, 1, 1);
            this.CBox_DebugThread.Size = new System.Drawing.Size(150, 39);
            this.CBox_DebugThread.TabIndex = 6;
            this.CBox_DebugThread.Text = "Enable Debug Thread";
            this.CBox_DebugThread.UseVisualStyleBackColor = true;
            this.CBox_DebugThread.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Table_PersonalThreads
            // 
            this.Table_PersonalThreads.ColumnCount = 3;
            this.Table_PersonalThreads.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Table_PersonalThreads.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Table_PersonalThreads.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Table_PersonalThreads.Controls.Add(this.Label_PersonalThreads, 0, 0);
            this.Table_PersonalThreads.Controls.Add(this.Btn_Wordofwind, 2, 1);
            this.Table_PersonalThreads.Controls.Add(this.Btn_Mikezord, 1, 1);
            this.Table_PersonalThreads.Controls.Add(this.Btn_Plgue, 2, 0);
            this.Table_PersonalThreads.Controls.Add(this.Btn_Dayuppy, 1, 0);
            this.Table_PersonalThreads.Dock = System.Windows.Forms.DockStyle.Top;
            this.Table_PersonalThreads.Location = new System.Drawing.Point(3, 3);
            this.Table_PersonalThreads.Name = "Table_PersonalThreads";
            this.Table_PersonalThreads.RowCount = 2;
            this.Table_PersonalThreads.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Table_PersonalThreads.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Table_PersonalThreads.Size = new System.Drawing.Size(500, 109);
            this.Table_PersonalThreads.TabIndex = 8;
            // 
            // Label_PersonalThreads
            // 
            this.Label_PersonalThreads.AutoSize = true;
            this.Label_PersonalThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_PersonalThreads.Location = new System.Drawing.Point(3, 0);
            this.Label_PersonalThreads.Name = "Label_PersonalThreads";
            this.Label_PersonalThreads.Size = new System.Drawing.Size(160, 54);
            this.Label_PersonalThreads.TabIndex = 8;
            this.Label_PersonalThreads.Text = "Personal Threads:";
            this.Label_PersonalThreads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Wordofwind
            // 
            this.Btn_Wordofwind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Wordofwind.Location = new System.Drawing.Point(344, 65);
            this.Btn_Wordofwind.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.Btn_Wordofwind.Name = "Btn_Wordofwind";
            this.Btn_Wordofwind.Size = new System.Drawing.Size(144, 33);
            this.Btn_Wordofwind.TabIndex = 3;
            this.Btn_Wordofwind.Text = "Wordofwind";
            this.Btn_Wordofwind.UseVisualStyleBackColor = true;
            // 
            // Btn_Mikezord
            // 
            this.Btn_Mikezord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Mikezord.Location = new System.Drawing.Point(178, 65);
            this.Btn_Mikezord.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.Btn_Mikezord.Name = "Btn_Mikezord";
            this.Btn_Mikezord.Size = new System.Drawing.Size(142, 33);
            this.Btn_Mikezord.TabIndex = 1;
            this.Btn_Mikezord.Text = "Mikezord";
            this.Btn_Mikezord.UseVisualStyleBackColor = true;
            // 
            // Btn_Plgue
            // 
            this.Btn_Plgue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Plgue.Location = new System.Drawing.Point(344, 11);
            this.Btn_Plgue.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.Btn_Plgue.Name = "Btn_Plgue";
            this.Btn_Plgue.Size = new System.Drawing.Size(144, 32);
            this.Btn_Plgue.TabIndex = 2;
            this.Btn_Plgue.Text = "Plgue";
            this.Btn_Plgue.UseVisualStyleBackColor = true;
            // 
            // Btn_Dayuppy
            // 
            this.Btn_Dayuppy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Dayuppy.Location = new System.Drawing.Point(178, 11);
            this.Btn_Dayuppy.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.Btn_Dayuppy.Name = "Btn_Dayuppy";
            this.Btn_Dayuppy.Size = new System.Drawing.Size(142, 32);
            this.Btn_Dayuppy.TabIndex = 0;
            this.Btn_Dayuppy.Text = "Dayuppy";
            this.Btn_Dayuppy.UseVisualStyleBackColor = true;
            // 
            // TabControl_DEV
            // 
            this.TabControl_DEV.Controls.Add(this.Tab_Dev1);
            this.TabControl_DEV.Controls.Add(this.Tab_Dev2);
            this.TabControl_DEV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_DEV.Location = new System.Drawing.Point(23, 22);
            this.TabControl_DEV.Name = "TabControl_DEV";
            this.TabControl_DEV.SelectedIndex = 0;
            this.TabControl_DEV.Size = new System.Drawing.Size(514, 345);
            this.TabControl_DEV.TabIndex = 7;
            this.TabControl_DEV.Visible = false;
            // 
            // Tab_User2
            // 
            this.Tab_User2.Controls.Add(this.CBox_UserMode_Graphics);
            this.Tab_User2.Controls.Add(this.CBox_UserMode_Widescreen);
            this.Tab_User2.Controls.Add(this.CBox_UserMode_WeaponBeeps);
            this.Tab_User2.Controls.Add(this.CBox_UserMode_BattleMusic);
            this.Tab_User2.Location = new System.Drawing.Point(4, 21);
            this.Tab_User2.Name = "Tab_User2";
            this.Tab_User2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Tab_User2.Size = new System.Drawing.Size(506, 320);
            this.Tab_User2.TabIndex = 1;
            this.Tab_User2.Text = "Options";
            this.Tab_User2.UseVisualStyleBackColor = true;
            // 
            // CBox_UserMode_Graphics
            // 
            this.CBox_UserMode_Graphics.AutoSize = true;
            this.CBox_UserMode_Graphics.Location = new System.Drawing.Point(47, 37);
            this.CBox_UserMode_Graphics.Name = "CBox_UserMode_Graphics";
            this.CBox_UserMode_Graphics.Size = new System.Drawing.Size(237, 18);
            this.CBox_UserMode_Graphics.TabIndex = 3;
            this.CBox_UserMode_Graphics.Text = "Enable Graphical Improvements";
            this.CBox_UserMode_Graphics.UseVisualStyleBackColor = true;
            this.CBox_UserMode_Graphics.CheckedChanged += new System.EventHandler(this.CBox_UserMode_Graphics_Changed);
            // 
            // CBox_UserMode_Widescreen
            // 
            this.CBox_UserMode_Widescreen.AutoSize = true;
            this.CBox_UserMode_Widescreen.Location = new System.Drawing.Point(47, 59);
            this.CBox_UserMode_Widescreen.Name = "CBox_UserMode_Widescreen";
            this.CBox_UserMode_Widescreen.Size = new System.Drawing.Size(150, 18);
            this.CBox_UserMode_Widescreen.TabIndex = 2;
            this.CBox_UserMode_Widescreen.Text = "Enable Widescreen";
            this.CBox_UserMode_Widescreen.UseVisualStyleBackColor = true;
            this.CBox_UserMode_Widescreen.CheckedChanged += new System.EventHandler(this.CBox_UserMode_Widescreen_Changed);
            // 
            // CBox_UserMode_WeaponBeeps
            // 
            this.CBox_UserMode_WeaponBeeps.AutoSize = true;
            this.CBox_UserMode_WeaponBeeps.Location = new System.Drawing.Point(47, 81);
            this.CBox_UserMode_WeaponBeeps.Name = "CBox_UserMode_WeaponBeeps";
            this.CBox_UserMode_WeaponBeeps.Size = new System.Drawing.Size(293, 18);
            this.CBox_UserMode_WeaponBeeps.TabIndex = 0;
            this.CBox_UserMode_WeaponBeeps.Text = "Disable Low Weapon HP Beeping Sounds";
            this.CBox_UserMode_WeaponBeeps.UseVisualStyleBackColor = true;
            this.CBox_UserMode_WeaponBeeps.CheckedChanged += new System.EventHandler(this.CBox_UserMode_WeaponBeepsChanged);
            // 
            // CBox_UserMode_BattleMusic
            // 
            this.CBox_UserMode_BattleMusic.AutoSize = true;
            this.CBox_UserMode_BattleMusic.Location = new System.Drawing.Point(47, 103);
            this.CBox_UserMode_BattleMusic.Name = "CBox_UserMode_BattleMusic";
            this.CBox_UserMode_BattleMusic.Size = new System.Drawing.Size(455, 18);
            this.CBox_UserMode_BattleMusic.TabIndex = 1;
            this.CBox_UserMode_BattleMusic.Text = "Disable Battle Music (make sure it\'s not already playing!)";
            this.CBox_UserMode_BattleMusic.UseVisualStyleBackColor = true;
            this.CBox_UserMode_BattleMusic.CheckedChanged += new System.EventHandler(this.CBox_UserMode_GraphicsChanged);
            // 
            // Tab_User1
            // 
            this.Tab_User1.Controls.Add(this.Label_UserMode_PlaceholderText);
            this.Tab_User1.Controls.Add(this.Label_UserMode_WelcomeTitle);
            this.Tab_User1.Controls.Add(this.Btn_UserMode_Quit);
            this.Tab_User1.Location = new System.Drawing.Point(4, 27);
            this.Tab_User1.Name = "Tab_User1";
            this.Tab_User1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Tab_User1.Size = new System.Drawing.Size(506, 314);
            this.Tab_User1.TabIndex = 0;
            this.Tab_User1.Text = "General";
            this.Tab_User1.UseVisualStyleBackColor = true;
            // 
            // Label_UserMode_PlaceholderText
            // 
            this.Label_UserMode_PlaceholderText.AutoSize = true;
            this.Label_UserMode_PlaceholderText.Location = new System.Drawing.Point(47, 94);
            this.Label_UserMode_PlaceholderText.Name = "Label_UserMode_PlaceholderText";
            this.Label_UserMode_PlaceholderText.Size = new System.Drawing.Size(123, 14);
            this.Label_UserMode_PlaceholderText.TabIndex = 1;
            this.Label_UserMode_PlaceholderText.Text = "Placeholder text";
            // 
            // Label_UserMode_WelcomeTitle
            // 
            this.Label_UserMode_WelcomeTitle.AutoSize = true;
            this.Label_UserMode_WelcomeTitle.Location = new System.Drawing.Point(47, 53);
            this.Label_UserMode_WelcomeTitle.Name = "Label_UserMode_WelcomeTitle";
            this.Label_UserMode_WelcomeTitle.Size = new System.Drawing.Size(212, 14);
            this.Label_UserMode_WelcomeTitle.TabIndex = 0;
            this.Label_UserMode_WelcomeTitle.Text = "Welcome to the Enhanced Mod!";
            // 
            // Btn_UserMode_Quit
            // 
            this.Btn_UserMode_Quit.Location = new System.Drawing.Point(50, 240);
            this.Btn_UserMode_Quit.Name = "Btn_UserMode_Quit";
            this.Btn_UserMode_Quit.Size = new System.Drawing.Size(87, 21);
            this.Btn_UserMode_Quit.TabIndex = 2;
            this.Btn_UserMode_Quit.Text = "Quit";
            this.Btn_UserMode_Quit.UseVisualStyleBackColor = true;
            this.Btn_UserMode_Quit.Click += new System.EventHandler(this.Btn_UserMode_Quit_Clicked);
            // 
            // TabControl_USER
            // 
            this.TabControl_USER.Controls.Add(this.Tab_User1);
            this.TabControl_USER.Controls.Add(this.Tab_User2);
            this.TabControl_USER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_USER.Location = new System.Drawing.Point(23, 22);
            this.TabControl_USER.Name = "TabControl_USER";
            this.TabControl_USER.SelectedIndex = 0;
            this.TabControl_USER.Size = new System.Drawing.Size(514, 345);
            this.TabControl_USER.TabIndex = 10;
            this.TabControl_USER.Visible = false;
            // 
            // Container_MainModes
            // 
            this.Container_MainModes.BackColor = System.Drawing.Color.Transparent;
            this.Container_MainModes.Controls.Add(this.Btn_ModeDev);
            this.Container_MainModes.Controls.Add(this.Btn_ModeUser);
            this.Container_MainModes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container_MainModes.Location = new System.Drawing.Point(23, 22);
            this.Container_MainModes.Margin = new System.Windows.Forms.Padding(0);
            this.Container_MainModes.Name = "Container_MainModes";
            this.Container_MainModes.Padding = new System.Windows.Forms.Padding(58, 0, 58, 0);
            this.Container_MainModes.Size = new System.Drawing.Size(514, 345);
            this.Container_MainModes.TabIndex = 7;
            // 
            // ModWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Dark_Cloud_Improved_Version.Properties.Resources.d06o_out_result;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(560, 389);
            this.Controls.Add(this.TabControl_DEV);
            this.Controls.Add(this.TabControl_USER);
            this.Controls.Add(this.Container_MainModes);
            this.Font = new System.Drawing.Font("DarkCloud", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(475, 340);
            this.Name = "ModWindow";
            this.Padding = new System.Windows.Forms.Padding(23, 22, 23, 22);
            this.Text = "Dark Cloud Enhanced Mod";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModWindow_FormClosed);
            this.Tab_Dev1.ResumeLayout(false);
            this.TabDev_SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TabDev_SplitContainer)).EndInit();
            this.TabDev_SplitContainer.ResumeLayout(false);
            this.Table_MainlThreads.ResumeLayout(false);
            this.Table_MainlThreads.PerformLayout();
            this.Table_PersonalThreads.ResumeLayout(false);
            this.Table_PersonalThreads.PerformLayout();
            this.TabControl_DEV.ResumeLayout(false);
            this.Tab_User2.ResumeLayout(false);
            this.Tab_User2.PerformLayout();
            this.Tab_User1.ResumeLayout(false);
            this.Tab_User1.PerformLayout();
            this.TabControl_USER.ResumeLayout(false);
            this.Container_MainModes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Btn_ModeUser;
        private System.Windows.Forms.Button Btn_ModeDev;
        private System.Windows.Forms.TabPage Tab_Dev2;
        private System.Windows.Forms.TabPage Tab_Dev1;
        private System.Windows.Forms.CheckBox CBox_DebugThread;
        private System.Windows.Forms.Button Btn_DungeonThread;
        private System.Windows.Forms.Button Btn_TownThread;
        private System.Windows.Forms.TabControl TabControl_DEV;
        private System.Windows.Forms.TabPage Tab_User2;
        private System.Windows.Forms.CheckBox CBox_UserMode_Graphics;
        private System.Windows.Forms.CheckBox CBox_UserMode_Widescreen;
        private System.Windows.Forms.CheckBox CBox_UserMode_BattleMusic;
        private System.Windows.Forms.CheckBox CBox_UserMode_WeaponBeeps;
        private System.Windows.Forms.TabPage Tab_User1;
        private System.Windows.Forms.Button Btn_UserMode_Quit;
        private System.Windows.Forms.Label Label_UserMode_PlaceholderText;
        private System.Windows.Forms.Label Label_UserMode_WelcomeTitle;
        private System.Windows.Forms.TabControl TabControl_USER;
        private System.Windows.Forms.Panel Container_MainModes;
        private System.Windows.Forms.TableLayoutPanel Table_MainlThreads;
        private System.Windows.Forms.Label Label_MainThreads;
        private System.Windows.Forms.TableLayoutPanel Table_PersonalThreads;
        private System.Windows.Forms.Label Label_PersonalThreads;
        private System.Windows.Forms.Button Btn_Wordofwind;
        private System.Windows.Forms.Button Btn_Mikezord;
        private System.Windows.Forms.Button Btn_Plgue;
        private System.Windows.Forms.Button Btn_Dayuppy;
        private System.Windows.Forms.Panel TabDev_Border1;
        private System.Windows.Forms.SplitContainer TabDev_SplitContainer;
        private System.Windows.Forms.Panel TabDev_Border2;
        private System.Windows.Forms.Button TabDev_BtnQuit;
    }
}

