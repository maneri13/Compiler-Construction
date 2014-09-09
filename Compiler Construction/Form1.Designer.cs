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
            this.SuspendLayout();
            // 
            // Lexical
            // 
            this.Lexical.Location = new System.Drawing.Point(60, 35);
            this.Lexical.Name = "Lexical";
            this.Lexical.Size = new System.Drawing.Size(75, 23);
            this.Lexical.TabIndex = 0;
            this.Lexical.Text = "Lexical Analysis";
            this.Lexical.UseVisualStyleBackColor = true;
            this.Lexical.Click += new System.EventHandler(this.Lexical_Click);
            // 
            // codeBlock
            // 
            this.codeBlock.Location = new System.Drawing.Point(60, 55);
            this.codeBlock.Name = "codeBlock";
            this.codeBlock.Size = new System.Drawing.Size(395, 146);
            this.codeBlock.TabIndex = 2;
            this.codeBlock.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(60, 223);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(395, 124);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 359);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.codeBlock);
            this.Controls.Add(this.Lexical);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Lexical;
        private System.Windows.Forms.RichTextBox codeBlock;
        private System.Windows.Forms.RichTextBox richTextBox1;

    }
}

