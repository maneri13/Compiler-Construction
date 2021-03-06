﻿namespace Compiler_Construction
{
    partial class Form1
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
            this.codeBlock = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TokenBox = new System.Windows.Forms.GroupBox();
            this.TokenBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.treeItem = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.syntaxErrorBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.error_valuePart = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.error_classPart = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.error_lineNo = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.CFG = new System.Windows.Forms.TreeView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TotalError = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.totalbreaker_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.totalLines = new System.Windows.Forms.Label();
            this.label_totalLines = new System.Windows.Forms.Label();
            this.totalWords = new System.Windows.Forms.Label();
            this.label_totalwords = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.BreakerOcc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BreakerBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bUILDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tEAMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fORMATToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tOOLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tESTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.symantecBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.syntaxBar = new System.Windows.Forms.ProgressBar();
            this.lexicalBar = new System.Windows.Forms.ProgressBar();
            this.fetchBar = new System.Windows.Forms.ProgressBar();
            this.Lexical = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lineBox = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.TokenBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.syntaxErrorBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeBlock
            // 
            this.codeBlock.AcceptsTab = true;
            this.codeBlock.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.codeBlock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeBlock.DetectUrls = false;
            this.codeBlock.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeBlock.ForeColor = System.Drawing.Color.Gold;
            this.codeBlock.Location = new System.Drawing.Point(34, 16);
            this.codeBlock.Name = "codeBlock";
            this.codeBlock.Size = new System.Drawing.Size(600, 497);
            this.codeBlock.TabIndex = 2;
            this.codeBlock.TabStop = false;
            this.codeBlock.Text = "";
            this.codeBlock.TextChanged += new System.EventHandler(this.codeBlock_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 12F);
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(549, 434);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(580, 500);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(572, 471);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lexical Analyzer";
            // 
            // TokenBox
            // 
            this.TokenBox.Controls.Add(this.TokenBox1);
            this.TokenBox.Location = new System.Drawing.Point(3, 3);
            this.TokenBox.Name = "TokenBox";
            this.TokenBox.Size = new System.Drawing.Size(560, 459);
            this.TokenBox.TabIndex = 7;
            this.TokenBox.TabStop = false;
            this.TokenBox.Text = "Tokenizer";
            // 
            // TokenBox1
            // 
            this.TokenBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TokenBox1.DetectUrls = false;
            this.TokenBox1.Font = new System.Drawing.Font("Consolas", 12F);
            this.TokenBox1.Location = new System.Drawing.Point(6, 16);
            this.TokenBox1.Name = "TokenBox1";
            this.TokenBox1.ReadOnly = true;
            this.TokenBox1.Size = new System.Drawing.Size(554, 437);
            this.TokenBox1.TabIndex = 0;
            this.TokenBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 459);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Word Seprator";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.checkBox2);
            this.tabPage2.Controls.Add(this.syntaxErrorBox);
            this.tabPage2.Controls.Add(this.CFG);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(572, 471);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Syntax Analyzer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Controls.Add(this.treeItem);
            this.groupBox6.Location = new System.Drawing.Point(371, 135);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(195, 75);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Search Tree";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(100, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Find Next";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeItem
            // 
            this.treeItem.Location = new System.Drawing.Point(7, 20);
            this.treeItem.Name = "treeItem";
            this.treeItem.Size = new System.Drawing.Size(182, 20);
            this.treeItem.TabIndex = 0;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(371, 6);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(87, 17);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Expand Tree";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // syntaxErrorBox
            // 
            this.syntaxErrorBox.Controls.Add(this.label8);
            this.syntaxErrorBox.Controls.Add(this.error_valuePart);
            this.syntaxErrorBox.Controls.Add(this.label9);
            this.syntaxErrorBox.Controls.Add(this.error_classPart);
            this.syntaxErrorBox.Controls.Add(this.label10);
            this.syntaxErrorBox.Controls.Add(this.error_lineNo);
            this.syntaxErrorBox.Controls.Add(this.label11);
            this.syntaxErrorBox.Location = new System.Drawing.Point(371, 29);
            this.syntaxErrorBox.Name = "syntaxErrorBox";
            this.syntaxErrorBox.Size = new System.Drawing.Size(195, 99);
            this.syntaxErrorBox.TabIndex = 8;
            this.syntaxErrorBox.TabStop = false;
            this.syntaxErrorBox.Text = "Syntax Error";
            this.syntaxErrorBox.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 12F);
            this.label8.Location = new System.Drawing.Point(10, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "Syntax Error Value";
            // 
            // error_valuePart
            // 
            this.error_valuePart.AutoSize = true;
            this.error_valuePart.Location = new System.Drawing.Point(72, 79);
            this.error_valuePart.Name = "error_valuePart";
            this.error_valuePart.Size = new System.Drawing.Size(0, 13);
            this.error_valuePart.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Line no";
            // 
            // error_classPart
            // 
            this.error_classPart.AutoSize = true;
            this.error_classPart.Location = new System.Drawing.Point(72, 59);
            this.error_classPart.Name = "error_classPart";
            this.error_classPart.Size = new System.Drawing.Size(0, 13);
            this.error_classPart.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Class Part";
            // 
            // error_lineNo
            // 
            this.error_lineNo.AutoSize = true;
            this.error_lineNo.Location = new System.Drawing.Point(72, 39);
            this.error_lineNo.Name = "error_lineNo";
            this.error_lineNo.Size = new System.Drawing.Size(0, 13);
            this.error_lineNo.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Value Part";
            // 
            // CFG
            // 
            this.CFG.Location = new System.Drawing.Point(6, 6);
            this.CFG.Name = "CFG";
            this.CFG.Size = new System.Drawing.Size(359, 459);
            this.CFG.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.TotalError);
            this.groupBox4.Controls.Add(this.ErrorLabel);
            this.groupBox4.Controls.Add(this.totalbreaker_label);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.totalLines);
            this.groupBox4.Controls.Add(this.label_totalLines);
            this.groupBox4.Controls.Add(this.totalWords);
            this.groupBox4.Controls.Add(this.label_totalwords);
            this.groupBox4.Location = new System.Drawing.Point(16, 529);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 108);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Stats";
            // 
            // TotalError
            // 
            this.TotalError.AutoSize = true;
            this.TotalError.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.TotalError.ForeColor = System.Drawing.Color.DimGray;
            this.TotalError.Location = new System.Drawing.Point(146, 88);
            this.TotalError.Name = "TotalError";
            this.TotalError.Size = new System.Drawing.Size(0, 19);
            this.TotalError.TabIndex = 18;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Consolas", 12F);
            this.ErrorLabel.Location = new System.Drawing.Point(6, 88);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(72, 19);
            this.ErrorLabel.TabIndex = 17;
            this.ErrorLabel.Text = "Errors:";
            // 
            // totalbreaker_label
            // 
            this.totalbreaker_label.AutoSize = true;
            this.totalbreaker_label.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.totalbreaker_label.ForeColor = System.Drawing.Color.DimGray;
            this.totalbreaker_label.Location = new System.Drawing.Point(146, 65);
            this.totalbreaker_label.Name = "totalbreaker_label";
            this.totalbreaker_label.Size = new System.Drawing.Size(0, 19);
            this.totalbreaker_label.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F);
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "Total Breaker:";
            // 
            // totalLines
            // 
            this.totalLines.AutoSize = true;
            this.totalLines.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.totalLines.ForeColor = System.Drawing.Color.DimGray;
            this.totalLines.Location = new System.Drawing.Point(145, 40);
            this.totalLines.Name = "totalLines";
            this.totalLines.Size = new System.Drawing.Size(0, 19);
            this.totalLines.TabIndex = 11;
            // 
            // label_totalLines
            // 
            this.label_totalLines.AutoSize = true;
            this.label_totalLines.Font = new System.Drawing.Font("Consolas", 12F);
            this.label_totalLines.Location = new System.Drawing.Point(6, 40);
            this.label_totalLines.Name = "label_totalLines";
            this.label_totalLines.Size = new System.Drawing.Size(117, 19);
            this.label_totalLines.TabIndex = 10;
            this.label_totalLines.Text = "Total Lines:";
            // 
            // totalWords
            // 
            this.totalWords.AutoSize = true;
            this.totalWords.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.totalWords.ForeColor = System.Drawing.Color.DimGray;
            this.totalWords.Location = new System.Drawing.Point(145, 16);
            this.totalWords.Name = "totalWords";
            this.totalWords.Size = new System.Drawing.Size(0, 19);
            this.totalWords.TabIndex = 9;
            // 
            // label_totalwords
            // 
            this.label_totalwords.AutoSize = true;
            this.label_totalwords.Font = new System.Drawing.Font("Consolas", 12F);
            this.label_totalwords.Location = new System.Drawing.Point(6, 16);
            this.label_totalwords.Name = "label_totalwords";
            this.label_totalwords.Size = new System.Drawing.Size(117, 19);
            this.label_totalwords.TabIndex = 8;
            this.label_totalwords.Text = "Total Words:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.BreakerOcc);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.BreakerBox);
            this.groupBox5.Location = new System.Drawing.Point(230, 529);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 108);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Word Breaker Analyzer";
            // 
            // BreakerOcc
            // 
            this.BreakerOcc.AutoSize = true;
            this.BreakerOcc.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BreakerOcc.ForeColor = System.Drawing.Color.DimGray;
            this.BreakerOcc.Location = new System.Drawing.Point(120, 75);
            this.BreakerOcc.Name = "BreakerOcc";
            this.BreakerOcc.Size = new System.Drawing.Size(0, 19);
            this.BreakerOcc.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F);
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Occurrence:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F);
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Word Breaker";
            // 
            // BreakerBox
            // 
            this.BreakerBox.FormattingEnabled = true;
            this.BreakerBox.Location = new System.Drawing.Point(6, 47);
            this.BreakerBox.Name = "BreakerBox";
            this.BreakerBox.Size = new System.Drawing.Size(188, 21);
            this.BreakerBox.TabIndex = 13;
            this.BreakerBox.SelectedIndexChanged += new System.EventHandler(this.selectBreaker);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.eDITToolStripMenuItem,
            this.bUILDToolStripMenuItem,
            this.tEAMToolStripMenuItem,
            this.fORMATToolStripMenuItem,
            this.tOOLSToolStripMenuItem,
            this.tESTToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1244, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.eDITToolStripMenuItem.Text = "EDIT";
            // 
            // bUILDToolStripMenuItem
            // 
            this.bUILDToolStripMenuItem.Name = "bUILDToolStripMenuItem";
            this.bUILDToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.bUILDToolStripMenuItem.Text = "BUILD";
            // 
            // tEAMToolStripMenuItem
            // 
            this.tEAMToolStripMenuItem.Name = "tEAMToolStripMenuItem";
            this.tEAMToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.tEAMToolStripMenuItem.Text = "TEAM";
            // 
            // fORMATToolStripMenuItem
            // 
            this.fORMATToolStripMenuItem.Name = "fORMATToolStripMenuItem";
            this.fORMATToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.fORMATToolStripMenuItem.Text = "FORMAT";
            // 
            // tOOLSToolStripMenuItem
            // 
            this.tOOLSToolStripMenuItem.Name = "tOOLSToolStripMenuItem";
            this.tOOLSToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.tOOLSToolStripMenuItem.Text = "TOOLS";
            // 
            // tESTToolStripMenuItem
            // 
            this.tESTToolStripMenuItem.Name = "tESTToolStripMenuItem";
            this.tESTToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.tESTToolStripMenuItem.Text = "TEST";
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.hELPToolStripMenuItem.Text = "HELP";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lineBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.symantecBar);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.syntaxBar);
            this.groupBox3.Controls.Add(this.lexicalBar);
            this.groupBox3.Controls.Add(this.fetchBar);
            this.groupBox3.Controls.Add(this.codeBlock);
            this.groupBox3.Location = new System.Drawing.Point(594, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(640, 579);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Source Code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F);
            this.label7.Location = new System.Drawing.Point(544, 551);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "Symantec";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 12F);
            this.label6.Location = new System.Drawing.Point(377, 551);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Syntax";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F);
            this.label5.Location = new System.Drawing.Point(195, 551);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Lexical";
            // 
            // symantecBar
            // 
            this.symantecBar.Location = new System.Drawing.Point(534, 522);
            this.symantecBar.Name = "symantecBar";
            this.symantecBar.Size = new System.Drawing.Size(100, 23);
            this.symantecBar.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F);
            this.label4.Location = new System.Drawing.Point(6, 551);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Code Fetch";
            // 
            // syntaxBar
            // 
            this.syntaxBar.Location = new System.Drawing.Point(358, 522);
            this.syntaxBar.Name = "syntaxBar";
            this.syntaxBar.Size = new System.Drawing.Size(100, 23);
            this.syntaxBar.TabIndex = 5;
            // 
            // lexicalBar
            // 
            this.lexicalBar.Location = new System.Drawing.Point(182, 522);
            this.lexicalBar.Name = "lexicalBar";
            this.lexicalBar.Size = new System.Drawing.Size(100, 23);
            this.lexicalBar.TabIndex = 4;
            // 
            // fetchBar
            // 
            this.fetchBar.Location = new System.Drawing.Point(6, 522);
            this.fetchBar.Name = "fetchBar";
            this.fetchBar.Size = new System.Drawing.Size(100, 23);
            this.fetchBar.TabIndex = 3;
            // 
            // Lexical
            // 
            this.Lexical.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lexical.Location = new System.Drawing.Point(17, 51);
            this.Lexical.Name = "Lexical";
            this.Lexical.Size = new System.Drawing.Size(118, 43);
            this.Lexical.TabIndex = 0;
            this.Lexical.Text = "COMPILE";
            this.Lexical.UseVisualStyleBackColor = true;
            this.Lexical.Click += new System.EventHandler(this.Lexical_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Consolas", 12F);
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(109, 23);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Live View";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.Lexical);
            this.groupBox2.Location = new System.Drawing.Point(436, 529);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 108);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compiler";
            // 
            // lineBox
            // 
            this.lineBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lineBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lineBox.Font = new System.Drawing.Font("Consolas", 12F);
            this.lineBox.ForeColor = System.Drawing.Color.Gold;
            this.lineBox.Location = new System.Drawing.Point(4, 16);
            this.lineBox.Name = "lineBox";
            this.lineBox.ReadOnly = true;
            this.lineBox.Size = new System.Drawing.Size(24, 497);
            this.lineBox.TabIndex = 11;
            this.lineBox.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TokenBox);
            this.splitContainer1.Size = new System.Drawing.Size(566, 465);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 648);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "-";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.TokenBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.syntaxErrorBox.ResumeLayout(false);
            this.syntaxErrorBox.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox codeBlock;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox TokenBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eDITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bUILDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tEAMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fORMATToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tOOLSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tESTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label_totalwords;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label totalWords;
        private System.Windows.Forms.Label label_totalLines;
        private System.Windows.Forms.Label totalLines;
        private System.Windows.Forms.ComboBox BreakerBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label BreakerOcc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalbreaker_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox TokenBox1;
        private System.Windows.Forms.Button Lexical;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label TotalError;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar symantecBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar syntaxBar;
        private System.Windows.Forms.ProgressBar lexicalBar;
        private System.Windows.Forms.ProgressBar fetchBar;
        public System.Windows.Forms.TreeView CFG;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label error_valuePart;
        public System.Windows.Forms.Label error_classPart;
        public System.Windows.Forms.Label error_lineNo;
        public System.Windows.Forms.GroupBox syntaxErrorBox;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox treeItem;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.RichTextBox lineBox;
        private System.Windows.Forms.SplitContainer splitContainer1;

    }
}

