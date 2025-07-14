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
            tb_output = new TextBox();
            button_Make = new Button();
            tabC_main = new TabControl();
            tab_editor = new TabPage();
            b_SaveTXT = new Button();
            b_LoadText = new Button();
            b_ass = new Button();
            textb_SongName = new TextBox();
            text_Score = new TextBox();
            tab_source = new TabPage();
            group_MilishitaVideoParser = new GroupBox();
            b_locateParser = new Button();
            lb_vidparserDir = new Label();
            tb_vidparserDir = new TextBox();
            b_video = new Button();
            group_hyrrore = new GroupBox();
            combo_SongName = new ComboBox();
            button_Download = new Button();
            button_updateSong = new Button();
            tab_Rework = new TabPage();
            cb_old = new CheckBox();
            b_rework = new Button();
            mc_old = new MonthCalendar();
            b_reworkAp = new Button();
            b_reworkBrowse = new Button();
            tb_reworkF = new TextBox();
            lb_reworkF = new Label();
            tab_Settings = new TabPage();
            combo_ver = new ComboBox();
            label1 = new Label();
            gb_delays = new GroupBox();
            lb_desyncOffset = new Label();
            num_nCmdScpt = new NumericUpDown();
            num_moveNum = new NumericUpDown();
            lb_divSpt = new Label();
            lb_delayMove = new Label();
            num_Den = new NumericUpDown();
            lb_divSign = new Label();
            lb_delayDown = new Label();
            num_downNum = new NumericUpDown();
            combo_difficulty = new ComboBox();
            pgbar_main = new ProgressBar();
            tabC_main.SuspendLayout();
            tab_editor.SuspendLayout();
            tab_source.SuspendLayout();
            group_MilishitaVideoParser.SuspendLayout();
            group_hyrrore.SuspendLayout();
            tab_Rework.SuspendLayout();
            tab_Settings.SuspendLayout();
            gb_delays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_nCmdScpt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_moveNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_Den).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_downNum).BeginInit();
            SuspendLayout();
            // 
            // tb_output
            // 
            tb_output.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tb_output.Location = new Point(667, 131);
            tb_output.Margin = new Padding(4);
            tb_output.Multiline = true;
            tb_output.Name = "tb_output";
            tb_output.ReadOnly = true;
            tb_output.ScrollBars = ScrollBars.Vertical;
            tb_output.Size = new Size(283, 343);
            tb_output.TabIndex = 0;
            // 
            // button_Make
            // 
            button_Make.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Make.Location = new Point(667, 72);
            button_Make.Margin = new Padding(4);
            button_Make.Name = "button_Make";
            button_Make.Size = new Size(134, 43);
            button_Make.TabIndex = 8;
            button_Make.Text = "Make";
            button_Make.UseVisualStyleBackColor = true;
            button_Make.Click += button_Make_Click;
            // 
            // tabC_main
            // 
            tabC_main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabC_main.Controls.Add(tab_editor);
            tabC_main.Controls.Add(tab_source);
            tabC_main.Controls.Add(tab_Rework);
            tabC_main.Controls.Add(tab_Settings);
            tabC_main.Location = new Point(15, 21);
            tabC_main.Margin = new Padding(4);
            tabC_main.Name = "tabC_main";
            tabC_main.SelectedIndex = 0;
            tabC_main.Size = new Size(634, 507);
            tabC_main.TabIndex = 9;
            // 
            // tab_editor
            // 
            tab_editor.Controls.Add(b_SaveTXT);
            tab_editor.Controls.Add(b_LoadText);
            tab_editor.Controls.Add(b_ass);
            tab_editor.Controls.Add(textb_SongName);
            tab_editor.Controls.Add(text_Score);
            tab_editor.Location = new Point(4, 33);
            tab_editor.Margin = new Padding(4);
            tab_editor.Name = "tab_editor";
            tab_editor.Padding = new Padding(4);
            tab_editor.Size = new Size(626, 470);
            tab_editor.TabIndex = 1;
            tab_editor.Text = "Editor";
            tab_editor.UseVisualStyleBackColor = true;
            // 
            // b_SaveTXT
            // 
            b_SaveTXT.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            b_SaveTXT.Location = new Point(154, 392);
            b_SaveTXT.Margin = new Padding(4);
            b_SaveTXT.Name = "b_SaveTXT";
            b_SaveTXT.Size = new Size(122, 43);
            b_SaveTXT.TabIndex = 14;
            b_SaveTXT.Text = "Save";
            b_SaveTXT.UseVisualStyleBackColor = true;
            b_SaveTXT.Click += b_SaveTXT_Click;
            // 
            // b_LoadText
            // 
            b_LoadText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            b_LoadText.Location = new Point(24, 392);
            b_LoadText.Margin = new Padding(4);
            b_LoadText.Name = "b_LoadText";
            b_LoadText.Size = new Size(122, 43);
            b_LoadText.TabIndex = 13;
            b_LoadText.Text = "Load";
            b_LoadText.UseVisualStyleBackColor = true;
            b_LoadText.Click += b_LoadText_Click;
            // 
            // b_ass
            // 
            b_ass.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            b_ass.Location = new Point(284, 392);
            b_ass.Margin = new Padding(4);
            b_ass.Name = "b_ass";
            b_ass.Size = new Size(134, 43);
            b_ass.TabIndex = 12;
            b_ass.Text = "Open ASS";
            b_ass.UseVisualStyleBackColor = true;
            b_ass.Click += b_ass_Click;
            // 
            // textb_SongName
            // 
            textb_SongName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textb_SongName.Location = new Point(24, 20);
            textb_SongName.Margin = new Padding(4);
            textb_SongName.Name = "textb_SongName";
            textb_SongName.Size = new Size(571, 30);
            textb_SongName.TabIndex = 11;
            textb_SongName.Text = "(Song_Name)";
            // 
            // text_Score
            // 
            text_Score.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            text_Score.Location = new Point(24, 71);
            text_Score.Margin = new Padding(4);
            text_Score.Multiline = true;
            text_Score.Name = "text_Score";
            text_Score.ScrollBars = ScrollBars.Both;
            text_Score.Size = new Size(571, 312);
            text_Score.TabIndex = 0;
            text_Score.TextChanged += textScore_Change;
            // 
            // tab_source
            // 
            tab_source.Controls.Add(group_MilishitaVideoParser);
            tab_source.Controls.Add(group_hyrrore);
            tab_source.Location = new Point(4, 33);
            tab_source.Margin = new Padding(4);
            tab_source.Name = "tab_source";
            tab_source.Padding = new Padding(4);
            tab_source.Size = new Size(626, 470);
            tab_source.TabIndex = 0;
            tab_source.Text = "Source";
            tab_source.UseVisualStyleBackColor = true;
            // 
            // group_MilishitaVideoParser
            // 
            group_MilishitaVideoParser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            group_MilishitaVideoParser.Controls.Add(b_locateParser);
            group_MilishitaVideoParser.Controls.Add(lb_vidparserDir);
            group_MilishitaVideoParser.Controls.Add(tb_vidparserDir);
            group_MilishitaVideoParser.Controls.Add(b_video);
            group_MilishitaVideoParser.Location = new Point(7, 149);
            group_MilishitaVideoParser.Margin = new Padding(4);
            group_MilishitaVideoParser.Name = "group_MilishitaVideoParser";
            group_MilishitaVideoParser.Padding = new Padding(4);
            group_MilishitaVideoParser.Size = new Size(610, 136);
            group_MilishitaVideoParser.TabIndex = 17;
            group_MilishitaVideoParser.TabStop = false;
            group_MilishitaVideoParser.Text = "MilishitaVideoParser";
            // 
            // b_locateParser
            // 
            b_locateParser.Location = new Point(174, 81);
            b_locateParser.Margin = new Padding(4);
            b_locateParser.Name = "b_locateParser";
            b_locateParser.Size = new Size(159, 43);
            b_locateParser.TabIndex = 18;
            b_locateParser.Text = "Locate EXE";
            b_locateParser.UseVisualStyleBackColor = true;
            b_locateParser.Click += b_locateParser_Click;
            // 
            // lb_vidparserDir
            // 
            lb_vidparserDir.AutoSize = true;
            lb_vidparserDir.Location = new Point(7, 40);
            lb_vidparserDir.Margin = new Padding(4, 0, 4, 0);
            lb_vidparserDir.Name = "lb_vidparserDir";
            lb_vidparserDir.Size = new Size(75, 24);
            lb_vidparserDir.TabIndex = 17;
            lb_vidparserDir.Text = "EXE dir:";
            // 
            // tb_vidparserDir
            // 
            tb_vidparserDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tb_vidparserDir.Location = new Point(112, 36);
            tb_vidparserDir.Margin = new Padding(4);
            tb_vidparserDir.Name = "tb_vidparserDir";
            tb_vidparserDir.Size = new Size(489, 30);
            tb_vidparserDir.TabIndex = 16;
            tb_vidparserDir.TextChanged += SettingControlsChanged;
            // 
            // b_video
            // 
            b_video.Location = new Point(7, 81);
            b_video.Margin = new Padding(4);
            b_video.Name = "b_video";
            b_video.Size = new Size(159, 43);
            b_video.TabIndex = 15;
            b_video.Text = "Parse video";
            b_video.UseVisualStyleBackColor = true;
            b_video.Click += b_video_Click;
            // 
            // group_hyrrore
            // 
            group_hyrrore.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            group_hyrrore.Controls.Add(combo_SongName);
            group_hyrrore.Controls.Add(button_Download);
            group_hyrrore.Controls.Add(button_updateSong);
            group_hyrrore.Location = new Point(7, 8);
            group_hyrrore.Margin = new Padding(4);
            group_hyrrore.Name = "group_hyrrore";
            group_hyrrore.Padding = new Padding(4);
            group_hyrrore.Size = new Size(610, 133);
            group_hyrrore.TabIndex = 16;
            group_hyrrore.TabStop = false;
            group_hyrrore.Text = "million.hyrorre.com";
            // 
            // combo_SongName
            // 
            combo_SongName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            combo_SongName.DisplayMember = "fullName";
            combo_SongName.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_SongName.FormattingEnabled = true;
            combo_SongName.Location = new Point(7, 36);
            combo_SongName.Margin = new Padding(4);
            combo_SongName.Name = "combo_SongName";
            combo_SongName.Size = new Size(594, 32);
            combo_SongName.TabIndex = 8;
            // 
            // button_Download
            // 
            button_Download.Location = new Point(7, 79);
            button_Download.Margin = new Padding(4);
            button_Download.Name = "button_Download";
            button_Download.Size = new Size(134, 43);
            button_Download.TabIndex = 2;
            button_Download.Text = "Download";
            button_Download.UseVisualStyleBackColor = true;
            button_Download.Click += button_Download_Click;
            // 
            // button_updateSong
            // 
            button_updateSong.Location = new Point(149, 79);
            button_updateSong.Margin = new Padding(4);
            button_updateSong.Name = "button_updateSong";
            button_updateSong.Size = new Size(215, 43);
            button_updateSong.TabIndex = 9;
            button_updateSong.Text = "Update song list";
            button_updateSong.UseVisualStyleBackColor = true;
            button_updateSong.Click += button_updateSong_Click;
            // 
            // tab_Rework
            // 
            tab_Rework.Controls.Add(cb_old);
            tab_Rework.Controls.Add(b_rework);
            tab_Rework.Controls.Add(mc_old);
            tab_Rework.Controls.Add(b_reworkAp);
            tab_Rework.Controls.Add(b_reworkBrowse);
            tab_Rework.Controls.Add(tb_reworkF);
            tab_Rework.Controls.Add(lb_reworkF);
            tab_Rework.Location = new Point(4, 33);
            tab_Rework.Margin = new Padding(4);
            tab_Rework.Name = "tab_Rework";
            tab_Rework.Padding = new Padding(4);
            tab_Rework.Size = new Size(626, 470);
            tab_Rework.TabIndex = 2;
            tab_Rework.Text = "Rework";
            tab_Rework.UseVisualStyleBackColor = true;
            // 
            // cb_old
            // 
            cb_old.AutoSize = true;
            cb_old.Checked = true;
            cb_old.CheckState = CheckState.Checked;
            cb_old.Location = new Point(20, 127);
            cb_old.Margin = new Padding(4);
            cb_old.Name = "cb_old";
            cb_old.Size = new Size(133, 28);
            cb_old.TabIndex = 7;
            cb_old.Text = "Older than:";
            cb_old.UseVisualStyleBackColor = true;
            // 
            // b_rework
            // 
            b_rework.Location = new Point(149, 69);
            b_rework.Margin = new Padding(4);
            b_rework.Name = "b_rework";
            b_rework.Size = new Size(177, 43);
            b_rework.TabIndex = 6;
            b_rework.Text = "Update";
            b_rework.UseVisualStyleBackColor = true;
            b_rework.Click += b_reworkAp_Click;
            // 
            // mc_old
            // 
            mc_old.Location = new Point(168, 128);
            mc_old.Margin = new Padding(11, 12, 11, 12);
            mc_old.MaxSelectionCount = 1;
            mc_old.Name = "mc_old";
            mc_old.ShowToday = false;
            mc_old.ShowTodayCircle = false;
            mc_old.TabIndex = 5;
            // 
            // b_reworkAp
            // 
            b_reworkAp.Location = new Point(334, 69);
            b_reworkAp.Margin = new Padding(4);
            b_reworkAp.Name = "b_reworkAp";
            b_reworkAp.Size = new Size(226, 43);
            b_reworkAp.TabIndex = 4;
            b_reworkAp.Text = "Update Appendage";
            b_reworkAp.UseVisualStyleBackColor = true;
            b_reworkAp.Click += b_reworkAp_Click;
            // 
            // b_reworkBrowse
            // 
            b_reworkBrowse.Location = new Point(20, 69);
            b_reworkBrowse.Margin = new Padding(4);
            b_reworkBrowse.Name = "b_reworkBrowse";
            b_reworkBrowse.Size = new Size(122, 43);
            b_reworkBrowse.TabIndex = 3;
            b_reworkBrowse.Text = "Browse...";
            b_reworkBrowse.UseVisualStyleBackColor = true;
            b_reworkBrowse.Click += b_reworkBrowse_Click;
            // 
            // tb_reworkF
            // 
            tb_reworkF.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tb_reworkF.Location = new Point(191, 20);
            tb_reworkF.Margin = new Padding(4);
            tb_reworkF.Name = "tb_reworkF";
            tb_reworkF.Size = new Size(418, 30);
            tb_reworkF.TabIndex = 2;
            // 
            // lb_reworkF
            // 
            lb_reworkF.AutoSize = true;
            lb_reworkF.Location = new Point(16, 24);
            lb_reworkF.Margin = new Padding(4, 0, 4, 0);
            lb_reworkF.Name = "lb_reworkF";
            lb_reworkF.Size = new Size(148, 24);
            lb_reworkF.TabIndex = 0;
            lb_reworkF.Text = "Working Folder:";
            // 
            // tab_Settings
            // 
            tab_Settings.Controls.Add(combo_ver);
            tab_Settings.Controls.Add(label1);
            tab_Settings.Controls.Add(gb_delays);
            tab_Settings.Location = new Point(4, 33);
            tab_Settings.Margin = new Padding(4);
            tab_Settings.Name = "tab_Settings";
            tab_Settings.Size = new Size(626, 470);
            tab_Settings.TabIndex = 0;
            tab_Settings.Text = "Settings";
            // 
            // combo_ver
            // 
            combo_ver.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            combo_ver.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_ver.FormattingEnabled = true;
            combo_ver.Location = new Point(128, 20);
            combo_ver.Margin = new Padding(4);
            combo_ver.Name = "combo_ver";
            combo_ver.Size = new Size(477, 32);
            combo_ver.TabIndex = 7;
            combo_ver.SelectedIndexChanged += SettingControlsChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 24);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 24);
            label1.TabIndex = 6;
            label1.Text = "Version:";
            // 
            // gb_delays
            // 
            gb_delays.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gb_delays.Controls.Add(lb_desyncOffset);
            gb_delays.Controls.Add(num_nCmdScpt);
            gb_delays.Controls.Add(num_moveNum);
            gb_delays.Controls.Add(lb_divSpt);
            gb_delays.Controls.Add(lb_delayMove);
            gb_delays.Controls.Add(num_Den);
            gb_delays.Controls.Add(lb_divSign);
            gb_delays.Controls.Add(lb_delayDown);
            gb_delays.Controls.Add(num_downNum);
            gb_delays.Location = new Point(15, 72);
            gb_delays.Margin = new Padding(4);
            gb_delays.Name = "gb_delays";
            gb_delays.Padding = new Padding(4);
            gb_delays.Size = new Size(592, 213);
            gb_delays.TabIndex = 0;
            gb_delays.TabStop = false;
            gb_delays.Text = "Desynchronization management";
            // 
            // lb_desyncOffset
            // 
            lb_desyncOffset.AutoSize = true;
            lb_desyncOffset.Location = new Point(9, 32);
            lb_desyncOffset.Margin = new Padding(4, 0, 4, 0);
            lb_desyncOffset.Name = "lb_desyncOffset";
            lb_desyncOffset.Size = new Size(266, 24);
            lb_desyncOffset.TabIndex = 9;
            lb_desyncOffset.Text = "Desync offset (num / den ms):";
            // 
            // num_nCmdScpt
            // 
            num_nCmdScpt.Location = new Point(400, 163);
            num_nCmdScpt.Margin = new Padding(4);
            num_nCmdScpt.Name = "num_nCmdScpt";
            num_nCmdScpt.Size = new Size(147, 30);
            num_nCmdScpt.TabIndex = 8;
            num_nCmdScpt.ValueChanged += SettingControlsChanged;
            // 
            // num_moveNum
            // 
            num_moveNum.Location = new Point(145, 112);
            num_moveNum.Margin = new Padding(4);
            num_moveNum.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            num_moveNum.Name = "num_moveNum";
            num_moveNum.Size = new Size(147, 30);
            num_moveNum.TabIndex = 1;
            num_moveNum.ValueChanged += SettingControlsChanged;
            // 
            // lb_divSpt
            // 
            lb_divSpt.AutoSize = true;
            lb_divSpt.Location = new Point(9, 165);
            lb_divSpt.Margin = new Padding(4, 0, 4, 0);
            lb_divSpt.Name = "lb_divSpt";
            lb_divSpt.Size = new Size(327, 24);
            lb_divSpt.TabIndex = 4;
            lb_divSpt.Text = "Command num each script (0 = INF):";
            // 
            // lb_delayMove
            // 
            lb_delayMove.AutoSize = true;
            lb_delayMove.Location = new Point(9, 116);
            lb_delayMove.Margin = new Padding(4, 0, 4, 0);
            lb_delayMove.Name = "lb_delayMove";
            lb_delayMove.Size = new Size(124, 24);
            lb_delayMove.TabIndex = 3;
            lb_delayMove.Text = "Mouse move:";
            // 
            // num_Den
            // 
            num_Den.Location = new Point(328, 89);
            num_Den.Margin = new Padding(4);
            num_Den.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            num_Den.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_Den.Name = "num_Den";
            num_Den.Size = new Size(147, 30);
            num_Den.TabIndex = 1;
            num_Den.Value = new decimal(new int[] { 1, 0, 0, 0 });
            num_Den.ValueChanged += SettingControlsChanged;
            // 
            // lb_divSign
            // 
            lb_divSign.AutoSize = true;
            lb_divSign.Location = new Point(299, 92);
            lb_divSign.Margin = new Padding(4, 0, 4, 0);
            lb_divSign.Name = "lb_divSign";
            lb_divSign.Size = new Size(18, 24);
            lb_divSign.TabIndex = 2;
            lb_divSign.Text = "/";
            // 
            // lb_delayDown
            // 
            lb_delayDown.AutoSize = true;
            lb_delayDown.Location = new Point(7, 69);
            lb_delayDown.Margin = new Padding(4, 0, 4, 0);
            lb_delayDown.Name = "lb_delayDown";
            lb_delayDown.Size = new Size(125, 24);
            lb_delayDown.TabIndex = 1;
            lb_delayDown.Text = "Mouse down:";
            // 
            // num_downNum
            // 
            num_downNum.Location = new Point(145, 67);
            num_downNum.Margin = new Padding(4);
            num_downNum.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            num_downNum.Name = "num_downNum";
            num_downNum.Size = new Size(147, 30);
            num_downNum.TabIndex = 0;
            num_downNum.ValueChanged += SettingControlsChanged;
            // 
            // combo_difficulty
            // 
            combo_difficulty.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            combo_difficulty.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_difficulty.FormattingEnabled = true;
            combo_difficulty.Location = new Point(667, 21);
            combo_difficulty.Margin = new Padding(4);
            combo_difficulty.Name = "combo_difficulty";
            combo_difficulty.Size = new Size(201, 32);
            combo_difficulty.TabIndex = 10;
            // 
            // pgbar_main
            // 
            pgbar_main.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pgbar_main.Location = new Point(667, 492);
            pgbar_main.Margin = new Padding(4);
            pgbar_main.Name = "pgbar_main";
            pgbar_main.Size = new Size(284, 31);
            pgbar_main.TabIndex = 11;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(978, 600);
            Controls.Add(pgbar_main);
            Controls.Add(combo_difficulty);
            Controls.Add(tabC_main);
            Controls.Add(button_Make);
            Controls.Add(tb_output);
            Margin = new Padding(4);
            Name = "FormMain";
            Text = "MilishitaMacro";
            FormClosing += form_main_FormClosing;
            tabC_main.ResumeLayout(false);
            tab_editor.ResumeLayout(false);
            tab_editor.PerformLayout();
            tab_source.ResumeLayout(false);
            group_MilishitaVideoParser.ResumeLayout(false);
            group_MilishitaVideoParser.PerformLayout();
            group_hyrrore.ResumeLayout(false);
            tab_Rework.ResumeLayout(false);
            tab_Rework.PerformLayout();
            tab_Settings.ResumeLayout(false);
            tab_Settings.PerformLayout();
            gb_delays.ResumeLayout(false);
            gb_delays.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_nCmdScpt).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_moveNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_Den).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_downNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox tb_output;
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

