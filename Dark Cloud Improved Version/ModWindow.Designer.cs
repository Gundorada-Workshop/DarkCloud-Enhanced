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
            this.Btn_ModeUser = new System.Windows.Forms.Button();
            this.Btn_ModeDev = new System.Windows.Forms.Button();
            this.Tab_Dev2 = new System.Windows.Forms.TabPage();
            this.Tab_Dev1 = new System.Windows.Forms.TabPage();
            this.TabDev_Border1 = new System.Windows.Forms.Panel();
            this.TabDev_Border2 = new System.Windows.Forms.Panel();
            this.TabDev_SplitContainer = new System.Windows.Forms.SplitContainer();
            this.TabDev_BtnBack = new System.Windows.Forms.Button();
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
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.Tab_User1 = new System.Windows.Forms.TabPage();
            this.Btn_Quit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.WelcomeTitle = new System.Windows.Forms.Label();
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
            this.Btn_ModeUser.Location = new System.Drawing.Point(64, 117);
            this.Btn_ModeUser.Name = "Btn_ModeUser";
            this.Btn_ModeUser.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Btn_ModeUser.Size = new System.Drawing.Size(126, 90);
            this.Btn_ModeUser.TabIndex = 8;
            this.Btn_ModeUser.Text = "Launch Mod as User";
            this.Btn_ModeUser.UseVisualStyleBackColor = true;
            this.Btn_ModeUser.Click += new System.EventHandler(this.buttonLaunchMod);
            // 
            // Btn_ModeDev
            // 
            this.Btn_ModeDev.Font = new System.Drawing.Font("DarkCloud", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ModeDev.Location = new System.Drawing.Point(250, 117);
            this.Btn_ModeDev.Name = "Btn_ModeDev";
            this.Btn_ModeDev.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Btn_ModeDev.Size = new System.Drawing.Size(126, 90);
            this.Btn_ModeDev.TabIndex = 9;
            this.Btn_ModeDev.Text = "Launch Mod as Developer";
            this.Btn_ModeDev.UseVisualStyleBackColor = true;
            this.Btn_ModeDev.Click += new System.EventHandler(this.buttonLaunchModAsDev);
            // 
            // Tab_Dev2
            // 
            this.Tab_Dev2.Location = new System.Drawing.Point(4, 21);
            this.Tab_Dev2.Name = "Tab_Dev2";
            this.Tab_Dev2.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Dev2.Size = new System.Drawing.Size(432, 292);
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
            this.Tab_Dev1.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Dev1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Tab_Dev1.Size = new System.Drawing.Size(432, 292);
            this.Tab_Dev1.TabIndex = 0;
            this.Tab_Dev1.Text = "Page1";
            // 
            // TabDev_Border1
            // 
            this.TabDev_Border1.BackColor = System.Drawing.Color.DarkGray;
            this.TabDev_Border1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabDev_Border1.Location = new System.Drawing.Point(2, 103);
            this.TabDev_Border1.Name = "TabDev_Border1";
            this.TabDev_Border1.Size = new System.Drawing.Size(424, 3);
            this.TabDev_Border1.TabIndex = 0;
            // 
            // TabDev_Border2
            // 
            this.TabDev_Border2.BackColor = System.Drawing.Color.DarkGray;
            this.TabDev_Border2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabDev_Border2.Location = new System.Drawing.Point(4, 203);
            this.TabDev_Border2.Name = "TabDev_Border2";
            this.TabDev_Border2.Size = new System.Drawing.Size(424, 3);
            this.TabDev_Border2.TabIndex = 10;
            // 
            // TabDev_SplitContainer
            // 
            this.TabDev_SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabDev_SplitContainer.Location = new System.Drawing.Point(3, 203);
            this.TabDev_SplitContainer.Name = "TabDev_SplitContainer";
            // 
            // TabDev_SplitContainer.Panel2
            // 
            this.TabDev_SplitContainer.Panel2.Controls.Add(this.TabDev_BtnBack);
            this.TabDev_SplitContainer.Size = new System.Drawing.Size(426, 86);
            this.TabDev_SplitContainer.SplitterDistance = 142;
            this.TabDev_SplitContainer.TabIndex = 9;
            // 
            // TabDev_BtnBack
            // 
            this.TabDev_BtnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TabDev_BtnBack.Location = new System.Drawing.Point(195, 56);
            this.TabDev_BtnBack.Margin = new System.Windows.Forms.Padding(10);
            this.TabDev_BtnBack.Name = "TabDev_BtnBack";
            this.TabDev_BtnBack.Size = new System.Drawing.Size(75, 23);
            this.TabDev_BtnBack.TabIndex = 0;
            this.TabDev_BtnBack.Text = "Back";
            this.TabDev_BtnBack.UseVisualStyleBackColor = true;
            this.TabDev_BtnBack.Click += new System.EventHandler(this.TabDev_BtnBack_Click);
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
            this.Table_MainlThreads.Location = new System.Drawing.Point(3, 103);
            this.Table_MainlThreads.Name = "Table_MainlThreads";
            this.Table_MainlThreads.RowCount = 2;
            this.Table_MainlThreads.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Table_MainlThreads.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Table_MainlThreads.Size = new System.Drawing.Size(426, 100);
            this.Table_MainlThreads.TabIndex = 7;
            // 
            // Label_MainThreads
            // 
            this.Label_MainThreads.AutoSize = true;
            this.Label_MainThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_MainThreads.Location = new System.Drawing.Point(3, 0);
            this.Label_MainThreads.Name = "Label_MainThreads";
            this.Label_MainThreads.Size = new System.Drawing.Size(136, 50);
            this.Label_MainThreads.TabIndex = 8;
            this.Label_MainThreads.Text = "Main Threads:";
            this.Label_MainThreads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_TownThread
            // 
            this.Btn_TownThread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_TownThread.Location = new System.Drawing.Point(152, 10);
            this.Btn_TownThread.Margin = new System.Windows.Forms.Padding(10);
            this.Btn_TownThread.Name = "Btn_TownThread";
            this.Btn_TownThread.Size = new System.Drawing.Size(122, 30);
            this.Btn_TownThread.TabIndex = 5;
            this.Btn_TownThread.Text = "Town Thread";
            this.Btn_TownThread.UseVisualStyleBackColor = true;
            this.Btn_TownThread.Click += new System.EventHandler(this.button6_Click);
            // 
            // Btn_DungeonThread
            // 
            this.Btn_DungeonThread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_DungeonThread.Location = new System.Drawing.Point(294, 10);
            this.Btn_DungeonThread.Margin = new System.Windows.Forms.Padding(10);
            this.Btn_DungeonThread.Name = "Btn_DungeonThread";
            this.Btn_DungeonThread.Size = new System.Drawing.Size(122, 30);
            this.Btn_DungeonThread.TabIndex = 4;
            this.Btn_DungeonThread.Text = "Dungeon Thread";
            this.Btn_DungeonThread.UseVisualStyleBackColor = true;
            this.Btn_DungeonThread.Click += new System.EventHandler(this.button5_Click);
            // 
            // CBox_DebugThread
            // 
            this.CBox_DebugThread.AutoSize = true;
            this.CBox_DebugThread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CBox_DebugThread.Location = new System.Drawing.Point(152, 60);
            this.CBox_DebugThread.Margin = new System.Windows.Forms.Padding(10);
            this.CBox_DebugThread.Name = "CBox_DebugThread";
            this.CBox_DebugThread.Padding = new System.Windows.Forms.Padding(1);
            this.CBox_DebugThread.Size = new System.Drawing.Size(122, 30);
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
            this.Table_PersonalThreads.Size = new System.Drawing.Size(426, 100);
            this.Table_PersonalThreads.TabIndex = 8;
            // 
            // Label_PersonalThreads
            // 
            this.Label_PersonalThreads.AutoSize = true;
            this.Label_PersonalThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_PersonalThreads.Location = new System.Drawing.Point(3, 0);
            this.Label_PersonalThreads.Name = "Label_PersonalThreads";
            this.Label_PersonalThreads.Size = new System.Drawing.Size(136, 50);
            this.Label_PersonalThreads.TabIndex = 8;
            this.Label_PersonalThreads.Text = "Personal Threads:";
            this.Label_PersonalThreads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Wordofwind
            // 
            this.Btn_Wordofwind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Wordofwind.Location = new System.Drawing.Point(294, 60);
            this.Btn_Wordofwind.Margin = new System.Windows.Forms.Padding(10);
            this.Btn_Wordofwind.Name = "Btn_Wordofwind";
            this.Btn_Wordofwind.Size = new System.Drawing.Size(122, 30);
            this.Btn_Wordofwind.TabIndex = 3;
            this.Btn_Wordofwind.Text = "Wordofwind";
            this.Btn_Wordofwind.UseVisualStyleBackColor = true;
            // 
            // Btn_Mikezord
            // 
            this.Btn_Mikezord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Mikezord.Location = new System.Drawing.Point(152, 60);
            this.Btn_Mikezord.Margin = new System.Windows.Forms.Padding(10);
            this.Btn_Mikezord.Name = "Btn_Mikezord";
            this.Btn_Mikezord.Size = new System.Drawing.Size(122, 30);
            this.Btn_Mikezord.TabIndex = 1;
            this.Btn_Mikezord.Text = "Mikezord";
            this.Btn_Mikezord.UseVisualStyleBackColor = true;
            // 
            // Btn_Plgue
            // 
            this.Btn_Plgue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Plgue.Location = new System.Drawing.Point(294, 10);
            this.Btn_Plgue.Margin = new System.Windows.Forms.Padding(10);
            this.Btn_Plgue.Name = "Btn_Plgue";
            this.Btn_Plgue.Size = new System.Drawing.Size(122, 30);
            this.Btn_Plgue.TabIndex = 2;
            this.Btn_Plgue.Text = "Plgue";
            this.Btn_Plgue.UseVisualStyleBackColor = true;
            // 
            // Btn_Dayuppy
            // 
            this.Btn_Dayuppy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Dayuppy.Location = new System.Drawing.Point(152, 10);
            this.Btn_Dayuppy.Margin = new System.Windows.Forms.Padding(10);
            this.Btn_Dayuppy.Name = "Btn_Dayuppy";
            this.Btn_Dayuppy.Size = new System.Drawing.Size(122, 30);
            this.Btn_Dayuppy.TabIndex = 0;
            this.Btn_Dayuppy.Text = "Dayuppy";
            this.Btn_Dayuppy.UseVisualStyleBackColor = true;
            // 
            // TabControl_DEV
            // 
            this.TabControl_DEV.Controls.Add(this.Tab_Dev1);
            this.TabControl_DEV.Controls.Add(this.Tab_Dev2);
            this.TabControl_DEV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_DEV.Location = new System.Drawing.Point(20, 20);
            this.TabControl_DEV.Name = "TabControl_DEV";
            this.TabControl_DEV.SelectedIndex = 0;
            this.TabControl_DEV.Size = new System.Drawing.Size(440, 317);
            this.TabControl_DEV.TabIndex = 7;
            this.TabControl_DEV.Visible = false;
            // 
            // Tab_User2
            // 
            this.Tab_User2.Controls.Add(this.checkBox5);
            this.Tab_User2.Controls.Add(this.checkBox4);
            this.Tab_User2.Controls.Add(this.checkBox3);
            this.Tab_User2.Controls.Add(this.checkBox2);
            this.Tab_User2.Location = new System.Drawing.Point(4, 21);
            this.Tab_User2.Name = "Tab_User2";
            this.Tab_User2.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_User2.Size = new System.Drawing.Size(432, 292);
            this.Tab_User2.TabIndex = 1;
            this.Tab_User2.Text = "Options";
            this.Tab_User2.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(40, 21);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(198, 15);
            this.checkBox5.TabIndex = 3;
            this.checkBox5.Text = "Enable Graphical Improvements";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(40, 41);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(126, 15);
            this.checkBox4.TabIndex = 2;
            this.checkBox4.Text = "Enable Widescreen";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(40, 82);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(372, 15);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Disable Battle Music (make sure it\'s not already playing!)";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(40, 61);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(240, 15);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Disable Low Weapon HP Beeping Sounds";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // Tab_User1
            // 
            this.Tab_User1.Controls.Add(this.label2);
            this.Tab_User1.Controls.Add(this.WelcomeTitle);
            this.Tab_User1.Controls.Add(this.Btn_Quit);
            this.Tab_User1.Location = new System.Drawing.Point(4, 21);
            this.Tab_User1.Name = "Tab_User1";
            this.Tab_User1.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_User1.Size = new System.Drawing.Size(432, 292);
            this.Tab_User1.TabIndex = 0;
            this.Tab_User1.Text = "General";
            this.Tab_User1.UseVisualStyleBackColor = true;
            // 
            // Btn_Quit
            // 
            this.Btn_Quit.Location = new System.Drawing.Point(43, 192);
            this.Btn_Quit.Name = "Btn_Quit";
            this.Btn_Quit.Size = new System.Drawing.Size(75, 19);
            this.Btn_Quit.TabIndex = 2;
            this.Btn_Quit.Text = "Quit";
            this.Btn_Quit.UseVisualStyleBackColor = true;
            this.Btn_Quit.Click += new System.EventHandler(this.button9_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 11);
            this.label2.TabIndex = 1;
            this.label2.Text = "Placeholder text";
            // 
            // WelcomeTitle
            // 
            this.WelcomeTitle.AutoSize = true;
            this.WelcomeTitle.Location = new System.Drawing.Point(40, 21);
            this.WelcomeTitle.Name = "WelcomeTitle";
            this.WelcomeTitle.Size = new System.Drawing.Size(173, 11);
            this.WelcomeTitle.TabIndex = 0;
            this.WelcomeTitle.Text = "Welcome to the Enhanced Mod!";
            // 
            // TabControl_USER
            // 
            this.TabControl_USER.Controls.Add(this.Tab_User1);
            this.TabControl_USER.Controls.Add(this.Tab_User2);
            this.TabControl_USER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_USER.Location = new System.Drawing.Point(20, 20);
            this.TabControl_USER.Name = "TabControl_USER";
            this.TabControl_USER.SelectedIndex = 0;
            this.TabControl_USER.Size = new System.Drawing.Size(440, 317);
            this.TabControl_USER.TabIndex = 10;
            this.TabControl_USER.Visible = false;
            // 
            // Container_MainModes
            // 
            this.Container_MainModes.BackColor = System.Drawing.Color.Transparent;
            this.Container_MainModes.Controls.Add(this.Btn_ModeDev);
            this.Container_MainModes.Controls.Add(this.Btn_ModeUser);
            this.Container_MainModes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container_MainModes.Location = new System.Drawing.Point(20, 20);
            this.Container_MainModes.Margin = new System.Windows.Forms.Padding(0);
            this.Container_MainModes.Name = "Container_MainModes";
            this.Container_MainModes.Padding = new System.Windows.Forms.Padding(50, 0, 50, 0);
            this.Container_MainModes.Size = new System.Drawing.Size(440, 317);
            this.Container_MainModes.TabIndex = 7;
            // 
            // ModWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Dark_Cloud_Improved_Version.Properties.Resources.d06o_out_result;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(480, 357);
            this.Controls.Add(this.TabControl_USER);
            this.Controls.Add(this.TabControl_DEV);
            this.Controls.Add(this.Container_MainModes);
            this.Font = new System.Drawing.Font("DarkCloud", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(410, 315);
            this.Name = "ModWindow";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Dark Cloud Enhanced Mod";
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
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TabPage Tab_User1;
        private System.Windows.Forms.Button Btn_Quit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label WelcomeTitle;
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
        private System.Windows.Forms.Button TabDev_BtnBack;
    }
}

