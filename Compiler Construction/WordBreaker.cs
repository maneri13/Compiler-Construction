using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* switch breaker on when we encounter char from breaker[]
 * switch addnext on when two breakers are to be combined as one operator eg. += ==
 * we use default in all cases when there is only one breaker eg. /n ,' '
 * */
namespace Compiler_Construction
{

    public class WordBreaker
    {
        char[] breakers = { ' ', '\n', '<', '>' , '+', '-', '*', '/', '=', '&', '|', '!', '#', '$', ',', ';', ':', '(', ')',
        '{', '}', '[', ']', '.', '\'', '\"' };
        //string[] output = new string[100];

        public List<string> totalBreaker = new List<string>();

        public List<string> distinctBreaker = new List<string>();

        public WordBreaker()
        {

        }

        public List<token> breakString(string myString)
        {
            List<token> output = new List<token>();
            string temp = "";
            bool breaker = false, addNext = false, isFloat = false, isString = false, newLine = false;
            int dump = 0;
            ushort line = 1;
            for (int i = 0; i < myString.Length; i++)
            {
                if (newLine)
                {
                    line++;
                    newLine = false;
                }

                foreach (char j in breakers)
                {
                    if (myString[i] == j)
                    {

                        totalBreaker.Add(j.ToString());
                        breaker = true;
                        if (i != myString.Length - 1)
                        {
                            
                            switch (myString[i])
                            {
                                
                                case '\n':
                                    newLine = true;
                                    break;
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
                                    if (myString[i + 1] == '#')
                                    {
                                        while (true)
                                        {
                                            if (myString[i] == '\n' || i == myString.Length - 1)
                                            {
                                                breaker = false;
                                                i++;
                                                line++;
                                                break;
                                                
                                            }
                                            i++;
                                        }
                                    }


                                    
                                    break;
                                case '$':
                                    if (myString[i + 1] == '#') { addNext = true; }
                                    else addNext = false;
                                    break;
                                case '.':
                                    if (int.TryParse(temp, out dump) && int.TryParse(myString[i + 1].ToString(), out dump))
                                    {
                                        breaker = false;
                                    }
                                    else if (int.TryParse(myString[i + 1].ToString(), out dump))
                                    {
                                        isFloat = true;
                                    }
                                    break;
                                case '\"':
                                    while (true)
                                    {
                                        temp += myString[i];
                                        i++;

                                        if ((myString[i] == '\"' && myString[i - 1] != '\\') || (myString[i] == '\n') || (i == myString.Length - 1) || (myString[i] == '\"' && myString[i - 1] == '\\' && myString[i - 1] == '\\'))
                                        {

                                            temp += myString[i];
                                            isString = true;

                                            if (myString[i] == '\n')
                                            {
                                                totalBreaker.Add("New Line");
                                                newLine = true;
                                                temp = temp.Remove(temp.Length - 1);
                                            }
                                            break;
                                        }
                                    }
                                    break;

                                case '\'':
                                    if (temp != "")
                                    {
                                        isString = true;
                                        i--;
                                        break;

                                    }
                                    short length = 0;
                                    while (true)
                                    {

                                        temp += myString[i];
                                        i++;
                                        if (length >= 2 && myString[i - 2] != '\\')
                                        {
                                            i--;
                                            isString = true;
                                            break;
                                        }
                                        if (length >= 3 && myString[i - 2] == '\\' && myString[i - 3] == '\\')
                                        {
                                            i--;
                                            isString = true;
                                            break;
                                        }
                                        if ((myString[i] == '\'' && myString[i - 1] != '\\') || (myString[i] == '\n') || (i == myString.Length - 1))
                                        {
                                            temp += myString[i];
                                            isString = true;
                                            if (myString[i] == '\n')
                                            {
                                                totalBreaker.Add("New Line");
                                                newLine = true;
                                                temp = temp.Remove(temp.Length - 1);
                                            }
                                            break;
                                        }
                                        length++;
                                    }
                                    break;
                                default:
                                    addNext = false;
                                    break;

                            }   // switch end   
                        }   // if ( i == length ) end
                    }  // if (i==j) end
                    if (breaker) break;
                }   // foreach (j)
                if (!breaker)
                {
                    temp += myString[i];
                }
                else if (breaker && !isString)
                {
                    if (temp != "") { output.Add(new token(line, temp)); }
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
                        addNext = false;
                    }
                    output.Add(new token(line, temp));
                    temp = "";
                    breaker = false;
                }
                else if (isString == true)
                {
                    output.Add(new token(line, temp));
                    temp = "";
                    isString = false;
                    breaker = false;
                    if (newLine)
                    {
                        output.Add(new token(line, "\n"));
                    }
                }
            }   // for (i)
            if (temp != "")
            {
                output.Add(new token(line, temp));
                temp = "";
            }

            

            return output;
        }

        public void breakerAnalyzer()
        {

            IEnumerable<string> IEdistinctBreaker = totalBreaker.Distinct();
            distinctBreaker = IEdistinctBreaker.ToList();
            for (int i = 0; i < distinctBreaker.Count; i++)
            {
                if (distinctBreaker[i] == "\n")
                {
                    distinctBreaker[i] = "New Line";
                }

                if (distinctBreaker[i] == " ")
                {
                    distinctBreaker[i] = "Space";
                }
            }
            for (int i = 0; i < totalBreaker.Count; i++)
            {
                if (totalBreaker[i] == "\n")
                {
                    totalBreaker[i] = "New Line";
                }

                if (totalBreaker[i] == " ")
                {
                    totalBreaker[i] = "Space";
                }
            }
        }
    }
}
