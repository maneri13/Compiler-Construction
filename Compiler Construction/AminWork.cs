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



        //Dummy Methods
        private bool DT_Id()
        {
            return false;
        }



        //Shared Methods
        private bool Id_Constant()
        {
            //<Id_Constant> -> Id|<Const>
            if (cp("_identifier"))
            {
                return true;
            }
            else if (Const())
            {
                return true;
            }

            else return false;
        }

        private bool Array_Init()
        {
            //<Array_Init> -> [] | Null
            if (cp("_bracket_square_open"))
            {
                if (cp("_bracket_square_close"))
                {
                   return true;
                }
                else return false;
            }
            else return true;

            
        }

        private bool Array_Index()
        {
            //<Array_Index> -> [<Id_Constant>] | Null
            if (cp("_bracket_square_open"))
            {
                if (Id_Constant())
                {
                    if (cp("_bracket_square_close"))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;   
            }
            else return true;
        }

        private bool Access_Modifier()
        {
            //<Access_Modifier> -> _access_modifier|Null
            if (cp("_accessmodifier"))
            {
               return true;
            }
            else return true;
        }

        private bool List_Param()
        {
            //<List_Param> -> <DT_Id><Array_Init> Id<List_Param_B>|Null
            if (DT_Id())
            {
                if (Array_Init())
                {
                    if (cp("_identifier"))
                    {
                        if (List_Param_B())
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return true;
        }

        private bool List_Param_B()
        {
            //<List_Param_B> -> Null |, <DT_Id> <Array_Init> Id<List_Param>
            if (cp("_comma"))
            {
                if (DT_Id())
                {
                    if (Array_Init())
                    {
                        if (cp("_identifier"))
                        {
                            if (List_Param())
                            {
                                return true;
                            }
                            return false;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return true;
        }




        // Extra Function
        private bool cp(string classpart)
        {
            if (Tokens[tokenIndex].classString == classpart) 
            {
                tokenIndex++;
                return true;
            }
            else return false;
        }
















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
