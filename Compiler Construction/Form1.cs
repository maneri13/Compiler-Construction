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
        
        WordBreaker myWordBreaker;
        List<token> wordBreakerOutput;
        List<token> TokenOutput;
        LexicalAnalyzer myLexicalAnalyzer = new LexicalAnalyzer();
        AminWork mySyntaxAnalyzer = new AminWork();
        public Form1()
        {
            InitializeComponent();
        }

        private void Lexical_Click(object sender, EventArgs e)
        {

            myWordBreaker = new WordBreaker();
            int totalError = 0;
            BreakerBox.Items.Clear();
            
            richTextBox1.Text = "";
            TokenBox1.Text = "";

            TotalError.Text = "";
            totalWords.Text = "";
            totalbreaker_label.Text = "";
            totalLines.Text = "";

            syntaxBar.Value = 0;
            syntaxBar.Value = 0;

            wordBreakerOutput = new List<token>();
            TokenOutput = new List<token>();
            
            wordBreakerOutput = myWordBreaker.breakString(codeBlock.Text);
            fetchBar.Value = 100;
            if (wordBreakerOutput.Count > 0)
            {
                totalLines.Text = wordBreakerOutput.Last().lineNumber.ToString();
            }
            totalWords.Text = wordBreakerOutput.Count().ToString();
            
            totalbreaker_label.Text = myWordBreaker.totalBreaker.Count.ToString();

           
            
            foreach (token s in wordBreakerOutput)
            {
                richTextBox1.Text +="(" +s.lineNumber +"→) >"+ s.wordString + "<\n";
            }
            myWordBreaker.breakerAnalyzer();
            foreach (string c in myWordBreaker.distinctBreaker)
            {
                BreakerBox.Items.Add(c);
            }
         
            int j = 0;
            while (true)
            {
                
                if (j == wordBreakerOutput.Count)
                {
                    break;
                }
                if (wordBreakerOutput[j].wordString == " " || wordBreakerOutput[j].wordString == "\n" || wordBreakerOutput[j].wordString == "\t")
                {
                    for (int i = 0; i < wordBreakerOutput.Count; i++)
                    {
                        if (wordBreakerOutput[i].wordString == "\t" || wordBreakerOutput[i].wordString == " " || wordBreakerOutput[i].wordString == "\n" || wordBreakerOutput[i].wordString == "##")
                        {
                            wordBreakerOutput.RemoveAt(i);
                            j = 0;
                        }
                    }
                    
                }
                else
                {
                    j++;
                }
            }
            
            

            TokenOutput = myLexicalAnalyzer.getTokens(wordBreakerOutput);
            lexicalBar.Value = 100;
            foreach (token s in TokenOutput)
            {
               if (s.classString == "_invalid")
                {
                    totalError++;
                    TotalError.Text = totalError.ToString();
                    lexicalBar.Value = 0;
                }
                TokenBox1.Text += "("+ s.lineNumber + " , " + s.wordString + " , " + s.classString + ")\n";
            }

            if (TokenOutput.Count > 0)
            {
                TokenOutput.Add(new token(TokenOutput.Last().lineNumber, "$", "_end_marker"));
            }
            
            bool abc = mySyntaxAnalyzer.syntaxAnlysis(TokenOutput);

            if (abc)
            {
                syntaxBar.Value = 100;
            }
            else
            {
                syntaxBar.Value = 0;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Lexical.Enabled = false;
                codeBlock.TextChanged += Lexical_Click;
                
            }

            if (!checkBox1.Checked)
            {
                Lexical.Enabled = true;
                codeBlock.TextChanged -= Lexical_Click;
                
            }
        }

        

    }


   
    
}
