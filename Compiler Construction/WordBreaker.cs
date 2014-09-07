using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


public class WordBreaker
{
    char[] breakers = { '<', '>' , '+', '-', '*', '/', '=', '&', '|', '!', '#', ',', ';', ':', '(', ')',
    '{', '}', '[', ']', '.', ' ', '\n', '\'', '\"'};
    //string[] output = new string[100];
    List<string> output = new List<string>();

	public WordBreaker()
	{


	}

    public List<string> breakString(string myString){
        string temp = "";
        bool breaker = false;
        int index = 0;
        for (int i = 0; i < myString.Length; i++ )
        {
            foreach (char j in breakers)
            {
                if (myString[i] == j)
                {
                    breaker = true;
                    switch (myString[i])
                    {
                        case '+':
                            break;
                        case '-':
                            break;
                        case '*':
                            break;
                        case '/':
                            break;
                        case '>':
                            break;
                        case '<':
                            break;
                        case '=':
                            break;
                        case '&':
                            break;
                        case '|':
                            break;
                        case '!':
                            break;
                        case '#':
                            break;
                        case ',':
                            break;
                        case ';':
                            break;
                        case ':':
                            break;
                        case '(':
                            break;
                        case ')':
                            break;
                        case '{':
                            break;
                        case '}':
                            break;
                        case '[':
                            break;
                        case ']':
                            break;
                        case '.':
                            break;
                        case ' ':
                            break;
                        case '\n':
                            break;
                        case '\'':
                            break;
                        case '\"':
                            break;

                    }   // switch end
                }   // if (i==j) end
                if (breaker) break;
            }   // foreach (j)
            if (!breaker)
            {
                temp += myString[i];
            }
            else if (breaker)
            {
                output.Add(temp);
                temp = myString[i].ToString();
                index++;
                breaker = false;
            }
        }   // for (i)
        return output;
    }


}
