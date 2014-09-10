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
           myWordBreaker.breakString(codeBlock.Text);
            
        }

       
    }
}
