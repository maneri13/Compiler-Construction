﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Compiler_Construction
{

    class LexicalAnalyzer
    {
        /// <summary>
        /// Integer DFA to check any integer constant
        /// </summary>
        /// <param name="input">integer in string format</param>
        /// <returns>true if pass through DFA, otherwise false</returns>
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

        /// <summary>
        /// Float DFA to check any float constant
        /// </summary>
        /// <param name="input">Float in string format</param>
        /// <returns>true if pass through DFA, otherwise false</returns>
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

        /// <summary>
        /// Identifier DFA to check any identifier constant
        /// </summary>
        /// <param name="input">Identifier in string format</param>
        /// <returns>true if pass through DFA, otherwise false</returns>
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

        /// <summary>
        /// String DFA to check any string constant
        /// </summary>
        /// <param name="input">Identifier in string format</param>
        /// <returns>true if pass through DFA, otherwise false</returns>
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

        /// <summary>
        /// Char DFA to check any Char constant
        /// </summary>
        /// <param name="input">Char in string format</param>
        /// <returns>true if pass through DFA, otherwise false</returns>
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

        /// <summary>
        /// Keywords DFA to check any Keywords
        /// </summary>
        /// <param name="word">Keywords in string format</param>
        /// <returns>true if pass through DFA, otherwise false</returns>
        public string checkKeyword(string word)
        {
            for (int i = 0; i < ClassName.keywords.Length/2; i++)
            {
                if (word == ClassName.keywords[i,0])
                {
                    return ClassName.keywords[i, 1];
                }
            }
            return "";
        }

        /// <summary>
        /// Operators method to check any Operators
        /// </summary>
        /// <param name="word">Operators in string format</param>
        /// <returns>true if pass through the method, otherwise false</returns>
        public string checkOperator(string word)
        {
            for (int i = 0; i < ClassName.Operators.Length/2; i++)
            {
                if (word == ClassName.Operators[i, 0])
                {
                    return ClassName.Operators[i, 1];
                }
            }
            return "";
        }

        /// <summary>
        /// Puntuators method to check any Puntuators
        /// </summary>
        /// <param name="word">Puntuators in string format</param>
        /// <returns>true if pass through the method, otherwise false</returns>
        public string checkPunctuators(string word)
        {
            for (int i = 0; i < ClassName.punctuators.Length/2; i++)
            {
                if (word == ClassName.punctuators[i, 0])
                {
                    return ClassName.punctuators[i, 1];
                }
            }
            return "";
        }

        /// <summary>
        /// Method to generate tokens
        /// </summary>
        /// <param name="words">list containing incomplete tokens</param>
        /// <returns>list containing complete tokens</returns>
        public List<token> getTokens(List<token> words){

            for (int i = 0; i < words.Count; i++)
            {
                string firstLetter = words[i].wordString[0].ToString();
                string word = words[i].wordString;
                string dump = "";
                
                if (Regex.IsMatch(firstLetter, RegularExp.Alphabet) ||
                    Regex.IsMatch(firstLetter, RegularExp.Underscore) ||
                    Regex.IsMatch(firstLetter, RegularExp.At))
                {
                    if (this.checkIdentifier(word))
                    {
                        dump = this.checkKeyword(word);
                        if (dump != "")
                        {
                            words[i].classString = dump;
                        }
                        else
                        {
                            words[i].classString = ClassName.nonKeywords._identifier.ToString();
                        }
                    }
                    else
                    {
                        words[i].classString = ClassName.nonKeywords._invalid.ToString();
                    }
                }
                else if (Regex.IsMatch(firstLetter, RegularExp.Digits) 
                    || Regex.IsMatch(firstLetter, RegularExp.Dot))
                {
                    if (this.checkInt(word))
                    {
                        words[i].classString = ClassName.nonKeywords._int_constant.ToString();
                    }
                    else if (this.checkFloat(word))
                    {
                        words[i].classString = ClassName.nonKeywords._float_constant.ToString();
                    }
                    else
                    {
                        dump = this.checkPunctuators(word);
                        if (dump != "")
                        {
                            words[i].classString = dump;
                        }
                        else
                        {
                            words[i].classString = ClassName.nonKeywords._invalid.ToString();
                        }
                    }
                }
                else if (Regex.IsMatch(firstLetter, RegularExp.StringStart))
                {
                    if (this.checkString(word))
                    {
                        words[i].classString = ClassName.nonKeywords._string_constant.ToString();
                    }
                    else
                    {
                        words[i].classString = ClassName.nonKeywords._invalid.ToString();
                    }
                }
                else if (Regex.IsMatch(firstLetter, RegularExp.CharStart))
                {
                    if (this.checkChar(word))
                    {
                        words[i].classString = ClassName.nonKeywords._char_constant.ToString();
                    }
                    else
                    {
                        words[i].classString = ClassName.nonKeywords._invalid.ToString();
                    }
                }
                else
                {
                    dump = this.checkOperator(word);
                    if (dump != "")
                    {
                        words[i].classString = dump;
                    }
                    else
                    {
                        dump = this.checkPunctuators(word);
                        if (dump != "")
                        {
                            words[i].classString = dump;
                        }
                        else
                        {
                            words[i].classString = ClassName.nonKeywords._invalid.ToString();
                        }
                    }
                }
            
            }     

            return words;
        }
    }
}

