<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* switch breaker on when we encounter char from breaker[]
 * switch addnext on when two breakers are to be combined as one operator eg. += ==
 * we use default in all cases when there is only one breaker eg. /n ,' '
 * */

public class WordBreaker
{
    char[] breakers = { ' ', '\n', '<', '>' , '+', '-', '*', '/', '=', '&', '|', '!', '#', '$', ',', ';', ':', '(', ')',
    '{', '}', '[', ']', '.', '\'', '\"' };
    //string[] output = new string[100];
    List<string> output = new List<string>();

	public WordBreaker()
	{


	}

    public List<string> breakString(string myString){
        output = new List<string>();
        string temp = "";
        bool breaker = false, addNext = false, isFloat = false;
        int index = 0, dump = 0;
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
                            if (myString[i + 1] == '+' || myString[i + 1] == '=') { addNext = true; }
                            else addNext = false;
                            break;
                        case '-':
                            if (myString[i + 1] == '-' || myString[i + 1] == '=') { addNext = true; }
                            else addNext = false;
                            break;
                        case '*':
                            if (myString[i + 1] == '=') { addNext = true; }
                            else addNext = false;
                            break;
                        case '/':
                            if (myString[i + 1] == '=') { addNext = true; }
                            else addNext = false;
                            break;
                        case '>':
                            if (myString[i + 1] == '=') { addNext = true; }
                            else addNext = false;
                            break;
                        case '<':
                            if (myString[i + 1] == '=') { addNext = true; }
                            else addNext = false;
                            break;
                        case '=':
                            if (myString[i + 1] == '=') { addNext = true; }
                            else addNext = false;
                            break;
                        case '&':
                            if (myString[i + 1] == '&') { addNext = true; }
                            else addNext = false;
                            break;
                        case '|':
                            if (myString[i + 1] == '|') { addNext = true; }
                            else addNext = false;
                            break;
                        case '!':
                            if (myString[i + 1] == '=') { addNext = true; }
                            else addNext = false;
                            break;
                        case '#':
                            if (myString[i + 1] == '#' || myString[i + 1] == '$') { addNext = true; }
                            else addNext = false;
                            break;
                        case '$':
                            if (myString[i + 1] == '#') { addNext = true; }
                            else addNext = false;
                            break;
                        case '.':
                            if(int.TryParse(temp, out dump) && int.TryParse(myString[i+1].ToString(),out dump))
                            {
                                breaker = false;
                            }
                            else if (int.TryParse(myString[i + 1].ToString(), out dump))
                            {
                                isFloat = true;
                            }
                            break;
                        default:
                            addNext = false;
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
                if (temp != "") { output.Add(temp); }
                temp = myString[i].ToString();
                if (isFloat)
                {
                    breaker = false;
                    isFloat = false;
                    continue;
                }
                else if (addNext)
                {
                    i++;
                    temp += myString[i];
                    index++;
                    addNext = false;
                }
                output.Add(temp);
                temp = "";
                index++;
                breaker = false;
            }
        }   // for (i)
        return output;
    }


}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


public class WordBreaker
{
    char[] breakers = { ' ', '\n', '<', '>' , '+', '-', '*', '/', '=', '&', '|', '!', '#', ',', ';', ':', '(', ')',
    '{', '}', '[', ']', '.', '\'', '\"'};
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
                            if (myString[i + 1] == '+') { }
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
                        case '.':
                            break;
                        default:
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
>>>>>>> 9dcd0c71369f511fe440b032f7f5cf78f513c540
