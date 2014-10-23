using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler_Construction
{
    internal class HashamWork
    {
        private List<token> Tokens;
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

        //dummy section
        private bool List_Const()
        {
            return true;
        }

        //shared
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

        private bool DT_Id()
        {
            //<DT_Id> -> DT|Id
            if (Tokens[tokenIndex].classString == "_datatype")
            {
                tokenIndex++;
                return true;
            }

            else if (Tokens[tokenIndex].classString == "_identifier")
            {
                tokenIndex++;
                return true;
            }
            else return false;
        }

        private bool Static_Shared()
        {
            //<Static_Shared> -> _static | _shared
            if (Tokens[tokenIndex].classString == "_static")
            {
                tokenIndex++;
                return true;
            }
            else if (Tokens[tokenIndex].classString == "_shared")
            {
                tokenIndex++;
                return true;
            }
            else
                return false;
        }

        private bool Static_Shared_Constant()
        {
            //<Static_Shared _Constant> -> <Static_Shared> | const
            if (Static_Shared())
            {
                return true;
            }
            else if (Const())
            {
                return true;
            }
            else return false;
        }

        private bool Return_Type()
        {
            //<Return_Type> -> <DT_Id>| void
            if (DT_Id())
            {
                return true;
            }
            else if (Tokens[tokenIndex].classString == "_void")
            {
                tokenIndex++;
                return true;
            }
            else return false;
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
            if (Tokens[tokenIndex].classString == "_assignment" && Tokens[tokenIndex].wordString == "=")
                // to be confirmed
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


        //object declaration

        private bool Object_Dec()
        {
            //<Object_Dec>-><DT_Id> <Object_Link>
            if (DT_Id())
            {
                if (Object_Link())
                {
                    return true;
                }
            }
            else return false;
            
        }

        private bool Object_Link()
        {
            //<Object_Link> ->Id <Object_Creation_Exp>
            if (Tokens[tokenIndex].classString=="_identifier")
            {
                tokenIndex++;
                if (Object_Creation_Exp())
                {
                    return true;
                }
            }
            else return false;

        }

        private bool Object_List()
        {
            //<Object_List> -> , Id<Object_Creation_Exp>|;
            if (Tokens[tokenIndex].classString=="_comma")
            {
                tokenIndex++;
                if (Tokens[tokenIndex].classString=="_identifier")
                {
                    tokenIndex++;
                    if (Object_Creation_Exp())
                    {
                        return true;
                    }
                    else return false;
                    
                }
                else return false;
            }
            else return false;
        }

        private bool Object_Creation_Exp()
        {
            // <Object_Creation_Exp> -> = new <DT_Id> (<List_Const>) <Object_List> |<Object_List>
            if (Tokens[tokenIndex].classString == "_assignment" && Tokens[tokenIndex].wordString == "=")
            {
                tokenIndex++;
                if (Tokens[tokenIndex].classString == "_new")
                {
                    tokenIndex++;
                    if (DT_Id())
                    {
                        if (Tokens[tokenIndex].classString == "_bracket_parentheses_open")
                        {
                            tokenIndex++;
                            if (List_Const())
                            {
                                if (Tokens[tokenIndex].classString == "_bracket_parentheses_close")
                                {
                                    tokenIndex++;
                                    if (Object_List())
                                    {
                                        return true;
                                    }
                                    else return false;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else if (Object_List())
            {
                return true;
            }
            else return false;
            
        }

    }

  
}
