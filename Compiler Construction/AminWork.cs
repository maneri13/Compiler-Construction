using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler_Construction
{
    class AminWork
    {
        List<token> Tokens;
        public int tokenIndex;


        public bool syntaxAnlysis(List<token> tokens)
        {
            Tokens = tokens;
            tokenIndex = 0;
            try
            {
                if (Variable_Dec())
                {
                    return true;
                }
            }
            catch
            {

                return false;
            }


            return false;
        }



        //General Rules
        private bool Const()
        {
            switch (Tokens[tokenIndex].classString)
            {
                case "_int_constant":
                case "_float_constant":
                case "_string_constant":
                case "_char_constant":
                case "_bool_constant":
                    tokenIndex++;
                    return true;

                default:
                    return false;

            }

        }



        // VARIABLE DECLARATION
        private bool Variable_Dec()
        {
            if (Tokens[tokenIndex].classString == "_datatype")
            {
                tokenIndex++;
                if (Variable_Link())
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        private bool Variable_Link()
        {
            if (Tokens[tokenIndex].classString == "_identifier")
            {
                tokenIndex++;
                if (Variable_Link2())
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
        private bool Variable_Link2()
        {
            if (Tokens[tokenIndex].classString == "_assignment" && Tokens[tokenIndex].wordString == "=") // to be confirmed
            {
                tokenIndex++;
                if (Variable_Assign())
                {
                    if (List_Variable())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (List_Variable())
            {
                return true;
            }
            else return false;
        }
        private bool Variable_Assign()
        {
            if (Tokens[tokenIndex].classString == "_identifier")
            {
                tokenIndex++;
                return true;
            }
            else if (Const())
            {
                return true;
            }
            else return false;
        }
        private bool List_Variable()
        {
            if (Tokens[tokenIndex].classString == "_comma")
            {
                tokenIndex++;
                if (Tokens[tokenIndex].classString == "_identifier")
                {
                    tokenIndex++;
                    if (Variable_Link2())
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else if (Tokens[tokenIndex].classString == "_terminator")
            {
                tokenIndex++;
                return true;
            }
            else return false;

        }
    }
}
