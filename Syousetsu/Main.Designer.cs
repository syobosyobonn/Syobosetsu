using System;
using System.Drawing;
using Sgry.Azuki;
using System.Windows.Forms;
using Sgry.Azuki.WinForms;

namespace Syobosetsu
{
    partial class Main
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
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            Sgry.Azuki.FontInfo fontInfo12 = new Sgry.Azuki.FontInfo();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReReadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OverWriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToMNFPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.編集ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MemoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AllSettingsEandIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExpSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InpSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.VerInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MoziLabel = new System.Windows.Forms.Label();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.FileNamePanel = new System.Windows.Forms.Panel();
            this.MoziPanel = new System.Windows.Forms.Panel();
            this.MainTextBox = new Sgry.Azuki.WinForms.AzukiControl();
            this.MainWindowProgressBar = new System.Windows.Forms.ProgressBar();
            this.menuStrip1.SuspendLayout();
            this.FileNamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem,
            this.編集ToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFileToolStripMenuItem,
            this.NewWindowToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.ReReadToolStripMenuItem,
            this.OverWriteToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.SaveToMNFPToolStripMenuItem,
            this.QuitToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // NewFileToolStripMenuItem
            // 
            this.NewFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("NewFileToolStripMenuItem.Image")));
            this.NewFileToolStripMenuItem.Name = "NewFileToolStripMenuItem";
            this.NewFileToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.NewFileToolStripMenuItem.Text = "新規作成　　(Ctrl+N)";
            this.NewFileToolStripMenuItem.Click += new System.EventHandler(this.新規作成ToolStripMenuItem_Click);
            // 
            // NewWindowToolStripMenuItem
            // 
            this.NewWindowToolStripMenuItem.Name = "NewWindowToolStripMenuItem";
            this.NewWindowToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.NewWindowToolStripMenuItem.Text = "新規ウィンドウ";
            this.NewWindowToolStripMenuItem.Click += new System.EventHandler(this.NewWindowToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenToolStripMenuItem.Image")));
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.OpenToolStripMenuItem.Text = "開く　　　　 (Ctrl+O)";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.開くToolStripMenuItem_Click);
            // 
            // ReReadToolStripMenuItem
            // 
            this.ReReadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ReReadToolStripMenuItem.Image")));
            this.ReReadToolStripMenuItem.Name = "ReReadToolStripMenuItem";
            this.ReReadToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ReReadToolStripMenuItem.Text = "再読み込み　(Ctrl+R)";
            this.ReReadToolStripMenuItem.Click += new System.EventHandler(this.ReRead_Click);
            // 
            // OverWriteToolStripMenuItem
            // 
            this.OverWriteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OverWriteToolStripMenuItem.Image")));
            this.OverWriteToolStripMenuItem.Name = "OverWriteToolStripMenuItem";
            this.OverWriteToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.OverWriteToolStripMenuItem.Text = "上書き保存　(Ctrl+S)";
            this.OverWriteToolStripMenuItem.Click += new System.EventHandler(this.上書き保存ToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveAsToolStripMenuItem.Image")));
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.SaveAsToolStripMenuItem.Text = "名前をつけて保存";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.名前をつけて保存ToolStripMenuItem_Click);
            // 
            // SaveToMNFPToolStripMenuItem
            // 
            this.SaveToMNFPToolStripMenuItem.Name = "SaveToMNFPToolStripMenuItem";
            this.SaveToMNFPToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.SaveToMNFPToolStripMenuItem.Text = "テキスト群をMNFPに保存";
            this.SaveToMNFPToolStripMenuItem.Click += new System.EventHandler(this.SaveToMNFPToolStripMenuItem_Click);
            // 
            // QuitToolStripMenuItem
            // 
            this.QuitToolStripMenuItem.Image = global::Syobosetsu.Properties.Resources.Exit;
            this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
            this.QuitToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.QuitToolStripMenuItem.Text = "終了";
            this.QuitToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // 編集ToolStripMenuItem
            // 
            this.編集ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MemoToolStripMenuItem,
            this.AnalysisToolStripMenuItem,
            this.SettingsToolStripMenuItem,
            this.AllSettingsEandIToolStripMenuItem});
            this.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem";
            this.編集ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.編集ToolStripMenuItem.Text = "編集";
            // 
            // MemoToolStripMenuItem
            // 
            this.MemoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("MemoToolStripMenuItem.Image")));
            this.MemoToolStripMenuItem.Name = "MemoToolStripMenuItem";
            this.MemoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.MemoToolStripMenuItem.Text = "メモ(Ctrl+M)";
            this.MemoToolStripMenuItem.Click += new System.EventHandler(this.MemoToolStripMenuItem_Click);
            // 
            // AnalysisToolStripMenuItem
            // 
            this.AnalysisToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("AnalysisToolStripMenuItem.Image")));
            this.AnalysisToolStripMenuItem.Name = "AnalysisToolStripMenuItem";
            this.AnalysisToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AnalysisToolStripMenuItem.Text = "解析(Ctrl+F)";
            this.AnalysisToolStripMenuItem.Click += new System.EventHandler(this.AnalysisToolStripMenuItem_Click);
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SettingsToolStripMenuItem.Image")));
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SettingsToolStripMenuItem.Text = "設定";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.設定ToolStripMenuItem_Click);
            // 
            // AllSettingsEandIToolStripMenuItem
            // 
            this.AllSettingsEandIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExpSettingsToolStripMenuItem,
            this.InpSettingsToolStripMenuItem});
            this.AllSettingsEandIToolStripMenuItem.Name = "AllSettingsEandIToolStripMenuItem";
            this.AllSettingsEandIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AllSettingsEandIToolStripMenuItem.Text = "全設定(メモ,設定)を...";
            // 
            // ExpSettingsToolStripMenuItem
            // 
            this.ExpSettingsToolStripMenuItem.Name = "ExpSettingsToolStripMenuItem";
            this.ExpSettingsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.ExpSettingsToolStripMenuItem.Text = "エクスポート";
            this.ExpSettingsToolStripMenuItem.Click += new System.EventHandler(this.ExpSettingsToolStripMenuItem_Click);
            // 
            // InpSettingsToolStripMenuItem
            // 
            this.InpSettingsToolStripMenuItem.Name = "InpSettingsToolStripMenuItem";
            this.InpSettingsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.InpSettingsToolStripMenuItem.Text = "インポート";
            this.InpSettingsToolStripMenuItem.Click += new System.EventHandler(this.InpSettingsToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpToolStripMenuItem1,
            this.VerInfoToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.HelpToolStripMenuItem.Text = "ヘルプ";
            // 
            // HelpToolStripMenuItem1
            // 
            this.HelpToolStripMenuItem1.Image = global::Syobosetsu.Properties.Resources.Help;
            this.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1";
            this.HelpToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.HelpToolStripMenuItem1.Text = "ヘルプ";
            this.HelpToolStripMenuItem1.Click += new System.EventHandler(this.ヘルプToolStripMenuItem1_Click);
            // 
            // VerInfoToolStripMenuItem
            // 
            this.VerInfoToolStripMenuItem.Image = global::Syobosetsu.Properties.Resources.Help;
            this.VerInfoToolStripMenuItem.Name = "VerInfoToolStripMenuItem";
            this.VerInfoToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.VerInfoToolStripMenuItem.Text = "バージョン情報";
            this.VerInfoToolStripMenuItem.Click += new System.EventHandler(this.バージョン情報ToolStripMenuItem_Click);
            // 
            // MoziLabel
            // 
            this.MoziLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MoziLabel.AutoSize = true;
            this.MoziLabel.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.MoziLabel.Location = new System.Drawing.Point(659, 435);
            this.MoziLabel.Name = "MoziLabel";
            this.MoziLabel.Size = new System.Drawing.Size(30, 10);
            this.MoziLabel.TabIndex = 3;
            this.MoziLabel.Text = "0文字";
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Font = new System.Drawing.Font("MS UI Gothic", 7F);
            this.FileNameLabel.Location = new System.Drawing.Point(3, 1);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(26, 10);
            this.FileNameLabel.TabIndex = 4;
            this.FileNameLabel.Text = "None";
            // 
            // FileNamePanel
            // 
            this.FileNamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileNamePanel.BackColor = System.Drawing.SystemColors.Window;
            this.FileNamePanel.Controls.Add(this.FileNameLabel);
            this.FileNamePanel.Location = new System.Drawing.Point(4, 434);
            this.FileNamePanel.Name = "FileNamePanel";
            this.FileNamePanel.Size = new System.Drawing.Size(649, 13);
            this.FileNamePanel.TabIndex = 5;
            // 
            // MoziPanel
            // 
            this.MoziPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MoziPanel.BackColor = System.Drawing.SystemColors.Window;
            this.MoziPanel.Location = new System.Drawing.Point(656, 434);
            this.MoziPanel.Name = "MoziPanel";
            this.MoziPanel.Size = new System.Drawing.Size(139, 13);
            this.MoziPanel.TabIndex = 7;
            // 
            // MainTextBox
            // 
            this.MainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTextBox.BackColor = System.Drawing.Color.White;
            this.MainTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.MainTextBox.DrawingOption = ((Sgry.Azuki.DrawingOption)(((((((Sgry.Azuki.DrawingOption.DrawsTab | Sgry.Azuki.DrawingOption.HighlightCurrentLine) 
            | Sgry.Azuki.DrawingOption.ShowsLineNumber) 
            | Sgry.Azuki.DrawingOption.ShowsHRuler) 
            | Sgry.Azuki.DrawingOption.DrawsEof) 
            | Sgry.Azuki.DrawingOption.ShowsDirtBar) 
            | Sgry.Azuki.DrawingOption.HighlightsMatchedBracket)));
            this.MainTextBox.DrawsEofMark = true;
            this.MainTextBox.DrawsEolCode = false;
            this.MainTextBox.DrawsFullWidthSpace = false;
            this.MainTextBox.FirstVisibleLine = 0;
            this.MainTextBox.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            fontInfo12.Name = "MS UI Gothic";
            fontInfo12.Size = 9;
            fontInfo12.Style = System.Drawing.FontStyle.Regular;
            this.MainTextBox.FontInfo = fontInfo12;
            this.MainTextBox.ForeColor = System.Drawing.Color.Black;
            this.MainTextBox.Location = new System.Drawing.Point(5, 27);
            this.MainTextBox.Name = "MainTextBox";
            this.MainTextBox.ScrollPos = new System.Drawing.Point(0, 0);
            this.MainTextBox.ShowsHRuler = true;
            this.MainTextBox.ShowsHScrollBar = false;
            this.MainTextBox.Size = new System.Drawing.Size(790, 401);
            this.MainTextBox.TabIndex = 8;
            this.MainTextBox.TabWidth = 4;
            this.MainTextBox.ViewType = Sgry.Azuki.ViewType.WrappedProportional;
            this.MainTextBox.ViewWidth = 4129;
            this.MainTextBox.TextChanged += new System.EventHandler(this.MainTextBox_TextChanged);
            this.MainTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDowning);
            // 
            // MainWindowProgressBar
            // 
            this.MainWindowProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MainWindowProgressBar.Location = new System.Drawing.Point(584, 434);
            this.MainWindowProgressBar.Name = "MainWindowProgressBar";
            this.MainWindowProgressBar.Size = new System.Drawing.Size(66, 13);
            this.MainWindowProgressBar.TabIndex = 9;
            this.MainWindowProgressBar.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainWindowProgressBar);
            this.Controls.Add(this.MainTextBox);
            this.Controls.Add(this.MoziLabel);
            this.Controls.Add(this.MoziPanel);
            this.Controls.Add(this.FileNamePanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(307, 157);
            this.Name = "Main";
            this.Opacity = 0.99D;
            this.Text = "Syobosetsu-MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.FileNamePanel.ResumeLayout(false);
            this.FileNamePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OverWriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 編集ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.Label MoziLabel;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReReadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SaveToMNFPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VerInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MemoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewWindowToolStripMenuItem;
        private System.Windows.Forms.Panel FileNamePanel;
        private System.Windows.Forms.Panel MoziPanel;
        private ToolStripMenuItem AllSettingsEandIToolStripMenuItem;
        private ToolStripMenuItem ExpSettingsToolStripMenuItem;
        private ToolStripMenuItem InpSettingsToolStripMenuItem;
        private AzukiControl MainTextBox;
        private ProgressBar MainWindowProgressBar;
    }
}