namespace MilishitaMacro {
    partial class form_main {
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
            this.button_Save = new System.Windows.Forms.Button();
            this.tabC_main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_updateSong = new System.Windows.Forms.Button();
            this.button_Download = new System.Windows.Forms.Button();
            this.button_FromMacros = new System.Windows.Forms.Button();
            this.combo_SongName = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.b_SaveTXT = new System.Windows.Forms.Button();
            this.b_LoadText = new System.Windows.Forms.Button();
            this.b_ass = new System.Windows.Forms.Button();
            this.textb_SongName = new System.Windows.Forms.TextBox();
            this.button_ToMacros = new System.Windows.Forms.Button();
            this.text_Score = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cb_old = new System.Windows.Forms.CheckBox();
            this.b_rework = new System.Windows.Forms.Button();
            this.mc_old = new System.Windows.Forms.MonthCalendar();
            this.b_reworkAp = new System.Windows.Forms.Button();
            this.b_reworkBrowse = new System.Windows.Forms.Button();
            this.tb_reworkF = new System.Windows.Forms.TextBox();
            this.lb_reworkF = new System.Windows.Forms.Label();
            this.combo_difficulty = new System.Windows.Forms.ComboBox();
            this.tabC_main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.output_000.Size = new System.Drawing.Size(232, 298);
            this.output_000.TabIndex = 0;
            // 
            // button_Save
            // 
            this.button_Save.Enabled = false;
            this.button_Save.Location = new System.Drawing.Point(546, 54);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(110, 34);
            this.button_Save.TabIndex = 8;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // tabC_main
            // 
            this.tabC_main.Controls.Add(this.tabPage1);
            this.tabC_main.Controls.Add(this.tabPage2);
            this.tabC_main.Controls.Add(this.tabPage3);
            this.tabC_main.Location = new System.Drawing.Point(12, 16);
            this.tabC_main.Name = "tabC_main";
            this.tabC_main.SelectedIndex = 0;
            this.tabC_main.Size = new System.Drawing.Size(519, 380);
            this.tabC_main.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_updateSong);
            this.tabPage1.Controls.Add(this.button_Download);
            this.tabPage1.Controls.Add(this.button_FromMacros);
            this.tabPage1.Controls.Add(this.combo_SongName);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(511, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hyrorre";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button_updateSong
            // 
            this.button_updateSong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_updateSong.Location = new System.Drawing.Point(30, 283);
            this.button_updateSong.Name = "button_updateSong";
            this.button_updateSong.Size = new System.Drawing.Size(176, 36);
            this.button_updateSong.TabIndex = 9;
            this.button_updateSong.Text = "Update song list";
            this.button_updateSong.UseVisualStyleBackColor = true;
            this.button_updateSong.Click += new System.EventHandler(this.button_updateSong_Click);
            // 
            // button_Download
            // 
            this.button_Download.Enabled = false;
            this.button_Download.Location = new System.Drawing.Point(30, 80);
            this.button_Download.Name = "button_Download";
            this.button_Download.Size = new System.Drawing.Size(110, 35);
            this.button_Download.TabIndex = 2;
            this.button_Download.Text = "Download";
            this.button_Download.UseVisualStyleBackColor = true;
            this.button_Download.Click += new System.EventHandler(this.button_Download_Click);
            // 
            // button_FromMacros
            // 
            this.button_FromMacros.Enabled = false;
            this.button_FromMacros.Location = new System.Drawing.Point(163, 80);
            this.button_FromMacros.Name = "button_FromMacros";
            this.button_FromMacros.Size = new System.Drawing.Size(146, 35);
            this.button_FromMacros.TabIndex = 2;
            this.button_FromMacros.Text = "Dump to manual";
            this.button_FromMacros.UseVisualStyleBackColor = true;
            this.button_FromMacros.Click += new System.EventHandler(this.button_FromMacros_Click);
            // 
            // combo_SongName
            // 
            this.combo_SongName.DisplayMember = "fullName";
            this.combo_SongName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_SongName.FormattingEnabled = true;
            this.combo_SongName.Location = new System.Drawing.Point(30, 25);
            this.combo_SongName.Name = "combo_SongName";
            this.combo_SongName.Size = new System.Drawing.Size(444, 26);
            this.combo_SongName.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.b_SaveTXT);
            this.tabPage2.Controls.Add(this.b_LoadText);
            this.tabPage2.Controls.Add(this.b_ass);
            this.tabPage2.Controls.Add(this.textb_SongName);
            this.tabPage2.Controls.Add(this.button_ToMacros);
            this.tabPage2.Controls.Add(this.text_Score);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(511, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manual";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // b_SaveTXT
            // 
            this.b_SaveTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_SaveTXT.Location = new System.Drawing.Point(246, 294);
            this.b_SaveTXT.Name = "b_SaveTXT";
            this.b_SaveTXT.Size = new System.Drawing.Size(101, 32);
            this.b_SaveTXT.TabIndex = 14;
            this.b_SaveTXT.Text = "Save TXT";
            this.b_SaveTXT.UseVisualStyleBackColor = true;
            this.b_SaveTXT.Click += new System.EventHandler(this.b_SaveTXT_Click);
            // 
            // b_LoadText
            // 
            this.b_LoadText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_LoadText.Location = new System.Drawing.Point(129, 294);
            this.b_LoadText.Name = "b_LoadText";
            this.b_LoadText.Size = new System.Drawing.Size(101, 33);
            this.b_LoadText.TabIndex = 13;
            this.b_LoadText.Text = "Load TXT";
            this.b_LoadText.UseVisualStyleBackColor = true;
            this.b_LoadText.Click += new System.EventHandler(this.b_LoadText_Click);
            // 
            // b_ass
            // 
            this.b_ass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.b_ass.Location = new System.Drawing.Point(20, 294);
            this.b_ass.Name = "b_ass";
            this.b_ass.Size = new System.Drawing.Size(97, 33);
            this.b_ass.TabIndex = 12;
            this.b_ass.Text = "Load ASS";
            this.b_ass.UseVisualStyleBackColor = true;
            this.b_ass.Click += new System.EventHandler(this.b_ass_Click);
            // 
            // textb_SongName
            // 
            this.textb_SongName.Location = new System.Drawing.Point(148, 15);
            this.textb_SongName.Name = "textb_SongName";
            this.textb_SongName.Size = new System.Drawing.Size(340, 28);
            this.textb_SongName.TabIndex = 11;
            this.textb_SongName.Text = "(Song_Name)";
            // 
            // button_ToMacros
            // 
            this.button_ToMacros.Location = new System.Drawing.Point(20, 15);
            this.button_ToMacros.Name = "button_ToMacros";
            this.button_ToMacros.Size = new System.Drawing.Size(114, 32);
            this.button_ToMacros.TabIndex = 3;
            this.button_ToMacros.Text = "To Macros";
            this.button_ToMacros.UseVisualStyleBackColor = true;
            this.button_ToMacros.Click += new System.EventHandler(this.button_ToMacros_Click);
            // 
            // text_Score
            // 
            this.text_Score.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.text_Score.Location = new System.Drawing.Point(20, 53);
            this.text_Score.Multiline = true;
            this.text_Score.Name = "text_Score";
            this.text_Score.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.text_Score.Size = new System.Drawing.Size(468, 235);
            this.text_Score.TabIndex = 0;
            this.text_Score.TextChanged += new System.EventHandler(this.textScore_Change);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cb_old);
            this.tabPage3.Controls.Add(this.b_rework);
            this.tabPage3.Controls.Add(this.mc_old);
            this.tabPage3.Controls.Add(this.b_reworkAp);
            this.tabPage3.Controls.Add(this.b_reworkBrowse);
            this.tabPage3.Controls.Add(this.tb_reworkF);
            this.tabPage3.Controls.Add(this.lb_reworkF);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(511, 348);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Rework";
            this.tabPage3.UseVisualStyleBackColor = true;
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
            this.mc_old.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // combo_difficulty
            // 
            this.combo_difficulty.DisplayMember = "displayName";
            this.combo_difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_difficulty.FormattingEnabled = true;
            this.combo_difficulty.Location = new System.Drawing.Point(546, 16);
            this.combo_difficulty.Name = "combo_difficulty";
            this.combo_difficulty.Size = new System.Drawing.Size(165, 26);
            this.combo_difficulty.TabIndex = 10;
            this.combo_difficulty.SelectedIndexChanged += new System.EventHandler(this.textScore_Change);
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.combo_difficulty);
            this.Controls.Add(this.tabC_main);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.output_000);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "form_main";
            this.Text = "MilishitaMacro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_main_FormClosing);
            this.tabC_main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox output_000;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.TabControl tabC_main;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox combo_difficulty;
        private System.Windows.Forms.TextBox text_Score;
        private System.Windows.Forms.Button button_ToMacros;
        private System.Windows.Forms.TextBox textb_SongName;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button_updateSong;
        private System.Windows.Forms.Button button_Download;
        private System.Windows.Forms.Button button_FromMacros;
        private System.Windows.Forms.ComboBox combo_SongName;
        private System.Windows.Forms.Button b_ass;
        private System.Windows.Forms.Button b_SaveTXT;
        private System.Windows.Forms.Button b_LoadText;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lb_reworkF;
        private System.Windows.Forms.TextBox tb_reworkF;
        private System.Windows.Forms.Button b_reworkBrowse;
        private System.Windows.Forms.Button b_reworkAp;
        private System.Windows.Forms.CheckBox cb_old;
        private System.Windows.Forms.Button b_rework;
        private System.Windows.Forms.MonthCalendar mc_old;
    }
}

