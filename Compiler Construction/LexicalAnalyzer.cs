using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Compiler_Construction
{
    static class RegularExp
    {
        public static string Digits = "^[0-9]+$";
        public static string EscSeq= "/\t/";
        public static string Signs = "[+-]";
    };
    class LexicalAnalyzer
    {       
        
        public bool checkInt(string input)
        {
            int cState = 0;
            bool valid = false;

            for (int i = 0; i < input.Length; i++)
			{
                switch (cState)
                {
                    case 0:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.Digits))
                        {
                            cState = 2;
                        }
                        else if (Regex.IsMatch(input[i].ToString(), RegularExp.Signs))
                        {
                            cState = 1;
                        }
                        else{
                            cState=3;
                        }
                        break;

                
                    case 1:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.Digits))
                        {
                            cState = 2;
                        }
                        else{
                            cState=3;
                        }
                        break;
                    
                    case 2:
                        valid = true;
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.Digits))
                        {
                            cState = 2;
                        }
                        else if (i == input.Length - 1)
                        {
                            break;
                        }
                        else{
                            cState=3;
                        }
                        break;

                    //error state    
                    case 3:
                        valid = false;
                        break;
                }
            }
            return valid;
        }
        /*
        public bool checkString(String input)
        {
            
            int cState = 0;
            for (int i = 1; i < input.Length-1; i++)
			{
			 
			
            switch (cState)
            {
                case 0:
                    if(){}

                    else{cState=3;}
                    break;

                
                case 1:
                    if(){}

                    else{cState=3;}
                    break;
                    
                case 2:
                    if(){}

                    else{cState=3;}
                    break;

                //error state    
                case 3:
                    
                    break;
            }
            }


            return false;
        }
        */
        public bool checkRE(string str, string pattern){
            bool match = (Regex.IsMatch(str, pattern));
            return match;
        }
    
    }
}
