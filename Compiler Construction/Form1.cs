using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler_Construction
{

    public partial class Form1 : Form
    {
        WordBreaker myWordBreaker = new WordBreaker();
        LexicalAnalyzer myLexicalAnalyzer = new LexicalAnalyzer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Lexical_Click(object sender, EventArgs e)
        {
            
            richTextBox1.Text = "";
            List<token> output = new List<token>();
            output = myWordBreaker.breakString(codeBlock.Text);
            totalWords.Text = output.Count().ToString();
            totalLines.Text = output.Last().lineNumber.ToString();
            totalbreaker_label.Text = myWordBreaker.totalBreaker.Count.ToString();
            foreach (token s in output)
            {
                richTextBox1.Text +="(" +s.lineNumber +"→) >"+ s.wordString + "<\n";
                
            }
            myWordBreaker.breakerAnalyzer();
            foreach (string c in myWordBreaker.distinctBreaker)
            {
                BreakerBox.Items.Add(c);
            }
        }

        private void selectBreaker(object sender, EventArgs e)
        {
            int count = 0;
            foreach (string c in myWordBreaker.totalBreaker)
            {
                if (c == BreakerBox.SelectedItem.ToString())
                {
                    count++;
                    BreakerOcc.Text = count.ToString();
                }
            }
        }





    }
}
