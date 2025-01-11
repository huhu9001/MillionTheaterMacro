namespace MilishitaMacro {
    partial class FormMain {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.output_000 = new System.Windows.Forms.TextBox();
            this.button_Make = new System.Windows.Forms.Button();
            this.tabC_main = new System.Windows.Forms.TabControl();
            this.tab_editor = new System.Windows.Forms.TabPage();
            this.b_SaveTXT = new System.Windows.Forms.Button();
            this.b_LoadText = new System.Windows.Forms.Button();
            this.b_ass = new System.Windows.Forms.Button();
            this.textb_SongName = new System.Windows.Forms.TextBox();
            this.text_Score = new System.Windows.Forms.TextBox();
            this.tab_source = new System.Windows.Forms.TabPage();
            this.group_MilishitaVideoParser = new System.Windows.Forms.GroupBox();
            this.b_locateParser = new System.Windows.Forms.Button();
            this.lb_vidparserDir = new System.Windows.Forms.Label();
            this.tb_vidparserDir = new System.Windows.Forms.TextBox();
            this.b_video = new System.Windows.Forms.Button();
            this.group_hyrrore = new System.Windows.Forms.GroupBox();
            this.combo_SongName = new System.Windows.Forms.ComboBox();
            this.button_Download = new System.Windows.Forms.Button();
            this.button_updateSong = new System.Windows.Forms.Button();
            this.tab_Rework = new System.Windows.Forms.TabPage();
            this.cb_old = new System.Windows.Forms.CheckBox();
            this.b_rework = new System.Windows.Forms.Button();
            this.mc_old = new System.Windows.Forms.MonthCalendar();
            this.b_reworkAp = new System.Windows.Forms.Button();
            this.b_reworkBrowse = new System.Windows.Forms.Button();
            this.tb_reworkF = new System.Windows.Forms.TextBox();
            this.lb_reworkF = new System.Windows.Forms.Label();
            this.tab_Settings = new System.Windows.Forms.TabPage();
            this.combo_ver = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_delays = new System.Windows.Forms.GroupBox();
            this.lb_desyncOffset = new System.Windows.Forms.Label();
            this.num_nCmdScpt = new System.Windows.Forms.NumericUpDown();
            this.num_moveNum = new System.Windows.Forms.NumericUpDown();
            this.lb_divSpt = new System.Windows.Forms.Label();
            this.lb_delayMove = new System.Windows.Forms.Label();
            this.num_Den = new System.Windows.Forms.NumericUpDown();
            this.lb_divSign = new System.Windows.Forms.Label();
            this.lb_delayDown = new System.Windows.Forms.Label();
            this.num_downNum = new System.Windows.Forms.NumericUpDown();
            this.combo_difficulty = new System.Windows.Forms.ComboBox();
            this.pgbar_main = new System.Windows.Forms.ProgressBar();
            this.tabC_main.SuspendLayout();
            this.tab_editor.SuspendLayout();
            this.tab_source.SuspendLayout();
            this.group_MilishitaVideoParser.SuspendLayout();
            this.group_hyrrore.SuspendLayout();
            this.tab_Rework.SuspendLayout();
            this.tab_Settings.SuspendLayout();
            this.gb_delays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_nCmdScpt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_moveNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Den)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_downNum)).BeginInit();
            this.SuspendLayout();
            // 
            // output_000
            // 
            this.output_000.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output_000.Location = new System.Drawing.Point(546, 98);
            this.output_000.Multiline = true;
            this.output_000.Name = "output_000";
            this.output_000.ReadOnly = true;
            this.output_000.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output_000.Size = new System.Drawing.Size(232, 258);
            this.output_000.TabIndex = 0;
            // 
            // button_Make
            // 
            this.button_Make.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Make.Location = new System.Drawing.Point(546, 54);
            this.button_Make.Name = "button_Make";
            this.button_Make.Size = new System.Drawing.Size(110, 34);
            this.button_Make.TabIndex = 8;
            this.button_Make.Text = "Make";
            this.button_Make.UseVisualStyleBackColor = true;
            this.button_Make.Click += new System.EventHandler(this.button_Make_Click);
            // 
            // tabC_main
            // 
            this.tabC_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabC_main.Controls.Add(this.tab_editor);
            this.tabC_main.Controls.Add(this.tab_source);
            this.tabC_main.Controls.Add(this.tab_Rework);
            this.tabC_main.Controls.Add(this.tab_Settings);
            this.tabC_main.Location = new System.Drawing.Point(12, 16);
            this.tabC_main.Name = "tabC_main";
            this.tabC_main.SelectedIndex = 0;
            this.tabC_main.Size = new System.Drawing.Size(519, 380);
            this.tabC_main.TabIndex = 9;
            // 
            // tab_editor
            // 
            this.tab_editor.Controls.Add(this.b_SaveTXT);
            this.tab_editor.Controls.Add(this.b_LoadText);
            this.tab_editor.Controls.Add(this.b_ass);
            this.tab_editor.Controls.Add(this.textb_SongName);
            this.tab_editor.Controls.Add(this.text_Score);
            this.tab_editor.Location = new System.Drawing.Point(4, 28);
            this.tab_editor.Name = "tab_editor";
            this.tab_editor.Padding = new System.Windows.Forms.Padding(3);
            this.tab_editor.Size = new System.Drawing.Size(511, 348);
            this.tab_editor.TabIndex = 1;
            this.tab_editor.Text = "Editor";
            this.tab_editor.UseVisualStyleBackColor = true;
            // 
            // b_SaveTXT
            // 
            this.b_SaveTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_SaveTXT.Location = new System.Drawing.Point(126, 294);
            this.b_SaveTXT.Name = "b_SaveTXT";
            this.b_SaveTXT.Size = new System.Drawing.Size(100, 32);
            this.b_SaveTXT.TabIndex = 14;
            this.b_SaveTXT.Text = "Save";
            this.b_SaveTXT.UseVisualStyleBackColor = true;
            this.b_SaveTXT.Click += new System.EventHandler(this.b_SaveTXT_Click);
            // 
            // b_LoadText
            // 
            this.b_LoadText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_LoadText.Location = new System.Drawing.Point(20, 294);
            this.b_LoadText.Name = "b_LoadText";
            this.b_LoadText.Size = new System.Drawing.Size(100, 33);
            this.b_LoadText.TabIndex = 13;
            this.b_LoadText.Text = "Load";
            this.b_LoadText.UseVisualStyleBackColor = true;
            this.b_LoadText.Click += new System.EventHandler(this.b_LoadText_Click);
            // 
            // b_ass
            // 
            this.b_ass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_ass.Location = new System.Drawing.Point(232, 294);
            this.b_ass.Name = "b_ass";
            this.b_ass.Size = new System.Drawing.Size(110, 33);
            this.b_ass.TabIndex = 12;
            this.b_ass.Text = "Open ASS";
            this.b_ass.UseVisualStyleBackColor = true;
            this.b_ass.Click += new System.EventHandler(this.b_ass_Click);
            // 
            // textb_SongName
            // 
            this.textb_SongName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textb_SongName.Location = new System.Drawing.Point(20, 15);
            this.textb_SongName.Name = "textb_SongName";
            this.textb_SongName.Size = new System.Drawing.Size(468, 28);
            this.textb_SongName.TabIndex = 11;
            this.textb_SongName.Text = "(Song_Name)";
            // 
            // text_Score
            // 
            this.text_Score.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Score.Location = new System.Drawing.Point(20, 53);
            this.text_Score.Multiline = true;
            this.text_Score.Name = "text_Score";
            this.text_Score.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.text_Score.Size = new System.Drawing.Size(468, 235);
            this.text_Score.TabIndex = 0;
            this.text_Score.TextChanged += new System.EventHandler(this.textScore_Change);
            // 
            // tab_source
            // 
            this.tab_source.Controls.Add(this.group_MilishitaVideoParser);
            this.tab_source.Controls.Add(this.group_hyrrore);
            this.tab_source.Location = new System.Drawing.Point(4, 28);
            this.tab_source.Name = "tab_source";
            this.tab_source.Padding = new System.Windows.Forms.Padding(3);
            this.tab_source.Size = new System.Drawing.Size(511, 348);
            this.tab_source.TabIndex = 0;
            this.tab_source.Text = "Source";
            this.tab_source.UseVisualStyleBackColor = true;
            // 
            // group_MilishitaVideoParser
            // 
            this.group_MilishitaVideoParser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_MilishitaVideoParser.Controls.Add(this.b_locateParser);
            this.group_MilishitaVideoParser.Controls.Add(this.lb_vidparserDir);
            this.group_MilishitaVideoParser.Controls.Add(this.tb_vidparserDir);
            this.group_MilishitaVideoParser.Controls.Add(this.b_video);
            this.group_MilishitaVideoParser.Location = new System.Drawing.Point(6, 112);
            this.group_MilishitaVideoParser.Name = "group_MilishitaVideoParser";
            this.group_MilishitaVideoParser.Size = new System.Drawing.Size(499, 102);
            this.group_MilishitaVideoParser.TabIndex = 17;
            this.group_MilishitaVideoParser.TabStop = false;
            this.group_MilishitaVideoParser.Text = "MilishitaVideoParser";
            // 
            // b_locateParser
            // 
            this.b_locateParser.Location = new System.Drawing.Point(142, 61);
            this.b_locateParser.Name = "b_locateParser";
            this.b_locateParser.Size = new System.Drawing.Size(130, 32);
            this.b_locateParser.TabIndex = 18;
            this.b_locateParser.Text = "Locate .exe";
            this.b_locateParser.UseVisualStyleBackColor = true;
            this.b_locateParser.Click += new System.EventHandler(this.b_locateParser_Click);
            // 
            // lb_vidparserDir
            // 
            this.lb_vidparserDir.AutoSize = true;
            this.lb_vidparserDir.Location = new System.Drawing.Point(6, 30);
            this.lb_vidparserDir.Name = "lb_vidparserDir";
            this.lb_vidparserDir.Size = new System.Drawing.Size(89, 18);
            this.lb_vidparserDir.TabIndex = 17;
            this.lb_vidparserDir.Text = ".exe dir:";
            // 
            // tb_vidparserDir
            // 
            this.tb_vidparserDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_vidparserDir.Location = new System.Drawing.Point(101, 27);
            this.tb_vidparserDir.Name = "tb_vidparserDir";
            this.tb_vidparserDir.Size = new System.Drawing.Size(392, 28);
            this.tb_vidparserDir.TabIndex = 16;
            this.tb_vidparserDir.TextChanged += new System.EventHandler(this.SettingControlsChanged);
            // 
            // b_video
            // 
            this.b_video.Location = new System.Drawing.Point(6, 61);
            this.b_video.Name = "b_video";
            this.b_video.Size = new System.Drawing.Size(130, 32);
            this.b_video.TabIndex = 15;
            this.b_video.Text = "Parse video";
            this.b_video.UseVisualStyleBackColor = true;
            this.b_video.Click += new System.EventHandler(this.b_video_Click);
            // 
            // group_hyrrore
            // 
            this.group_hyrrore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_hyrrore.Controls.Add(this.combo_SongName);
            this.group_hyrrore.Controls.Add(this.button_Download);
            this.group_hyrrore.Controls.Add(this.button_updateSong);
            this.group_hyrrore.Location = new System.Drawing.Point(6, 6);
            this.group_hyrrore.Name = "group_hyrrore";
            this.group_hyrrore.Size = new System.Drawing.Size(499, 100);
            this.group_hyrrore.TabIndex = 16;
            this.group_hyrrore.TabStop = false;
            this.group_hyrrore.Text = "million.hyrorre.com";
            // 
            // combo_SongName
            // 
            this.combo_SongName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_SongName.DisplayMember = "fullName";
            this.combo_SongName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_SongName.FormattingEnabled = true;
            this.combo_SongName.Location = new System.Drawing.Point(6, 27);
            this.combo_SongName.Name = "combo_SongName";
            this.combo_SongName.Size = new System.Drawing.Size(487, 26);
            this.combo_SongName.TabIndex = 8;
            // 
            // button_Download
            // 
            this.button_Download.Location = new System.Drawing.Point(6, 59);
            this.button_Download.Name = "button_Download";
            this.button_Download.Size = new System.Drawing.Size(110, 32);
            this.button_Download.TabIndex = 2;
            this.button_Download.Text = "Download";
            this.button_Download.UseVisualStyleBackColor = true;
            this.button_Download.Click += new System.EventHandler(this.button_Download_Click);
            // 
            // button_updateSong
            // 
            this.button_updateSong.Location = new System.Drawing.Point(122, 59);
            this.button_updateSong.Name = "button_updateSong";
            this.button_updateSong.Size = new System.Drawing.Size(176, 32);
            this.button_updateSong.TabIndex = 9;
            this.button_updateSong.Text = "Update song list";
            this.button_updateSong.UseVisualStyleBackColor = true;
            this.button_updateSong.Click += new System.EventHandler(this.button_updateSong_Click);
            // 
            // tab_Rework
            // 
            this.tab_Rework.Controls.Add(this.cb_old);
            this.tab_Rework.Controls.Add(this.b_rework);
            this.tab_Rework.Controls.Add(this.mc_old);
            this.tab_Rework.Controls.Add(this.b_reworkAp);
            this.tab_Rework.Controls.Add(this.b_reworkBrowse);
            this.tab_Rework.Controls.Add(this.tb_reworkF);
            this.tab_Rework.Controls.Add(this.lb_reworkF);
            this.tab_Rework.Location = new System.Drawing.Point(4, 28);
            this.tab_Rework.Name = "tab_Rework";
            this.tab_Rework.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Rework.Size = new System.Drawing.Size(511, 348);
            this.tab_Rework.TabIndex = 2;
            this.tab_Rework.Text = "Rework";
            this.tab_Rework.UseVisualStyleBackColor = true;
            // 
            // cb_old
            // 
            this.cb_old.AutoSize = true;
            this.cb_old.Checked = true;
            this.cb_old.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_old.Location = new System.Drawing.Point(16, 95);
            this.cb_old.Name = "cb_old";
            this.cb_old.Size = new System.Drawing.Size(133, 22);
            this.cb_old.TabIndex = 7;
            this.cb_old.Text = "Older than:";
            this.cb_old.UseVisualStyleBackColor = true;
            // 
            // b_rework
            // 
            this.b_rework.Location = new System.Drawing.Point(122, 52);
            this.b_rework.Name = "b_rework";
            this.b_rework.Size = new System.Drawing.Size(145, 28);
            this.b_rework.TabIndex = 6;
            this.b_rework.Text = "Update";
            this.b_rework.UseVisualStyleBackColor = true;
            this.b_rework.Click += new System.EventHandler(this.b_reworkAp_Click);
            // 
            // mc_old
            // 
            this.mc_old.Location = new System.Drawing.Point(154, 81);
            this.mc_old.MaxSelectionCount = 1;
            this.mc_old.Name = "mc_old";
            this.mc_old.ShowToday = false;
            this.mc_old.ShowTodayCircle = false;
            this.mc_old.TabIndex = 5;
            // 
            // b_reworkAp
            // 
            this.b_reworkAp.Location = new System.Drawing.Point(273, 52);
            this.b_reworkAp.Name = "b_reworkAp";
            this.b_reworkAp.Size = new System.Drawing.Size(185, 28);
            this.b_reworkAp.TabIndex = 4;
            this.b_reworkAp.Text = "Update Appendage";
            this.b_reworkAp.UseVisualStyleBackColor = true;
            this.b_reworkAp.Click += new System.EventHandler(this.b_reworkAp_Click);
            // 
            // b_reworkBrowse
            // 
            this.b_reworkBrowse.Location = new System.Drawing.Point(16, 52);
            this.b_reworkBrowse.Name = "b_reworkBrowse";
            this.b_reworkBrowse.Size = new System.Drawing.Size(100, 28);
            this.b_reworkBrowse.TabIndex = 3;
            this.b_reworkBrowse.Text = "browse...";
            this.b_reworkBrowse.UseVisualStyleBackColor = true;
            this.b_reworkBrowse.Click += new System.EventHandler(this.b_reworkBrowse_Click);
            // 
            // tb_reworkF
            // 
            this.tb_reworkF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_reworkF.Location = new System.Drawing.Point(156, 15);
            this.tb_reworkF.Name = "tb_reworkF";
            this.tb_reworkF.Size = new System.Drawing.Size(343, 28);
            this.tb_reworkF.TabIndex = 2;
            // 
            // lb_reworkF
            // 
            this.lb_reworkF.AutoSize = true;
            this.lb_reworkF.Location = new System.Drawing.Point(13, 18);
            this.lb_reworkF.Name = "lb_reworkF";
            this.lb_reworkF.Size = new System.Drawing.Size(143, 18);
            this.lb_reworkF.TabIndex = 0;
            this.lb_reworkF.Text = "Working Folder:";
            // 
            // tab_Settings
            // 
            this.tab_Settings.Controls.Add(this.combo_ver);
            this.tab_Settings.Controls.Add(this.label1);
            this.tab_Settings.Controls.Add(this.gb_delays);
            this.tab_Settings.Location = new System.Drawing.Point(4, 28);
            this.tab_Settings.Name = "tab_Settings";
            this.tab_Settings.Size = new System.Drawing.Size(511, 348);
            this.tab_Settings.TabIndex = 0;
            this.tab_Settings.Text = "Settings";
            // 
            // combo_ver
            // 
            this.combo_ver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_ver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_ver.FormattingEnabled = true;
            this.combo_ver.Location = new System.Drawing.Point(105, 15);
            this.combo_ver.Name = "combo_ver";
            this.combo_ver.Size = new System.Drawing.Size(391, 26);
            this.combo_ver.TabIndex = 7;
            this.combo_ver.SelectedIndexChanged += new System.EventHandler(this.SettingControlsChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Version:";
            // 
            // gb_delays
            // 
            this.gb_delays.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_delays.Controls.Add(this.lb_desyncOffset);
            this.gb_delays.Controls.Add(this.num_nCmdScpt);
            this.gb_delays.Controls.Add(this.num_moveNum);
            this.gb_delays.Controls.Add(this.lb_divSpt);
            this.gb_delays.Controls.Add(this.lb_delayMove);
            this.gb_delays.Controls.Add(this.num_Den);
            this.gb_delays.Controls.Add(this.lb_divSign);
            this.gb_delays.Controls.Add(this.lb_delayDown);
            this.gb_delays.Controls.Add(this.num_downNum);
            this.gb_delays.Location = new System.Drawing.Point(12, 54);
            this.gb_delays.Name = "gb_delays";
            this.gb_delays.Size = new System.Drawing.Size(484, 160);
            this.gb_delays.TabIndex = 0;
            this.gb_delays.TabStop = false;
            this.gb_delays.Text = "Desynchronization management";
            // 
            // lb_desyncOffset
            // 
            this.lb_desyncOffset.AutoSize = true;
            this.lb_desyncOffset.Location = new System.Drawing.Point(7, 24);
            this.lb_desyncOffset.Name = "lb_desyncOffset";
            this.lb_desyncOffset.Size = new System.Drawing.Size(269, 18);
            this.lb_desyncOffset.TabIndex = 9;
            this.lb_desyncOffset.Text = "Desync offset (num / den ms):";
            // 
            // num_nCmdScpt
            // 
            this.num_nCmdScpt.Location = new System.Drawing.Point(327, 122);
            this.num_nCmdScpt.Name = "num_nCmdScpt";
            this.num_nCmdScpt.Size = new System.Drawing.Size(120, 28);
            this.num_nCmdScpt.TabIndex = 8;
            this.num_nCmdScpt.ValueChanged += new System.EventHandler(this.SettingControlsChanged);
            // 
            // num_moveNum
            // 
            this.num_moveNum.Location = new System.Drawing.Point(119, 84);
            this.num_moveNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_moveNum.Name = "num_moveNum";
            this.num_moveNum.Size = new System.Drawing.Size(120, 28);
            this.num_moveNum.TabIndex = 1;
            this.num_moveNum.ValueChanged += new System.EventHandler(this.SettingControlsChanged);
            // 
            // lb_divSpt
            // 
            this.lb_divSpt.AutoSize = true;
            this.lb_divSpt.Location = new System.Drawing.Point(7, 124);
            this.lb_divSpt.Name = "lb_divSpt";
            this.lb_divSpt.Size = new System.Drawing.Size(314, 18);
            this.lb_divSpt.TabIndex = 4;
            this.lb_divSpt.Text = "Command num each script (0 = INF):";
            // 
            // lb_delayMove
            // 
            this.lb_delayMove.AutoSize = true;
            this.lb_delayMove.Location = new System.Drawing.Point(7, 87);
            this.lb_delayMove.Name = "lb_delayMove";
            this.lb_delayMove.Size = new System.Drawing.Size(107, 18);
            this.lb_delayMove.TabIndex = 3;
            this.lb_delayMove.Text = "Mouse move:";
            // 
            // num_Den
            // 
            this.num_Den.Location = new System.Drawing.Point(268, 67);
            this.num_Den.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_Den.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Den.Name = "num_Den";
            this.num_Den.Size = new System.Drawing.Size(120, 28);
            this.num_Den.TabIndex = 1;
            this.num_Den.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Den.ValueChanged += new System.EventHandler(this.SettingControlsChanged);
            // 
            // lb_divSign
            // 
            this.lb_divSign.AutoSize = true;
            this.lb_divSign.Location = new System.Drawing.Point(245, 69);
            this.lb_divSign.Name = "lb_divSign";
            this.lb_divSign.Size = new System.Drawing.Size(17, 18);
            this.lb_divSign.TabIndex = 2;
            this.lb_divSign.Text = "/";
            // 
            // lb_delayDown
            // 
            this.lb_delayDown.AutoSize = true;
            this.lb_delayDown.Location = new System.Drawing.Point(6, 52);
            this.lb_delayDown.Name = "lb_delayDown";
            this.lb_delayDown.Size = new System.Drawing.Size(107, 18);
            this.lb_delayDown.TabIndex = 1;
            this.lb_delayDown.Text = "Mouse down:";
            // 
            // num_downNum
            // 
            this.num_downNum.Location = new System.Drawing.Point(119, 50);
            this.num_downNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_downNum.Name = "num_downNum";
            this.num_downNum.Size = new System.Drawing.Size(120, 28);
            this.num_downNum.TabIndex = 0;
            this.num_downNum.ValueChanged += new System.EventHandler(this.SettingControlsChanged);
            // 
            // combo_difficulty
            // 
            this.combo_difficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_difficulty.FormattingEnabled = true;
            this.combo_difficulty.Location = new System.Drawing.Point(546, 16);
            this.combo_difficulty.Name = "combo_difficulty";
            this.combo_difficulty.Size = new System.Drawing.Size(165, 26);
            this.combo_difficulty.TabIndex = 10;
            this.combo_difficulty.SelectedIndexChanged += new System.EventHandler(this.textScore_Change);
            // 
            // pgbar_main
            // 
            this.pgbar_main.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbar_main.Location = new System.Drawing.Point(546, 369);
            this.pgbar_main.Name = "pgbar_main";
            this.pgbar_main.Size = new System.Drawing.Size(232, 23);
            this.pgbar_main.TabIndex = 11;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pgbar_main);
            this.Controls.Add(this.combo_difficulty);
            this.Controls.Add(this.tabC_main);
            this.Controls.Add(this.button_Make);
            this.Controls.Add(this.output_000);
            this.Name = "FormMain";
            this.Text = "MilishitaMacro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_main_FormClosing);
            this.tabC_main.ResumeLayout(false);
            this.tab_editor.ResumeLayout(false);
            this.tab_editor.PerformLayout();
            this.tab_source.ResumeLayout(false);
            this.group_MilishitaVideoParser.ResumeLayout(false);
            this.group_MilishitaVideoParser.PerformLayout();
            this.group_hyrrore.ResumeLayout(false);
            this.tab_Rework.ResumeLayout(false);
            this.tab_Rework.PerformLayout();
            this.tab_Settings.ResumeLayout(false);
            this.tab_Settings.PerformLayout();
            this.gb_delays.ResumeLayout(false);
            this.gb_delays.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_nCmdScpt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_moveNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Den)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_downNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox output_000;
        private System.Windows.Forms.Button button_Make;
        private System.Windows.Forms.TabControl tabC_main;
        private System.Windows.Forms.TabPage tab_editor;
        private System.Windows.Forms.ComboBox combo_difficulty;
        private System.Windows.Forms.TextBox text_Score;
        private System.Windows.Forms.TextBox textb_SongName;
        private System.Windows.Forms.TabPage tab_source;
        private System.Windows.Forms.Button button_updateSong;
        private System.Windows.Forms.Button button_Download;
        private System.Windows.Forms.ComboBox combo_SongName;
        private System.Windows.Forms.Button b_ass;
        private System.Windows.Forms.Button b_SaveTXT;
        private System.Windows.Forms.Button b_LoadText;
        private System.Windows.Forms.TabPage tab_Rework;
        private System.Windows.Forms.Label lb_reworkF;
        private System.Windows.Forms.TextBox tb_reworkF;
        private System.Windows.Forms.Button b_reworkBrowse;
        private System.Windows.Forms.Button b_reworkAp;
        private System.Windows.Forms.CheckBox cb_old;
        private System.Windows.Forms.Button b_rework;
        private System.Windows.Forms.MonthCalendar mc_old;
        private System.Windows.Forms.TabPage tab_Settings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_delays;
        private System.Windows.Forms.NumericUpDown num_moveNum;
        private System.Windows.Forms.Label lb_delayMove;
        private System.Windows.Forms.NumericUpDown num_Den;
        private System.Windows.Forms.Label lb_divSign;
        private System.Windows.Forms.Label lb_delayDown;
        private System.Windows.Forms.NumericUpDown num_downNum;
        private System.Windows.Forms.ComboBox combo_ver;
        private System.Windows.Forms.Label lb_divSpt;
        private System.Windows.Forms.NumericUpDown num_nCmdScpt;
        private System.Windows.Forms.Label lb_desyncOffset;
        private System.Windows.Forms.ProgressBar pgbar_main;
        private System.Windows.Forms.Button b_video;
        private System.Windows.Forms.GroupBox group_hyrrore;
        private System.Windows.Forms.GroupBox group_MilishitaVideoParser;
        private System.Windows.Forms.Button b_locateParser;
        private System.Windows.Forms.Label lb_vidparserDir;
        private System.Windows.Forms.TextBox tb_vidparserDir;
    }
}

