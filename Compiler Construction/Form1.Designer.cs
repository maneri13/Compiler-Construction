namespace Compiler_Construction
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
            this.Lexical = new System.Windows.Forms.Button();
            this.codeBlock = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BreakerBox = new System.Windows.Forms.ComboBox();
            this.totalLines = new System.Windows.Forms.Label();
            this.label_totalLines = new System.Windows.Forms.Label();
            this.totalWords = new System.Windows.Forms.Label();
            this.label_totalwords = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.label2 = new System.Windows.Forms.Label();
            this.BreakerOcc = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.totalbreaker_label = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lexical
            // 
            this.Lexical.Location = new System.Drawing.Point(597, 239);
            this.Lexical.Name = "Lexical";
            this.Lexical.Size = new System.Drawing.Size(75, 23);
            this.Lexical.TabIndex = 0;
            this.Lexical.Text = "COMPILE";
            this.Lexical.UseVisualStyleBackColor = true;
            this.Lexical.Click += new System.EventHandler(this.Lexical_Click);
            // 
            // codeBlock
            // 
            this.codeBlock.AcceptsTab = true;
            this.codeBlock.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.codeBlock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeBlock.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeBlock.ForeColor = System.Drawing.Color.Gold;
            this.codeBlock.Location = new System.Drawing.Point(6, 15);
            this.codeBlock.Name = "codeBlock";
            this.codeBlock.Size = new System.Drawing.Size(648, 96);
            this.codeBlock.TabIndex = 2;
            this.codeBlock.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 12F);
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(200, 142);
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
            this.tabControl1.Size = new System.Drawing.Size(660, 205);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(652, 176);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lexical Analyzer";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.totalbreaker_label);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.totalLines);
            this.groupBox4.Controls.Add(this.label_totalLines);
            this.groupBox4.Controls.Add(this.totalWords);
            this.groupBox4.Controls.Add(this.label_totalwords);
            this.groupBox4.Location = new System.Drawing.Point(432, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(214, 166);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Stats";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.BreakerOcc);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.BreakerBox);
            this.groupBox5.Location = new System.Drawing.Point(10, 87);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(198, 73);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Word Breaker Analyzer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F);
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Word Breaker";
            // 
            // BreakerBox
            // 
            this.BreakerBox.FormattingEnabled = true;
            this.BreakerBox.Location = new System.Drawing.Point(129, 17);
            this.BreakerBox.Name = "BreakerBox";
            this.BreakerBox.Size = new System.Drawing.Size(63, 21);
            this.BreakerBox.TabIndex = 13;
            this.BreakerBox.SelectedIndexChanged += new System.EventHandler(this.selectBreaker);
            // 
            // totalLines
            // 
            this.totalLines.AutoSize = true;
            this.totalLines.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.totalLines.ForeColor = System.Drawing.Color.OrangeRed;
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
            this.totalWords.ForeColor = System.Drawing.Color.OrangeRed;
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
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(225, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 166);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tokenizer";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 167);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Word Seprator";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(652, 176);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Syntax Analyzer";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
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
            this.groupBox3.Controls.Add(this.codeBlock);
            this.groupBox3.Location = new System.Drawing.Point(12, 264);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(660, 117);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Source Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F);
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Occurrence:";
            // 
            // BreakerOcc
            // 
            this.BreakerOcc.AutoSize = true;
            this.BreakerOcc.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BreakerOcc.ForeColor = System.Drawing.Color.OrangeRed;
            this.BreakerOcc.Location = new System.Drawing.Point(136, 41);
            this.BreakerOcc.Name = "BreakerOcc";
            this.BreakerOcc.Size = new System.Drawing.Size(0, 19);
            this.BreakerOcc.TabIndex = 15;
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
            // totalbreaker_label
            // 
            this.totalbreaker_label.AutoSize = true;
            this.totalbreaker_label.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.totalbreaker_label.ForeColor = System.Drawing.Color.OrangeRed;
            this.totalbreaker_label.Location = new System.Drawing.Point(146, 65);
            this.totalbreaker_label.Name = "totalbreaker_label";
            this.totalbreaker_label.Size = new System.Drawing.Size(0, 19);
            this.totalbreaker_label.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 393);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Lexical);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Lexical;
        private System.Windows.Forms.RichTextBox codeBlock;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
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

    }
}

