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

        /// Extra Function
        private bool cp(string classpart)
        {
            if (Tokens[tokenIndex].classString == classpart)
            {
                tokenIndex++;
                return true;
            }
            else return false;
        }

        // dummy rule
        private bool List_Const()
        {
            return false;
        }

        //General Rules

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
            if (cp("_datatype"))
            {
                return true;
            }

            else if (cp("_identifier"))
            {
                return true;
            }
            else return false;
        }

        private bool Static_Shared()
        {
            //<Static_Shared> -> _static | _shared
            if (cp("_static"))
            {
                return true;
            }
            else if (cp("_shared"))
            {
                
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
            else if (cp("_void"))
            {
                
                return true;
            }
            else return false;
        }

        // VARIABLE DECLARATION
        private bool Variable_Dec()
        {
            if (cp("_datatype"))
            {
                
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
            if (cp("_identifier"))
            {
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
            if (Tokens[tokenIndex].wordString == "=" && cp("_assignment"))
                // to be confirmed
            {
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

        private bool List_Variable()
        {
            if (cp("_comma"))
            {
                tokenIndex++;
                if (cp("_identifier"))
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
            else if (cp("_terminator"))
            {
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
                else return false;
            }
            else return false;
            
        }

        private bool Object_Link()
        {
            //<Object_Link> ->Id <Object_Creation_Exp>
            if (cp("_identifier"))
            {
                if (Object_Creation_Exp())
                {
                    return true;
                }
                else return false;
            }
            else return false;

        }

        private bool Object_List()
        {
            //<Object_List> -> , Id<Object_Creation_Exp>|;
            if (cp("_comma"))
            {
                if (cp("_identifier"))
                {
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
            if (Tokens[tokenIndex].wordString == "=" && cp("_assignment"))
            {
                if (cp("_new"))
                {
                    if (DT_Id())
                    {
                        if (cp("_bracket_parentheses_open"))
                        {
                            if (List_Const())
                            {
                                if (cp("_bracket_parentheses_close"))
                                {
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
