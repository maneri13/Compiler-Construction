using System;


public static class WordBreaker
{
    char[] breakers = new char { '<', '>' , '+', '-', '*', '/', '=', '&', '|', '!', '#', ',', ';', ':', '(', ')',
    '{', '}', '[', ']', '.', ' ', '\n', '\'', '\"'};
    string[] output;

	public WordBreaker()
	{


	}

    public static string[] breakString(string myString){
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

            }   // foreach (j)
            if (!breaker)
            {
                temp += myString[i];
            }
            else if (breaker)
            {
                output[index] = temp;
                temp = "";
                index++;
                breaker = false;
            }
        }   // for (i)
    }


}
