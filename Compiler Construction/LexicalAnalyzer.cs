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
        public static string Signs = "[+-]";
        public static string Alphabet = @"^[a-zA-Z]+$";
        public static string AlphaNumeric = @"^[a-zA-Z0-9]+$";
        public static string Underscore="[_]";
        public static string CharStart="[']";
        public static string StringStart="[\"]";
        public static string BackSlash = "[\\\\]";
        public static string EscSeq = "[nrtfbv]";
        public static string SpChar = "[\\\\\"\']";
        public static string At = "[@]";
        public static string Dot = "[.]";
    };
    class LexicalAnalyzer
    {
        
        
        public bool checkInt(string input)
        {
            int cState = 0;
            bool valid = false;

            for (int i = 0; i < input.Length && cState!=3; i++)
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
                        else
                        {
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
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.Digits))
                        {
                            cState = 2;
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
            if (cState == 2) valid = true;
            return valid;
        }

        public bool checkFloat(string input)
        {
            int cState = 0;
            bool valid = false;


            for (int i = 0; i < input.Length && cState!=5; i++)
            {
                switch (cState)
                {
                    case 0:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.Signs) )
                        {
                            cState = 1;
                        }
                        else if (Regex.IsMatch(input[i].ToString(), RegularExp.Digits))
                        {
                            cState = 2;
                        }
                        else if (Regex.IsMatch(input[i].ToString(), RegularExp.Dot))
                        {
                            cState = 3;
                        }
                        else
                        {
                            cState = 5;
                        }
                        break;

                    case 1:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.Digits))
                        {
                            cState = 2;
                        }
                        else
                        {
                            cState = 5;
                        }
                        break;
                    case 2:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.Digits))
                        {
                            cState = 2;                            
                        }
                        else if (Regex.IsMatch(input[i].ToString(),RegularExp.Dot ))
                        {
                            cState = 3;
                        }
                        else
                        {
                            cState = 5;
                        }
                        break;

                    case 3:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.Digits))
                        {
                            cState = 4;
                        }
                        else
                        {
                            cState = 5;
                        }
                        break;

                    case 4:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.Digits))
                        {
                            cState = 4;
                        }
                        else
                        {
                            cState = 5;
                        }
                        break;

                    case 5:
                        valid = false;
                        break;
                }
            }
            if (cState == 2 || cState == 4)
            {
                valid = true;
            }
            return valid;
        }
    
        
        // add logic to compare to keywords
        public bool checkIdentifier(string input)
        {
            int cState = 0;
            bool valid = false;
            

            for (int i = 0; i < input.Length && cState!=3; i++)
            {
                switch (cState)
                {
                    case 0:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.Alphabet) ||
                            Regex.IsMatch(input[i].ToString(), RegularExp.Underscore))
                        {
                            cState = 2;
                        }
                        else if (Regex.IsMatch(input[i].ToString(), RegularExp.At))
                        {
                            cState = 1;
                        }
                        else
                        {
                            cState = 3;
                        }
                        break;

                    case 1:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.Alphabet) ||
                            Regex.IsMatch(input[i].ToString(), RegularExp.Underscore))
                        {
                            cState = 2;
                        }
                        else
                        {
                            cState = 3;
                        }
                        break;

                    case 2:
                        if(Regex.IsMatch(input[i].ToString(), RegularExp.AlphaNumeric) ||
                            Regex.IsMatch(input[i].ToString(), RegularExp.Underscore))
                        {
                            cState = 2;
                        }
                        else
                        {
                            cState = 3;
                        }
                        break;

                    case 3:
                        valid = false;
                        break;
                }
            }
            if (cState == 2) valid = true;
            return valid;
        }

        
        public bool checkString(String input) 
        {
            int cState = 0;
            bool valid = false;

            for (int i = 0; i < input.Length && cState!=4; i++)
            {
                switch (cState)
                {
                    case 0:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.StringStart))
                        {
                            cState = 1;
                        }
                        else
                        {
                            cState = 4;
                        }
                        break;
                    case 1:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.BackSlash))
                        {
                            cState = 2;
                        }
                        else if (Regex.IsMatch(input[i].ToString(), RegularExp.StringStart))
                        {
                            cState = 3;
                        }
                        else
                        {
                            cState = 1;                     // all other characters 
                        }
                        break;
                    case 2:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.EscSeq) ||
                            Regex.IsMatch(input[i].ToString(), RegularExp.SpChar))
                        {
                            cState = 1;
                        }
                        else
                        {
                            cState = 4;
                        }
                        break;
                    case 3:
                        if (i <= input.Length - 1)
                        {
                            cState = 4;
                        }
                        break;
                    case 4:
                        valid = false;
                        break;
                }
            }
            if (cState == 3) valid = true;

            return valid;
        }


        public bool checkChar(String input)
        {
            int cState = 0;
            bool valid = false;

            for (int i = 0; i < input.Length && cState != 5; i++)
            {
                switch (cState)
                {
                    case 0:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.CharStart))
                        {
                            cState = 1;
                        }
                        else
                        {
                            cState = 5;
                        }
                        break;
                    case 1:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.BackSlash))
                        {
                            cState = 2;
                        }
                        
                        else
                        {
                            cState = 3;                     // all other characters 
                        }
                        break;
                    case 2:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.EscSeq) ||
                            Regex.IsMatch(input[i].ToString(), RegularExp.SpChar))
                        {
                            cState = 3;
                        }
                        else
                        {
                            cState = 5;
                        }
                        break;
                    case 3:
                        if (Regex.IsMatch(input[i].ToString(), RegularExp.CharStart))
                        {
                            cState = 4;
                        }
                        else
                        {
                            cState = 5;
                        }
                        break;
                    case 4:
                        if (i <= input.Length - 1)
                        {
                            cState = 5;
                        }
                        break;
                    case 5:
                        valid = false;
                        break;
                }
            }
            if (cState == 4) valid = true;

            return valid;
        }
        //public bool checkRE(string str, string pattern){
        //    bool match = (Regex.IsMatch(str, pattern));
        //    return match;
        //}
    
    }
}
